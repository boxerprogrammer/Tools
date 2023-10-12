namespace JsonToBinary
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
            this.btnLoadTexturePackerJSON = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.dlgOpenJSON = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnLoadTexturePackerJSON
            // 
            this.btnLoadTexturePackerJSON.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnLoadTexturePackerJSON.Location = new System.Drawing.Point(83, 340);
            this.btnLoadTexturePackerJSON.Name = "btnLoadTexturePackerJSON";
            this.btnLoadTexturePackerJSON.Size = new System.Drawing.Size(170, 60);
            this.btnLoadTexturePackerJSON.TabIndex = 0;
            this.btnLoadTexturePackerJSON.Text = "TexturePackerJSONをロード";
            this.btnLoadTexturePackerJSON.UseVisualStyleBackColor = true;
            this.btnLoadTexturePackerJSON.Click += new System.EventHandler(this.btnLoadTexturePackerJSON_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnConvert.Location = new System.Drawing.Point(519, 340);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(170, 60);
            this.btnConvert.TabIndex = 1;
            this.btnConvert.Text = "バイナリにコンバート";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // dlgOpenJSON
            // 
            this.dlgOpenJSON.FileName = "texture.json";
            this.dlgOpenJSON.Filter = "JSONファイル|*.json";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnLoadTexturePackerJSON);
            this.Name = "frmMain";
            this.Text = "JsonToBinary";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadTexturePackerJSON;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.OpenFileDialog dlgOpenJSON;
    }
}

