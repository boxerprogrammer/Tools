namespace ActionTool
{
    partial class frmImage
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImage));
			this.label1 = new System.Windows.Forms.Label();
			this.btnZoomIn = new System.Windows.Forms.Button();
			this.btnZoomOut = new System.Windows.Forms.Button();
			this.lblScale = new System.Windows.Forms.Label();
			this.btnReset = new System.Windows.Forms.Button();
			this.lblPosition = new System.Windows.Forms.Label();
			this.lblCutRect = new System.Windows.Forms.Label();
			this.btnCenterReset = new System.Windows.Forms.Button();
			this.btnCenterShrink = new System.Windows.Forms.Button();
			this.btnCenterExpand = new System.Windows.Forms.Button();
			this.btnAddFixCenter = new System.Windows.Forms.Button();
			this.panelCentered = new System.Windows.Forms.Panel();
			this.pictCenteredFilter = new System.Windows.Forms.PictureBox();
			this.pictCutImage = new System.Windows.Forms.PictureBox();
			this.btnLoadOriginal = new System.Windows.Forms.Button();
			this.imgList = new System.Windows.Forms.ImageList(this.components);
			this.listActions = new System.Windows.Forms.ListBox();
			this.mnuMain = new System.Windows.Forms.MenuStrip();
			this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuOpenProject = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSaveProject = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSaveNamedProjectFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuWriteBinary = new System.Windows.Forms.ToolStripMenuItem();
			this.インポートToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImportEdgeData = new System.Windows.Forms.ToolStripMenuItem();
			this.追加インポートToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuAppendEdgeData = new System.Windows.Forms.ToolStripMenuItem();
			this.元画像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuReadOriginalPicture = new System.Windows.Forms.ToolStripMenuItem();
			this.panellBack = new System.Windows.Forms.Panel();
			this.panelOriginal = new System.Windows.Forms.Panel();
			this.pictOriginalFilter = new System.Windows.Forms.PictureBox();
			this.pictOriginal = new System.Windows.Forms.PictureBox();
			this.pictOriginalBack = new System.Windows.Forms.PictureBox();
			this.txtActionName = new System.Windows.Forms.TextBox();
			this.saveProjectFile = new System.Windows.Forms.SaveFileDialog();
			this.openProjectFile = new System.Windows.Forms.OpenFileDialog();
			this.openOriginalPicture = new System.Windows.Forms.OpenFileDialog();
			this.label2 = new System.Windows.Forms.Label();
			this.lblCenterPos = new System.Windows.Forms.Label();
			this.lblCenterScale = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDuration = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.listPictures = new System.Windows.Forms.ListView();
			this.btnPreview = new System.Windows.Forms.Button();
			this.btnReEditRect = new System.Windows.Forms.Button();
			this.btnFinalizeAmendment = new System.Windows.Forms.Button();
			this.btnAmendFixCenter = new System.Windows.Forms.Button();
			this.btnDeleteFixCenter = new System.Windows.Forms.Button();
			this.listEditing = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.chkLoop = new System.Windows.Forms.CheckBox();
			this.timeBlink = new System.Windows.Forms.Timer(this.components);
			this.btnAddInfo = new System.Windows.Forms.Button();
			this.btnDeleteRect = new System.Windows.Forms.Button();
			this.btnCut = new System.Windows.Forms.Button();
			this.btnDisposeOriginalPicture = new System.Windows.Forms.Button();
			this.openEdgeFile = new System.Windows.Forms.OpenFileDialog();
			this.panelCentered.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictCenteredFilter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictCutImage)).BeginInit();
			this.mnuMain.SuspendLayout();
			this.panellBack.SuspendLayout();
			this.panelOriginal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictOriginalFilter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictOriginal)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictOriginalBack)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDuration)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(14, 541);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "元画像";
			// 
			// btnZoomIn
			// 
			this.btnZoomIn.BackColor = System.Drawing.Color.DimGray;
			this.btnZoomIn.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnZoomIn.ForeColor = System.Drawing.Color.White;
			this.btnZoomIn.Location = new System.Drawing.Point(15, 584);
			this.btnZoomIn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnZoomIn.Name = "btnZoomIn";
			this.btnZoomIn.Size = new System.Drawing.Size(134, 34);
			this.btnZoomIn.TabIndex = 3;
			this.btnZoomIn.Text = "拡大";
			this.btnZoomIn.UseVisualStyleBackColor = false;
			this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
			// 
			// btnZoomOut
			// 
			this.btnZoomOut.BackColor = System.Drawing.Color.DimGray;
			this.btnZoomOut.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnZoomOut.ForeColor = System.Drawing.Color.White;
			this.btnZoomOut.Location = new System.Drawing.Point(167, 584);
			this.btnZoomOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnZoomOut.Name = "btnZoomOut";
			this.btnZoomOut.Size = new System.Drawing.Size(134, 34);
			this.btnZoomOut.TabIndex = 4;
			this.btnZoomOut.Text = "縮小";
			this.btnZoomOut.UseVisualStyleBackColor = false;
			this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
			// 
			// lblScale
			// 
			this.lblScale.AutoSize = true;
			this.lblScale.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblScale.ForeColor = System.Drawing.Color.White;
			this.lblScale.Location = new System.Drawing.Point(78, 541);
			this.lblScale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblScale.Name = "lblScale";
			this.lblScale.Size = new System.Drawing.Size(87, 17);
			this.lblScale.TabIndex = 5;
			this.lblScale.Text = "倍率=100%";
			// 
			// btnReset
			// 
			this.btnReset.BackColor = System.Drawing.Color.DimGray;
			this.btnReset.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnReset.ForeColor = System.Drawing.Color.White;
			this.btnReset.Location = new System.Drawing.Point(317, 584);
			this.btnReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(134, 34);
			this.btnReset.TabIndex = 6;
			this.btnReset.Text = "倍率リセット";
			this.btnReset.UseVisualStyleBackColor = false;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// lblPosition
			// 
			this.lblPosition.AutoSize = true;
			this.lblPosition.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblPosition.ForeColor = System.Drawing.Color.White;
			this.lblPosition.Location = new System.Drawing.Point(164, 541);
			this.lblPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblPosition.Name = "lblPosition";
			this.lblPosition.Size = new System.Drawing.Size(79, 17);
			this.lblPosition.TabIndex = 7;
			this.lblPosition.Text = "X=0 , Y=0";
			// 
			// lblCutRect
			// 
			this.lblCutRect.AutoSize = true;
			this.lblCutRect.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblCutRect.ForeColor = System.Drawing.Color.White;
			this.lblCutRect.Location = new System.Drawing.Point(14, 561);
			this.lblCutRect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblCutRect.Name = "lblCutRect";
			this.lblCutRect.Size = new System.Drawing.Size(71, 17);
			this.lblCutRect.TabIndex = 8;
			this.lblCutRect.Text = "切抜矩形=";
			// 
			// btnCenterReset
			// 
			this.btnCenterReset.BackColor = System.Drawing.Color.DimGray;
			this.btnCenterReset.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnCenterReset.ForeColor = System.Drawing.Color.White;
			this.btnCenterReset.Location = new System.Drawing.Point(673, 312);
			this.btnCenterReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnCenterReset.Name = "btnCenterReset";
			this.btnCenterReset.Size = new System.Drawing.Size(87, 34);
			this.btnCenterReset.TabIndex = 19;
			this.btnCenterReset.Text = "倍率ﾘｾｯﾄ";
			this.btnCenterReset.UseVisualStyleBackColor = false;
			this.btnCenterReset.Click += new System.EventHandler(this.btnCenterReset_Click);
			// 
			// btnCenterShrink
			// 
			this.btnCenterShrink.BackColor = System.Drawing.Color.DimGray;
			this.btnCenterShrink.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnCenterShrink.ForeColor = System.Drawing.Color.White;
			this.btnCenterShrink.Location = new System.Drawing.Point(611, 312);
			this.btnCenterShrink.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnCenterShrink.Name = "btnCenterShrink";
			this.btnCenterShrink.Size = new System.Drawing.Size(58, 34);
			this.btnCenterShrink.TabIndex = 18;
			this.btnCenterShrink.Text = "縮小";
			this.btnCenterShrink.UseVisualStyleBackColor = false;
			this.btnCenterShrink.Click += new System.EventHandler(this.btnCenterShrink_Click);
			// 
			// btnCenterExpand
			// 
			this.btnCenterExpand.BackColor = System.Drawing.Color.DimGray;
			this.btnCenterExpand.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnCenterExpand.ForeColor = System.Drawing.Color.White;
			this.btnCenterExpand.Location = new System.Drawing.Point(539, 312);
			this.btnCenterExpand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnCenterExpand.Name = "btnCenterExpand";
			this.btnCenterExpand.Size = new System.Drawing.Size(68, 34);
			this.btnCenterExpand.TabIndex = 17;
			this.btnCenterExpand.Text = "拡大";
			this.btnCenterExpand.UseVisualStyleBackColor = false;
			this.btnCenterExpand.Click += new System.EventHandler(this.btnCenterExpand_Click);
			// 
			// btnAddFixCenter
			// 
			this.btnAddFixCenter.BackColor = System.Drawing.Color.DimGray;
			this.btnAddFixCenter.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnAddFixCenter.ForeColor = System.Drawing.Color.White;
			this.btnAddFixCenter.Location = new System.Drawing.Point(759, 404);
			this.btnAddFixCenter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnAddFixCenter.Name = "btnAddFixCenter";
			this.btnAddFixCenter.Size = new System.Drawing.Size(85, 34);
			this.btnAddFixCenter.TabIndex = 20;
			this.btnAddFixCenter.Text = "追加登録";
			this.btnAddFixCenter.UseVisualStyleBackColor = false;
			this.btnAddFixCenter.Click += new System.EventHandler(this.btnAddFixCenter_Click);
			// 
			// panelCentered
			// 
			this.panelCentered.AutoScroll = true;
			this.panelCentered.BackColor = System.Drawing.Color.Gainsboro;
			this.panelCentered.Controls.Add(this.pictCenteredFilter);
			this.panelCentered.Controls.Add(this.pictCutImage);
			this.panelCentered.Location = new System.Drawing.Point(539, 50);
			this.panelCentered.Name = "panelCentered";
			this.panelCentered.Size = new System.Drawing.Size(315, 257);
			this.panelCentered.TabIndex = 21;
			this.panelCentered.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelCentered_Scroll);
			// 
			// pictCenteredFilter
			// 
			this.pictCenteredFilter.BackColor = System.Drawing.Color.DimGray;
			this.pictCenteredFilter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictCenteredFilter.Location = new System.Drawing.Point(0, 0);
			this.pictCenteredFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pictCenteredFilter.Name = "pictCenteredFilter";
			this.pictCenteredFilter.Size = new System.Drawing.Size(305, 258);
			this.pictCenteredFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictCenteredFilter.TabIndex = 23;
			this.pictCenteredFilter.TabStop = false;
			this.pictCenteredFilter.Click += new System.EventHandler(this.pictCenteredFilter_Click);
			this.pictCenteredFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictCenteredFilter_MouseDown);
			this.pictCenteredFilter.MouseEnter += new System.EventHandler(this.pictCenteredFilter_MouseEnter);
			this.pictCenteredFilter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictCenteredFilter_MouseMove);
			this.pictCenteredFilter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictCenteredFilter_MouseUp);
			this.pictCenteredFilter.Resize += new System.EventHandler(this.pictCenteredFilter_Resize);
			// 
			// pictCutImage
			// 
			this.pictCutImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictCutImage.Location = new System.Drawing.Point(0, 0);
			this.pictCutImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pictCutImage.Name = "pictCutImage";
			this.pictCutImage.Size = new System.Drawing.Size(305, 258);
			this.pictCutImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictCutImage.TabIndex = 16;
			this.pictCutImage.TabStop = false;
			// 
			// btnLoadOriginal
			// 
			this.btnLoadOriginal.BackColor = System.Drawing.Color.DimGray;
			this.btnLoadOriginal.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnLoadOriginal.ForeColor = System.Drawing.Color.White;
			this.btnLoadOriginal.Location = new System.Drawing.Point(17, 631);
			this.btnLoadOriginal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnLoadOriginal.Name = "btnLoadOriginal";
			this.btnLoadOriginal.Size = new System.Drawing.Size(134, 34);
			this.btnLoadOriginal.TabIndex = 22;
			this.btnLoadOriginal.Text = "元画像読込";
			this.btnLoadOriginal.UseVisualStyleBackColor = false;
			this.btnLoadOriginal.Click += new System.EventHandler(this.btnLoadOriginal_Click);
			// 
			// imgList
			// 
			this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imgList.ImageSize = new System.Drawing.Size(40, 40);
			this.imgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// listActions
			// 
			this.listActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.listActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listActions.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.listActions.ForeColor = System.Drawing.Color.White;
			this.listActions.FormattingEnabled = true;
			this.listActions.ItemHeight = 19;
			this.listActions.Location = new System.Drawing.Point(539, 457);
			this.listActions.Name = "listActions";
			this.listActions.Size = new System.Drawing.Size(149, 173);
			this.listActions.TabIndex = 23;
			this.listActions.SelectedIndexChanged += new System.EventHandler(this.listActions_SelectedIndexChanged);
			// 
			// mnuMain
			// 
			this.mnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.元画像ToolStripMenuItem});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Size = new System.Drawing.Size(1024, 24);
			this.mnuMain.TabIndex = 24;
			this.mnuMain.Text = "menuStrip1";
			// 
			// ファイルToolStripMenuItem
			// 
			this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenProject,
            this.mnuSaveProject,
            this.mnuSaveNamedProjectFile,
            this.mnuWriteBinary,
            this.インポートToolStripMenuItem,
            this.追加インポートToolStripMenuItem});
			this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
			this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.ファイルToolStripMenuItem.Text = "ファイル";
			this.ファイルToolStripMenuItem.Click += new System.EventHandler(this.ファイルToolStripMenuItem_Click);
			// 
			// mnuOpenProject
			// 
			this.mnuOpenProject.Name = "mnuOpenProject";
			this.mnuOpenProject.Size = new System.Drawing.Size(180, 22);
			this.mnuOpenProject.Text = "プロジェクトを開く";
			this.mnuOpenProject.Click += new System.EventHandler(this.openProject_Click);
			// 
			// mnuSaveProject
			// 
			this.mnuSaveProject.Name = "mnuSaveProject";
			this.mnuSaveProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.mnuSaveProject.Size = new System.Drawing.Size(180, 22);
			this.mnuSaveProject.Text = "保存";
			this.mnuSaveProject.Click += new System.EventHandler(this.mnuSaveProject_Click);
			// 
			// mnuSaveNamedProjectFile
			// 
			this.mnuSaveNamedProjectFile.Name = "mnuSaveNamedProjectFile";
			this.mnuSaveNamedProjectFile.Size = new System.Drawing.Size(180, 22);
			this.mnuSaveNamedProjectFile.Text = "名前をつけて保存";
			this.mnuSaveNamedProjectFile.Click += new System.EventHandler(this.mnuSaveNamedProjectFile_Click);
			// 
			// mnuWriteBinary
			// 
			this.mnuWriteBinary.Name = "mnuWriteBinary";
			this.mnuWriteBinary.Size = new System.Drawing.Size(180, 22);
			this.mnuWriteBinary.Text = "バイナリ書き出し";
			this.mnuWriteBinary.Click += new System.EventHandler(this.mnuWriteBinary_Click);
			// 
			// インポートToolStripMenuItem
			// 
			this.インポートToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportEdgeData});
			this.インポートToolStripMenuItem.Name = "インポートToolStripMenuItem";
			this.インポートToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.インポートToolStripMenuItem.Text = "インポート";
			// 
			// mnuImportEdgeData
			// 
			this.mnuImportEdgeData.Name = "mnuImportEdgeData";
			this.mnuImportEdgeData.Size = new System.Drawing.Size(180, 22);
			this.mnuImportEdgeData.Text = "Edgeデータ";
			this.mnuImportEdgeData.Click += new System.EventHandler(this.mnuImportEdgeData_Click);
			// 
			// 追加インポートToolStripMenuItem
			// 
			this.追加インポートToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAppendEdgeData});
			this.追加インポートToolStripMenuItem.Name = "追加インポートToolStripMenuItem";
			this.追加インポートToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.追加インポートToolStripMenuItem.Text = "追加インポート";
			// 
			// mnuAppendEdgeData
			// 
			this.mnuAppendEdgeData.Name = "mnuAppendEdgeData";
			this.mnuAppendEdgeData.Size = new System.Drawing.Size(126, 22);
			this.mnuAppendEdgeData.Text = "Edgeデータ";
			this.mnuAppendEdgeData.Click += new System.EventHandler(this.mnuAppendEdgeData_Click);
			// 
			// 元画像ToolStripMenuItem
			// 
			this.元画像ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReadOriginalPicture});
			this.元画像ToolStripMenuItem.Name = "元画像ToolStripMenuItem";
			this.元画像ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.元画像ToolStripMenuItem.Text = "元画像";
			// 
			// mnuReadOriginalPicture
			// 
			this.mnuReadOriginalPicture.Name = "mnuReadOriginalPicture";
			this.mnuReadOriginalPicture.Size = new System.Drawing.Size(120, 22);
			this.mnuReadOriginalPicture.Text = "読み込み";
			this.mnuReadOriginalPicture.Click += new System.EventHandler(this.btnLoadOriginal_Click);
			// 
			// panellBack
			// 
			this.panellBack.AllowDrop = true;
			this.panellBack.Controls.Add(this.panelOriginal);
			this.panellBack.Controls.Add(this.pictOriginalBack);
			this.panellBack.Location = new System.Drawing.Point(12, 27);
			this.panellBack.Name = "panellBack";
			this.panellBack.Size = new System.Drawing.Size(493, 511);
			this.panellBack.TabIndex = 25;
			this.panellBack.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelOriginal_DragDrop);
			this.panellBack.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelOriginal_DragEnter);
			this.panellBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictOriginalFilter_MouseDown);
			this.panellBack.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictOriginalFilter_MouseMove);
			this.panellBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictOriginalFilter_MouseUp);
			// 
			// panelOriginal
			// 
			this.panelOriginal.AllowDrop = true;
			this.panelOriginal.AutoScroll = true;
			this.panelOriginal.BackColor = System.Drawing.Color.Transparent;
			this.panelOriginal.Controls.Add(this.pictOriginalFilter);
			this.panelOriginal.Controls.Add(this.pictOriginal);
			this.panelOriginal.Location = new System.Drawing.Point(0, 0);
			this.panelOriginal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.panelOriginal.Name = "panelOriginal";
			this.panelOriginal.Size = new System.Drawing.Size(491, 512);
			this.panelOriginal.TabIndex = 16;
			// 
			// pictOriginalFilter
			// 
			this.pictOriginalFilter.BackColor = System.Drawing.Color.Transparent;
			this.pictOriginalFilter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictOriginalFilter.Location = new System.Drawing.Point(0, 0);
			this.pictOriginalFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pictOriginalFilter.Name = "pictOriginalFilter";
			this.pictOriginalFilter.Size = new System.Drawing.Size(640, 640);
			this.pictOriginalFilter.TabIndex = 14;
			this.pictOriginalFilter.TabStop = false;
			this.pictOriginalFilter.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelOriginal_DragDrop);
			this.pictOriginalFilter.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelOriginal_DragEnter);
			this.pictOriginalFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictOriginalFilter_MouseDown);
			this.pictOriginalFilter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictOriginalFilter_MouseMove);
			this.pictOriginalFilter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictOriginalFilter_MouseUp);
			// 
			// pictOriginal
			// 
			this.pictOriginal.BackColor = System.Drawing.Color.Transparent;
			this.pictOriginal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictOriginal.Location = new System.Drawing.Point(0, 0);
			this.pictOriginal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pictOriginal.Name = "pictOriginal";
			this.pictOriginal.Size = new System.Drawing.Size(640, 640);
			this.pictOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictOriginal.TabIndex = 11;
			this.pictOriginal.TabStop = false;
			// 
			// pictOriginalBack
			// 
			this.pictOriginalBack.BackColor = System.Drawing.Color.Black;
			this.pictOriginalBack.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictOriginalBack.Location = new System.Drawing.Point(0, 0);
			this.pictOriginalBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pictOriginalBack.Name = "pictOriginalBack";
			this.pictOriginalBack.Size = new System.Drawing.Size(493, 511);
			this.pictOriginalBack.TabIndex = 15;
			this.pictOriginalBack.TabStop = false;
			// 
			// txtActionName
			// 
			this.txtActionName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtActionName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtActionName.ForeColor = System.Drawing.Color.White;
			this.txtActionName.Location = new System.Drawing.Point(644, 370);
			this.txtActionName.Name = "txtActionName";
			this.txtActionName.Size = new System.Drawing.Size(198, 23);
			this.txtActionName.TabIndex = 26;
			// 
			// saveProjectFile
			// 
			this.saveProjectFile.DefaultExt = "actproj";
			this.saveProjectFile.Filter = "アクションファイル|*.actproj";
			// 
			// openProjectFile
			// 
			this.openProjectFile.DefaultExt = "actproj";
			this.openProjectFile.Filter = "アクションファイル|*.actproj";
			// 
			// openOriginalPicture
			// 
			this.openOriginalPicture.Filter = "pngファイル|*.png|bmpファイル|*bmp";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(641, 353);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 17);
			this.label2.TabIndex = 28;
			this.label2.Text = "アクション名";
			// 
			// lblCenterPos
			// 
			this.lblCenterPos.AutoSize = true;
			this.lblCenterPos.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblCenterPos.ForeColor = System.Drawing.Color.White;
			this.lblCenterPos.Location = new System.Drawing.Point(713, 33);
			this.lblCenterPos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblCenterPos.Name = "lblCenterPos";
			this.lblCenterPos.Size = new System.Drawing.Size(79, 17);
			this.lblCenterPos.TabIndex = 30;
			this.lblCenterPos.Text = "X=0 , Y=0";
			// 
			// lblCenterScale
			// 
			this.lblCenterScale.AutoSize = true;
			this.lblCenterScale.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblCenterScale.ForeColor = System.Drawing.Color.White;
			this.lblCenterScale.Location = new System.Drawing.Point(627, 33);
			this.lblCenterScale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblCenterScale.Name = "lblCenterScale";
			this.lblCenterScale.Size = new System.Drawing.Size(87, 17);
			this.lblCenterScale.TabIndex = 29;
			this.lblCenterScale.Text = "倍率=100%";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(536, 33);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(60, 17);
			this.label5.TabIndex = 31;
			this.label5.Text = "切抜画像";
			// 
			// txtDuration
			// 
			this.txtDuration.BackColor = System.Drawing.Color.DimGray;
			this.txtDuration.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtDuration.ForeColor = System.Drawing.Color.White;
			this.txtDuration.Location = new System.Drawing.Point(580, 370);
			this.txtDuration.Name = "txtDuration";
			this.txtDuration.Size = new System.Drawing.Size(39, 22);
			this.txtDuration.TabIndex = 32;
			this.txtDuration.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(536, 353);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(75, 17);
			this.label6.TabIndex = 33;
			this.label6.Text = "継続フレーム";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(535, 440);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(89, 17);
			this.label7.TabIndex = 34;
			this.label7.Text = "アクションリスト";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label8.ForeColor = System.Drawing.Color.White;
			this.label8.Location = new System.Drawing.Point(693, 440);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(78, 17);
			this.label8.TabIndex = 35;
			this.label8.Text = "ピクチャリスト";
			// 
			// listPictures
			// 
			this.listPictures.BackColor = System.Drawing.Color.DimGray;
			this.listPictures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listPictures.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.listPictures.ForeColor = System.Drawing.Color.White;
			this.listPictures.GridLines = true;
			this.listPictures.LargeImageList = this.imgList;
			this.listPictures.Location = new System.Drawing.Point(696, 457);
			this.listPictures.MultiSelect = false;
			this.listPictures.Name = "listPictures";
			this.listPictures.Size = new System.Drawing.Size(148, 223);
			this.listPictures.SmallImageList = this.imgList;
			this.listPictures.StateImageList = this.imgList;
			this.listPictures.TabIndex = 36;
			this.listPictures.UseCompatibleStateImageBehavior = false;
			this.listPictures.SelectedIndexChanged += new System.EventHandler(this.listPictures_SelectedIndexChanged);
			// 
			// btnPreview
			// 
			this.btnPreview.BackColor = System.Drawing.Color.DimGray;
			this.btnPreview.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnPreview.ForeColor = System.Drawing.SystemColors.Window;
			this.btnPreview.Location = new System.Drawing.Point(696, 678);
			this.btnPreview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnPreview.Name = "btnPreview";
			this.btnPreview.Size = new System.Drawing.Size(148, 26);
			this.btnPreview.TabIndex = 38;
			this.btnPreview.Text = "プレビュー";
			this.btnPreview.UseVisualStyleBackColor = false;
			this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
			// 
			// btnReEditRect
			// 
			this.btnReEditRect.BackColor = System.Drawing.Color.DimGray;
			this.btnReEditRect.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnReEditRect.ForeColor = System.Drawing.Color.White;
			this.btnReEditRect.Location = new System.Drawing.Point(767, 312);
			this.btnReEditRect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnReEditRect.Name = "btnReEditRect";
			this.btnReEditRect.Size = new System.Drawing.Size(87, 34);
			this.btnReEditRect.TabIndex = 39;
			this.btnReEditRect.Text = "再切抜き";
			this.btnReEditRect.UseVisualStyleBackColor = false;
			this.btnReEditRect.Click += new System.EventHandler(this.btnReEditRect_Click);
			// 
			// btnFinalizeAmendment
			// 
			this.btnFinalizeAmendment.BackColor = System.Drawing.Color.DimGray;
			this.btnFinalizeAmendment.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnFinalizeAmendment.ForeColor = System.Drawing.Color.White;
			this.btnFinalizeAmendment.Location = new System.Drawing.Point(167, 631);
			this.btnFinalizeAmendment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnFinalizeAmendment.Name = "btnFinalizeAmendment";
			this.btnFinalizeAmendment.Size = new System.Drawing.Size(134, 34);
			this.btnFinalizeAmendment.TabIndex = 40;
			this.btnFinalizeAmendment.Text = "修正確定";
			this.btnFinalizeAmendment.UseVisualStyleBackColor = false;
			this.btnFinalizeAmendment.Visible = false;
			this.btnFinalizeAmendment.Click += new System.EventHandler(this.btnFinalizeAmendment_Click);
			// 
			// btnAmendFixCenter
			// 
			this.btnAmendFixCenter.BackColor = System.Drawing.Color.DimGray;
			this.btnAmendFixCenter.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnAmendFixCenter.ForeColor = System.Drawing.Color.White;
			this.btnAmendFixCenter.Location = new System.Drawing.Point(671, 404);
			this.btnAmendFixCenter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnAmendFixCenter.Name = "btnAmendFixCenter";
			this.btnAmendFixCenter.Size = new System.Drawing.Size(84, 34);
			this.btnAmendFixCenter.TabIndex = 42;
			this.btnAmendFixCenter.Text = "修正登録";
			this.btnAmendFixCenter.UseVisualStyleBackColor = false;
			this.btnAmendFixCenter.Click += new System.EventHandler(this.btnAmendFixCenter_Click);
			// 
			// btnDeleteFixCenter
			// 
			this.btnDeleteFixCenter.BackColor = System.Drawing.Color.DimGray;
			this.btnDeleteFixCenter.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnDeleteFixCenter.ForeColor = System.Drawing.Color.White;
			this.btnDeleteFixCenter.Location = new System.Drawing.Point(580, 404);
			this.btnDeleteFixCenter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnDeleteFixCenter.Name = "btnDeleteFixCenter";
			this.btnDeleteFixCenter.Size = new System.Drawing.Size(85, 34);
			this.btnDeleteFixCenter.TabIndex = 43;
			this.btnDeleteFixCenter.Text = "削除登録";
			this.btnDeleteFixCenter.UseVisualStyleBackColor = false;
			this.btnDeleteFixCenter.Click += new System.EventHandler(this.btnDeleteFixCenter_Click);
			// 
			// listEditing
			// 
			this.listEditing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.listEditing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listEditing.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.listEditing.ForeColor = System.Drawing.Color.White;
			this.listEditing.FormattingEnabled = true;
			this.listEditing.ItemHeight = 19;
			this.listEditing.Items.AddRange(new object[] {
            "中心点"});
			this.listEditing.Location = new System.Drawing.Point(862, 67);
			this.listEditing.Name = "listEditing";
			this.listEditing.Size = new System.Drawing.Size(120, 78);
			this.listEditing.TabIndex = 45;
			this.listEditing.SelectedIndexChanged += new System.EventHandler(this.listEditing_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(859, 50);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 17);
			this.label4.TabIndex = 46;
			this.label4.Text = "編集中";
			// 
			// chkLoop
			// 
			this.chkLoop.AutoSize = true;
			this.chkLoop.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.chkLoop.ForeColor = System.Drawing.Color.White;
			this.chkLoop.Location = new System.Drawing.Point(850, 647);
			this.chkLoop.Name = "chkLoop";
			this.chkLoop.Size = new System.Drawing.Size(115, 23);
			this.chkLoop.TabIndex = 47;
			this.chkLoop.Text = "ループアクション";
			this.chkLoop.UseVisualStyleBackColor = true;
			this.chkLoop.Click += new System.EventHandler(this.chkLoop_Click);
			// 
			// timeBlink
			// 
			this.timeBlink.Enabled = true;
			this.timeBlink.Interval = 150;
			this.timeBlink.Tick += new System.EventHandler(this.timeBlink_Tick);
			// 
			// btnAddInfo
			// 
			this.btnAddInfo.BackColor = System.Drawing.Color.DimGray;
			this.btnAddInfo.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnAddInfo.ForeColor = System.Drawing.Color.White;
			this.btnAddInfo.Location = new System.Drawing.Point(987, 67);
			this.btnAddInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnAddInfo.Name = "btnAddInfo";
			this.btnAddInfo.Size = new System.Drawing.Size(26, 56);
			this.btnAddInfo.TabIndex = 50;
			this.btnAddInfo.Text = "追加";
			this.btnAddInfo.UseVisualStyleBackColor = false;
			this.btnAddInfo.Click += new System.EventHandler(this.btnAddInfo_Click);
			// 
			// btnDeleteRect
			// 
			this.btnDeleteRect.BackColor = System.Drawing.Color.DimGray;
			this.btnDeleteRect.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnDeleteRect.ForeColor = System.Drawing.Color.White;
			this.btnDeleteRect.Location = new System.Drawing.Point(987, 127);
			this.btnDeleteRect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnDeleteRect.Name = "btnDeleteRect";
			this.btnDeleteRect.Size = new System.Drawing.Size(26, 58);
			this.btnDeleteRect.TabIndex = 51;
			this.btnDeleteRect.Text = "削除";
			this.btnDeleteRect.UseVisualStyleBackColor = false;
			this.btnDeleteRect.Click += new System.EventHandler(this.btnDeleteRect_Click);
			// 
			// btnCut
			// 
			this.btnCut.BackColor = System.Drawing.Color.DimGray;
			this.btnCut.Enabled = false;
			this.btnCut.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnCut.ForeColor = System.Drawing.Color.White;
			this.btnCut.Location = new System.Drawing.Point(167, 631);
			this.btnCut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnCut.Name = "btnCut";
			this.btnCut.Size = new System.Drawing.Size(134, 34);
			this.btnCut.TabIndex = 52;
			this.btnCut.Text = "切り抜き";
			this.btnCut.UseVisualStyleBackColor = false;
			this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
			// 
			// btnDisposeOriginalPicture
			// 
			this.btnDisposeOriginalPicture.BackColor = System.Drawing.Color.DimGray;
			this.btnDisposeOriginalPicture.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnDisposeOriginalPicture.ForeColor = System.Drawing.Color.White;
			this.btnDisposeOriginalPicture.Location = new System.Drawing.Point(17, 631);
			this.btnDisposeOriginalPicture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnDisposeOriginalPicture.Name = "btnDisposeOriginalPicture";
			this.btnDisposeOriginalPicture.Size = new System.Drawing.Size(134, 34);
			this.btnDisposeOriginalPicture.TabIndex = 53;
			this.btnDisposeOriginalPicture.Text = "元画像破棄";
			this.btnDisposeOriginalPicture.UseVisualStyleBackColor = false;
			// 
			// openEdgeFile
			// 
			this.openEdgeFile.DefaultExt = "anim";
			this.openEdgeFile.Filter = "anmファイル|*.anm";
			// 
			// frmImage
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1024, 715);
			this.Controls.Add(this.btnDisposeOriginalPicture);
			this.Controls.Add(this.btnCut);
			this.Controls.Add(this.btnDeleteRect);
			this.Controls.Add(this.btnAddInfo);
			this.Controls.Add(this.chkLoop);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.listEditing);
			this.Controls.Add(this.btnDeleteFixCenter);
			this.Controls.Add(this.btnAmendFixCenter);
			this.Controls.Add(this.btnFinalizeAmendment);
			this.Controls.Add(this.btnReEditRect);
			this.Controls.Add(this.btnPreview);
			this.Controls.Add(this.listPictures);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtDuration);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblCenterPos);
			this.Controls.Add(this.lblCenterScale);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtActionName);
			this.Controls.Add(this.panellBack);
			this.Controls.Add(this.listActions);
			this.Controls.Add(this.btnLoadOriginal);
			this.Controls.Add(this.panelCentered);
			this.Controls.Add(this.btnAddFixCenter);
			this.Controls.Add(this.btnCenterReset);
			this.Controls.Add(this.btnCenterShrink);
			this.Controls.Add(this.btnCenterExpand);
			this.Controls.Add(this.lblCutRect);
			this.Controls.Add(this.lblPosition);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.lblScale);
			this.Controls.Add(this.btnZoomOut);
			this.Controls.Add(this.btnZoomIn);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mnuMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mnuMain;
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "frmImage";
			this.Text = "切り抜き＆中心点ツール";
			this.Load += new System.EventHandler(this.frmImage_Load);
			this.panelCentered.ResumeLayout(false);
			this.panelCentered.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictCenteredFilter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictCutImage)).EndInit();
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.panellBack.ResumeLayout(false);
			this.panelOriginal.ResumeLayout(false);
			this.panelOriginal.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictOriginalFilter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictOriginal)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictOriginalBack)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDuration)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnZoomIn;
		private System.Windows.Forms.Button btnZoomOut;
		private System.Windows.Forms.Label lblScale;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Label lblPosition;
		private System.Windows.Forms.Label lblCutRect;
        private System.Windows.Forms.Button btnCenterReset;
        private System.Windows.Forms.Button btnCenterShrink;
        private System.Windows.Forms.Button btnCenterExpand;
        private System.Windows.Forms.Button btnAddFixCenter;
		private System.Windows.Forms.Panel panelCentered;
		private System.Windows.Forms.PictureBox pictCutImage;
		private System.Windows.Forms.Button btnLoadOriginal;
		private System.Windows.Forms.PictureBox pictCenteredFilter;
		private System.Windows.Forms.ImageList imgList;
		private System.Windows.Forms.ListBox listActions;
		private System.Windows.Forms.MenuStrip mnuMain;
		private System.Windows.Forms.Panel panellBack;
		private System.Windows.Forms.Panel panelOriginal;
		private System.Windows.Forms.PictureBox pictOriginalFilter;
		private System.Windows.Forms.PictureBox pictOriginal;
		private System.Windows.Forms.PictureBox pictOriginalBack;
		private System.Windows.Forms.TextBox txtActionName;
		private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuSaveProject;
		private System.Windows.Forms.SaveFileDialog saveProjectFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenProject;
        private System.Windows.Forms.OpenFileDialog openProjectFile;
		private System.Windows.Forms.ToolStripMenuItem mnuSaveNamedProjectFile;
		private System.Windows.Forms.ToolStripMenuItem 元画像ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuReadOriginalPicture;
		private System.Windows.Forms.OpenFileDialog openOriginalPicture;
		private System.Windows.Forms.ToolStripMenuItem mnuWriteBinary;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblCenterPos;
		private System.Windows.Forms.Label lblCenterScale;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown txtDuration;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ListView listPictures;
		private System.Windows.Forms.Button btnPreview;
		private System.Windows.Forms.Button btnReEditRect;
		private System.Windows.Forms.Button btnFinalizeAmendment;
		private System.Windows.Forms.Button btnAmendFixCenter;
		private System.Windows.Forms.Button btnDeleteFixCenter;
        private System.Windows.Forms.ListBox listEditing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkLoop;
		private System.Windows.Forms.Timer timeBlink;
		private System.Windows.Forms.Button btnAddInfo;
		private System.Windows.Forms.Button btnDeleteRect;
		private System.Windows.Forms.Button btnCut;
		private System.Windows.Forms.Button btnDisposeOriginalPicture;
        private System.Windows.Forms.ToolStripMenuItem インポートToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuImportEdgeData;
        private System.Windows.Forms.OpenFileDialog openEdgeFile;
        private System.Windows.Forms.ToolStripMenuItem 追加インポートToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAppendEdgeData;
    }
}

