namespace ACT.TTSYukkuri.HOYA
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    using ACT.TTSYukkuri.Config;
    using VoiceTextWebAPI.Client;

    public partial class HOYASettingsPanel : UserControl
    {
        private const string APIRegisterUrl = @"https://cloud.voicetext.jp/webapi/api_keys/new";

        private static HOYASettingsPanel instance;

        public static HOYASettingsPanel Default
        {
            get
            {
                if (instance == null)
                {
                    instance = new HOYASettingsPanel();
                }

                return instance;
            }
        }

        private bool dontSave = false;

        public HOYASettingsPanel()
        {
            this.InitializeComponent();

            this.Load += HOYASettingsPanel_Load;

            this.APIKeyTextBox.Validated += (s, e) =>
            {
                this.SaveSettings();
            };

            this.VolumeTrackBar.ValueChanged += (s, e) =>
            {
                this.VolumeTextBox.Text = (s as TrackBar).Value.ToString();
                this.SaveSettings();
            };

            this.SpeedTrackBar.ValueChanged += (s, e) =>
            {
                this.SpeedTextBox.Text = (s as TrackBar).Value.ToString();
                this.SaveSettings();
            };

            this.PitchTrackBar.ValueChanged += (s, e) =>
            {
                this.PitchTextBox.Text = (s as TrackBar).Value.ToString();
                this.SaveSettings();
            };

            this.APIKeyLinkLabel.Click += (s, e) =>
            {
                Process.Start(APIRegisterUrl);
            };

            this.DefaultButton.Click += (s, e) =>
            {
                TTSYukkuriConfig.Default.HOYASettings.SetDefault();
                this.OnLoad(new EventArgs());
            };
        }

        private void HOYASettingsPanel_Load(object sender, EventArgs e)
        {
            try
            {
                this.dontSave = true;

                this.SpeakerComboBox.DataSource = Enum.GetValues(typeof(Speaker));
                this.EmotionComboBox.DataSource = Enum.GetValues(typeof(Emotion));
                this.EmotionLevelComboBox.DataSource = Enum.GetValues(typeof(EmotionLevel));

                this.APIKeyTextBox.Text = TTSYukkuriConfig.Default.HOYASettings.APIKey;

                this.SpeakerComboBox.SelectedItem = TTSYukkuriConfig.Default.HOYASettings.Speaker;
                this.EmotionComboBox.SelectedItem = TTSYukkuriConfig.Default.HOYASettings.Emotion;
                this.EmotionLevelComboBox.SelectedItem = TTSYukkuriConfig.Default.HOYASettings.EmotionLevel;

                this.VolumeTrackBar.Value = TTSYukkuriConfig.Default.HOYASettings.Volume;
                this.SpeedTrackBar.Value = TTSYukkuriConfig.Default.HOYASettings.Speed;
                this.PitchTrackBar.Value = TTSYukkuriConfig.Default.HOYASettings.Pitch;

                this.SpeakerComboBox.SelectedIndexChanged += (s1, e1) => this.SaveSettings();
                this.EmotionComboBox.SelectedIndexChanged += (s1, e1) => this.SaveSettings();
                this.EmotionLevelComboBox.SelectedIndexChanged += (s1, e1) => this.SaveSettings();
            }
            finally
            {
                this.dontSave = false;
            }
        }

        /// <summary>
        /// 設定を保存する
        /// </summary>
        private void SaveSettings()
        {
            if (this.dontSave)
            {
                return;
            }

            TTSYukkuriConfig.Default.HOYASettings.APIKey = this.APIKeyTextBox.Text;
            TTSYukkuriConfig.Default.HOYASettings.Speaker = (Speaker)this.SpeakerComboBox.SelectedItem;
            TTSYukkuriConfig.Default.HOYASettings.Emotion = (Emotion)this.EmotionComboBox.SelectedItem;
            TTSYukkuriConfig.Default.HOYASettings.EmotionLevel = (EmotionLevel)this.EmotionLevelComboBox.SelectedItem;
            TTSYukkuriConfig.Default.HOYASettings.Volume = this.VolumeTrackBar.Value;
            TTSYukkuriConfig.Default.HOYASettings.Speed = this.SpeedTrackBar.Value;
            TTSYukkuriConfig.Default.HOYASettings.Pitch = this.PitchTrackBar.Value;

            // 設定を保存する
            TTSYukkuriConfig.Default.Save();
        }

    }
}
