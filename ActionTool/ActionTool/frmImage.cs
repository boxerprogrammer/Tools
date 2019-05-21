using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using System.Text.RegularExpressions;//正規表現用
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;//プロジェクトシリアライズ用
using System.IO;

using System.Diagnostics;//デバッグ用


//C#メモ
//①foreachの時の変数は「読み取り専用」らしい

namespace ActionTool
{
	public partial class frmImage : Form
	{
		private bool _lineBlink = false;
		private const float _version = 1.01f;///このアクションツールのバージョン

		/// <summary>
		/// 追加情報種別
		/// </summary>
		public enum AdditiveInfoType
		{
			center,//中心
			anchor,//アンカー
			attack,//攻撃
			damage,//食らい
		};



		/// <summary>
		/// 矩形種別
		/// </summary>
		/// <remarks>
		/// enumの値が日本語となっていることに色々と言いたいことはあるかもしれないが
		/// リストから選択する部分などにToString()で表示しているため、意味があってやっている事
		/// と思ってください。
		/// </remarks>
		public enum RectType
		{
			無効,//0
			攻撃矩形,//攻撃
			食らい矩形,//食らい
			押当り矩形,//押し当たり矩形
		}


		/// <summary>
		/// 追加矩形
		/// </summary>
		/// <remarks>
		/// 矩形に矩形種別を追加したものです
		/// </remarks>
		[DataContract]
		struct ActionRect
		{
			public ActionRect(RectType inrt,Rectangle inrc)
			{
				rt = inrt;
				rc = inrc;
			}

			[DataMember(Name = "rectType")]
			public RectType rt;
			[DataMember(Name = "rect")]
			public Rectangle rc;
		}

		/// <summary>
		/// 現在編集中のアクション矩形
		/// </summary>
		List<ActionRect> _currentActionRects = new List<ActionRect>();

		//定数
		const uint MAX_SCALE = 800;
		const uint MIN_SCALE = 50;

		//オリジナル画像系
		string _originalFileName;
		Image _originalImage;///元画像保持用
		uint _originalImagePercentage = 100;///元画像表示比率(%)
		Point _cutBeginPos;///カット開始位置
		Bitmap _filterLayerBmp;///フィルターレイヤービットマップオブジェクト
		Rectangle _apprentCutRect;///切り取り矩形(切り取り用ピクチャの画面上での矩形→見かけ上の矩形)
		Rectangle _actualCutRect;///切り取り矩形の実寸のサイズ

		const float FULL_SCALE_PERCENTAGE = 100.0f;
		//中心点画像系
		uint _centeredImagePercentage = (int)FULL_SCALE_PERCENTAGE;///中心点画像倍率(%)
		Point _centerPos;///中心点位置 
		Image _centeredImage;///中心点画像保持用
		Bitmap _centeredFilterLayerBMP;///中心点系フィルターレイヤー用
		//追加矩形系
		Point _actionRectBeginPos;//矩形開始位置(攻撃矩形等用)
		
		//動作辻褄合わせ用
		private bool _isDraggingImageFilter = false;///イメージ上でマウスをドラッグ中と見なされるか？
		private bool _isMovingCutRect = false;///矩形平行移動中か？
		private Point _pointOfRectMoveStart = new Point(0, 0);///矩形の平行移動、拡縮のスタート地点
		private Point _floatingLastPoint = new Point(0, 0);///

		private bool _isHExpandingCutRect = false;///幅拡大中
		private bool _isVExpandingCutRect = false;///高さ拡大中

		private string _amendingActionName;///現在編集中のアクションファイル名
		private int _amendingPictureIndex;///現在編集中のピクチャインデックス

		Dictionary<RectType, Color> _rectColorTable=new Dictionary<RectType, Color>();


		//プロジェクト用
		/// <summary>
		/// 切り抜き情報
		/// </summary>
		[DataContract]
		struct CuttingInfo
		{
			[DataMember(Name = "cutrect")]
			public Rectangle cutRect;//切り抜き矩形
			[DataMember(Name = "center")]
			public Point center;//中心点
			[DataMember(Name = "duration")]
			public int duration;//継続時間
			[DataMember(Name = "addrects")]
			public List<ActionRect> addrects;
		}
		/// <summary>
		/// アクション情報
		/// </summary>
		[DataContract]
		struct ActionInfo
		{
			[DataMember(Name = "loop")]
			public bool isLoop;//ループアクションか？
			[DataMember(Name = "cuts")]
			public List<CuttingInfo> _cuts;//カット情報セット
		}
		//切り抜き情報テーブル
		Dictionary<string, ActionInfo> _cuttingTable = new Dictionary<string, ActionInfo>();

		/// <summary>
		/// プロジェクトとして保存する用
		/// </summary>
		[DataContract]
		class ProjectInfo
		{
			[DataMember(Name = "Version")]
			public readonly float version = _version;
			[DataMember(Name = "filename")]
			public string originalFileName { get; set; }//元ファイル名(複数に対応させるかも)
			[DataMember(Name = "cuttable")]
			public Dictionary<string, ActionInfo> cuttingTable { get; set; }//切り抜き情報テーブル
		}

		string _savedFileName = "";//読み込んだプロジェクトを「上書き保存」するために必要

		public frmImage()
		{
			InitializeComponent();
		}

		private void frmImage_Load(object sender, EventArgs e)
		{
            var asm = Assembly.GetExecutingAssembly();
            var asmname=asm.GetName();
            this.Text = this.Text+ ":" + asmname.Version.ToString();
			//オリジナル画像部分初期化
			InitializeForOriginalImage();
			//中心点設定部分初期化
			InitializeForCenteredImage();

			listEditing.SelectedIndex = 0;
			_rectColorTable[RectType.攻撃矩形] = Color.Red;
			_rectColorTable[RectType.食らい矩形] = Color.Green;
			_rectColorTable[RectType.押当り矩形] = Color.Blue;

		}

		/// <summary>
		/// 中心点設定部分初期化
		/// </summary>
		private void InitializeForCenteredImage()
		{
			pictCenteredFilter.Parent = pictCutImage;
			pictCenteredFilter.BackColor = Color.Transparent;
			pictCenteredFilter.Cursor = Cursors.Cross;
			//切り抜きの矩形とかを描画する用のレイヤー作成
			_centeredFilterLayerBMP = new Bitmap(pictCenteredFilter.Width, pictCenteredFilter.Height);
			Graphics g = Graphics.FromImage(_centeredFilterLayerBMP);
			//透明色で塗りつぶし
			g.FillRectangle(Brushes.White, 0, 0, _centeredFilterLayerBMP.Width, _centeredFilterLayerBMP.Height);
			_centeredFilterLayerBMP.MakeTransparent(Color.White);
			pictCenteredFilter.Image = _centeredFilterLayerBMP;
			g.Dispose();
		}

		/// <summary>
		/// オリジナル画像部分初期化
		/// </summary>
		private void InitializeForOriginalImage()
		{
			//切り抜きの矩形とかを描画する用のレイヤー作成
			CreatePictureAndImageForCutRect();

			//背面に市松模様を表示させるためのpictOriginalBackその他設定
			pictOriginal.Parent = panelOriginal;
			panelOriginal.Parent = pictOriginalBack;
			pictOriginalBack.Width = panelOriginal.Width;
			pictOriginalBack.Height = panelOriginal.Height;

			//市松模様描画
			CreateBackestForOriginalImage();
			((Control)pictOriginalFilter).AllowDrop = true;
		}

		/// <summary>
		/// 市松模様描画
		/// </summary>
		private void CreateBackestForOriginalImage()
		{
			HatchBrush hb = new HatchBrush(HatchStyle.LargeCheckerBoard, Color.LightGray, Color.White);
			Bitmap checker = new Bitmap(pictOriginalBack.Width, pictOriginalBack.Height);
			Graphics g = Graphics.FromImage(checker);
			g.FillRectangle(hb, 0, 0, pictOriginalBack.Width, pictOriginalBack.Height);
			pictOriginalBack.Image = checker;
			g.Dispose();
		}

		/// <summary>
		/// 切り抜きの矩形とかを描画する用のレイヤー作成
		/// </summary>
		private void CreatePictureAndImageForCutRect()
		{
			//切り抜きの矩形とかを描画する用のレイヤー作成
			_filterLayerBmp = new Bitmap(pictOriginalFilter.Width, pictOriginalFilter.Height);
			Graphics g = Graphics.FromImage(_filterLayerBmp);
			//透明色で塗りつぶし
			g.FillRectangle(Brushes.White, 0, 0, _filterLayerBmp.Width, _filterLayerBmp.Height);
			_filterLayerBmp.MakeTransparent(Color.White);
			pictOriginalFilter.Image = _filterLayerBmp;
			pictOriginalFilter.Parent = pictOriginal;
			g.Dispose();
		}


		/// <summary>
		/// 元の画像から、拡大縮小したイメージを返す
		/// </summary>
		/// <param name="inImage">イメージへの参照</param>
		/// <param name="scale">拡大率</param>
		/// <returns>拡大縮小済みのイメージ</returns>
		static public Image GetScaledImageFromImage(ref Image inImage, float scale)
		{
			Bitmap canvas = new Bitmap((int)(inImage.Width * scale), (int)(inImage.Height * scale));
			Graphics g = Graphics.FromImage(canvas);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			g.DrawImage(inImage, 0, 0, inImage.Width * scale, inImage.Height * scale);
			g.Dispose();
			return canvas;
		}

		/// <summary>
		/// オリジナル画像表示部分のリフレッシュ
		/// </summary>
		private void RefreshOriginalImage()
		{
			if (_originalImage == null) return;
			lblScale.Text = "倍率=" + _originalImagePercentage.ToString() + "%";
			float scale = (float)_originalImagePercentage / FULL_SCALE_PERCENTAGE;
			pictOriginal.Image.Dispose();
			pictOriginal.Image = GetScaledImageFromImage(ref _originalImage, scale);
		}

		/// <summary>
		/// オリジナル画像部分の拡大
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnZoomIn_Click(object sender, EventArgs e)
		{
			if (pictOriginal.Image == null) return;
			_originalImagePercentage = Math.Min(_originalImagePercentage + 50, MAX_SCALE);
			RefreshOriginalImage();


			pictOriginalFilter.Image.Dispose();
			Bitmap canvas = new Bitmap(pictOriginal.Image.Width, pictOriginal.Image.Height);

			Graphics g = Graphics.FromImage(canvas);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			g.Clear(Color.Transparent);
			g.Dispose();
			pictOriginalFilter.Image = canvas;
			//スケーリングを考慮した、オリジナル画像への矩形描画
			DrawCutRectToOriginalFilterLayerWithScale();

		}

		/// <summary>
		/// スケーリングを考慮した、オリジナル画像への矩形描画
		/// </summary>
		/// <param name="scale"></param>
		private void DrawCutRectToOriginalFilterLayerWithScale(bool blink=false)
		{
			float scale = (float)_originalImagePercentage / FULL_SCALE_PERCENTAGE;

			if (_actualCutRect != null)
			{
				_apprentCutRect = _actualCutRect;
			}
			_apprentCutRect.X = (int)(_apprentCutRect.X * scale);
			_apprentCutRect.Y = (int)(_apprentCutRect.Y * scale);
			_apprentCutRect.Width = (int)(_apprentCutRect.Width * scale);
			_apprentCutRect.Height = (int)(_apprentCutRect.Height * scale);
			DrawRectToOriginalFilterLayer(_apprentCutRect,blink);
		}

		/// <summary>
		/// オリジナル画像部分の縮小
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnZoomOut_Click(object sender, EventArgs e)
		{
			//スケール値変更
			_originalImagePercentage = Math.Max(_originalImagePercentage - 50, MIN_SCALE);

			//元画像の拡大表示
			RefreshOriginalImage();

			//スケーリングを考慮した、オリジナル画像への矩形描画
			DrawCutRectToOriginalFilterLayerWithScale();

		}

		/// <summary>
		/// オリジナル画像表示サイズリセット(100%に)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReset_Click(object sender, EventArgs e)
		{
			_originalImagePercentage = (uint)FULL_SCALE_PERCENTAGE;
			RefreshOriginalImage();

			//スケーリングを考慮した、オリジナル画像への矩形描画
			DrawCutRectToOriginalFilterLayerWithScale();
		}

		/// <summary>
		/// オリジナル画像のドラッグアンドドロップ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelOriginal_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				string[] filename = (string[])(e.Data.GetData(DataFormats.FileDrop));
				LoadOriginalPicture(filename[0]);
			}
		}

		/// <summary>
		/// 元画像のロード
		/// </summary>
		/// <param name="fileName">ファイル名</param>
		/// <returns>ロード成功/失敗</returns>
		private bool LoadOriginalPicture(string fileName)
		{
			if (!System.IO.File.Exists(fileName)) {
				return false;
			}
			_originalImage = Image.FromFile(fileName);
			pictOriginal.Image = (Image)_originalImage.Clone();
			_originalFileName = fileName;
			return true;
		}

		/// <summary>
		/// オリジナル画像へのドラッグの際にアイコンを書き換えてるだけ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panelOriginal_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				e.Effect = DragDropEffects.Copy;
			} else {
				e.Effect = DragDropEffects.None;
			}
		}

		/// <summary>
		/// オリジナル画像上で現在のカーソル位置を記録
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictOriginalFilter_MouseDown(object sender, MouseEventArgs e)
		{
			//画面外になるとめんどくさいので補正
			_cutBeginPos.X = Math.Max(e.Location.X, 0);
			_cutBeginPos.Y = Math.Max(e.Location.Y, 0);

			_isDraggingImageFilter = true;//矩形のためのドラッグ開始(生成、拡縮、移動)
			if (IsCurrentPositionHExpandableArea(e.Location)) {
				_isHExpandingCutRect = IsCurrentPositionHExpandableArea(e.Location);//幅拡大中
			} else if (IsCurrentPositionVExpandableArea(e.Location)) {
				_isVExpandingCutRect = IsCurrentPositionVExpandableArea(e.Location);//高拡大中
			} else if (IsCurrentPositionMovableArea(e.Location)) {
				_isMovingCutRect = IsCurrentPositionMovableArea(e.Location);//移動中
			} else {
				return;
			}
			_pointOfRectMoveStart = e.Location;//矩形移動、矩形拡縮の時のみ記録
		}

		/// <summary>
		/// 実際の切り取り矩形サイズを返す
		/// 現在の画面上の矩形から実際の矩形のサイズを返す
		/// </summary>
		/// <returns>拡大縮小を考慮に入れない矩形情報</returns>
		private Rectangle GetActualCutRect()
		{
			///パーセンテージを拡大率へ
			float scale = (float)_originalImagePercentage / FULL_SCALE_PERCENTAGE;
			Rectangle ret = new Rectangle();
			ret.X = (int)(_apprentCutRect.X / scale);
			ret.Y = (int)(_apprentCutRect.Y / scale);
			ret.Width = (int)(_apprentCutRect.Width / scale);
			ret.Height = (int)(_apprentCutRect.Height / scale);
			return ret;
		}

		/// <summary>
		/// 見た目上の矩形サイズを返す
		/// </summary>
		/// <returns>拡大縮小を考慮に入れない矩形情報</returns>
		private Rectangle GetCutRectOnPictureBox(Rectangle rc)
		{
			///パーセンテージを拡大率へ
			float scale = (float)_originalImagePercentage / FULL_SCALE_PERCENTAGE;
			Rectangle ret = new Rectangle();
			ret.X = (int)(rc.X * scale);
			ret.Y = (int)(rc.Y * scale);
			ret.Width = (int)(rc.Width * scale);
			ret.Height = (int)(rc.Height * scale);
			return ret;
		}

		/// <summary>
		/// オリジナル画像上でマウスを動かしたときの挙動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictOriginalFilter_MouseMove(object sender, MouseEventArgs e)
		{
			//現在位置をラベルに表示
			//そのまま行きたいところだが、ピクチャ画面が拡縮されている可能性が
			//あるため、事前に計算しておく
			Point p = e.Location;
			float scale = (float)_originalImagePercentage / FULL_SCALE_PERCENTAGE;
			p.X = Math.Max((int)(p.X / scale), 0);//0以下になると面倒な事になるので…
			p.Y = Math.Max((int)(p.Y / scale), 0);//0以下になると面倒な事になるので…
			lblPosition.Text = p.ToString();

			//ドラッグ中
			if (e.Button == MouseButtons.Left && _isDraggingImageFilter)
			{
				//横拡大縮小中
				if (_isHExpandingCutRect)
				{
					if (Math.Abs(_apprentCutRect.Right - e.Location.X) < Math.Abs(_apprentCutRect.Left - e.Location.X))
                    {//右側拡大縮小
                        ExpandRightSide(e);
                    }
                    else//左側拡大縮小
                    {
                        ExpandLeftSide(e);
                    }
                } else if (_isVExpandingCutRect) {//縦拡大縮小中
					if (Math.Abs(_apprentCutRect.Bottom - e.Location.Y) < Math.Abs(_apprentCutRect.Top - e.Location.Y))
                    {//下側拡大縮小
                        ExpandBottomSide(e);
                    }
                    else//上側拡大縮小
                    {
                        ExpandUpSide(e);
                    }
                }
				else if (_isMovingCutRect)
                {//平行移動中
                    TranslateCutRect(e);
                }
                else//矩形作成中
				{
					//ドラッグ中の矩形の作成と描画
					DrawDraggingRectForOriginal(e.Location);
					_actualCutRect = GetScaledRectangle( _apprentCutRect ,1.0f/scale);
					lblCutRect.Text = "切抜矩形=" + GetActualCutRect().ToString();
					return;
				}
				_apprentCutRect.X = (int)(Math.Round((float)_apprentCutRect.X / scale) * scale);
				_apprentCutRect.Y = (int)(Math.Round((float)_apprentCutRect.Y / scale) * scale);
				_apprentCutRect.Width = (int)(Math.Round((float)_apprentCutRect.Width / scale) * scale);
				_apprentCutRect.Height = (int)(Math.Round((float)_apprentCutRect.Height / scale) * scale);
				_actualCutRect = GetActualCutRect();
				DrawRectToOriginalFilterLayer(_apprentCutRect);
			}
			else
            {
                ChangeCursorBySituation(e);
            }
        }

        private void ChangeCursorBySituation(MouseEventArgs e)
        {
            //既に矩形があり、マウスが矩形編集範囲内に入っているならば
            if (_actualCutRect != null && _actualCutRect.Width > 0 && _actualCutRect.Height > 0)
            {
                //優先順位は横拡大＞縦拡大＞平行移動である。
                if (IsCurrentPositionHExpandableArea(e.Location))
                {
                    Cursor.Current = Cursors.SizeWE;
                }
                else if (IsCurrentPositionVExpandableArea(e.Location))
                {
                    Cursor.Current = Cursors.SizeNS;
                }
                else if (IsCurrentPositionMovableArea(e.Location))
                {
                    Cursor.Current = Cursors.SizeAll;//SizeWE
                }
            }
        }

        private void TranslateCutRect(MouseEventArgs e)
        {
            var delta = new Point(e.Location.X - _pointOfRectMoveStart.X, e.Location.Y - _pointOfRectMoveStart.Y);
            _pointOfRectMoveStart = e.Location;
            _apprentCutRect.X += delta.X;
            _apprentCutRect.Y += delta.Y;
        }

		/// <summary>
		/// 上側へ拡大縮小
		/// </summary>
		/// <param name="e"></param>
        private void ExpandUpSide(MouseEventArgs e)
        {
            var deltaY = e.Location.Y - _apprentCutRect.Top;
			
			_pointOfRectMoveStart = e.Location;
            _apprentCutRect.Y += deltaY;
            _apprentCutRect.Height -= deltaY;


		}

        private void ExpandBottomSide(MouseEventArgs e)
        {
            var deltaY = e.Location.Y - _apprentCutRect.Bottom;
            _pointOfRectMoveStart = e.Location;
            _apprentCutRect.Height += deltaY;
			
		}

        private void ExpandLeftSide(MouseEventArgs e)
        {
            var deltaX = e.Location.X - _apprentCutRect.Left;
            _pointOfRectMoveStart = e.Location;
            _apprentCutRect.X += deltaX;
            _apprentCutRect.Width -= deltaX;
        }

        private void ExpandRightSide(MouseEventArgs e)
        {
            var deltaX = e.Location.X - _apprentCutRect.Right;
            _pointOfRectMoveStart = e.Location;
            _apprentCutRect.Width += deltaX;
        }

        /// <summary>
        /// 現在のカーソル位置が、矩形平行移動可能座標ならば
        /// </summary>
        /// <param name="p">座標</param>
        /// <returns></returns>
        private bool IsCurrentPositionMovableArea(Point p)
		{
			var rc = GetCutRectOnPictureBox(_actualCutRect);
			if (p.X > rc.Left && p.X < rc.Right)
			{
				if (p.Y > rc.Top && p.Y < rc.Bottom)
				{
					return true;

				}
			}
			return false;
		}


        /// <summary>
        /// 現在座標は横方向に拡張可能な場所か？
        /// </summary>
        /// <param name="p">チェックしたい座標</param>
        /// <returns>拡張可能ならtrue、そうでないならfalse</returns>
        private bool IsCurrentPositionHExpandableArea(Point p)
		{
			var rc = GetCutRectOnPictureBox(_actualCutRect);
			if (p.Y > rc.Top && p.Y < rc.Bottom)
			{
				if (Math.Abs(rc.Right - p.X) <= 1 || Math.Abs(rc.Left - p.X) <= 1)
					return true;
			}
			return false;
		}

        /// <summary>
        /// 現在座標は縦方向に拡張可能な場所か？
        /// </summary>
        /// <param name="p">チェックしたい座標</param>
        /// <returns>拡張可能ならtrue、そうでないならfalse</returns>
		private bool IsCurrentPositionVExpandableArea(Point p)
		{
			var rc = GetCutRectOnPictureBox(_actualCutRect);
			if (p.X > rc.Left && p.X < rc.Right)
			{
				if (Math.Abs(rc.Top - p.Y) <= 1 || Math.Abs(rc.Bottom - p.Y) <= 1)
					return true;
			}
			return false;
		}

		/// <summary>
		/// ドラッグ中の矩形の作成と描画
		/// </summary>
		/// <param name="pos"></param>
		private void DrawDraggingRectForOriginal(Point pos)
		{
			Rectangle rc = CreateRectFor2Point(pos, _cutBeginPos);
			DrawRectToOriginalFilterLayer(rc);
			_apprentCutRect = rc;
		}

		/// <summary>
		/// 指定されたピクチャボックスに矩形を描画する
		/// </summary>
		/// <param name="pict">ピクチャオブジェクト</param>
		/// <param name="rc">矩形</param>
		/// <param name="pen">ペン</param>
		private void DrawRectToPictureObject(PictureBox pict, Rectangle rc, Pen pen,bool clearFlg=true)
		{
			if (pen == null) return;
			Graphics g = Graphics.FromImage(pict.Image);
			if (clearFlg)
			{
				g.Clear(Color.Transparent);
			}
			g.DrawRectangle(pen, rc);
			pict.Refresh();
			pen.Dispose();
			g.Dispose();
		}
		/// <summary>
		/// 指定されたピクチャボックスに矩形を描画する
		/// </summary>
		/// <param name="pict">ピクチャオブジェクト</param>
		/// <param name="rc">矩形</param>
		/// <param name="pen1">ペン①</param>
		/// <param name="pen2">ペン②</param>
		private void DrawRectToPictureObject(PictureBox pict, Rectangle rc, Pen pen1, Pen pen2,bool clearFlg=true)
		{
			Graphics g = Graphics.FromImage(pict.Image);
			if (clearFlg)
			{
				g.Clear(Color.Transparent);
			}
			g.DrawRectangle(pen1, rc);
			g.DrawRectangle(pen2, rc);

			pict.Refresh();

			pen1.Dispose();
			pen2.Dispose();

			g.Dispose();
		}

		/// <summary>
		/// 元画像レイヤーに矩形を描画
		/// </summary>
		/// <param name="rc"></param>
		private void DrawRectToOriginalFilterLayer(Rectangle rc, bool blink = false)
		{
			Pen pen = new Pen(Color.White, 2);
			Pen pen2 = (Pen)pen.Clone();
			pen2.Color = Color.Black;
			pen2.DashStyle = DashStyle.Dot;
			if (blink)
			{
				pen.Color = Color.Black;
				pen2.Color = Color.White;
			}
			DrawRectToPictureObject(pictOriginalFilter, rc, pen, pen2);
		}

        /// <summary>
        /// 2点の情報から矩形を生成する(2点あれば左上～右下がわかるため)
        /// </summary>
        /// <param name="pos1">点１</param>
        /// <param name="pos2">点２</param>
        /// <returns></returns>
		private static Rectangle CreateRectFor2Point(Point pos1, Point pos2)
		{
			//ドラッグにより形成される矩形を計算
			int px = Math.Max(0, pos1.X);
			int py = Math.Max(0, pos1.Y);
			int x = Math.Min(pos2.X, px);
			int y = Math.Min(pos2.Y, py);
			int w = Math.Abs(pos2.X - px);
			int h = Math.Abs(pos2.Y - py);
			if (w == 0 || h == 0) return new Rectangle();
			return new Rectangle(x, y, w, h);

		}


		private void pictOriginalFilter_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Location == _cutBeginPos)
			{
				ClearOriginalImageFilter();
			}

			if (_isHExpandingCutRect)
			{
				_isHExpandingCutRect = false;
			} else if (_isVExpandingCutRect) {
				_isVExpandingCutRect = false;
			} else if (_isMovingCutRect) {
				_isMovingCutRect = false;
			}
			else if (_isDraggingImageFilter)
			{
				_apprentCutRect = CreateRectFor2Point(e.Location, _cutBeginPos);
				_isDraggingImageFilter = false;
			}
			else
			{
				return;
			}
			_actualCutRect = GetActualCutRect();
			lblCutRect.Text = "切抜矩形=" + GetActualCutRect().ToString();
		}

		private void panelOriginal_Scroll(object sender, ScrollEventArgs e)
		{
			if (e.ScrollOrientation == ScrollOrientation.VerticalScroll) {
				pictOriginal.Location = new Point(pictOriginal.Location.X, -e.NewValue);
			} else {
				pictOriginal.Location = new Point(-e.NewValue, pictOriginal.Location.Y);
			}
		}

		/// <summary>
		/// 現在の矩形でオリジナル画像のカットを行い、DBに登録する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCut_Click(object sender, EventArgs e)
		{
			if (_originalImage == null) return;
			Rectangle rect = _actualCutRect;
            for(var i=0;i< _currentActionRects.Count();++i)
            {
                _currentActionRects[i] = new ActionRect();
            }
            DisplayCutPicture(rect, new Point(rect.Width / 2, rect.Height));
            DisplayAdditionalInfo();

            SetDefaultActionName();
		}

		/// <summary>
		/// 元画像を矩形で切り抜いた
		/// </summary>
		/// <param name="rect"></param>
		private void DisplayCutPicture(Rectangle rect, Point p)
		{
			if (rect.Width == 0 || rect.Height == 0)
			{
				return;
			}

			CutRectForCutRect(rect);
			pictCutImage.Refresh();
			DrawCrossLineToCenterLayer(p);
		}
		/// <summary>
		/// 切り抜き画像を「切り抜き矩形」から作成し、pictCutImageに割り当てる
		/// </summary>
		/// <param name="rect">切り抜き矩形</param>
		private void CutRectForCutRect(Rectangle rect)
		{
			Bitmap bmp = new Bitmap(rect.Width, rect.Height);
			Graphics g = Graphics.FromImage(bmp);
			Rectangle drect = rect;
			drect.X = 0;
			drect.Y = 0;
			g.DrawImage(_originalImage, drect, rect, GraphicsUnit.Pixel);
			_centeredImage = bmp;
			pictCutImage.Image = bmp;
		}

		/// <summary>
		/// デフォルトアクション名設定
		/// </summary>
		private void SetDefaultActionName()
		{
			if (txtActionName.Text == "" || Regex.IsMatch(txtActionName.Text, @"Action\d\d\d")) {
				var items = from item in listActions.Items.Cast<string>()
							orderby item descending
							where item.StartsWith("Action")
							select item;
				foreach (var actioname in items) {
					if (Regex.IsMatch(actioname, @"Action\d\d\d")) {
						var strnumber = actioname.Substring("Action".Length);
						int number = 0;
						if (Int32.TryParse(strnumber, out number)) {
							txtActionName.Text = String.Format("Action{0:D3}", number + 1);
							return;
						}
					}
				}
				txtActionName.Text = "Action000";
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private bool IsCuttingTableData()
		{
			return listPictures.Items.Count > 0;
		}

		/// <summary>
		/// 矩形及び中心点情報をリストに登録する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnFixCenter_Click(object sender, EventArgs e)
		{
			CuttingInfo ct;
			ct.cutRect = _actualCutRect;// _cutRect;
			ct.center = _centerPos;
			ct.duration = (int)txtDuration.Value;
			ct.addrects = new List<ActionRect>();
			ActionInfo actInfo;

			//アクションが新しいかどうかで場合分け
			if (listActions.Items.Contains(txtActionName.Text)) {//既存アクション
				_cuttingTable[txtActionName.Text]._cuts.Add(ct);
				AddCutPictureToImageList();
			} else {//新規アクション
				listPictures.Items.Clear();
				listActions.Items.Add(txtActionName.Text);
				actInfo = new ActionInfo();
				actInfo._cuts = new List<CuttingInfo>();
				actInfo._cuts.Add(ct);
				_cuttingTable.Add(txtActionName.Text, actInfo);
				listActions.SelectedIndex = listActions.Items.Count - 1;

				AddCutPictureToImageList();
				listPictures.Clear();
				BuildListFromActionName(txtActionName.Text, actInfo);
				listPictures.Refresh();

			}
			if (IsCuttingTableData())
			{
				btnPreview.Enabled = true;
			}
			else
			{
				btnPreview.Enabled = false;
			}

			if (listActions.SelectedIndex == -1)
			{
				listActions.SelectedIndex = listActions.Items.Count - 1;
			}
		}

		/// <summary>
		/// イメージリストに現在の切り抜き画像を登録する
		/// </summary>
		private void AddCutPictureToImageList()
		{
			Image cutimg = pictCutImage.Image;
			string name = txtActionName.Text;

			AddCutPictureToImageList(cutimg, name);
		}

		private void AmendCutPictureToImageList(Image cutImg, int key)
		{
			Image img = new Bitmap(40, 40);
			Rectangle destRc = new Rectangle(0, 0, img.Width, img.Height);
			Graphics g = Graphics.FromImage(img);
			g.DrawImage(cutImg, destRc, new Rectangle(0, 0, cutImg.Width, cutImg.Height), GraphicsUnit.Pixel);
			imgList.Images[key] = img;
			listPictures.Refresh();
			g.Dispose();
		}

		private void AddCutPictureToImageList(Image cutimg, string name)
		{
			Image img = new Bitmap(40, 40);
			Rectangle destRc = new Rectangle(0, 0, img.Width, img.Height);
			Graphics g = Graphics.FromImage(img);
			g.DrawImage(cutimg, destRc, new Rectangle(0, 0, cutimg.Width, cutimg.Height), GraphicsUnit.Pixel);
			string key = listPictures.Items.Count.ToString();
			key = name + ":" + key;
			imgList.Images.Add(key, img);
			var sup = listPictures.Items.Add(key, key);

			sup.Selected = true;
			listPictures.Refresh();
			g.Dispose();

		}

		/// <summary>
		/// 中心点画像表示部分のリフレッシュ
		/// </summary>
		private void RefreshCenteredImage()
		{

			//スケーリング済み切り抜き画像の表示
			float scale = (float)_centeredImagePercentage / FULL_SCALE_PERCENTAGE;
			//pictCutImage.Image.Dispose();
			pictCutImage.Image = GetScaledImageFromImage(ref _centeredImage, scale);
			pictCutImage.Refresh();

            var img = (Image)_centeredFilterLayerBMP;
            pictCenteredFilter.Image = GetScaledImageFromImage(ref img, scale);
            pictCenteredFilter.Refresh();

			lblCenterPos.Text = _centerPos.ToString();

			DisplayAdditionalInfo();
		}
		private void btnCenterExpand_Click(object sender, EventArgs e)
		{
			if (_centeredImage == null) return;
			_centeredImagePercentage = Math.Min(_centeredImagePercentage + 50, MAX_SCALE);
			lblCenterScale.Text = "倍率=" + _centeredImagePercentage.ToString() + "%";
			RefreshCenteredImage();
		}

		private void btnCenterShrink_Click(object sender, EventArgs e)
		{
			if (_centeredImage == null) return;
			_centeredImagePercentage = Math.Max(_centeredImagePercentage - 50, MIN_SCALE);
			lblCenterScale.Text = "倍率=" + _centeredImagePercentage.ToString() + "%";
			RefreshCenteredImage();
		}

		private void btnCenterReset_Click(object sender, EventArgs e)
		{
			if (_centeredImage == null) return;
			_centeredImagePercentage = (uint)FULL_SCALE_PERCENTAGE;
			lblCenterScale.Text = "倍率=" + _centeredImagePercentage.ToString() + "%";
			RefreshCenteredImage();
		}
		private void pictCenteredFilter_MouseDown(object sender, MouseEventArgs e)
		{
			if (listEditing.SelectedIndex == (int)AdditiveInfoType.center)
			{

			}
			else
			{
				//画面外になるとめんどくさいので補正
				_actionRectBeginPos.X = Math.Max(e.Location.X, 0);
				_actionRectBeginPos.Y = Math.Max(e.Location.Y, 0);
			}
		}
		private void pictCenteredFilter_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (listEditing.SelectedIndex == (int)AdditiveInfoType.center)
				{
					//現在中心位置をラベルに表示
					Point p = e.Location;

					SetCenterFromPoint(p);
				}
				else
				{
					Point p = e.Location;
					float scale = (float)_originalImagePercentage / FULL_SCALE_PERCENTAGE;
					p.X = Math.Max((int)(p.X / scale), 0);//0以下になると面倒な事になるので…
					p.Y = Math.Max((int)(p.Y / scale), 0);//0以下になると面倒な事になるので…

					Rectangle rc = CreateRectFor2Point(e.Location, _actionRectBeginPos);
					if (listEditing.SelectedIndex > 0)
					{
						RectType rt = RectType.無効;
						if (Enum.TryParse<RectType>(listEditing.SelectedItem.ToString(), out rt)) {
							Pen pen = new Pen(Color.White, 1); ;
							pen.Color = GetRectColor(rt);
							DrawRectToPictureObject(pictCenteredFilter, rc, pen);
						}
					}
				}
			}
		}


		private void pictCenteredFilter_MouseUp(object sender, MouseEventArgs e)
		{
            if (listEditing.SelectedIndex < 0) return;
            float rcscale = (float)_centeredImagePercentage / FULL_SCALE_PERCENTAGE;
            Point p;
			if (listEditing.SelectedIndex == 0)
			{
				//現在中心位置をラベルに表示
				p = e.Location;
				SetCenterFromPoint(p);
			}
			else
			{
				Rectangle rc = CreateRectFor2Point(e.Location, _actionRectBeginPos);
				Pen pen= new Pen(Color.White, 1);
				RectType rt = RectType.無効;
				if (Enum.TryParse<RectType>(listEditing.SelectedItem.ToString(), out rt))
				{
					Color col = GetRectColor(rt);
					DrawRectToPictureObject(pictCenteredFilter, rc, pen, true);

                    //本来の矩形データに変換
                    rc.X = (int)((float)rc.X / rcscale);
                    rc.Y = (int)((float)rc.Y / rcscale);
                    rc.Width = (int)((float)rc.Width / rcscale);
                    rc.Height = (int)((float)rc.Height / rcscale);

                    _currentActionRects[listEditing.SelectedIndex-1] = new ActionRect(rt, rc);
				}
				p = _centerPos;
				p.X = (int)((float)p.X * rcscale);
				p.Y = (int)((float)p.Y * rcscale);
				DrawCrossLineToCenterLayer(p);
			}

			//全矩形表示更新
			for (int i= 1;i < listEditing.Items.Count;++i) {
				var item = listEditing.Items[i];
				RectType rt;
				if(!Enum.TryParse<RectType>(item.ToString(),out rt))
				{
					continue;
				}
				if (rt!= RectType.無効)
				{
					Pen pen = new Pen(Color.White,1);
					pen.Color = GetRectColor(rt);
                    var rc = _currentActionRects[i - 1].rc;

                    rc.X = (int)((float)rc.X * rcscale);
                    rc.Y = (int)((float)rc.Y * rcscale);
                    rc.Width = (int)((float)rc.Width * rcscale);
                    rc.Height = (int)((float)rc.Height * rcscale);

                    DrawRectToPictureObject(pictCenteredFilter, rc , pen, false);
				}
			}
		}
		/// <summary>
		/// 指定された座標を中心点として設定
		/// メンバスコープのスケーリングも考慮されている
		/// </summary>
		/// <param name="p">指定された座標</param>
		private void SetCenterFromPoint(Point p,bool isblink=false)
		{
			//最前面レイヤーに十字を描画
			DrawCrossLineToCenterLayer(p,isblink);

			//実際の中心点を保持
			float scale = (float)_centeredImagePercentage / FULL_SCALE_PERCENTAGE;
			p.X = Math.Max((int)(p.X / scale), 0);
			p.Y = Math.Max((int)(p.Y / scale), 0);
			_centerPos = p;
			lblCenterPos.Text = _centerPos.ToString();
		}

		void Swap<T>(ref T lval,ref T rval)
		{
			T tmp = lval;
			lval = rval;
			rval = tmp;
		}

		/// <summary>
		/// 中心点最前面レイヤーに十字を描画
		/// </summary>
		/// <param name="p"></param>
		private void DrawCrossLineToCenterLayer(Point p,bool isblink=false)
		{
			Color col1=Color.Yellow;
			Color col2 = Color.Black;
			if(isblink && _lineBlink)
			{
				Swap(ref col1, ref col2);
			}

			Graphics g = Graphics.FromImage(pictCenteredFilter.Image);
			if (!isblink)
			{
				g.Clear(Color.Transparent);
			}
			Pen pen = new Pen(col1, 1);
			g.DrawLine(pen, new Point(p.X, 0), new Point(p.X, pictCenteredFilter.Height));
			g.DrawLine(pen, new Point(0, p.Y), new Point(pictCenteredFilter.Width, p.Y));

			if (isblink)
			{
				pen.Color = col2;
				pen.DashStyle = DashStyle.Dot;
				g.DrawLine(pen, new Point(p.X, 0), new Point(p.X, pictCenteredFilter.Height));
				g.DrawLine(pen, new Point(0, p.Y), new Point(pictCenteredFilter.Width, p.Y));
			}

			pen.Dispose();
			g.Dispose();
			pictCenteredFilter.Refresh();
		}

		private void pictCenteredFilter_MouseEnter(object sender, EventArgs e)
		{

		}

		private void mnuSaveProject_Click(object sender, EventArgs e)
		{
			if (_savedFileName == "") {
				saveProjectFile.Filter = "(*.actproj)|*.actproj";
				if (saveProjectFile.ShowDialog() == DialogResult.Cancel) {
					return;
				}
				_savedFileName = saveProjectFile.FileName.ToString();
			}

			SaveNamedProjectFile(_savedFileName);
		}
		/// <summary>
		/// プロジェクトファイルを保存する
		/// </summary>
		/// <param name="savefileName">ファイル名称</param>
		private void SaveNamedProjectFile(string savefileName)
		{
			var proj = new ProjectInfo();
			var dirPath = Path.GetDirectoryName(savefileName) + "/";
			Directory.SetCurrentDirectory(dirPath);
			if (Path.IsPathRooted(_originalFileName))//絶対パスなら相対パスへ変換
			{
				Uri dirUri = new Uri(dirPath);
				Uri filepathUri = new Uri(_originalFileName);
				Uri relativeUri = dirUri.MakeRelativeUri(filepathUri);
				proj.originalFileName = relativeUri.ToString();
			}
			else
			{
				proj.originalFileName = _originalFileName;
			}
			proj.cuttingTable = _cuttingTable;
			_savedFileName = savefileName;
			//シリアライズ準備
			var fs = new System.IO.FileStream(savefileName, System.IO.FileMode.Create);//

			//シリアライザーにProjectInfoの内容を書き込み
			var serializer = new DataContractJsonSerializer(typeof(ProjectInfo));
			serializer.WriteObject(fs, proj);
			fs.Close();
		}

		private void openProject_Click(object sender, EventArgs e)
		{
			openProjectFile.Filter = "(*.actproj)|*.actproj";
			if (openProjectFile.ShowDialog() == DialogResult.Cancel) {
				return;
			}

			var dirPath = Path.GetDirectoryName(openProjectFile.FileName.ToString()) + "/";
			Directory.SetCurrentDirectory(dirPath);

			//保存したJSONをロードして、保存時の状態を復元する
			var serializer = new DataContractJsonSerializer(typeof(ProjectInfo));
			var fs = new System.IO.FileStream(openProjectFile.FileName.ToString(), System.IO.FileMode.Open);//
			ProjectInfo proj = (ProjectInfo)serializer.ReadObject(fs);
			if (Path.IsPathRooted(proj.originalFileName))
			{
				_originalFileName = proj.originalFileName;
			}
			else
			{
				_originalFileName = Path.GetFullPath(proj.originalFileName);
			}
			_cuttingTable = proj.cuttingTable;
			if (!File.Exists(_originalFileName))
			{
				if (MessageBox.Show("関連の画像ファイルが存在しないようです。\n再設定しますか？", "ファイルがないよ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (openOriginalPicture.ShowDialog() == DialogResult.Cancel)
					{
						MessageBox.Show("画像ファイルの関連付けがされてないため\n不正な挙動になります…", "どうなっても知らんよ？", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					_originalFileName = openOriginalPicture.FileName;
				}
				else
				{
					MessageBox.Show("画像ファイルの関連付けがされてないため\n不正な挙動になります…", "どうなっても知らんよ？", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}
			_originalImage = Image.FromFile(_originalFileName);
			pictOriginal.Image = (Image)_originalImage.Clone();
			fs.Close();
			listActions.Items.Clear();
			listPictures.Items.Clear();
			//アクションループ
			foreach (var item in _cuttingTable)
			{
				//アクションの追加
				var index = listActions.Items.Add(item.Key);
				BuildListFromActionName(item.Key, item.Value);
				listActions.SelectedIndex = index;
			}
			listPictures.SelectedIndices.Add(0);
			listPictures.Select();
			txtActionName.Text = listActions.Text;
			_savedFileName = openProjectFile.FileName.ToString();
			btnCut.Enabled = true;
		}

		private void BuildListFromActionName(string actionName, ActionInfo actionInfo)
		{
			if (actionInfo._cuts == null) return;
			foreach (var cut in actionInfo._cuts)
			{
				CutRectForCutRect(cut.cutRect);
				AddCutPictureToImageList(pictCutImage.Image, actionName);

				_centerPos = cut.center;

			}
		}

		private void listActions_SelectedIndexChanged(object sender, EventArgs e)
		{
			var key = ((ListBox)sender).SelectedItem.ToString();
			var value = _cuttingTable[key];
			DisplayCutPicture(value._cuts[0].cutRect, value._cuts[0].center);
			listPictures.Clear();
			BuildListFromActionName(key, value);
			listPictures.Refresh();
			chkLoop.Checked = value.isLoop;
            DisplayAdditionalInfo();

        }

		private void mnuSaveNamedProjectFile_Click(object sender, EventArgs e)
		{
			saveProjectFile.Filter = "(*.actproj)|*.actproj";
			//プロジェクトを名前をつけて保存
			if (saveProjectFile.ShowDialog() == DialogResult.Cancel) {
				return;
			}
			_savedFileName = saveProjectFile.FileName.ToString();
			SaveNamedProjectFile(_savedFileName);
		}

		private void btnLoadOriginal_Click(object sender, EventArgs e)
		{
			//オリジナル画像のロード
			if (openOriginalPicture.ShowDialog() == DialogResult.Cancel) {
				return;
			}
			LoadOriginalPicture(openOriginalPicture.FileName.ToString());
			btnCut.Enabled = true;
		}

		private void mnuWriteBinary_Click(object sender, EventArgs e)
		{
			saveProjectFile.Filter = "(*.act)|*.act";
			//バイナリに名前をつけて保存
			if (saveProjectFile.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}
			FileStream fs = new FileStream(saveProjectFile.FileName, FileMode.Create);
			BinaryWriter bw = new BinaryWriter(fs);
			bw.Write(_version);
			var dirPath = Directory.GetCurrentDirectory() + "/";
			var imgFilePath = "";
			if (Path.IsPathRooted(_originalFileName))//絶対パスなら相対パスへ変換
			{
				Uri dirUri = new Uri(dirPath);
				Uri filepathUri = new Uri(_originalFileName);
				Uri relativeUri = dirUri.MakeRelativeUri(filepathUri);
				imgFilePath = relativeUri.ToString();
			}
			else
			{
				imgFilePath = _originalFileName;
			}
			UInt32 imgFilePathLen = (UInt32)System.Text.Encoding.UTF8.GetByteCount(imgFilePath);
			byte[] imgFilePathByteArray = System.Text.Encoding.UTF8.GetBytes(imgFilePath);
			bw.Write(imgFilePathLen);
			bw.Write(imgFilePathByteArray);

			UInt32 actionCnt = (UInt32)_cuttingTable.Count;//
			bw.Write(actionCnt);//アクション数
			foreach (var act in _cuttingTable) {
				UInt32 keylen = (UInt32)System.Text.Encoding.UTF8.GetByteCount(act.Key);
				bw.Write(keylen);//キー(アクション名)の名前長さ
				bw.Write(System.Text.Encoding.UTF8.GetBytes(act.Key));//キー(アクション名)文字列
				bw.Write(act.Value.isLoop);//ループしますか？
				bw.Write(act.Value._cuts.Count);//切り抜き情報カウント
				//切り抜き情報を出力
				foreach (var cutinfo in act.Value._cuts) {
					bw.Write(cutinfo.cutRect.X + cutinfo.cutRect.Width / 2);//矩形中心X
					bw.Write(cutinfo.cutRect.Y + cutinfo.cutRect.Height / 2);//矩形中心Y
					bw.Write(cutinfo.cutRect.Width);//幅
					bw.Write(cutinfo.cutRect.Height);//高さ
					bw.Write(cutinfo.center.X);//中心点X
					bw.Write(cutinfo.center.Y);//中心点Y
					bw.Write(cutinfo.duration);//フレーム数
					//さらに攻撃矩形等があればそれも出力
					if (cutinfo.addrects == null)//なくても0出力
					{
						bw.Write((int)0);
					}
					else
					{
						bw.Write((int)cutinfo.addrects.Count);
						foreach(var rc in cutinfo.addrects)
						{
							bw.Write((int)rc.rt);//矩形種別登録
							//矩形の座標を、中心点からのオフセットとして登録(理由は実機における反転時の処理を楽にするため)
							var pos = new Point((rc.rc.Left + rc.rc.Right) / 2, (rc.rc.Top + rc.rc.Bottom) / 2);
							var offset = new Point(pos.X - cutinfo.center.X, pos.Y - cutinfo.center.Y);
							bw.Write(offset.X);
							bw.Write(offset.Y);
							bw.Write(rc.rc.Width);
							bw.Write(rc.rc.Height);
						}
					}
				}
			}
			bw.Close();
		}

        /// <summary>
        /// 矩形タイプのリストを現在のカット情報から更新する
        /// </summary>
        /// <param name="cuttingInfo"></param>
        private void RefreshRectTypeList(CuttingInfo cuttingInfo)
        {
            listEditing.Items.Clear();
            listEditing.Items.Add("中心点");
			if (cuttingInfo.addrects != null)
			{
				foreach (var rc in cuttingInfo.addrects)
				{
					listEditing.Items.Add(rc.rt.ToString());
				}
			}
        }

		private void listPictures_SelectedIndexChanged(object sender, EventArgs e)
		{
			var actionIndex = listActions.SelectedIndex;
			if (actionIndex == -1 || listPictures.SelectedIndices.Count == 0) return;
			var pictIndex = listPictures.SelectedIndices[0];
			var actionName = listActions.Items[actionIndex].ToString();
			if (pictIndex == -1 || pictIndex >= _cuttingTable[actionName]._cuts.Count) return;
			var cutdata = _cuttingTable[actionName]._cuts[pictIndex];
			CutRectForCutRect(cutdata.cutRect);
			float scale = (float)_centeredImagePercentage / FULL_SCALE_PERCENTAGE;
			SetCenterFromPoint(new Point((int)(cutdata.center.X*scale), (int)(cutdata.center.Y*scale)));
			_currentActionRects.Clear();
			if (cutdata.addrects != null)
			{
				foreach (var addrect in cutdata.addrects)
                {
                    _currentActionRects.Add(addrect);
                }
				//foreach (var rc in cutdata.addrects)
				//{
				//	_currentActionRects[(int)rc.rt] = rc.rc;
				//}
            }
			RefreshRectTypeList(cutdata);
			_amendingPictureIndex = pictIndex;
			txtDuration.Value = cutdata.duration;
			RefreshCenteredImage();
		}


		private void btnPreview_Click(object sender, EventArgs e)
		{
			if (listActions.SelectedIndex == -1)
			{
				listActions.SelectedIndex = listActions.Items.Count - 1;
			}
			var selectedActionName = listActions.SelectedItem.ToString();
			if (listPictures.Items.Count == 0)
			{
				MessageBox.Show("アニメーションパターンがありません", "あかんで");
				return;
			}
			var frm = new frmPreview();

			foreach (var data in _cuttingTable[selectedActionName]._cuts)
			{
				var bmp = new Bitmap(_originalImage);
				Rectangle rc = data.cutRect;
				//0未満になってた時補正(なんかの理由(今の所原因不明)で矩形の場所がマイナスになってた時落ちる)
				rc.X = Math.Max(0, rc.X);
				rc.Y = Math.Max(0, rc.Y);
				var cutBmp = bmp.Clone(rc, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				frm.AddImage(cutBmp, data.center,data.duration);
			}



			frm.ShowDialog(this);
		}

		/// <summary>
		/// オリジナル画像フィルターをクリアする(切り抜き矩形をクリア)
		/// </summary>
		private void ClearOriginalImageFilter()
		{
			Graphics g = Graphics.FromImage(pictOriginalFilter.Image);
			g.Clear(Color.Transparent);
			pictOriginalFilter.Refresh();
			g.Dispose();
		}

		/// <summary>
		/// 矩形修正ボタン押下
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReEditRect_Click(object sender, EventArgs e)
		{
			var actionIndex = listActions.SelectedIndex;
			if (actionIndex == -1 || listPictures.SelectedIndices.Count == 0) return;
			var pictIndex = listPictures.SelectedIndices[0];
			if (pictIndex == -1) return;
			var actionName = listActions.Items[actionIndex].ToString();
			var cutdata = _cuttingTable[actionName]._cuts[pictIndex];
			_actualCutRect = cutdata.cutRect;

			_apprentCutRect = GetCutRectOnPictureBox(_actualCutRect);

			DrawCutRectToOriginalFilterLayerWithScale();


			btnFinalizeAmendment.Visible = true;
			_amendingActionName = actionName;
			_amendingPictureIndex = pictIndex;
		}

		private void btnFinalizeAmendment_Click(object sender, EventArgs e)
		{
			var info = _cuttingTable[_amendingActionName]._cuts[_amendingPictureIndex];
			info.cutRect = _actualCutRect;
			_cuttingTable[_amendingActionName]._cuts[_amendingPictureIndex] = info;
			CutRectForCutRect(_actualCutRect);
			AmendCutPictureToImageList(pictCutImage.Image, _amendingPictureIndex);
			btnFinalizeAmendment.Visible = false;
		}

		private void ファイルToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void btnDeleteFixCenter_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(txtActionName.Text + "のピクチャ" + _amendingPictureIndex + "番を消去します。よろしいか？", "消す？消す？", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
			//ピクチャテーブルデータの消去
			_cuttingTable[txtActionName.Text]._cuts.RemoveAt(_amendingPictureIndex);
			listPictures.Items.RemoveAt(_amendingPictureIndex);
		}

		private void btnAmendFixCenter_Click(object sender, EventArgs e)
		{
			var actionname = listActions.SelectedItem.ToString();
			var cut = _cuttingTable[actionname]._cuts[_amendingPictureIndex];
			cut.duration = (int)txtDuration.Value;
			cut.center = _centerPos;
			if (listEditing.Items.Count > 0)
			{
				cut.addrects = new List<ActionRect>();
			}
			foreach(var actrect in _currentActionRects)
			{
				cut.addrects.Add(actrect) ;
			}
			_cuttingTable[actionname]._cuts[_amendingPictureIndex] = cut;
			AmendCutPictureToImageList(pictCutImage.Image, _amendingPictureIndex);
		}


		private void chkLoop_Click(object sender, EventArgs e)
		{
			if (listActions == null) return;
			if (listActions.SelectedItem == null) return;
			var key = listActions.SelectedItem.ToString();
			var value = _cuttingTable[key];
			value.isLoop = chkLoop.Checked;
			_cuttingTable[key] = value;
		}


		/// <summary>
		/// 追加属性(中心点/矩形など)を画面上に表示する
		/// 矩形の場合は表示チェックが入っている者のみ表示する
		/// </summary>
		private void DisplayAdditionalInfo()
		{
			float scale = (float)_centeredImagePercentage / FULL_SCALE_PERCENTAGE;
			SetCenterFromPoint(new Point((int)(_centerPos.X * scale), (int)(_centerPos.Y * scale)));

			//全矩形表示更新
			foreach (var actrect in _currentActionRects)
			{
				var actrc = actrect;

				Color color = GetRectColor(actrc.rt);
				Pen pen = new Pen(color, 1);
				var rc = GetScaledRectangle(actrc.rc, scale);
				DrawRectToPictureObject(pictCenteredFilter, rc, pen, false);
			}
		}

		/// <summary>
		/// 矩形
		/// </summary>
		/// <param name="rt"></param>
		/// <returns></returns>
		private Color GetRectColor(RectType rt)
		{
			Color ret=Color.White;
			if(_rectColorTable.TryGetValue(rt,out ret))
			{
				return ret;
			}
			return Color.White;
		}

		/// <summary>
		/// 編集中の追加属性(中心点/矩形など)を画面上に表示する
		/// </summary>
		/// <remarks>
		/// 引数なしのバージョンとは違い、これで指定されたものはやや太めに
		/// そして縞模様で表示される
		/// </remarks>
		private void DisplayAdditionalInfo(int index)
		{
			if (index < 0)
			{
				return;
			}
			float scale = (float)_centeredImagePercentage / FULL_SCALE_PERCENTAGE;

			//中心点
			if (index == 0)
			{
				SetCenterFromPoint(new Point((int)(_centerPos.X * scale), (int)(_centerPos.Y * scale)), true);
				return;
			}


			RectType rt;
			if (!Enum.TryParse<RectType>(listEditing.Items[index].ToString(), out rt))
			{
				return;
			}
			//矩形および矩形種別を取得
			var actrc = _currentActionRects[index - 1];

			//矩形の決定
			var rc = actrc.rc;

			DrawCurrentActionRect(scale, rt, rc);

		}

		private void DrawCurrentActionRect(float scale, RectType rt, Rectangle rc)
        {
            Pen pen1 = new Pen(Color.White, 1);
            Color col1 = Color.White;
            Color col2 = Color.White;

            //色の決定
            col1 = GetRectColor(rt);

            //フォトショの選択範囲みたいに矩形をチリチリさせる
            if (_lineBlink)
            {
                Swap(ref col1, ref col2);
            }
            pen1.Color = col1;
            Pen pen2 = (Pen)pen1.Clone();
            pen2.Color = col2;
            pen2.DashStyle = DashStyle.Dot;

            rc = GetScaledRectangle(rc, scale);

            DrawRectToPictureObject(pictCenteredFilter, rc, pen1, pen2, false);
        }

        private static Rectangle GetScaledRectangle( Rectangle rc, float scale)
        {
            rc.X = (int)((float)rc.X * scale);
            rc.Y = (int)((float)rc.Y * scale);
            rc.Width = (int)((float)rc.Width * scale);
            rc.Height = (int)((float)rc.Height * scale);
            return rc;
        }

        private void listChkDisplay_SelectedIndexChanged(object sender, EventArgs e)
		{
			DisplayAdditionalInfo();
		}

		private void timeBlink_Tick(object sender, EventArgs e)
		{
			DrawCutRectToOriginalFilterLayerWithScale(_lineBlink);
			DisplayAdditionalInfo(listEditing.SelectedIndex);
			_lineBlink = !_lineBlink;
		}

		private void btnAddInfo_Click(object sender, EventArgs e)
		{
			var frm=new frmRectTypeCatalog();
			if (frm.ShowDialog() == DialogResult.Cancel) return;
			var idx=listEditing.Items.Add(frm.SelectedRectType.ToString());
            listEditing.SelectedIndex = idx;
			_currentActionRects.Add(new ActionRect(frm.SelectedRectType,new Rectangle()));
			
		}

		private void listEditing_SelectedIndexChanged(object sender, EventArgs e)
		{
			DisplayAdditionalInfo();
		}

		private void pictCenteredFilter_Click(object sender, EventArgs e)
		{

		}

		private void btnDeleteRect_Click(object sender, EventArgs e)
		{
			if (listEditing.SelectedIndex == 0)
			{
				MessageBox.Show("中心点は消せへんねん。すまんな", "ダメです", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			//「現在の」矩形から現在編集中の矩形を削除する。
			//「現在編集中の矩形」とはデータ上のどれか
			//「あるのかないのかどっちなんだ」をどう判断するか
			//必要なのは現在のインデックス…と、現在のアクション名
			//インデックスの0番は中心点なのでマイナス１しとく
			var actionname = listActions.SelectedItem.ToString();
			var pictIdx = listPictures.SelectedIndices[0];
			Debug.Print("{0}:{1}",actionname,pictIdx);
			var cutinfo = _cuttingTable[actionname];
			Debug.Print(cutinfo.ToString());
			var rc= _currentActionRects[listEditing.SelectedIndex - 1];
			Debug.Print("{0} : {1}",rc.rt.ToString(),rc.rc);
			var msresult = MessageBox.Show(actionname + "の" + pictIdx + "番目の" + rc.rt.ToString() + "を削除します。\nよろしいですか？",
				"ホンマに消してええんか？",
				MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if(msresult== DialogResult.Cancel)
			{
				return;
			}
			//こっから、実際に消しますよ～消す消す。ヌッ！
			_currentActionRects.RemoveAt(listEditing.SelectedIndex - 1);
			_cuttingTable[actionname]._cuts[pictIdx].addrects.RemoveAt(listEditing.SelectedIndex - 1);
			listEditing.Items.RemoveAt(listEditing.SelectedIndex);

			MessageBox.Show("消したで", "後悔すんなよ", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

        private void panelCentered_Scroll(object sender, ScrollEventArgs e)
        {
            DisplayAdditionalInfo();
        }

        private void pictCenteredFilter_Resize(object sender, EventArgs e)
        {
            //if (pictCenteredFilter.Image == null) return;
            //DisplayAdditionalInfo();
        }

        internal unsafe struct FrameData
        {
            public fixed char filename[64];
            public fixed char titlename[16];
            public Int32 srcX;
            public Int32 srcY;
            public Int32 layerNum;
            public Int32 Width;
            public Int32 Height;
            public Int32 destX;
            public Int32 destY;
            public Int32 delay;
            public Int32 layerAdd;
            public Int32 ckeyFlg;
            public Int32 ckeyNum;
        };

        private void mnuImportEdgeData_Click(object sender, EventArgs e)
        {
            var result = openEdgeFile.ShowDialog();
            if(result== DialogResult.Cancel)
            {
                return;
            }

        }

        private void mnuAppendEdgeData_Click(object sender, EventArgs e)
        {
            openEdgeFile.ShowDialog();
        }
    }
}
