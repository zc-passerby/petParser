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
using Newtonsoft.Json.Linq;

namespace petShikongParser
{
    public partial class parserMain : Form
    {
        public dataProcessor processor = new dataProcessor();   // 数据解析

        public JArray propList = null;
        public JArray propDetailList = null;

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

        private void btnGetPropData_Click(object sender, EventArgs e)
        {
            if (propList != null)
                propList = null;
            propList = processor.parsePropDefineData();
        }

        private void btnOpenPropDB_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertPropDB_Click(object sender, EventArgs e)
        {
            if (propList == null)
            {
                MessageBox.Show("请先获取道具数据，再执行数据库插入");
                return;
            }
            int tableCount = processor.getTableCountFromDb(dbTableOptions.propTable);
            //MessageBox.Show("数据库数据条数：" + tableCount.ToString());
            if (tableCount != 0)
            {
                MessageBox.Show("道具数据表不存在或表数据不为空，请清空表后再插入数据！");
                return;
            }
            int insertCount = processor.insertDataToDb(propList, dbTableOptions.propTable);
            MessageBox.Show("插入道具定义条数：" + insertCount.ToString());
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
