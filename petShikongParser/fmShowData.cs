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
    public partial class fmShowData : Form
    {
        public fmShowData()
        {
            InitializeComponent();
        }

        public void setData(string text)
        {
            tbFroDebug.Text = text;
        }
    }
}
