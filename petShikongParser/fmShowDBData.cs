using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petShikongParser
{
    public partial class fmShowDBData : Form
    {
        private bool bTextShow = false;   // 文本展示框是否显示

        public fmShowDBData(showDBDataFormParam param)
        {
            InitializeComponent();
            dgvShowData.Height = 330;
            tbCellData.Visible = false;
            Text = param.formText;
            dgvShowData.DataSource = param.dgvShowDataSrc;
            dgvShowData.DataMember = "Table";
        }

        private void dgvShowData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            tbCellData.Text = "";
            try
            {
                tbCellData.Text = dgvShowData.SelectedCells[0].Value.ToString();
            }
            catch
            {
                return;
            }
        }

        private void btnCellData_Click(object sender, EventArgs e)
        {
            if (bTextShow)
            {
                bTextShow = false;
                dgvShowData.Height = 330;
                tbCellData.Visible = false;
            }
            else
            {
                bTextShow = true;
                dgvShowData.Height = 260;
                tbCellData.Visible = true;
            }
        }
    }

    public class showDBDataFormParam
    {
        public string formText { get; set; }

        public DataSet dgvShowDataSrc { get; set; }
    }
}
