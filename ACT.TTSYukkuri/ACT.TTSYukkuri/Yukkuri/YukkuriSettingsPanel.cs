namespace ACT.TTSYukkuri.Yukkuri
{
    using System;
    using System.Windows.Forms;

    using ACT.TTSYukkuri.Config;

    /// <summary>
    /// ゆっくり設定Panel
    /// </summary>
    public partial class YukkuriSettingsPanel : UserControl
    {
        /// <summary>
        /// ロックオブジェクト
        /// </summary>
        private static object lockObject = new object();

        /// <summary>
        /// シングルトンinstance
        /// </summary>
        private static YukkuriSettingsPanel instance;

        /// <summary>
        /// シングルトンinstance
        /// </summary>
        public static YukkuriSettingsPanel Default
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new YukkuriSettingsPanel();
                    }

                    return instance;
                }
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public YukkuriSettingsPanel()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void YukkuriSettingsPanel_Load(object sender, EventArgs e)
        {
            // 設定をロードする
            this.enabledYukkuriVolumeSettingCheckBox.Checked = TTSYukkuriConfig.Default.EnabledYukkuriVolumeSetting;
            this.yukkuriVolumeTextBox.Text = TTSYukkuriConfig.Default.YukkuriVolume.ToString();

            if (TTSYukkuriConfig.Default.EnabledYukkuriVolumeSetting)
            {
                this.yukkuriVolumeTextBox.Enabled = true;
            }
            else
            {
                this.yukkuriVolumeTextBox.Enabled = false;
            }

            if (TTSYukkuriConfig.Default.YukkuriSpeed == 0)
            {
                // デフォは110とする
                TTSYukkuriConfig.Default.YukkuriSpeed = 110;
            }

            this.yukkuriSpeedTextBox.Text = TTSYukkuriConfig.Default.YukkuriSpeed.ToString();

            this.SaveSettings();

            // イベントを定義する
            this.yukkuriSpeedTextBox.Leave += (s1, e1) =>
            {
                var c = s1 as TextBox;

                int i;
                if (int.TryParse(c.Text, out i))
                {
                    if (i <= 50)
                    {
                        i = 50;
                    }

                    if (i >= 300)
                    {
                        i = 300;
                    }

                    c.Text = i.ToString();
                }
                else
                {
                    c.Text = "110";
                }

                this.SaveSettings();
            };

            this.enabledYukkuriVolumeSettingCheckBox.CheckedChanged += (s1, e1) =>
            {
                var c = s1 as CheckBox;

                if (c.Checked)
                {
                    this.yukkuriVolumeTextBox.Enabled = true;
                }
                else
                {
                    this.yukkuriVolumeTextBox.Enabled = false;
                }

                this.SaveSettings();
            };

            this.yukkuriVolumeTextBox.Leave += (s1, e1) =>
            {
                var c = s1 as TextBox;

                int i;
                if (int.TryParse(c.Text, out i))
                {
                    if (i <= 0)
                    {
                        i = 0;
                    }

                    if (i >= 100)
                    {
                        i = 100;
                    }

                    c.Text = i.ToString();
                }
                else
                {
                    c.Text = "0";
                }

                this.SaveSettings();
            };
        }

        /// <summary>
        /// 設定を保存する
        /// </summary>
        private void SaveSettings()
        {
            TTSYukkuriConfig.Default.YukkuriSpeed = int.Parse(this.yukkuriSpeedTextBox.Text);
            TTSYukkuriConfig.Default.EnabledYukkuriVolumeSetting = this.enabledYukkuriVolumeSettingCheckBox.Checked;
            TTSYukkuriConfig.Default.YukkuriVolume = int.Parse(this.yukkuriVolumeTextBox.Text);

            TTSYukkuriConfig.Default.Save();
        }
    }
}
