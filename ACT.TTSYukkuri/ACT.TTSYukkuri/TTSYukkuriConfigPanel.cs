namespace ACT.TTSYukkuri
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    using ACT.TTSYukkuri.Config;
    using ACT.TTSYukkuri.SoundPlayer;

    /// <summary>
    /// TTSゆっくり設定Panel
    /// </summary>
    public partial class TTSYukkuriConfigPanel : UserControl
    {
        /// <summary>
        /// TTS設定Panel
        /// </summary>
        private UserControl ttsSettingsPanel;

        /// <summary>
        /// ロード完了
        /// </summary>
        private bool Loaded;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TTSYukkuriConfigPanel()
        {
            this.InitializeComponent();

            this.ttsShuruiComboBox.DisplayMember = "Display";
            this.ttsShuruiComboBox.ValueMember = "Value";
            this.ttsShuruiComboBox.DataSource = TTSType.ToComboBox;

            this.ttsShuruiComboBox.TextChanged += (s1, e1) =>
            {
                if (this.Loaded)
                {
                    this.SaveSettings();
                    this.LoadTTS();
                }
            };
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void TTSYukkuriConfigPanel_Load(object sender, EventArgs e)
        {
            this.PlayerComboBox.DataSource = Enum.GetValues(typeof(WavePlayers));
            this.PlayerComboBox.SelectedItem = TTSYukkuriConfig.Default.Player;

            this.EnumrateDevices();
            this.enabledSubDeviceCheckBox.Checked = TTSYukkuriConfig.Default.EnabledSubDevice;
            this.subDeviceComboBox.Enabled = this.enabledSubDeviceCheckBox.Checked;

            this.WaveVolTrackBar.Value = TTSYukkuriConfig.Default.WaveVolume;
            this.WaveCacheClearCheckBox.Checked = TTSYukkuriConfig.Default.WaveCacheClearEnable;

            this.enabledSubDeviceCheckBox.CheckedChanged += (s1, e1) =>
            {
                var c = s1 as CheckBox;
                this.subDeviceComboBox.Enabled = c.Checked;
                this.SaveSettings();
            };

            this.PlayerComboBox.SelectedIndexChanged += (s1, e1) =>
            {
                if ((s1 as Control).Enabled)
                {
                    TTSYukkuriConfig.Default.Player = (WavePlayers)this.PlayerComboBox.SelectedItem;
                    this.EnumrateDevices();
                    this.SaveSettings();
                    (s1 as Control).Focus();
                }
            };

            this.mainDeviceComboBox.TextChanged += (s1, e1) =>
            {
                if ((s1 as Control).Enabled)
                {
                    this.SaveSettings();
                }
            };

            this.subDeviceComboBox.TextChanged += (s1, e1) =>
            {
                if ((s1 as Control).Enabled)
                {
                    this.SaveSettings();
                }
            };

            this.WaveVolTrackBar.ValueChanged += (s1, e1) =>
            {
                this.SaveSettings();
            };

            this.WaveCacheClearCheckBox.CheckedChanged += (s1, e1) =>
            {
                this.SaveSettings();
            };

            this.ttsShuruiComboBox.SelectedValue = TTSYukkuriConfig.Default.TTS;

            this.LoadTTS();

            // オプションのロードを呼出す
            this.LoadOptions();

            this.Loaded = true;
        }

        /// <summary>
        /// 再生デバイスを列挙する
        /// </summary>
        private void EnumrateDevices()
        {
            try
            {
                this.PlayerComboBox.Enabled = false;
                this.mainDeviceComboBox.Enabled = false;
                this.subDeviceComboBox.Enabled = false;

                var devices = NAudioPlayer.EnumlateDevices();

                // 再生デバイスコンボボックスを設定する
                this.mainDeviceComboBox.DisplayMember = "Name";
                this.mainDeviceComboBox.ValueMember = "ID";
                this.mainDeviceComboBox.DataSource = devices.ToArray();

                this.subDeviceComboBox.DisplayMember = "Name";
                this.subDeviceComboBox.ValueMember = "ID";
                this.subDeviceComboBox.DataSource = devices.ToArray();

                var defaultDeviceID = devices
                    .Select(x => x.ID)
                    .FirstOrDefault() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(TTSYukkuriConfig.Default.MainDeviceID))
                {
                    TTSYukkuriConfig.Default.MainDeviceID = defaultDeviceID;
                }

                if (string.IsNullOrWhiteSpace(TTSYukkuriConfig.Default.SubDeviceID))
                {
                    TTSYukkuriConfig.Default.SubDeviceID = defaultDeviceID;
                }

                if (devices.Count > 0)
                {
                    this.mainDeviceComboBox.SelectedValue = TTSYukkuriConfig.Default.MainDeviceID;
                    this.subDeviceComboBox.SelectedValue = TTSYukkuriConfig.Default.SubDeviceID;

                    if (string.IsNullOrWhiteSpace(this.mainDeviceComboBox.Text))
                    {
                        this.mainDeviceComboBox.SelectedIndex = 0;
                    }

                    if (string.IsNullOrWhiteSpace(this.subDeviceComboBox.Text))
                    {
                        this.subDeviceComboBox.SelectedIndex = 0;
                    }
                }
            }
            finally
            {
                this.PlayerComboBox.Enabled = true;
                this.mainDeviceComboBox.Enabled = true;
                this.subDeviceComboBox.Enabled = this.enabledSubDeviceCheckBox.Checked;
            }
        }

        /// <summary>
        /// 設定を保存する
        /// </summary>
        private void SaveSettings()
        {
            TTSYukkuriConfig.Default.TTS = (this.ttsShuruiComboBox.SelectedItem as ComboBoxItem).Value;

            TTSYukkuriConfig.Default.Player = (WavePlayers)this.PlayerComboBox.SelectedItem;
            TTSYukkuriConfig.Default.MainDeviceID = (string)this.mainDeviceComboBox.SelectedValue;
            TTSYukkuriConfig.Default.EnabledSubDevice = this.enabledSubDeviceCheckBox.Checked;
            TTSYukkuriConfig.Default.SubDeviceID = (string)this.subDeviceComboBox.SelectedValue;
            TTSYukkuriConfig.Default.WaveVolume = (int)this.WaveVolTrackBar.Value;
            TTSYukkuriConfig.Default.WaveCacheClearEnable = this.WaveCacheClearCheckBox.Checked;

            this.SaveSettingsOptions();

            TTSYukkuriConfig.Default.Save();
        }

        /// <summary>
        /// TTSを読み込む
        /// </summary>
        private void LoadTTS()
        {
            try
            {
                // TTSを初期化する
                SpeechController.Default.Initialize();

                // 前のPanelを除去する
                if (this.ttsSettingsPanel != null)
                {
                    this.ttsSettingsGroupBox.Controls.Remove(this.ttsSettingsPanel);
                }

                // 新しいPanelをセットする
                var ttsSettingsPanelNew = SpeechController.Default.TTSSettingsPanel;
                if (ttsSettingsPanelNew != null)
                {
                    ttsSettingsPanelNew.Dock = DockStyle.Fill;
                    this.ttsSettingsGroupBox.Controls.Add(ttsSettingsPanelNew);

                    this.ttsSettingsPanel = ttsSettingsPanelNew;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    "TTSの初期化中に例外が発生しました。環境を確認してください" + Environment.NewLine + Environment.NewLine +
                    ex.ToString(),
                    "TTSゆっくりプラグイン",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                // TTSをゆっくりに戻す
                TTSYukkuriConfig.Default.TTS = TTSType.Yukkuri;
                TTSYukkuriConfig.Default.Save();
                this.ttsShuruiComboBox.SelectedValue = TTSYukkuriConfig.Default.TTS;
            }
        }
    }
}
