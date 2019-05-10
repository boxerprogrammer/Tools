using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ActionTool
{
	public partial class frmPreview : Form
	{
		private int _currentFrame;
		private int _totalFrame;
		//private int _lastIndex = -1;
		private float _previewScale = 1.0f;
		private Point _centerpos;
		class CutImageData
		{
			public Image img;//内部的に「切り抜かれた」イメージ
			public Point center;//この「画像」における中心点
			public int duration;//このコマのフレーム数
			public CutImageData(Image i,Point c,int d)
			{
				img = i;
				center = c;
				duration = d;
			}
		}
		private List<CutImageData> _cutImages=new List<CutImageData>();

		public void ClearImage()
		{
			_cutImages.Clear();
		}

		/// <summary>
		/// イメージ情報を追加
		/// </summary>
		/// <param name="img">画像リファレンス</param>
		/// <param name="center">その画像における中心点までのオフセット</param>
		public void AddImage(Image img,Point center,int duration)
		{
			_cutImages.Add(new CutImageData(img, center,duration));
		}

		/// <summary>
		/// トータルフレームを計算する
		/// </summary>
		private void CalculateTotalFrame()
		{


			_totalFrame = 0;
			foreach (var cutimg in _cutImages)
			{
				_totalFrame += cutimg.duration;
			}
		}

		/// <summary>
		/// フレーム番号から画像のインデックスを得る
		/// </summary>
		/// <param name="frame">計算したいフレーム数</param>
		/// <returns>インデックス</returns>
		private int CalculateIndexFromFrame(int frame)
		{
			var f = _currentFrame;
			int index = 0;
			for(int i=0;i<_cutImages.Count;++i)
			{
				f-=_cutImages[i].duration;
				index = i;
				if (f <= 0)
				{
					break;
				}
			}
			return index;
		}
		public frmPreview()
		{
			InitializeComponent();
			_currentFrame = 0;
			_totalFrame = 0;
		}

		private void frmPreview_Load(object sender, EventArgs e)
		{
			CalculateTotalFrame();
			trackBar.Maximum = _totalFrame;
			pictPreview.Image = new Bitmap(512,512);
			_centerpos.X = 256;
			_centerpos.Y = 256;
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			//btnPlay.Visible = true;
			//btnStop.Visible = false;
			animTimer.Stop();
		}

		private void btnPlay_Click(object sender, EventArgs e)
		{
			//btnPlay.Visible = false;
			//btnStop.Visible = true;
			animTimer.Start();
		}

		private void animTimer_Tick(object sender, EventArgs e)
		{
			RefreshByCurrentFrame(_currentFrame);
			trackBar.Value = _currentFrame;
			_currentFrame = (_currentFrame + 1) % _totalFrame;
		}

		/// <summary>
		/// 現在のフレーム情報を元にプレビューピクチャを書き換えます。
		/// </summary>
		private void RefreshByCurrentFrame(int frame)
		{
			var index = CalculateIndexFromFrame(frame);

			//元
			//Image img =frmImage.GetScaledImageFromImage(ref _cutImages[index].img,_previewScale);
			pictPreview.Image.Dispose();
			Image img = new Bitmap(pictPreview.Width, pictPreview.Height);
			Image inImg = _cutImages[index].img;
			Bitmap canvas = new Bitmap((int)(inImg.Width * _previewScale), (int)(inImg.Height * _previewScale));
			Graphics g = Graphics.FromImage(img);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			int x = (int)(-_cutImages[index].center.X * _previewScale)+_centerpos.X;
			int y = (int)(-_cutImages[index].center.Y * _previewScale)+_centerpos.Y;
			int width = (int)(inImg.Width * _previewScale);
			int height = (int)(inImg.Height * _previewScale);
			Rectangle r = new Rectangle(x, y, width, height);
			g.DrawImage(inImg, r);

			Pen pen = new Pen(Color.Yellow,_previewScale );


			g.DrawLine(pen, new Point(_centerpos.X - (int)(2*_previewScale), _centerpos.Y), new Point(_centerpos.X + (int)(2*_previewScale), _centerpos.Y));
			g.DrawLine(pen, new Point(_centerpos.X , _centerpos.Y- (int)(2 * _previewScale)), new Point(_centerpos.X , _centerpos.Y+ (int)(2 * _previewScale)));

			//g.DrawImage(inImg, _centerpos.X, 0, inImg.Width * _previewScale, inImg.Height * _previewScale);
			g.Dispose();
			
			//書き込み
			pictPreview.Image = img;
			pictPreview.Refresh();
			
		}

		private void trackBar_Scroll(object sender, EventArgs e)
		{
			_currentFrame = trackBar.Value;
			RefreshByCurrentFrame(_currentFrame);

		}


		private void btnZoomIn_Click(object sender, EventArgs e)
		{
			_previewScale *= 2.0f;
		}

		private void btnZoomOut_Click(object sender, EventArgs e)
		{
			_previewScale *= 0.5f;
		}

		private void pictPreview_Click(object sender, EventArgs e)
		{

		}
	}
}
