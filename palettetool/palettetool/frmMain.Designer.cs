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
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnPalette = new System.Windows.Forms.Button();
			this.picIndexed = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictPicture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picPalette)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picIndexed)).BeginInit();
			this.SuspendLayout();
			// 
			// pictPicture
			// 
			this.pictPicture.BackColor = System.Drawing.Color.White;
			this.pictPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictPicture.Location = new System.Drawing.Point(12, 41);
			this.pictPicture.Name = "pictPicture";
			this.pictPicture.Size = new System.Drawing.Size(287, 384);
			this.pictPicture.TabIndex = 0;
			this.pictPicture.TabStop = false;
			// 
			// picPalette
			// 
			this.picPalette.BackColor = System.Drawing.Color.White;
			this.picPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picPalette.Location = new System.Drawing.Point(329, 41);
			this.picPalette.Name = "picPalette";
			this.picPalette.Size = new System.Drawing.Size(320, 32);
			this.picPalette.TabIndex = 1;
			this.picPalette.TabStop = false;
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(329, 78);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(75, 23);
			this.btnLoad.TabIndex = 2;
			this.btnLoad.Text = "読み込み";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnPalette
			// 
			this.btnPalette.Location = new System.Drawing.Point(410, 78);
			this.btnPalette.Name = "btnPalette";
			this.btnPalette.Size = new System.Drawing.Size(75, 23);
			this.btnPalette.TabIndex = 3;
			this.btnPalette.Text = "パレット抽出";
			this.btnPalette.UseVisualStyleBackColor = true;
			this.btnPalette.Click += new System.EventHandler(this.btnPalette_Click);
			// 
			// picIndexed
			// 
			this.picIndexed.BackColor = System.Drawing.Color.White;
			this.picIndexed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picIndexed.Location = new System.Drawing.Point(329, 188);
			this.picIndexed.Name = "picIndexed";
			this.picIndexed.Size = new System.Drawing.Size(287, 237);
			this.picIndexed.TabIndex = 4;
			this.picIndexed.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(325, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 22);
			this.label1.TabIndex = 5;
			this.label1.Text = "パレット";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.Location = new System.Drawing.Point(325, 164);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 22);
			this.label2.TabIndex = 6;
			this.label2.Text = "インデクス化";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label3.Location = new System.Drawing.Point(12, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 22);
			this.label3.TabIndex = 7;
			this.label3.Text = "元画像";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(491, 78);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 8;
			this.btnSave.Text = "保存";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(660, 438);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.picIndexed);
			this.Controls.Add(this.btnPalette);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.picPalette);
			this.Controls.Add(this.pictPicture);
			this.Name = "frmMain";
			this.Text = "パレットツール";
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictPicture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picPalette)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picIndexed)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictPicture;
        private System.Windows.Forms.PictureBox picPalette;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
	private System.Windows.Forms.Button btnLoad;
	private System.Windows.Forms.Button btnPalette;
	private System.Windows.Forms.PictureBox picIndexed;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Button btnSave;
    }
}

