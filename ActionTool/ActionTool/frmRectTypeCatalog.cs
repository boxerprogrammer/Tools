using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActionTool
{
    public partial class frmRectTypeCatalog : Form
    {
		Dictionary<string, frmImage.RectType> typeDic = new Dictionary<string, frmImage.RectType>();
        public frmRectTypeCatalog()
        {
            InitializeComponent();
        }

		private void frmRectTypeCatalog_Load(object sender, EventArgs e)
		{
			foreach (frmImage.RectType v in Enum.GetValues(typeof(frmImage.RectType)))
			{
				if (v != frmImage.RectType.無効)
				{
					typeDic[v.ToString()] = v;
					
				}
			}
			foreach(var str in typeDic)
			{
				listRectType.Items.Add(str.Key);
			}
		}

		private void frmRectTypeCatalog_FormClosed(object sender, FormClosedEventArgs e)
		{
			
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
		public frmImage.RectType SelectedRectType
		{
			get
			{
				return typeDic[listRectType.SelectedItem.ToString()];
			}
		}

		private void listRectType_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void listRectType_DoubleClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
	}
}
