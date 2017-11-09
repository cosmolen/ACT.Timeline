namespace ACT.TTSYukkuri.Boyomichan
{
    using System.Windows.Forms;

    using ACT.TTSYukkuri.Config;

    /// <summary>
    /// 棒読みちゃん設定パネル
    /// </summary>
    public partial class BoyomiSettingPanel : UserControl
    {
        /// <summary>
        /// シングルトンinstance
        /// </summary>
        private static BoyomiSettingPanel instance;

        /// <summary>
        /// シングルトンinstance
        /// </summary>
        public static BoyomiSettingPanel Default
        {
            get
            {
                if (instance == null)
                {
                    instance = new BoyomiSettingPanel();
                }

                return instance;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BoyomiSettingPanel()
        {
            this.InitializeComponent();

            this.Load += (s, e) =>
            {
                this.BoyomiServerTextBox.Text = TTSYukkuriConfig.Default.BoyomiServer.Count > 0 ?
                    TTSYukkuriConfig.Default.BoyomiServer[0] :
                    BoyomichanSpeechController.BoyomichanServer;

                this.BoyomiPortNumericUpDown.Value = TTSYukkuriConfig.Default.BoyomiServer.Count > 1 ?
                    int.Parse(TTSYukkuriConfig.Default.BoyomiServer[1]) :
                    BoyomichanSpeechController.BoyomichanServicePort;

                this.BoyomiServerTextBox.Leave += (s1, e1) =>
                {
                    if (string.IsNullOrWhiteSpace(this.BoyomiServerTextBox.Text))
                    {
                        this.BoyomiServerTextBox.Text = "127.0.0.1";
                    }

                    TTSYukkuriConfig.Default.BoyomiServer.Clear();
                    TTSYukkuriConfig.Default.BoyomiServer.Add(this.BoyomiServerTextBox.Text);
                    TTSYukkuriConfig.Default.BoyomiServer.Add(this.BoyomiPortNumericUpDown.Value.ToString());

                    TTSYukkuriConfig.Default.Save();
                };

                this.BoyomiPortNumericUpDown.ValueChanged += (s1, e1) =>
                {
                    TTSYukkuriConfig.Default.BoyomiServer.Clear();
                    TTSYukkuriConfig.Default.BoyomiServer.Add(this.BoyomiServerTextBox.Text);
                    TTSYukkuriConfig.Default.BoyomiServer.Add(this.BoyomiPortNumericUpDown.Value.ToString());

                    TTSYukkuriConfig.Default.Save();
                };
            };
        }
    }
}
