namespace ACT.TTSYukkuri.OpenJTalk
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    using ACT.TTSYukkuri.Config;
    using NAudio.Wave;

    public class OpenJTalkSpeechController :
        SpeechControllerBase,
        ISpeechController
    {
        /// <summary>
        /// ロックオブジェクト
        /// </summary>
        private static object lockObject = new object();

        /// <summary>
        /// TTSの設定Panel
        /// </summary>
        public override UserControl TTSSettingsPanel
        {
            get
            {
                return OpenJTalkSettingsPanel.Default;
            }
        }

        /// <summary>
        /// ユーザ辞書
        /// </summary>
        private List<KeyValuePair<string, string>> userDictionary = new List<KeyValuePair<string, string>>();

        /// <summary>
        /// 初期化する
        /// </summary>
        public override void Initialize()
        {
            // NO-OP
        }

        /// <summary>
        /// テキストを読み上げる
        /// </summary>
        /// <param name="text">読み上げるテキスト</param>
        public override void Speak(
            string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            // テキストをユーザ辞書で置き換える
            text = this.ReplaceByUserDictionary(text);

            // 現在の条件からwaveファイル名を生成する
            var wave = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"anoyetta\ACT\" + ("OpenJTalk" + TTSYukkuriConfig.Default.OpenJTalkSettings.ToString() + text).GetMD5() + ".wav");

            if (!File.Exists(wave))
            {
                this.CreateWave(
                    text,
                    wave);
            }

            // サブデバイスを再生する
            // サブデバイスは専らVoiceChat用であるため先に鳴動させる
            if (TTSYukkuriConfig.Default.EnabledSubDevice)
            {
                SoundPlayerWrapper.Play(
                    TTSYukkuriConfig.Default.SubDeviceID,
                    wave,
                    TTSYukkuriConfig.Default.OpenJTalkSettings.Volume);
            }

            // メインデバイスを再生する
            SoundPlayerWrapper.Play(
                TTSYukkuriConfig.Default.MainDeviceID,
                wave,
                TTSYukkuriConfig.Default.OpenJTalkSettings.Volume);
        }

        /// <summary>
        /// WAVEファイルを生成する
        /// </summary>
        /// <param name="textToSpeak">
        /// Text to Speak</param>
        /// <param name="wave">
        /// WAVEファイルのパス</param>
        private void CreateWave(
            string textToSpeak,
            string wave)
        {
            // パス関係を生成する
            var openJTalkDir = TTSYukkuriConfig.Default.OpenJTalkSettings.OpenJTalkDirectory;
            if (string.IsNullOrWhiteSpace(openJTalkDir))
            {
                openJTalkDir = "OpenJTalk";
            }

            var openJTalk = Path.Combine(openJTalkDir, @"open_jtalk.exe");
            var dic = Path.Combine(openJTalkDir, @"dic");
            var voice = Path.Combine(openJTalkDir, @"voice\" + TTSYukkuriConfig.Default.OpenJTalkSettings.Voice);
            var waveTemp = Path.GetTempFileName();
            if (File.Exists(waveTemp))
            {
                File.Delete(waveTemp);
            }

            var volume = (float)TTSYukkuriConfig.Default.OpenJTalkSettings.Volume / 100f;
            var speed = (float)TTSYukkuriConfig.Default.OpenJTalkSettings.Speed / 100f;
            var pitch = (float)TTSYukkuriConfig.Default.OpenJTalkSettings.Pitch / 10f;

            var textFile = Path.GetTempFileName();
            File.WriteAllText(textFile, textToSpeak, Encoding.GetEncoding("Shift_JIS"));

            var args = new string[]
            {
                "-x " + "\"" + dic + "\"",
                "-m " + "\"" + voice + "\"",
                "-ow " + "\"" + waveTemp + "\"",
                "-g " + volume.ToString("N1"),
                "-r " + speed.ToString("N1"),
                "-fm " + pitch.ToString("N1"),
                textFile
            };

            var pi = new ProcessStartInfo()
            {
                FileName = openJTalk,
                CreateNoWindow = true,
                UseShellExecute = false,
                Arguments = string.Join(" ", args),
                RedirectStandardError = true,
                RedirectStandardOutput = true,
            };

            Debug.WriteLine(pi.FileName + " " + pi.Arguments);

            using (var p = Process.Start(pi))
            {
                var stderr = p.StandardError.ReadToEnd();
                var stdout = p.StandardOutput.ReadToEnd();

                if (!string.IsNullOrWhiteSpace(stderr))
                {
                    Debug.WriteLine(stderr);
                }

                if (!string.IsNullOrWhiteSpace(stdout))
                {
                    Debug.WriteLine(stdout);
                }

                p.WaitForExit();
            }

            if (File.Exists(textFile))
            {
                File.Delete(textFile);
            }

            var gain = (float)TTSYukkuriConfig.Default.OpenJTalkSettings.Gain / 100f;

            if (gain != 1.0f)
            {
                using (var reader = new WaveFileReader(waveTemp))
                {
                    var prov = new VolumeWaveProvider16(reader);
                    prov.Volume = gain;

                    WaveFileWriter.CreateWaveFile(
                        wave,
                        prov);
                }
            }
            else
            {
                File.Move(waveTemp, wave);
            }

            if (File.Exists(waveTemp))
            {
                File.Delete(waveTemp);
            }
        }

        /// <summary>
        /// ユーザ辞書で置換する
        /// </summary>
        /// <param name="textToSpeak">
        /// Text to Speak</param>
        /// <returns>
        /// 置換後のText to Speak</returns>
        private string ReplaceByUserDictionary(
            string textToSpeak)
        {
            var t = textToSpeak;

            var openJTalkDir = TTSYukkuriConfig.Default.OpenJTalkSettings.OpenJTalkDirectory;
            if (string.IsNullOrWhiteSpace(openJTalkDir))
            {
                openJTalkDir = "OpenJTalk";
            }

            var userDic = Path.Combine(
                openJTalkDir,
                @"dic\user_dictionary.txt");

            if (!File.Exists(userDic))
            {
                return t;
            }

            if (this.userDictionary.Count < 1)
            {
                using (var sr = new StreamReader(userDic, new UTF8Encoding(false)))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine().Trim();

                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }

                        if (line.StartsWith("#"))
                        {
                            continue;
                        }

                        var words = line.Split('\t');
                        if (words.Length < 2)
                        {
                            continue;
                        }

                        this.userDictionary.Add(new KeyValuePair<string, string>(
                            words[0].Trim(),
                            words[1].Trim()));
                    }
                }
            }

            foreach (var item in this.userDictionary)
            {
                t = t.Replace(item.Key, item.Value);
            }

            return t;
        }
    }
}
