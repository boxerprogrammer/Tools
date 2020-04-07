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

	public enum DividingRule
	{
		dr_width_height,//幅と高さで分割
		dr_divXY//X方向およびY方向の分割数で分割
	};
	public partial class frmBundleCut : Form
	{
		
		private DialogResult result = new DialogResult();
		

		public frmBundleCut()
		{
			InitializeComponent();
		}

		public DialogResult Result { get => result; set => result = value; }

		private void btnOK_Click(object sender, EventArgs e)
		{
			Result = DialogResult.OK;
			if (radioWidthHeight.Checked)
			{

			}
			else
			{

			}
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			result = DialogResult.Cancel;
			this.Close();
		}
	}
}
