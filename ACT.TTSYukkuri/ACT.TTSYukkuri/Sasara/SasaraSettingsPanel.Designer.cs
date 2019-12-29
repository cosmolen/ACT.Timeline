namespace ACT.TTSYukkuri.Sasara
{
    partial class SasaraSettingsPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.kanjoDataGridView = new System.Windows.Forms.DataGridView();
            this.KanjoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AtaiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.castComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.onryoTextBox = new System.Windows.Forms.TextBox();
            this.hayasaTextBox = new System.Windows.Forms.TextBox();
            this.takasaTextBox = new System.Windows.Forms.TextBox();
            this.seishitsuTextBox = new System.Windows.Forms.TextBox();
            this.yokuyoTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kanjoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "キャスト";
            // 
            // kanjoDataGridView
            // 
            this.kanjoDataGridView.AllowUserToAddRows = false;
            this.kanjoDataGridView.AllowUserToDeleteRows = false;
            this.kanjoDataGridView.AllowUserToResizeColumns = false;
            this.kanjoDataGridView.AllowUserToResizeRows = false;
            this.kanjoDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kanjoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kanjoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KanjoColumn,
            this.AtaiColumn});
            this.kanjoDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.kanjoDataGridView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.kanjoDataGridView.Location = new System.Drawing.Point(49, 49);
            this.kanjoDataGridView.Name = "kanjoDataGridView";
            this.kanjoDataGridView.RowHeadersVisible = false;
            this.kanjoDataGridView.RowTemplate.Height = 21;
            this.kanjoDataGridView.Size = new System.Drawing.Size(296, 152);
            this.kanjoDataGridView.TabIndex = 1;
            this.kanjoDataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.kanjoDataGridView_CellValidated);
            this.kanjoDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.kanjoDataGridView_DataError);
            // 
            // KanjoColumn
            // 
            this.KanjoColumn.DataPropertyName = "Name";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.KanjoColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.KanjoColumn.HeaderText = "感情";
            this.KanjoColumn.MinimumWidth = 200;
            this.KanjoColumn.Name = "KanjoColumn";
            this.KanjoColumn.ReadOnly = true;
            this.KanjoColumn.Width = 200;
            // 
            // AtaiColumn
            // 
            this.AtaiColumn.DataPropertyName = "Value";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AtaiColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.AtaiColumn.HeaderText = "値";
            this.AtaiColumn.MaxInputLength = 3;
            this.AtaiColumn.MinimumWidth = 70;
            this.AtaiColumn.Name = "AtaiColumn";
            this.AtaiColumn.Width = 70;
            // 
            // castComboBox
            // 
            this.castComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.castComboBox.FormattingEnabled = true;
            this.castComboBox.Location = new System.Drawing.Point(49, 23);
            this.castComboBox.Name = "castComboBox";
            this.castComboBox.Size = new System.Drawing.Size(296, 20);
            this.castComboBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "音量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "早さ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "高さ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "声質";
            // 
            // onryoTextBox
            // 
            this.onryoTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.onryoTextBox.Location = new System.Drawing.Point(49, 207);
            this.onryoTextBox.MaxLength = 3;
            this.onryoTextBox.Name = "onryoTextBox";
            this.onryoTextBox.Size = new System.Drawing.Size(59, 19);
            this.onryoTextBox.TabIndex = 7;
            this.onryoTextBox.Text = "0";
            this.onryoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hayasaTextBox
            // 
            this.hayasaTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.hayasaTextBox.Location = new System.Drawing.Point(49, 232);
            this.hayasaTextBox.MaxLength = 3;
            this.hayasaTextBox.Name = "hayasaTextBox";
            this.hayasaTextBox.Size = new System.Drawing.Size(59, 19);
            this.hayasaTextBox.TabIndex = 8;
            this.hayasaTextBox.Text = "0";
            this.hayasaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // takasaTextBox
            // 
            this.takasaTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.takasaTextBox.Location = new System.Drawing.Point(49, 257);
            this.takasaTextBox.MaxLength = 3;
            this.takasaTextBox.Name = "takasaTextBox";
            this.takasaTextBox.Size = new System.Drawing.Size(59, 19);
            this.takasaTextBox.TabIndex = 9;
            this.takasaTextBox.Text = "0";
            this.takasaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // seishitsuTextBox
            // 
            this.seishitsuTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.seishitsuTextBox.Location = new System.Drawing.Point(49, 282);
            this.seishitsuTextBox.MaxLength = 3;
            this.seishitsuTextBox.Name = "seishitsuTextBox";
            this.seishitsuTextBox.Size = new System.Drawing.Size(59, 19);
            this.seishitsuTextBox.TabIndex = 10;
            this.seishitsuTextBox.Text = "0";
            this.seishitsuTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // yokuyoTextBox
            // 
            this.yokuyoTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.yokuyoTextBox.Location = new System.Drawing.Point(49, 307);
            this.yokuyoTextBox.MaxLength = 3;
            this.yokuyoTextBox.Name = "yokuyoTextBox";
            this.yokuyoTextBox.Size = new System.Drawing.Size(59, 19);
            this.yokuyoTextBox.TabIndex = 12;
            this.yokuyoTextBox.Text = "0";
            this.yokuyoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "抑揚";
            // 
            // SasaraSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.yokuyoTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.seishitsuTextBox);
            this.Controls.Add(this.takasaTextBox);
            this.Controls.Add(this.hayasaTextBox);
            this.Controls.Add(this.onryoTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.castComboBox);
            this.Controls.Add(this.kanjoDataGridView);
            this.Controls.Add(this.label1);
            this.Name = "SasaraSettingsPanel";
            this.Size = new System.Drawing.Size(368, 345);
            this.Load += new System.EventHandler(this.SasaraSettingsPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kanjoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView kanjoDataGridView;
        private System.Windows.Forms.ComboBox castComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox onryoTextBox;
        private System.Windows.Forms.TextBox hayasaTextBox;
        private System.Windows.Forms.TextBox takasaTextBox;
        private System.Windows.Forms.TextBox seishitsuTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn KanjoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AtaiColumn;
        private System.Windows.Forms.TextBox yokuyoTextBox;
        private System.Windows.Forms.Label label6;
    }
}
