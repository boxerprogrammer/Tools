namespace TexturePackerToEtcJson
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
            this.btnOpenOriginalJSON = new System.Windows.Forms.Button();
            this.btnOpenTexturePackerJSON = new System.Windows.Forms.Button();
            this.dlgOpenJSON = new System.Windows.Forms.OpenFileDialog();
            this.btnConvert = new System.Windows.Forms.Button();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.txtPrePath = new System.Windows.Forms.TextBox();
            this.lblPrePath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPackedImageDir = new System.Windows.Forms.TextBox();
            this.btnPackedImageFolder = new System.Windows.Forms.Button();
            this.dlgPackedImgFolder = new System.Windows.Forms.OpenFileDialog();
            this.txtBasePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBasePath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOpenOriginalJSON
            // 
            this.btnOpenOriginalJSON.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOpenOriginalJSON.Location = new System.Drawing.Point(104, 304);
            this.btnOpenOriginalJSON.Name = "btnOpenOriginalJSON";
            this.btnOpenOriginalJSON.Size = new System.Drawing.Size(123, 54);
            this.btnOpenOriginalJSON.TabIndex = 0;
            this.btnOpenOriginalJSON.Text = "元のJSONを開く";
            this.btnOpenOriginalJSON.UseVisualStyleBackColor = true;
            this.btnOpenOriginalJSON.Click += new System.EventHandler(this.btnOpenOriginalJSON_Click);
            // 
            // btnOpenTexturePackerJSON
            // 
            this.btnOpenTexturePackerJSON.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOpenTexturePackerJSON.Location = new System.Drawing.Point(328, 304);
            this.btnOpenTexturePackerJSON.Name = "btnOpenTexturePackerJSON";
            this.btnOpenTexturePackerJSON.Size = new System.Drawing.Size(123, 54);
            this.btnOpenTexturePackerJSON.TabIndex = 1;
            this.btnOpenTexturePackerJSON.Text = "TexturePackerのJSONを開く";
            this.btnOpenTexturePackerJSON.UseVisualStyleBackColor = true;
            this.btnOpenTexturePackerJSON.Click += new System.EventHandler(this.btnOpenTexturePackerJSON_Click);
            // 
            // dlgOpenJSON
            // 
            this.dlgOpenJSON.FileName = "openFileDialog1";
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnConvert.Location = new System.Drawing.Point(550, 304);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(123, 54);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "コンバート";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // dlgSave
            // 
            this.dlgSave.FileName = "_packed.json";
            this.dlgSave.Filter = "JSONファイル|*.json";
            // 
            // txtPrePath
            // 
            this.txtPrePath.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPrePath.Location = new System.Drawing.Point(173, 185);
            this.txtPrePath.Name = "txtPrePath";
            this.txtPrePath.Size = new System.Drawing.Size(141, 30);
            this.txtPrePath.TabIndex = 3;
            this.txtPrePath.Text = "gui2023";
            this.txtPrePath.TextChanged += new System.EventHandler(this.txtPrePath_TextChanged);
            // 
            // lblPrePath
            // 
            this.lblPrePath.AutoSize = true;
            this.lblPrePath.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPrePath.ForeColor = System.Drawing.Color.White;
            this.lblPrePath.Location = new System.Drawing.Point(67, 188);
            this.lblPrePath.Name = "lblPrePath";
            this.lblPrePath.Size = new System.Drawing.Size(100, 23);
            this.lblPrePath.TabIndex = 4;
            this.lblPrePath.Text = "付加プリパス";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(375, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "パック画像フォルダ";
            // 
            // txtPackedImageDir
            // 
            this.txtPackedImageDir.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPackedImageDir.Location = new System.Drawing.Point(526, 185);
            this.txtPackedImageDir.Name = "txtPackedImageDir";
            this.txtPackedImageDir.Size = new System.Drawing.Size(141, 30);
            this.txtPackedImageDir.TabIndex = 5;
            // 
            // btnPackedImageFolder
            // 
            this.btnPackedImageFolder.Image = global::TexturePackerToEtcJson.Properties.Resources.folderIcon;
            this.btnPackedImageFolder.Location = new System.Drawing.Point(673, 178);
            this.btnPackedImageFolder.Name = "btnPackedImageFolder";
            this.btnPackedImageFolder.Size = new System.Drawing.Size(55, 44);
            this.btnPackedImageFolder.TabIndex = 7;
            this.btnPackedImageFolder.UseVisualStyleBackColor = true;
            this.btnPackedImageFolder.Click += new System.EventHandler(this.btnPackedImageFolder_Click);
            // 
            // dlgPackedImgFolder
            // 
            this.dlgPackedImgFolder.CheckFileExists = false;
            this.dlgPackedImgFolder.FileName = "FileName";
            this.dlgPackedImgFolder.Filter = "Folder|.";
            // 
            // txtBasePath
            // 
            this.txtBasePath.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBasePath.Location = new System.Drawing.Point(173, 95);
            this.txtBasePath.Name = "txtBasePath";
            this.txtBasePath.Size = new System.Drawing.Size(141, 30);
            this.txtBasePath.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(67, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "ベースパス";
            // 
            // btnBasePath
            // 
            this.btnBasePath.Image = global::TexturePackerToEtcJson.Properties.Resources.folderIcon;
            this.btnBasePath.Location = new System.Drawing.Point(328, 88);
            this.btnBasePath.Name = "btnBasePath";
            this.btnBasePath.Size = new System.Drawing.Size(55, 44);
            this.btnBasePath.TabIndex = 10;
            this.btnBasePath.UseVisualStyleBackColor = true;
            this.btnBasePath.Click += new System.EventHandler(this.btnBasePath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(389, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(298, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "dataフォルダをベースパスにしてください";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBasePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBasePath);
            this.Controls.Add(this.btnPackedImageFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPackedImageDir);
            this.Controls.Add(this.lblPrePath);
            this.Controls.Add(this.txtPrePath);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnOpenTexturePackerJSON);
            this.Controls.Add(this.btnOpenOriginalJSON);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenOriginalJSON;
        private System.Windows.Forms.Button btnOpenTexturePackerJSON;
        private System.Windows.Forms.OpenFileDialog dlgOpenJSON;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.TextBox txtPrePath;
        private System.Windows.Forms.Label lblPrePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPackedImageDir;
        private System.Windows.Forms.Button btnPackedImageFolder;
        private System.Windows.Forms.OpenFileDialog dlgPackedImgFolder;
        private System.Windows.Forms.TextBox txtBasePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBasePath;
        private System.Windows.Forms.Label label3;
    }
}

