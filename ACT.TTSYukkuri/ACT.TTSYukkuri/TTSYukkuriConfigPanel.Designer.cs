namespace ACT.TTSYukkuri
{
    partial class TTSYukkuriConfigPanel
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TTSYukkuriConfigPanel));
            this.label1 = new System.Windows.Forms.Label();
            this.ttsShuruiComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ttsSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.optionGroupBox = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.watchHPTabPage = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.watchTargetsHPCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.hpTextToSpeakTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HPThresholdTextBox = new System.Windows.Forms.TextBox();
            this.enableWatchHPCheckBox = new System.Windows.Forms.CheckBox();
            this.watchMPTabPage = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.watchTargetsMPCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.mpTextToSpeakTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MPThresholdTextBox = new System.Windows.Forms.TextBox();
            this.enableWatchMPCheckBox = new System.Windows.Forms.CheckBox();
            this.watchTPTabPage = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.watchTargetsTPCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tpTextToSpeakTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TPThresholdTextBox = new System.Windows.Forms.TextBox();
            this.enableWatchTPCheckBox = new System.Windows.Forms.CheckBox();
            this.saiseiDeviceGroupBox = new System.Windows.Forms.GroupBox();
            this.PlayerComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.enabledSubDeviceCheckBox = new System.Windows.Forms.CheckBox();
            this.subDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mainDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.WaveVolTrackBar = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.WaveCacheClearCheckBox = new System.Windows.Forms.CheckBox();
            this.optionGroupBox.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.watchHPTabPage.SuspendLayout();
            this.watchMPTabPage.SuspendLayout();
            this.watchTPTabPage.SuspendLayout();
            this.saiseiDeviceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaveVolTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "TTSの種類";
            // 
            // ttsShuruiComboBox
            // 
            this.ttsShuruiComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ttsShuruiComboBox.FormattingEnabled = true;
            this.ttsShuruiComboBox.Location = new System.Drawing.Point(69, 16);
            this.ttsShuruiComboBox.Name = "ttsShuruiComboBox";
            this.ttsShuruiComboBox.Size = new System.Drawing.Size(224, 20);
            this.ttsShuruiComboBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(395, 33);
            this.label3.TabIndex = 3;
            this.label3.Text = "※注意\r\n「CeVIO Creative Studio」は製品版が必要です";
            // 
            // ttsSettingsGroupBox
            // 
            this.ttsSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ttsSettingsGroupBox.Location = new System.Drawing.Point(5, 126);
            this.ttsSettingsGroupBox.Name = "ttsSettingsGroupBox";
            this.ttsSettingsGroupBox.Size = new System.Drawing.Size(463, 505);
            this.ttsSettingsGroupBox.TabIndex = 3;
            this.ttsSettingsGroupBox.TabStop = false;
            this.ttsSettingsGroupBox.Text = "TTSの設定";
            // 
            // optionGroupBox
            // 
            this.optionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionGroupBox.Controls.Add(this.tabControl);
            this.optionGroupBox.Location = new System.Drawing.Point(474, 126);
            this.optionGroupBox.Name = "optionGroupBox";
            this.optionGroupBox.Size = new System.Drawing.Size(720, 505);
            this.optionGroupBox.TabIndex = 3;
            this.optionGroupBox.TabStop = false;
            this.optionGroupBox.Text = "オプション設定";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.watchHPTabPage);
            this.tabControl.Controls.Add(this.watchMPTabPage);
            this.tabControl.Controls.Add(this.watchTPTabPage);
            this.tabControl.Location = new System.Drawing.Point(6, 18);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(708, 481);
            this.tabControl.TabIndex = 11;
            // 
            // watchHPTabPage
            // 
            this.watchHPTabPage.Controls.Add(this.label8);
            this.watchHPTabPage.Controls.Add(this.watchTargetsHPCheckedListBox);
            this.watchHPTabPage.Controls.Add(this.textBox1);
            this.watchHPTabPage.Controls.Add(this.hpTextToSpeakTextBox);
            this.watchHPTabPage.Controls.Add(this.label2);
            this.watchHPTabPage.Controls.Add(this.HPThresholdTextBox);
            this.watchHPTabPage.Controls.Add(this.enableWatchHPCheckBox);
            this.watchHPTabPage.Location = new System.Drawing.Point(4, 22);
            this.watchHPTabPage.Name = "watchHPTabPage";
            this.watchHPTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.watchHPTabPage.Size = new System.Drawing.Size(700, 455);
            this.watchHPTabPage.TabIndex = 0;
            this.watchHPTabPage.Text = "HP監視　　";
            this.watchHPTabPage.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "監視対象";
            // 
            // watchTargetsHPCheckedListBox
            // 
            this.watchTargetsHPCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.watchTargetsHPCheckedListBox.CheckOnClick = true;
            this.watchTargetsHPCheckedListBox.FormattingEnabled = true;
            this.watchTargetsHPCheckedListBox.Items.AddRange(new object[] {
            "自分自身",
            "ナイト・剣術士",
            "戦士・斧術士",
            "白魔道士・幻術士",
            "学者",
            "モンク・格闘士",
            "竜騎士・槍術士",
            "忍者・双剣士",
            "吟遊詩人・弓術士",
            "黒魔道士・呪術士",
            "召喚士・巴術士",
            "ギャザラー・クラフター",
            "機工士",
            "暗黒騎士",
            "占星術師"});
            this.watchTargetsHPCheckedListBox.Location = new System.Drawing.Point(6, 101);
            this.watchTargetsHPCheckedListBox.Name = "watchTargetsHPCheckedListBox";
            this.watchTargetsHPCheckedListBox.Size = new System.Drawing.Size(405, 336);
            this.watchTargetsHPCheckedListBox.TabIndex = 16;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(417, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(280, 242);
            this.textBox1.TabIndex = 15;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // hpTextToSpeakTextBox
            // 
            this.hpTextToSpeakTextBox.Location = new System.Drawing.Point(6, 53);
            this.hpTextToSpeakTextBox.Name = "hpTextToSpeakTextBox";
            this.hpTextToSpeakTextBox.Size = new System.Drawing.Size(405, 19);
            this.hpTextToSpeakTextBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "%以下になったら読上げる";
            // 
            // HPThresholdTextBox
            // 
            this.HPThresholdTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.HPThresholdTextBox.Location = new System.Drawing.Point(6, 28);
            this.HPThresholdTextBox.MaxLength = 3;
            this.HPThresholdTextBox.Name = "HPThresholdTextBox";
            this.HPThresholdTextBox.Size = new System.Drawing.Size(59, 19);
            this.HPThresholdTextBox.TabIndex = 12;
            this.HPThresholdTextBox.Text = "0";
            this.HPThresholdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // enableWatchHPCheckBox
            // 
            this.enableWatchHPCheckBox.AutoSize = true;
            this.enableWatchHPCheckBox.Location = new System.Drawing.Point(6, 6);
            this.enableWatchHPCheckBox.Name = "enableWatchHPCheckBox";
            this.enableWatchHPCheckBox.Size = new System.Drawing.Size(152, 16);
            this.enableWatchHPCheckBox.TabIndex = 11;
            this.enableWatchHPCheckBox.Text = "PartyのHP低下を監視する";
            this.enableWatchHPCheckBox.UseVisualStyleBackColor = true;
            // 
            // watchMPTabPage
            // 
            this.watchMPTabPage.Controls.Add(this.label9);
            this.watchMPTabPage.Controls.Add(this.watchTargetsMPCheckedListBox);
            this.watchMPTabPage.Controls.Add(this.textBox2);
            this.watchMPTabPage.Controls.Add(this.mpTextToSpeakTextBox);
            this.watchMPTabPage.Controls.Add(this.label4);
            this.watchMPTabPage.Controls.Add(this.MPThresholdTextBox);
            this.watchMPTabPage.Controls.Add(this.enableWatchMPCheckBox);
            this.watchMPTabPage.Location = new System.Drawing.Point(4, 22);
            this.watchMPTabPage.Name = "watchMPTabPage";
            this.watchMPTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.watchMPTabPage.Size = new System.Drawing.Size(700, 455);
            this.watchMPTabPage.TabIndex = 1;
            this.watchMPTabPage.Text = "MP監視　　";
            this.watchMPTabPage.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "監視対象";
            // 
            // watchTargetsMPCheckedListBox
            // 
            this.watchTargetsMPCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.watchTargetsMPCheckedListBox.CheckOnClick = true;
            this.watchTargetsMPCheckedListBox.FormattingEnabled = true;
            this.watchTargetsMPCheckedListBox.Items.AddRange(new object[] {
            "自分自身",
            "ナイト・剣術士",
            "戦士・斧術士",
            "白魔道士・幻術士",
            "学者",
            "モンク・格闘士",
            "竜騎士・槍術士",
            "忍者・双剣士",
            "吟遊詩人・弓術士",
            "黒魔道士・呪術士",
            "召喚士・巴術士",
            "ギャザラー・クラフター",
            "機工士",
            "暗黒騎士",
            "占星術師"});
            this.watchTargetsMPCheckedListBox.Location = new System.Drawing.Point(6, 101);
            this.watchTargetsMPCheckedListBox.Name = "watchTargetsMPCheckedListBox";
            this.watchTargetsMPCheckedListBox.Size = new System.Drawing.Size(405, 336);
            this.watchTargetsMPCheckedListBox.TabIndex = 18;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox2.Location = new System.Drawing.Point(417, 6);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(280, 242);
            this.textBox2.TabIndex = 16;
            this.textBox2.TabStop = false;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // mpTextToSpeakTextBox
            // 
            this.mpTextToSpeakTextBox.Location = new System.Drawing.Point(6, 53);
            this.mpTextToSpeakTextBox.Name = "mpTextToSpeakTextBox";
            this.mpTextToSpeakTextBox.Size = new System.Drawing.Size(405, 19);
            this.mpTextToSpeakTextBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "%以下になったら読上げる";
            // 
            // MPThresholdTextBox
            // 
            this.MPThresholdTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MPThresholdTextBox.Location = new System.Drawing.Point(6, 28);
            this.MPThresholdTextBox.MaxLength = 3;
            this.MPThresholdTextBox.Name = "MPThresholdTextBox";
            this.MPThresholdTextBox.Size = new System.Drawing.Size(59, 19);
            this.MPThresholdTextBox.TabIndex = 9;
            this.MPThresholdTextBox.Text = "0";
            this.MPThresholdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // enableWatchMPCheckBox
            // 
            this.enableWatchMPCheckBox.AutoSize = true;
            this.enableWatchMPCheckBox.Location = new System.Drawing.Point(6, 6);
            this.enableWatchMPCheckBox.Name = "enableWatchMPCheckBox";
            this.enableWatchMPCheckBox.Size = new System.Drawing.Size(153, 16);
            this.enableWatchMPCheckBox.TabIndex = 8;
            this.enableWatchMPCheckBox.Text = "PartyのMP低下を監視する";
            this.enableWatchMPCheckBox.UseVisualStyleBackColor = true;
            // 
            // watchTPTabPage
            // 
            this.watchTPTabPage.Controls.Add(this.label10);
            this.watchTPTabPage.Controls.Add(this.watchTargetsTPCheckedListBox);
            this.watchTPTabPage.Controls.Add(this.textBox3);
            this.watchTPTabPage.Controls.Add(this.tpTextToSpeakTextBox);
            this.watchTPTabPage.Controls.Add(this.label5);
            this.watchTPTabPage.Controls.Add(this.TPThresholdTextBox);
            this.watchTPTabPage.Controls.Add(this.enableWatchTPCheckBox);
            this.watchTPTabPage.Location = new System.Drawing.Point(4, 22);
            this.watchTPTabPage.Name = "watchTPTabPage";
            this.watchTPTabPage.Size = new System.Drawing.Size(700, 455);
            this.watchTPTabPage.TabIndex = 2;
            this.watchTPTabPage.Text = "TP監視　　";
            this.watchTPTabPage.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "監視対象";
            // 
            // watchTargetsTPCheckedListBox
            // 
            this.watchTargetsTPCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.watchTargetsTPCheckedListBox.CheckOnClick = true;
            this.watchTargetsTPCheckedListBox.FormattingEnabled = true;
            this.watchTargetsTPCheckedListBox.Items.AddRange(new object[] {
            "自分自身",
            "ナイト・剣術士",
            "戦士・斧術士",
            "白魔道士・幻術士",
            "学者",
            "モンク・格闘士",
            "竜騎士・槍術士",
            "忍者・双剣士",
            "吟遊詩人・弓術士",
            "黒魔道士・呪術士",
            "召喚士・巴術士",
            "ギャザラー・クラフター",
            "機工士",
            "暗黒騎士",
            "占星術師"});
            this.watchTargetsTPCheckedListBox.Location = new System.Drawing.Point(6, 101);
            this.watchTargetsTPCheckedListBox.Name = "watchTargetsTPCheckedListBox";
            this.watchTargetsTPCheckedListBox.Size = new System.Drawing.Size(405, 336);
            this.watchTargetsTPCheckedListBox.TabIndex = 20;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Window;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox3.Location = new System.Drawing.Point(417, 6);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(280, 242);
            this.textBox3.TabIndex = 17;
            this.textBox3.TabStop = false;
            this.textBox3.Text = resources.GetString("textBox3.Text");
            // 
            // tpTextToSpeakTextBox
            // 
            this.tpTextToSpeakTextBox.Location = new System.Drawing.Point(6, 53);
            this.tpTextToSpeakTextBox.Name = "tpTextToSpeakTextBox";
            this.tpTextToSpeakTextBox.Size = new System.Drawing.Size(405, 19);
            this.tpTextToSpeakTextBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "%以下になったら読上げる";
            // 
            // TPThresholdTextBox
            // 
            this.TPThresholdTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TPThresholdTextBox.Location = new System.Drawing.Point(6, 28);
            this.TPThresholdTextBox.MaxLength = 3;
            this.TPThresholdTextBox.Name = "TPThresholdTextBox";
            this.TPThresholdTextBox.Size = new System.Drawing.Size(59, 19);
            this.TPThresholdTextBox.TabIndex = 11;
            this.TPThresholdTextBox.Text = "0";
            this.TPThresholdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // enableWatchTPCheckBox
            // 
            this.enableWatchTPCheckBox.AutoSize = true;
            this.enableWatchTPCheckBox.Location = new System.Drawing.Point(6, 6);
            this.enableWatchTPCheckBox.Name = "enableWatchTPCheckBox";
            this.enableWatchTPCheckBox.Size = new System.Drawing.Size(151, 16);
            this.enableWatchTPCheckBox.TabIndex = 10;
            this.enableWatchTPCheckBox.Text = "PartyのTP低下を監視する";
            this.enableWatchTPCheckBox.UseVisualStyleBackColor = true;
            // 
            // saiseiDeviceGroupBox
            // 
            this.saiseiDeviceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saiseiDeviceGroupBox.Controls.Add(this.PlayerComboBox);
            this.saiseiDeviceGroupBox.Controls.Add(this.label12);
            this.saiseiDeviceGroupBox.Controls.Add(this.enabledSubDeviceCheckBox);
            this.saiseiDeviceGroupBox.Controls.Add(this.subDeviceComboBox);
            this.saiseiDeviceGroupBox.Controls.Add(this.label6);
            this.saiseiDeviceGroupBox.Controls.Add(this.mainDeviceComboBox);
            this.saiseiDeviceGroupBox.Controls.Add(this.label7);
            this.saiseiDeviceGroupBox.Location = new System.Drawing.Point(474, 3);
            this.saiseiDeviceGroupBox.Name = "saiseiDeviceGroupBox";
            this.saiseiDeviceGroupBox.Size = new System.Drawing.Size(720, 117);
            this.saiseiDeviceGroupBox.TabIndex = 4;
            this.saiseiDeviceGroupBox.TabStop = false;
            this.saiseiDeviceGroupBox.Text = "再生デバイス";
            // 
            // PlayerComboBox
            // 
            this.PlayerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlayerComboBox.FormattingEnabled = true;
            this.PlayerComboBox.Location = new System.Drawing.Point(105, 14);
            this.PlayerComboBox.Name = "PlayerComboBox";
            this.PlayerComboBox.Size = new System.Drawing.Size(306, 20);
            this.PlayerComboBox.TabIndex = 0;
            this.ToolTip.SetToolTip(this.PlayerComboBox, "WaveOut → 遅延(中), 音質(中) Windowsの伝統的なAPIで再生します。\r\nDirectSound → 遅延(小), 音質(低)\r\nWASAPI" +
        " → 遅延(小), 音質(中+) Windows7以降の新APIで再生します。オススメ\r\nASIO → 遅延(小), 音質(高) ASIO対応の高級デバイスでの" +
        "み動作します\r\n");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "再生方式";
            this.ToolTip.SetToolTip(this.label12, "WaveOut → 遅延(中), 音質(中) Windowsの伝統的なAPIで再生します。\r\nDirectSound → 遅延(小), 音質(低)\r\nWASAPI" +
        " → 遅延(小), 音質(中+) Windows7以降の新APIで再生します。オススメ\r\nASIO → 遅延(小), 音質(高) ASIO対応の高級デバイスでの" +
        "み動作します\r\n");
            // 
            // enabledSubDeviceCheckBox
            // 
            this.enabledSubDeviceCheckBox.AutoSize = true;
            this.enabledSubDeviceCheckBox.Location = new System.Drawing.Point(8, 68);
            this.enabledSubDeviceCheckBox.Name = "enabledSubDeviceCheckBox";
            this.enabledSubDeviceCheckBox.Size = new System.Drawing.Size(166, 16);
            this.enabledSubDeviceCheckBox.TabIndex = 2;
            this.enabledSubDeviceCheckBox.Text = "サブ再生デバイスを有効にする";
            this.enabledSubDeviceCheckBox.UseVisualStyleBackColor = true;
            // 
            // subDeviceComboBox
            // 
            this.subDeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subDeviceComboBox.FormattingEnabled = true;
            this.subDeviceComboBox.Location = new System.Drawing.Point(105, 86);
            this.subDeviceComboBox.Name = "subDeviceComboBox";
            this.subDeviceComboBox.Size = new System.Drawing.Size(306, 20);
            this.subDeviceComboBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "サブ再生デバイス";
            // 
            // mainDeviceComboBox
            // 
            this.mainDeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mainDeviceComboBox.FormattingEnabled = true;
            this.mainDeviceComboBox.Location = new System.Drawing.Point(105, 40);
            this.mainDeviceComboBox.Name = "mainDeviceComboBox";
            this.mainDeviceComboBox.Size = new System.Drawing.Size(306, 20);
            this.mainDeviceComboBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "メイン再生デバイス";
            // 
            // WaveVolTrackBar
            // 
            this.WaveVolTrackBar.LargeChange = 10;
            this.WaveVolTrackBar.Location = new System.Drawing.Point(404, 23);
            this.WaveVolTrackBar.Maximum = 100;
            this.WaveVolTrackBar.Name = "WaveVolTrackBar";
            this.WaveVolTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.WaveVolTrackBar.Size = new System.Drawing.Size(45, 93);
            this.WaveVolTrackBar.TabIndex = 2;
            this.WaveVolTrackBar.TickFrequency = 10;
            this.WaveVolTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ToolTip.SetToolTip(this.WaveVolTrackBar, "外部から呼び出した時のwaveサウンドの再生ボリュームです\r\nTTSの音量設定は各種「TTSの設定」から調整してください");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(386, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 12);
            this.label11.TabIndex = 23;
            this.label11.Text = "waveボリューム";
            // 
            // ToolTip
            // 
            this.ToolTip.IsBalloon = true;
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // WaveCacheClearCheckBox
            // 
            this.WaveCacheClearCheckBox.AutoSize = true;
            this.WaveCacheClearCheckBox.Location = new System.Drawing.Point(5, 89);
            this.WaveCacheClearCheckBox.Name = "WaveCacheClearCheckBox";
            this.WaveCacheClearCheckBox.Size = new System.Drawing.Size(275, 16);
            this.WaveCacheClearCheckBox.TabIndex = 1;
            this.WaveCacheClearCheckBox.Text = "終了時にキャッシュしたTTS用waveファイルを削除する";
            this.WaveCacheClearCheckBox.UseVisualStyleBackColor = true;
            // 
            // TTSYukkuriConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WaveCacheClearCheckBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.saiseiDeviceGroupBox);
            this.Controls.Add(this.WaveVolTrackBar);
            this.Controls.Add(this.optionGroupBox);
            this.Controls.Add(this.ttsSettingsGroupBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ttsShuruiComboBox);
            this.Controls.Add(this.label1);
            this.Name = "TTSYukkuriConfigPanel";
            this.Size = new System.Drawing.Size(1201, 638);
            this.Load += new System.EventHandler(this.TTSYukkuriConfigPanel_Load);
            this.optionGroupBox.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.watchHPTabPage.ResumeLayout(false);
            this.watchHPTabPage.PerformLayout();
            this.watchMPTabPage.ResumeLayout(false);
            this.watchMPTabPage.PerformLayout();
            this.watchTPTabPage.ResumeLayout(false);
            this.watchTPTabPage.PerformLayout();
            this.saiseiDeviceGroupBox.ResumeLayout(false);
            this.saiseiDeviceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaveVolTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ttsShuruiComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox ttsSettingsGroupBox;
        private System.Windows.Forms.GroupBox optionGroupBox;
        private System.Windows.Forms.GroupBox saiseiDeviceGroupBox;
        private System.Windows.Forms.CheckBox enabledSubDeviceCheckBox;
        private System.Windows.Forms.ComboBox subDeviceComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox mainDeviceComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage watchHPTabPage;
        private System.Windows.Forms.TabPage watchMPTabPage;
        private System.Windows.Forms.TabPage watchTPTabPage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox hpTextToSpeakTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HPThresholdTextBox;
        private System.Windows.Forms.CheckBox enableWatchHPCheckBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox mpTextToSpeakTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MPThresholdTextBox;
        private System.Windows.Forms.CheckBox enableWatchMPCheckBox;
        private System.Windows.Forms.TextBox tpTextToSpeakTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TPThresholdTextBox;
        private System.Windows.Forms.CheckBox enableWatchTPCheckBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox watchTargetsHPCheckedListBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox watchTargetsMPCheckedListBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox watchTargetsTPCheckedListBox;
        private System.Windows.Forms.TrackBar WaveVolTrackBar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.CheckBox WaveCacheClearCheckBox;
        private System.Windows.Forms.ComboBox PlayerComboBox;
        private System.Windows.Forms.Label label12;
    }
}
