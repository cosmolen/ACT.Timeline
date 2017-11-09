namespace ACT.TTSYukkuri
{
    using System.Windows.Forms;

    using ACT.TTSYukkuri.Config;

    /// <summary>
    /// TTSゆっくり設定Panel オプション設定
    /// </summary>
    public partial class TTSYukkuriConfigPanel
    {
        /// <summary>
        /// オプションをロードする
        /// </summary>
        private void LoadOptions()
        {
            // 設定をロードする
            this.enableWatchHPCheckBox.Checked = TTSYukkuriConfig.Default.OptionSettings.EnabledHPWatch;
            this.enableWatchMPCheckBox.Checked = TTSYukkuriConfig.Default.OptionSettings.EnabledMPWatch;
            this.enableWatchTPCheckBox.Checked = TTSYukkuriConfig.Default.OptionSettings.EnabledTPWatch;
            this.HPThresholdTextBox.Text = TTSYukkuriConfig.Default.OptionSettings.HPThreshold.ToString();
            this.MPThresholdTextBox.Text = TTSYukkuriConfig.Default.OptionSettings.MPThreshold.ToString();
            this.TPThresholdTextBox.Text = TTSYukkuriConfig.Default.OptionSettings.TPThreshold.ToString();
            this.hpTextToSpeakTextBox.Text = TTSYukkuriConfig.Default.OptionSettings.HPTextToSpeack;
            this.mpTextToSpeakTextBox.Text = TTSYukkuriConfig.Default.OptionSettings.MPTextToSpeack;
            this.tpTextToSpeakTextBox.Text = TTSYukkuriConfig.Default.OptionSettings.TPTextToSpeack;

            var array = new bool[0];

            array = TTSYukkuriConfig.Default.OptionSettings.WatchTargetsHP.ItemArray;
            for (int i = 0; i < array.Length; i++)
            {
                this.watchTargetsHPCheckedListBox.SetItemChecked(i, array[i]);
            }

            array = TTSYukkuriConfig.Default.OptionSettings.WatchTargetsMP.ItemArray;
            for (int i = 0; i < array.Length; i++)
            {
                this.watchTargetsMPCheckedListBox.SetItemChecked(i, array[i]);
            }

            array = TTSYukkuriConfig.Default.OptionSettings.WatchTargetsTP.ItemArray;
            for (int i = 0; i < array.Length; i++)
            {
                this.watchTargetsTPCheckedListBox.SetItemChecked(i, array[i]);
            }

            this.HPThresholdTextBox.Enabled = this.enableWatchHPCheckBox.Checked;
            this.MPThresholdTextBox.Enabled = this.enableWatchMPCheckBox.Checked;
            this.TPThresholdTextBox.Enabled = this.enableWatchTPCheckBox.Checked;
            this.hpTextToSpeakTextBox.Enabled = this.enableWatchHPCheckBox.Checked;
            this.mpTextToSpeakTextBox.Enabled = this.enableWatchMPCheckBox.Checked;
            this.tpTextToSpeakTextBox.Enabled = this.enableWatchTPCheckBox.Checked;
            this.watchTargetsHPCheckedListBox.Enabled = this.enableWatchHPCheckBox.Checked;
            this.watchTargetsMPCheckedListBox.Enabled = this.enableWatchMPCheckBox.Checked;
            this.watchTargetsTPCheckedListBox.Enabled = this.enableWatchTPCheckBox.Checked;

            // イベントを定義する
            this.HPThresholdTextBox.Leave += (s1, e1) => this.ValidateThresholdTextBox(s1);
            this.MPThresholdTextBox.Leave += (s1, e1) => this.ValidateThresholdTextBox(s1);
            this.TPThresholdTextBox.Leave += (s1, e1) => this.ValidateThresholdTextBox(s1);

            this.enableWatchHPCheckBox.CheckedChanged += (s1, e1) =>
            {
                this.HPThresholdTextBox.Enabled = (s1 as CheckBox).Checked;
                this.hpTextToSpeakTextBox.Enabled = (s1 as CheckBox).Checked;
                this.watchTargetsHPCheckedListBox.Enabled = (s1 as CheckBox).Checked;
                this.SaveSettings();
            };

            this.enableWatchMPCheckBox.CheckedChanged += (s1, e1) =>
            {
                this.MPThresholdTextBox.Enabled = (s1 as CheckBox).Checked;
                this.mpTextToSpeakTextBox.Enabled = (s1 as CheckBox).Checked;
                this.watchTargetsMPCheckedListBox.Enabled = (s1 as CheckBox).Checked;
                this.SaveSettings();
            };

            this.enableWatchTPCheckBox.CheckedChanged += (s1, e1) =>
            {
                this.TPThresholdTextBox.Enabled = (s1 as CheckBox).Checked;
                this.tpTextToSpeakTextBox.Enabled = (s1 as CheckBox).Checked;
                this.watchTargetsTPCheckedListBox.Enabled = (s1 as CheckBox).Checked;
                this.SaveSettings();
            };

            this.hpTextToSpeakTextBox.Leave += (s1, e1) => this.SaveSettings();
            this.mpTextToSpeakTextBox.Leave += (s1, e1) => this.SaveSettings();
            this.tpTextToSpeakTextBox.Leave += (s1, e1) => this.SaveSettings();

            this.watchTargetsHPCheckedListBox.SelectedIndexChanged += (s1, e1) => this.SaveSettings();
            this.watchTargetsMPCheckedListBox.SelectedIndexChanged += (s1, e1) => this.SaveSettings();
            this.watchTargetsTPCheckedListBox.SelectedIndexChanged += (s1, e1) => this.SaveSettings();
            this.watchTargetsHPCheckedListBox.DoubleClick += (s1, e1) => this.SaveSettings();
            this.watchTargetsMPCheckedListBox.DoubleClick += (s1, e1) => this.SaveSettings();
            this.watchTargetsTPCheckedListBox.DoubleClick += (s1, e1) => this.SaveSettings();
        }

        /// <summary>
        /// しきい値テキストボックスを検証する
        /// </summary>
        /// <param name="control">対象のControl</param>
        private void ValidateThresholdTextBox(
            object control)
        {
            var c = control as TextBox;

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
        }

        /// <summary>
        /// 設定を保存する(オプション部分)
        /// </summary>
        private void SaveSettingsOptions()
        {
            TTSYukkuriConfig.Default.OptionSettings.EnabledHPWatch = this.enableWatchHPCheckBox.Checked;
            TTSYukkuriConfig.Default.OptionSettings.EnabledMPWatch = this.enableWatchMPCheckBox.Checked;
            TTSYukkuriConfig.Default.OptionSettings.EnabledTPWatch = this.enableWatchTPCheckBox.Checked;
            TTSYukkuriConfig.Default.OptionSettings.HPThreshold = int.Parse(this.HPThresholdTextBox.Text);
            TTSYukkuriConfig.Default.OptionSettings.MPThreshold = int.Parse(this.MPThresholdTextBox.Text);
            TTSYukkuriConfig.Default.OptionSettings.TPThreshold = int.Parse(this.TPThresholdTextBox.Text);
            TTSYukkuriConfig.Default.OptionSettings.HPTextToSpeack = this.hpTextToSpeakTextBox.Text;
            TTSYukkuriConfig.Default.OptionSettings.MPTextToSpeack = this.mpTextToSpeakTextBox.Text;
            TTSYukkuriConfig.Default.OptionSettings.TPTextToSpeack = this.tpTextToSpeakTextBox.Text;

            var array = new bool[0];

            array = TTSYukkuriConfig.Default.OptionSettings.WatchTargetsHP.ItemArray;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = this.watchTargetsHPCheckedListBox.GetItemChecked(i);
            }

            TTSYukkuriConfig.Default.OptionSettings.WatchTargetsHP.ItemArray = array;

            array = TTSYukkuriConfig.Default.OptionSettings.WatchTargetsMP.ItemArray;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = this.watchTargetsMPCheckedListBox.GetItemChecked(i);
            }

            TTSYukkuriConfig.Default.OptionSettings.WatchTargetsMP.ItemArray = array;

            array = TTSYukkuriConfig.Default.OptionSettings.WatchTargetsTP.ItemArray;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = this.watchTargetsTPCheckedListBox.GetItemChecked(i);
            }

            TTSYukkuriConfig.Default.OptionSettings.WatchTargetsTP.ItemArray = array;
        }
    }
}
