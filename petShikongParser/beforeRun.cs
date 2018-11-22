using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petShikongParser
{
    public partial class beforeRun : Form
    {
        public bool bComplete { get; set; }
        public string strPetShikongPath { get; set; }

        public beforeRun()
        {
            InitializeComponent();

            this.bComplete = false;
        }

        private void btnSetDir_Click(object sender, EventArgs e)
        {
            if(tbSetDir.Text == "")
            {
                MessageBox.Show("请输入口袋单机的游戏路径");
                return;
            }
            string petShikongPath = tbSetDir.Text;
            if (Directory.Exists(petShikongPath) == false)
            {
                MessageBox.Show("你输入的路径不存在，请确认后再设置");
                tbSetDir.Text = "";
                return;
            }
            this.bComplete = true;
            this.strPetShikongPath = petShikongPath;
            MessageBox.Show("设置成功！");
            this.Close();
        }
    }
}
