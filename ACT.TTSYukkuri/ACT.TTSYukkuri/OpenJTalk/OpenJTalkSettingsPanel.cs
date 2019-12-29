namespace ACT.TTSYukkuri.OpenJTalk
{
    using System;
    using System.Windows.Forms;

    using ACT.TTSYukkuri.Config;

    public partial class OpenJTalkSettingsPanel : UserControl
    {
        private static OpenJTalkSettingsPanel instance;

        public static OpenJTalkSettingsPanel Default
        {
            get
            {
                if (instance == null)
                {
                    instance = new OpenJTalkSettingsPanel();
                }

                return instance;
            }
        }

        private bool dontSave = false;

        public OpenJTalkSettingsPanel()
        {
            this.InitializeComponent();

            this.Load += this.OpenJTalkSettingsPanel_Load;

            this.GainTrackBar.ValueChanged += (s, e) =>
            {
                this.GainTextBox.Text = (s as TrackBar).Value.ToString();
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
        }

        private void OpenJTalkSettingsPanel_Load(object sender, EventArgs e)
        {
            this.VoiceComboBox.ValueMember = "Value";
            this.VoiceComboBox.DisplayMember = "Name";
            this.VoiceComboBox.DataSource = TTSYukkuriConfig.Default.OpenJTalkSettings.EnumlateVoice();
            this.VoiceComboBox.SelectedValue = TTSYukkuriConfig.Default.OpenJTalkSettings.Voice;

            this.VoiceComboBox.SelectedIndexChanged += (s1, e1) =>
            {
                this.SaveSettings();
            };

            try
            {
                this.dontSave = true;

                this.GainTrackBar.Value = TTSYukkuriConfig.Default.OpenJTalkSettings.Gain;
                this.VolumeTrackBar.Value = TTSYukkuriConfig.Default.OpenJTalkSettings.Volume;
                this.SpeedTrackBar.Value = TTSYukkuriConfig.Default.OpenJTalkSettings.Speed;
                this.PitchTrackBar.Value = TTSYukkuriConfig.Default.OpenJTalkSettings.Pitch;

                this.GainTextBox.Text = TTSYukkuriConfig.Default.OpenJTalkSettings.Gain.ToString();
                this.VolumeTextBox.Text = TTSYukkuriConfig.Default.OpenJTalkSettings.Volume.ToString();
                this.SpeedTextBox.Text = TTSYukkuriConfig.Default.OpenJTalkSettings.Speed.ToString();
                this.PitchTextBox.Text = TTSYukkuriConfig.Default.OpenJTalkSettings.Pitch.ToString();
            }
            finally
            {
                this.dontSave = false;
            }

            this.DefaultButton.Click += (s1, e1) =>
            {
                try
                {
                    this.dontSave = true;

                    TTSYukkuriConfig.Default.OpenJTalkSettings.SetDefault();

                    this.VoiceComboBox.SelectedValue = TTSYukkuriConfig.Default.OpenJTalkSettings.Voice;

                    this.GainTrackBar.Value = TTSYukkuriConfig.Default.OpenJTalkSettings.Gain;
                    this.VolumeTrackBar.Value = TTSYukkuriConfig.Default.OpenJTalkSettings.Volume;
                    this.SpeedTrackBar.Value = TTSYukkuriConfig.Default.OpenJTalkSettings.Speed;
                    this.PitchTrackBar.Value = TTSYukkuriConfig.Default.OpenJTalkSettings.Pitch;

                    this.GainTextBox.Text = TTSYukkuriConfig.Default.OpenJTalkSettings.Gain.ToString();
                    this.VolumeTextBox.Text = TTSYukkuriConfig.Default.OpenJTalkSettings.Volume.ToString();
                    this.SpeedTextBox.Text = TTSYukkuriConfig.Default.OpenJTalkSettings.Speed.ToString();
                    this.PitchTextBox.Text = TTSYukkuriConfig.Default.OpenJTalkSettings.Pitch.ToString();
                }
                finally
                {
                    this.dontSave = false;
                }

                this.SaveSettings();
            };
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

            TTSYukkuriConfig.Default.OpenJTalkSettings.Voice = (string)this.VoiceComboBox.SelectedValue;
            TTSYukkuriConfig.Default.OpenJTalkSettings.Gain = this.GainTrackBar.Value;
            TTSYukkuriConfig.Default.OpenJTalkSettings.Volume = this.VolumeTrackBar.Value;
            TTSYukkuriConfig.Default.OpenJTalkSettings.Speed = this.SpeedTrackBar.Value;
            TTSYukkuriConfig.Default.OpenJTalkSettings.Pitch = this.PitchTrackBar.Value;

            // 設定を保存する
            TTSYukkuriConfig.Default.Save();
        }
    }
}
