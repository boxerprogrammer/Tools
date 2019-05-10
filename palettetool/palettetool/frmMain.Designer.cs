namespace palettetool
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
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            this.pictPicture = new System.Windows.Forms.PictureBox();
            this.picPalette = new System.Windows.Forms.PictureBox();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPalette)).BeginInit();
            this.SuspendLayout();
            // 
            // pictPicture
            // 
            this.pictPicture.Location = new System.Drawing.Point(16, 15);
            this.pictPicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictPicture.Name = "pictPicture";
            this.pictPicture.Size = new System.Drawing.Size(383, 424);
            this.pictPicture.TabIndex = 0;
            this.pictPicture.TabStop = false;
            // 
            // picPalette
            // 
            this.picPalette.Location = new System.Drawing.Point(407, 15);
            this.picPalette.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picPalette.Name = "picPalette";
            this.picPalette.Size = new System.Drawing.Size(133, 62);
            this.picPalette.TabIndex = 1;
            this.picPalette.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 466);
            this.Controls.Add(this.picPalette);
            this.Controls.Add(this.pictPicture);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.Text = "パレットツール";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPalette)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictPicture;
        private System.Windows.Forms.PictureBox picPalette;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
    }
}

