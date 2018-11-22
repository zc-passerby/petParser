using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace petShikongParser
{
    public partial class parserMain : Form
    {
        public dataProcessor processor = new dataProcessor();   // 数据解析

        public parserMain(beforeRun bf)
        {
            processor.setPetShikongPath(bf.strPetShikongPath);
            InitializeComponent();
        }

        private void parserMain_Load(object sender, EventArgs e)
        {
            string version = processor.getVersion();
            MessageBox.Show("当前版本号是：" + version);
        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionStr = "Data Source=F:\\github\\PythonTools\\52poke\\52Poke.db3;Version=3;password=";
            string sqlStr = "select * from PokemonInfo";
            SQLiteParameter[] paramList = { };
            DataSet ds = SQLiteHelper.ExecuteDataSet(connectionStr, sqlStr, paramList);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Table";
        }
        */
    }
}
