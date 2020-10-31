namespace MakeSpriteFontCommandGenerator
{
    partial class frmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFontSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.txtFontName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFontSearch = new System.Windows.Forms.Button();
            this.txtUseString = new System.Windows.Forms.TextBox();
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCopyClipboard = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.chkLatin = new System.Windows.Forms.CheckBox();
            this.chkHiragana = new System.Windows.Forms.CheckBox();
            this.chkKatakana = new System.Windows.Forms.CheckBox();
            this.chkWideLatin = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOutFileName = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFontSize
            // 
            this.txtFontSize.DecimalPlaces = 2;
            this.txtFontSize.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtFontSize.Location = new System.Drawing.Point(615, 11);
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.Size = new System.Drawing.Size(120, 30);
            this.txtFontSize.TabIndex = 2;
            this.txtFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFontSize.Value = new decimal(new int[] {
            36,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(494, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "フォントサイズ";
            // 
            // fontDialog
            // 
            this.fontDialog.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.fontDialog.FontMustExist = true;
            this.fontDialog.Apply += new System.EventHandler(this.fontDialog_Apply);
            // 
            // txtFontName
            // 
            this.txtFontName.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtFontName.Location = new System.Drawing.Point(103, 11);
            this.txtFontName.Name = "txtFontName";
            this.txtFontName.ReadOnly = true;
            this.txtFontName.Size = new System.Drawing.Size(100, 30);
            this.txtFontName.TabIndex = 0;
            this.txtFontName.Text = "メイリオ";
            this.txtFontName.TextChanged += new System.EventHandler(this.txtFontName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "フォント名";
            // 
            // btnFontSearch
            // 
            this.btnFontSearch.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFontSearch.Location = new System.Drawing.Point(209, 11);
            this.btnFontSearch.Name = "btnFontSearch";
            this.btnFontSearch.Size = new System.Drawing.Size(122, 30);
            this.btnFontSearch.TabIndex = 1;
            this.btnFontSearch.Text = "フォント検索";
            this.btnFontSearch.UseVisualStyleBackColor = true;
            this.btnFontSearch.Click += new System.EventHandler(this.btnFontSearch_Click);
            // 
            // txtUseString
            // 
            this.txtUseString.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtUseString.Location = new System.Drawing.Point(16, 87);
            this.txtUseString.Multiline = true;
            this.txtUseString.Name = "txtUseString";
            this.txtUseString.Size = new System.Drawing.Size(1022, 211);
            this.txtUseString.TabIndex = 3;
            this.txtUseString.TextChanged += new System.EventHandler(this.txtUseString_TextChanged);
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtCommandLine.Location = new System.Drawing.Point(16, 335);
            this.txtCommandLine.Multiline = true;
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.ReadOnly = true;
            this.txtCommandLine.Size = new System.Drawing.Size(1022, 211);
            this.txtCommandLine.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "使用する文字列";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "コマンドライン";
            // 
            // btnCopyClipboard
            // 
            this.btnCopyClipboard.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCopyClipboard.Location = new System.Drawing.Point(836, 556);
            this.btnCopyClipboard.Name = "btnCopyClipboard";
            this.btnCopyClipboard.Size = new System.Drawing.Size(202, 30);
            this.btnCopyClipboard.TabIndex = 5;
            this.btnCopyClipboard.Text = "クリップボードへコピー";
            this.btnCopyClipboard.UseVisualStyleBackColor = true;
            this.btnCopyClipboard.Click += new System.EventHandler(this.btnCopyClipboard_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 556);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "デフォルト文字種：";
            // 
            // chkLatin
            // 
            this.chkLatin.AutoSize = true;
            this.chkLatin.Checked = true;
            this.chkLatin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLatin.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkLatin.ForeColor = System.Drawing.Color.White;
            this.chkLatin.Location = new System.Drawing.Point(155, 556);
            this.chkLatin.Name = "chkLatin";
            this.chkLatin.Size = new System.Drawing.Size(59, 27);
            this.chkLatin.TabIndex = 11;
            this.chkLatin.Text = "英数";
            this.chkLatin.UseVisualStyleBackColor = true;
            this.chkLatin.Click += new System.EventHandler(this.Checkbox_Click);
            // 
            // chkHiragana
            // 
            this.chkHiragana.AutoSize = true;
            this.chkHiragana.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkHiragana.ForeColor = System.Drawing.Color.White;
            this.chkHiragana.Location = new System.Drawing.Point(220, 556);
            this.chkHiragana.Name = "chkHiragana";
            this.chkHiragana.Size = new System.Drawing.Size(89, 27);
            this.chkHiragana.TabIndex = 12;
            this.chkHiragana.Text = "ひらがな";
            this.chkHiragana.UseVisualStyleBackColor = true;
            this.chkHiragana.Click += new System.EventHandler(this.Checkbox_Click);
            // 
            // chkKatakana
            // 
            this.chkKatakana.AutoSize = true;
            this.chkKatakana.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkKatakana.ForeColor = System.Drawing.Color.White;
            this.chkKatakana.Location = new System.Drawing.Point(315, 555);
            this.chkKatakana.Name = "chkKatakana";
            this.chkKatakana.Size = new System.Drawing.Size(89, 27);
            this.chkKatakana.TabIndex = 13;
            this.chkKatakana.Text = "カタカナ";
            this.chkKatakana.UseVisualStyleBackColor = true;
            this.chkKatakana.Click += new System.EventHandler(this.Checkbox_Click);
            // 
            // chkWideLatin
            // 
            this.chkWideLatin.AutoSize = true;
            this.chkWideLatin.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkWideLatin.ForeColor = System.Drawing.Color.White;
            this.chkWideLatin.Location = new System.Drawing.Point(410, 555);
            this.chkWideLatin.Name = "chkWideLatin";
            this.chkWideLatin.Size = new System.Drawing.Size(89, 27);
            this.chkWideLatin.TabIndex = 14;
            this.chkWideLatin.Text = "全角英数";
            this.chkWideLatin.UseVisualStyleBackColor = true;
            this.chkWideLatin.Click += new System.EventHandler(this.Checkbox_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(751, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 23);
            this.label6.TabIndex = 17;
            this.label6.Text = "出力ファイル名";
            // 
            // txtOutFileName
            // 
            this.txtOutFileName.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtOutFileName.Location = new System.Drawing.Point(872, 11);
            this.txtOutFileName.Name = "txtOutFileName";
            this.txtOutFileName.Size = new System.Drawing.Size(159, 30);
            this.txtOutFileName.TabIndex = 15;
            this.txtOutFileName.Text = "newfont.spritefont";
            this.txtOutFileName.TextChanged += new System.EventHandler(this.txtOutFileName_TextChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(505, 557);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 23);
            this.lblStatus.TabIndex = 18;
            // 
            // chkBold
            // 
            this.chkBold.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBold.AutoSize = true;
            this.chkBold.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkBold.Location = new System.Drawing.Point(337, 10);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(32, 34);
            this.chkBold.TabIndex = 19;
            this.chkBold.Text = "B";
            this.chkBold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBold.UseVisualStyleBackColor = true;
            this.chkBold.CheckedChanged += new System.EventHandler(this.chkBold_CheckedChanged);
            this.chkBold.Click += new System.EventHandler(this.FontCheckbox_Clicked);
            // 
            // chkItalic
            // 
            this.chkItalic.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkItalic.AutoSize = true;
            this.chkItalic.Font = new System.Drawing.Font("メイリオ", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkItalic.Location = new System.Drawing.Point(375, 10);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(28, 34);
            this.chkItalic.TabIndex = 20;
            this.chkItalic.Text = "I";
            this.chkItalic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkItalic.UseVisualStyleBackColor = true;
            this.chkItalic.CheckedChanged += new System.EventHandler(this.chkItalic_CheckedChanged);
            this.chkItalic.Click += new System.EventHandler(this.FontCheckbox_Clicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1050, 598);
            this.Controls.Add(this.chkItalic);
            this.Controls.Add(this.chkBold);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOutFileName);
            this.Controls.Add(this.chkWideLatin);
            this.Controls.Add(this.chkKatakana);
            this.Controls.Add(this.chkHiragana);
            this.Controls.Add(this.chkLatin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCopyClipboard);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCommandLine);
            this.Controls.Add(this.txtUseString);
            this.Controls.Add(this.btnFontSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFontName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFontSize);
            this.Name = "frmMain";
            this.Text = "MakeSpriteFontコマンドジェネレータ";
            ((System.ComponentModel.ISupportInitialize)(this.txtFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtFontSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.TextBox txtFontName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFontSearch;
        private System.Windows.Forms.TextBox txtUseString;
        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCopyClipboard;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkLatin;
        private System.Windows.Forms.CheckBox chkHiragana;
        private System.Windows.Forms.CheckBox chkKatakana;
        private System.Windows.Forms.CheckBox chkWideLatin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOutFileName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.CheckBox chkItalic;
    }
}

