using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace palettetool
{
    public partial class frmMain : Form
    {
	Bitmap _img;
	Image _palette;
	Bitmap _paletteBMP;
	    Bitmap _indexedBMP;
	    
	Color[,] _pixelData;
	Color[,] _indexData;
	HashSet<Color> _paletteSet=new HashSet<Color>();

        public frmMain()
        {
            InitializeComponent();
        }

	private void btnLoad_Click(object sender, EventArgs e)
	{
		if(dlgOpen.ShowDialog(this)== System.Windows.Forms.DialogResult.Cancel){
			return;
		}
		_img=new Bitmap(Image.FromFile(dlgOpen.FileName));
		_indexedBMP=new Bitmap(Image.FromFile(dlgOpen.FileName));
		pictPicture.Image = _img;
		_pixelData = new Color[_img.Width, _img.Height];
		_indexData = new Color[_img.Width,_img.Height];
		for (int y = 0; y < _img.Height; y++){
			for (int x = 0; x < _img.Width; x++){
				_pixelData[x, y] = _img.GetPixel(x, y);
			}
		}
	}

	private void btnPalette_Click(object sender, EventArgs e)
	{
		_paletteSet.Clear();
		for (int y = 0; y < _img.Height; y++){
			for (int x = 0; x < _img.Width; x++){
				_paletteSet.Add( _pixelData[x, y]);
			}
		}
		int i=0;
		foreach(Color plt in _paletteSet){
			_paletteBMP.SetPixel(i,0,plt); 
			i++;
		}
		Color[] colors= _paletteSet.ToArray();
		for (int y = 0; y < _img.Height; y++){
			for (int x = 0; x < _img.Width; x++){
				int idx=Array.IndexOf(colors,_img.GetPixel(x,y));
				_indexData[x,y]=Color.FromArgb(idx,idx,idx,idx);
				_indexedBMP.SetPixel(x,y,_indexData[x,y]);	
			}
		}


		picPalette.Image =_paletteBMP;
		picIndexed.Image=_indexedBMP;
		Bitmap canvas = new Bitmap(picPalette.Width, picPalette.Height);
		//ImageオブジェクトのGraphicsオブジェクトを作成する
		Graphics g = Graphics.FromImage(canvas);

		g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
		g.DrawImage(_paletteBMP, 0, 0, picPalette.Width, picPalette.Height);
		picPalette.Image=canvas;
		g.Dispose();
		//canvas.Dispose();
	}

	private void frmMain_Load(object sender, EventArgs e)
	{
		_paletteBMP=new Bitmap(256,1,PixelFormat.Format32bppArgb);
		
	}

	private void label2_Click(object sender, EventArgs e)
	{

	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
		{
			return;
		}
		string folder  = System.IO.Path.GetDirectoryName(dlgSave.FileName);
		string filename=System.IO.Path.GetFileNameWithoutExtension(dlgOpen.FileName);
		_indexedBMP.Save(folder+"/"+filename+"_idx.png",ImageFormat.Png);
		_paletteBMP.Save(folder+"/"+filename+"_plt.png",ImageFormat.Png);

	}
    }
}
