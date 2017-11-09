namespace ACT.TTSYukkuri.Config
{
    using System;
    using System.Text;

    using ACT.TTSYukkuri.Sasara;

    /// <summary>
    /// TTSささら設定
    /// </summary>
    [Serializable]
    public class SasaraConfig
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SasaraConfig()
        {
            this.Components = new SasaraSettingsDataSet.SasaraComponentsDataTable();

            this.Cast = "さとうささら";
            this.Onryo = 100;
            this.Hayasa = 50;
            this.Takasa = 50;
            this.Seishitsu = 50;
            this.Yokuyo = 50;
        }

        /// <summary>
        /// キャスト
        /// </summary>
        public string Cast { get; set; }

        /// <summary>
        /// 感情コンポーネント
        /// </summary>
        public SasaraSettingsDataSet.SasaraComponentsDataTable Components { get; set; }

        /// <summary>
        /// 音量
        /// </summary>
        public uint Onryo { get; set; }

        /// <summary>
        /// 早さ
        /// </summary>
        public uint Hayasa { get; set; }

        /// <summary>
        /// 高さ
        /// </summary>
        public uint Takasa { get; set; }

        /// <summary>
        /// 声質
        /// </summary>
        public uint Seishitsu { get; set; }

        /// <summary>
        /// 抑揚
        /// </summary>
        public uint Yokuyo { get; set; }

        /// <summary>
        /// 内容をMD5化する
        /// </summary>
        /// <returns></returns>
        public string GetMD5()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.Cast);
            sb.AppendLine(this.Onryo.ToString());
            sb.AppendLine(this.Hayasa.ToString());
            sb.AppendLine(this.Takasa.ToString());
            sb.AppendLine(this.Seishitsu.ToString());
            sb.AppendLine(this.Yokuyo.ToString());

            if (this.Components != null)
            {
                foreach (var c in this.Components)
                {
                    sb.AppendLine(c.Id + c.Name + c.Value.ToString());
                }
            }

            return sb.ToString().GetMD5();
        }
    }
}
