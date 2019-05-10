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
            this.pictPicture.Location = new System.Drawing.Point(12, 12);
            this.pictPicture.Name = "pictPicture";
            this.pictPicture.Size = new System.Drawing.Size(287, 339);
            this.pictPicture.TabIndex = 0;
            this.pictPicture.TabStop = false;
            // 
            // picPalette
            // 
            this.picPalette.Location = new System.Drawing.Point(305, 12);
            this.picPalette.Name = "picPalette";
            this.picPalette.Size = new System.Drawing.Size(100, 50);
            this.picPalette.TabIndex = 1;
            this.picPalette.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 373);
            this.Controls.Add(this.picPalette);
            this.Controls.Add(this.pictPicture);
            this.Name = "frmMain";
            this.Text = "パレットツール";
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

