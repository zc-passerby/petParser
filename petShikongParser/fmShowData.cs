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
        public fmShowData(showDataFormParam param)
        {
            InitializeComponent();
            Text = param.formText;
            tbShowData.Text = param.tbShowDataText;
        }
    }

    public class showDataFormParam
    {
        public string formText { get; set; }

        public string tbShowDataText { get; set; }
    }
}
