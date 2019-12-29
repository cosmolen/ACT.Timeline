namespace ACT.TTSYukkuri.OpenJTalk
{
    partial class OpenJTalkSettingsPanel
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
            this.VoiceComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GainTrackBar = new System.Windows.Forms.TrackBar();
            this.VolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.SpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.PitchTrackBar = new System.Windows.Forms.TrackBar();
            this.GainTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.VolumeTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PitchValueLabel = new System.Windows.Forms.Label();
            this.SpeedTextBox = new System.Windows.Forms.TextBox();
            this.PitchTextBox = new System.Windows.Forms.TextBox();
            this.DefaultButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GainTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PitchTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // VoiceComboBox
            // 
            this.VoiceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VoiceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VoiceComboBox.FormattingEnabled = true;
            this.VoiceComboBox.Location = new System.Drawing.Point(92, 22);
            this.VoiceComboBox.Name = "VoiceComboBox";
            this.VoiceComboBox.Size = new System.Drawing.Size(218, 20);
            this.VoiceComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Voice";
            // 
            // GainTrackBar
            // 
            this.GainTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GainTrackBar.LargeChange = 20;
            this.GainTrackBar.Location = new System.Drawing.Point(92, 60);
            this.GainTrackBar.Maximum = 400;
            this.GainTrackBar.Name = "GainTrackBar";
            this.GainTrackBar.Size = new System.Drawing.Size(218, 45);
            this.GainTrackBar.TabIndex = 1;
            this.GainTrackBar.TickFrequency = 20;
            this.GainTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GainTrackBar.Value = 200;
            // 
            // VolumeTrackBar
            // 
            this.VolumeTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeTrackBar.LargeChange = 10;
            this.VolumeTrackBar.Location = new System.Drawing.Point(92, 84);
            this.VolumeTrackBar.Maximum = 100;
            this.VolumeTrackBar.Name = "VolumeTrackBar";
            this.VolumeTrackBar.Size = new System.Drawing.Size(218, 45);
            this.VolumeTrackBar.TabIndex = 2;
            this.VolumeTrackBar.TickFrequency = 10;
            this.VolumeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VolumeTrackBar.Value = 100;
            // 
            // SpeedTrackBar
            // 
            this.SpeedTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpeedTrackBar.LargeChange = 20;
            this.SpeedTrackBar.Location = new System.Drawing.Point(92, 108);
            this.SpeedTrackBar.Maximum = 400;
            this.SpeedTrackBar.Minimum = 1;
            this.SpeedTrackBar.Name = "SpeedTrackBar";
            this.SpeedTrackBar.Size = new System.Drawing.Size(218, 45);
            this.SpeedTrackBar.TabIndex = 3;
            this.SpeedTrackBar.TickFrequency = 20;
            this.SpeedTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SpeedTrackBar.Value = 100;
            // 
            // PitchTrackBar
            // 
            this.PitchTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PitchTrackBar.LargeChange = 10;
            this.PitchTrackBar.Location = new System.Drawing.Point(92, 135);
            this.PitchTrackBar.Maximum = 100;
            this.PitchTrackBar.Minimum = -100;
            this.PitchTrackBar.Name = "PitchTrackBar";
            this.PitchTrackBar.Size = new System.Drawing.Size(218, 45);
            this.PitchTrackBar.TabIndex = 5;
            this.PitchTrackBar.TickFrequency = 10;
            this.PitchTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // GainTextBox
            // 
            this.GainTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.GainTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GainTextBox.Location = new System.Drawing.Point(61, 60);
            this.GainTextBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.GainTextBox.Name = "GainTextBox";
            this.GainTextBox.Size = new System.Drawing.Size(25, 12);
            this.GainTextBox.TabIndex = 10;
            this.GainTextBox.TabStop = false;
            this.GainTextBox.Text = "100";
            this.GainTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "増幅率";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "ボリューム";
            // 
            // VolumeTextBox
            // 
            this.VolumeTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.VolumeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VolumeTextBox.Location = new System.Drawing.Point(61, 84);
            this.VolumeTextBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.VolumeTextBox.Name = "VolumeTextBox";
            this.VolumeTextBox.Size = new System.Drawing.Size(25, 12);
            this.VolumeTextBox.TabIndex = 13;
            this.VolumeTextBox.TabStop = false;
            this.VolumeTextBox.Text = "100";
            this.VolumeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "スピード";
            // 
            // PitchValueLabel
            // 
            this.PitchValueLabel.AutoSize = true;
            this.PitchValueLabel.Location = new System.Drawing.Point(3, 132);
            this.PitchValueLabel.Name = "PitchValueLabel";
            this.PitchValueLabel.Size = new System.Drawing.Size(29, 12);
            this.PitchValueLabel.TabIndex = 15;
            this.PitchValueLabel.Text = "音程";
            // 
            // SpeedTextBox
            // 
            this.SpeedTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.SpeedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SpeedTextBox.Location = new System.Drawing.Point(61, 108);
            this.SpeedTextBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.SpeedTextBox.Name = "SpeedTextBox";
            this.SpeedTextBox.Size = new System.Drawing.Size(25, 12);
            this.SpeedTextBox.TabIndex = 16;
            this.SpeedTextBox.TabStop = false;
            this.SpeedTextBox.Text = "100";
            this.SpeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PitchTextBox
            // 
            this.PitchTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.PitchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PitchTextBox.Location = new System.Drawing.Point(61, 132);
            this.PitchTextBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.PitchTextBox.Name = "PitchTextBox";
            this.PitchTextBox.Size = new System.Drawing.Size(25, 12);
            this.PitchTextBox.TabIndex = 17;
            this.PitchTextBox.TabStop = false;
            this.PitchTextBox.Text = "100";
            this.PitchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DefaultButton
            // 
            this.DefaultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DefaultButton.Location = new System.Drawing.Point(5, 170);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(75, 23);
            this.DefaultButton.TabIndex = 6;
            this.DefaultButton.Text = "リセット";
            this.DefaultButton.UseVisualStyleBackColor = true;
            // 
            // OpenJTalkSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PitchTrackBar);
            this.Controls.Add(this.DefaultButton);
            this.Controls.Add(this.PitchTextBox);
            this.Controls.Add(this.SpeedTextBox);
            this.Controls.Add(this.PitchValueLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.VolumeTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GainTextBox);
            this.Controls.Add(this.SpeedTrackBar);
            this.Controls.Add(this.VolumeTrackBar);
            this.Controls.Add(this.GainTrackBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VoiceComboBox);
            this.Name = "OpenJTalkSettingsPanel";
            this.Size = new System.Drawing.Size(326, 199);
            ((System.ComponentModel.ISupportInitialize)(this.GainTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PitchTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox VoiceComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar GainTrackBar;
        private System.Windows.Forms.TrackBar VolumeTrackBar;
        private System.Windows.Forms.TrackBar SpeedTrackBar;
        private System.Windows.Forms.TrackBar PitchTrackBar;
        private System.Windows.Forms.TextBox GainTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox VolumeTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label PitchValueLabel;
        private System.Windows.Forms.TextBox SpeedTextBox;
        private System.Windows.Forms.TextBox PitchTextBox;
        private System.Windows.Forms.Button DefaultButton;
    }
}
