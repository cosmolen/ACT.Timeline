namespace ACT.TTSYukkuri.Boyomichan
{
    partial class BoyomiSettingPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BoyomiServerTextBox = new System.Windows.Forms.TextBox();
            this.BoyomiPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BoyomiPortNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "棒読みちゃんサーバ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "棒読みちゃんサーバのポート";
            // 
            // BoyomiServerTextBox
            // 
            this.BoyomiServerTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.BoyomiServerTextBox.Location = new System.Drawing.Point(157, 9);
            this.BoyomiServerTextBox.Name = "BoyomiServerTextBox";
            this.BoyomiServerTextBox.Size = new System.Drawing.Size(215, 19);
            this.BoyomiServerTextBox.TabIndex = 2;
            // 
            // BoyomiPortNumericUpDown
            // 
            this.BoyomiPortNumericUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.BoyomiPortNumericUpDown.Location = new System.Drawing.Point(157, 34);
            this.BoyomiPortNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.BoyomiPortNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BoyomiPortNumericUpDown.Name = "BoyomiPortNumericUpDown";
            this.BoyomiPortNumericUpDown.Size = new System.Drawing.Size(59, 19);
            this.BoyomiPortNumericUpDown.TabIndex = 3;
            this.BoyomiPortNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BoyomiPortNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "※意味がわからない人はデフォルトから変更しないように";
            // 
            // BoyomiSettingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BoyomiPortNumericUpDown);
            this.Controls.Add(this.BoyomiServerTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BoyomiSettingPanel";
            this.Size = new System.Drawing.Size(385, 98);
            ((System.ComponentModel.ISupportInitialize)(this.BoyomiPortNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BoyomiServerTextBox;
        private System.Windows.Forms.NumericUpDown BoyomiPortNumericUpDown;
        private System.Windows.Forms.Label label3;
    }
}
