namespace ACT.TTSYukkuri
{
    /// <summary>
    /// TTSの種類
    /// </summary>
    public static class TTSType
    {
        /// <summary>
        /// Yukkuri:ゆっくり
        /// </summary>
        public const string Yukkuri = "Yukkuri";

        /// <summary>
        /// Sasara:CeVIO Creative Studio
        /// </summary>
        public const string SasaraSato = "Sasara";

        /// <summary>
        /// Boyomichan:棒読みちゃん
        /// </summary>
        public const string Boyomichan = "Boyomichan";

        /// <summary>
        /// OpenJTalk:Open JTalk
        /// </summary>
        public const string OpenJTalk = "OpenJTalk";

        /// <summary>
        /// HOYA:HOYA
        /// </summary>
        public const string HOYA = "HOYA";

        /// <summary>
        /// コンボボックスコレクション
        /// </summary>
        public static ComboBoxItem[] ToComboBox = new ComboBoxItem[]
        {
            new ComboBoxItem("ゆっくり", TTSType.Yukkuri),
            new ComboBoxItem("Open JTalk", TTSType.OpenJTalk),
            new ComboBoxItem("HOYA VoiceText Web API", TTSType.HOYA),
            new ComboBoxItem("棒読みちゃん(TCPインターフェース)", TTSType.Boyomichan),
            new ComboBoxItem("CeVIO Creative Studio", TTSType.SasaraSato),
        };
    }

    public class ComboBoxItem
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="display">表示用</param>
        /// <param name="value">値用</param>
        public ComboBoxItem(
            string display,
            string value)
        {
            this.Display = display;
            this.Value = value;
        }

        /// <summary>
        /// 表示用メンバ
        /// </summary>
        public string Display { get; set; }

        /// <summary>
        /// 値用メンバ
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return this.Display;
        }
    }
}
