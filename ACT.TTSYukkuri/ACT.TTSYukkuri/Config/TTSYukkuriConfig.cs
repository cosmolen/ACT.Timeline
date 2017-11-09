namespace ACT.TTSYukkuri.Config
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    using ACT.TTSYukkuri.SoundPlayer;
    using ACT.TTSYukkuri.TTSServer;
    using ACT.TTSYukkuri.TTSServer.Core;

    /// <summary>
    /// TTSYukkuri設定
    /// </summary>
    [Serializable]
    public class TTSYukkuriConfig
    {
        /// <summary>
        /// ロックオブジェクト
        /// </summary>
        [XmlIgnore]
        private static object lockObject = new object();

        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        [XmlIgnore]
        private static TTSYukkuriConfig instance;

        /// <summary>
        /// シングルトンインスタンスを返す
        /// </summary>
        [XmlIgnore]
        public static TTSYukkuriConfig Default
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new TTSYukkuriConfig();
                        instance.Load();
                    }

                    return instance;
                }
            }
        }

        /// <summary>
        /// 設定ファイルのパスを返す
        /// </summary>
        [XmlIgnore]
        public static string FilePath
        {
            get
            {
                var r = string.Empty;

                r = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "anoyetta\\ACT\\ACT.TTSYukkuri.config");

                return r;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TTSYukkuriConfig()
        {
            this.LastUpdateDatetime = DateTime.Now;

            this.SasaraSettings = new SasaraConfig();
            this.BoyomiServer = new List<string>();
            this.OptionSettings = new OptionsConfig();
            this.OpenJTalkSettings = new OpenJTalkConfig();
            this.HOYASettings = new HOYAConfig();

            this.WaveVolume = 100;

            this.TTS = TTSType.Yukkuri;

            this.Player = WavePlayers.WASAPI;
        }

        /// <summary>
        /// 最終アップデート日時
        /// </summary>
        public DateTime LastUpdateDatetime { get; set; }

        /// <summary>
        /// TTSの種類
        /// </summary>
        public string TTS { get; set; }

        /// <summary>
        /// ゆっくりのスピード
        /// </summary>
        public int YukkuriSpeed { get; set; }

        /// <summary>
        /// ゆっくりのボリューム調整を有効にする
        /// </summary>
        public bool EnabledYukkuriVolumeSetting { get; set; }

        /// <summary>
        /// ゆっくりのボリューム
        /// </summary>
        public int YukkuriVolume { get; set; }

        /// <summary>
        /// メイン再生デバイスID
        /// </summary>
        public string MainDeviceID { get; set; }

        /// <summary>
        /// サブ再生デバイスを有効にする
        /// </summary>
        public bool EnabledSubDevice { get; set; }

        /// <summary>
        /// サブ再生デバイスID
        /// </summary>
        public string SubDeviceID { get; set; }

        /// <summary>
        /// Wave再生時のボリューム
        /// </summary>
        public int WaveVolume { get; set; }

        /// <summary>
        /// ささら設定
        /// </summary>
        public SasaraConfig SasaraSettings { get; set; }

        /// <summary>
        /// 棒読み設定(サーバ, ポート)
        /// </summary>
        public List<string> BoyomiServer { get; set; }

        /// <summary>
        /// OpenJTalk設定
        /// </summary>
        public OpenJTalkConfig OpenJTalkSettings { get; set; }

        /// <summary>
        /// HOYA VoiceTextWebAPI 設定
        /// </summary>
        public HOYAConfig HOYASettings { get; set; }

        /// <summary>
        /// オプション設定
        /// </summary>
        public OptionsConfig OptionSettings { get; set; }

        /// <summary>
        /// 終了時にキャッシュしたwaveファイルを削除する
        /// </summary>
        public bool WaveCacheClearEnable { get; set; }

        /// <summary>
        /// 再生方式
        /// </summary>
        public WavePlayers Player { get; set; }

        /// <summary>
        /// 設定をロードする
        /// </summary>
        public void Load()
        {
            lock (lockObject)
            {
                var file = FilePath;

                if (File.Exists(file))
                {
                    using (var sr = new StreamReader(file, new UTF8Encoding(false)))
                    {
                        var xs = new XmlSerializer(typeof(TTSYukkuriConfig));
                        instance = (TTSYukkuriConfig)xs.Deserialize(sr);
                    }
                }
            }
        }

        /// <summary>
        /// 設定をセーブする
        /// </summary>
        public void Save()
        {
            lock (lockObject)
            {
                var file = FilePath;

                var dir = Path.GetDirectoryName(file);

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                using (var sw = new StreamWriter(file, false, new UTF8Encoding(false)))
                {
                    var xs = new XmlSerializer(typeof(TTSYukkuriConfig));
                    xs.Serialize(sw, Default);
                }
            }
        }

        /// <summary>
        /// ささらを設定する
        /// </summary>
        public void SetSasara()
        {
            var talker = new SasaraSettings();

            talker.Cast = TTSYukkuriConfig.Default.SasaraSettings.Cast;
            talker.Volume = TTSYukkuriConfig.Default.SasaraSettings.Onryo;
            talker.Speed = TTSYukkuriConfig.Default.SasaraSettings.Hayasa;
            talker.Tone = TTSYukkuriConfig.Default.SasaraSettings.Takasa;
            talker.Alpha = TTSYukkuriConfig.Default.SasaraSettings.Seishitsu;
            talker.ToneScale = TTSYukkuriConfig.Default.SasaraSettings.Yokuyo;

            var components = new List<SasaraTalkerComponent>();
            foreach (var c in TTSYukkuriConfig.Default.SasaraSettings.Components)
            {
                components.Add(new SasaraTalkerComponent()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Value = c.Value
                });
            }

            talker.Components = components.ToArray();

            // ささらに反映する
            TTSServerController.Message.SetSasaraSettings(new TTSMessage.SasaraSettingsEventArg()
            {
                Settings = talker
            });
        }
    }
}
