namespace ACT.TTSYukkuri.HOYA
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    using ACT.TTSYukkuri.Config;
    using VoiceTextWebAPI.Client;

    public class HOYASpeechController :
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
                return HOYASettingsPanel.Default;
            }
        }

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

            // 現在の条件からwaveファイル名を生成する
            var wave = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"anoyetta\ACT\" + ("HOYA" + TTSYukkuriConfig.Default.HOYASettings.ToString() + text).GetMD5() + ".wav");

            if (!File.Exists(wave))
            {
                if (string.IsNullOrWhiteSpace(
                    TTSYukkuriConfig.Default.HOYASettings.APIKey))
                {
                    return;
                }

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
                    100);
            }

            // メインデバイスを再生する
            SoundPlayerWrapper.Play(
                TTSYukkuriConfig.Default.MainDeviceID,
                wave,
                100);
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
            var client = new VoiceTextClient()
            {
                APIKey = TTSYukkuriConfig.Default.HOYASettings.APIKey,
                Speaker = TTSYukkuriConfig.Default.HOYASettings.Speaker,
                Emotion = TTSYukkuriConfig.Default.HOYASettings.Emotion,
                EmotionLevel = TTSYukkuriConfig.Default.HOYASettings.EmotionLevel,
                Volume = TTSYukkuriConfig.Default.HOYASettings.Volume,
                Speed = TTSYukkuriConfig.Default.HOYASettings.Speed,
                Pitch = TTSYukkuriConfig.Default.HOYASettings.Pitch,
            };

            var waveData = client.GetVoice(textToSpeak);

            File.WriteAllBytes(wave, waveData);
        }
    }
}
