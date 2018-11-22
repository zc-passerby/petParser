namespace petShikongParser
{
    partial class parserMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(parserMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpUserInfo = new System.Windows.Forms.TabPage();
            this.tpUserProp = new System.Windows.Forms.TabPage();
            this.tpUserEquip = new System.Windows.Forms.TabPage();
            this.tpUserPet = new System.Windows.Forms.TabPage();
            this.tpUserTask = new System.Windows.Forms.TabPage();
            this.gbPropDB = new System.Windows.Forms.GroupBox();
            this.btnOpenPropDB = new System.Windows.Forms.Button();
            this.btnGetPropData = new System.Windows.Forms.Button();
            this.btnClearPropDB = new System.Windows.Forms.Button();
            this.btnInsertPropDB = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpUserProp.SuspendLayout();
            this.gbPropDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(551, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpUserInfo);
            this.tabControl1.Controls.Add(this.tpUserProp);
            this.tabControl1.Controls.Add(this.tpUserEquip);
            this.tabControl1.Controls.Add(this.tpUserPet);
            this.tabControl1.Controls.Add(this.tpUserTask);
            this.tabControl1.Location = new System.Drawing.Point(12, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(527, 405);
            this.tabControl1.TabIndex = 2;
            // 
            // tpUserInfo
            // 
            this.tpUserInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpUserInfo.Location = new System.Drawing.Point(4, 22);
            this.tpUserInfo.Name = "tpUserInfo";
            this.tpUserInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpUserInfo.Size = new System.Drawing.Size(519, 379);
            this.tpUserInfo.TabIndex = 0;
            this.tpUserInfo.Text = "用户信息";
            this.tpUserInfo.UseVisualStyleBackColor = true;
            // 
            // tpUserProp
            // 
            this.tpUserProp.Controls.Add(this.gbPropDB);
            this.tpUserProp.Location = new System.Drawing.Point(4, 22);
            this.tpUserProp.Name = "tpUserProp";
            this.tpUserProp.Padding = new System.Windows.Forms.Padding(3);
            this.tpUserProp.Size = new System.Drawing.Size(519, 379);
            this.tpUserProp.TabIndex = 1;
            this.tpUserProp.Text = "用户道具";
            this.tpUserProp.UseVisualStyleBackColor = true;
            // 
            // tpUserEquip
            // 
            this.tpUserEquip.Location = new System.Drawing.Point(4, 22);
            this.tpUserEquip.Name = "tpUserEquip";
            this.tpUserEquip.Size = new System.Drawing.Size(519, 379);
            this.tpUserEquip.TabIndex = 2;
            this.tpUserEquip.Text = "用户装备";
            this.tpUserEquip.UseVisualStyleBackColor = true;
            // 
            // tpUserPet
            // 
            this.tpUserPet.Location = new System.Drawing.Point(4, 22);
            this.tpUserPet.Name = "tpUserPet";
            this.tpUserPet.Size = new System.Drawing.Size(519, 379);
            this.tpUserPet.TabIndex = 3;
            this.tpUserPet.Text = "用户宠物";
            this.tpUserPet.UseVisualStyleBackColor = true;
            // 
            // tpUserTask
            // 
            this.tpUserTask.Location = new System.Drawing.Point(4, 22);
            this.tpUserTask.Name = "tpUserTask";
            this.tpUserTask.Size = new System.Drawing.Size(519, 379);
            this.tpUserTask.TabIndex = 4;
            this.tpUserTask.Text = "用户任务";
            this.tpUserTask.UseVisualStyleBackColor = true;
            // 
            // gbPropDB
            // 
            this.gbPropDB.Controls.Add(this.btnInsertPropDB);
            this.gbPropDB.Controls.Add(this.btnClearPropDB);
            this.gbPropDB.Controls.Add(this.btnGetPropData);
            this.gbPropDB.Controls.Add(this.btnOpenPropDB);
            this.gbPropDB.Location = new System.Drawing.Point(7, 7);
            this.gbPropDB.Name = "gbPropDB";
            this.gbPropDB.Size = new System.Drawing.Size(506, 54);
            this.gbPropDB.TabIndex = 0;
            this.gbPropDB.TabStop = false;
            this.gbPropDB.Text = "道具数据库";
            // 
            // btnOpenPropDB
            // 
            this.btnOpenPropDB.Location = new System.Drawing.Point(6, 20);
            this.btnOpenPropDB.Name = "btnOpenPropDB";
            this.btnOpenPropDB.Size = new System.Drawing.Size(85, 23);
            this.btnOpenPropDB.TabIndex = 0;
            this.btnOpenPropDB.Text = "打开数据库";
            this.btnOpenPropDB.UseVisualStyleBackColor = true;
            // 
            // btnGetPropData
            // 
            this.btnGetPropData.Location = new System.Drawing.Point(149, 20);
            this.btnGetPropData.Name = "btnGetPropData";
            this.btnGetPropData.Size = new System.Drawing.Size(75, 23);
            this.btnGetPropData.TabIndex = 1;
            this.btnGetPropData.Text = "获取数据";
            this.btnGetPropData.UseVisualStyleBackColor = true;
            this.btnGetPropData.Click += new System.EventHandler(this.btnGetPropData_Click);
            // 
            // btnClearPropDB
            // 
            this.btnClearPropDB.Location = new System.Drawing.Point(295, 20);
            this.btnClearPropDB.Name = "btnClearPropDB";
            this.btnClearPropDB.Size = new System.Drawing.Size(75, 23);
            this.btnClearPropDB.TabIndex = 2;
            this.btnClearPropDB.Text = "清空数据库";
            this.btnClearPropDB.UseVisualStyleBackColor = true;
            // 
            // btnInsertPropDB
            // 
            this.btnInsertPropDB.Location = new System.Drawing.Point(425, 20);
            this.btnInsertPropDB.Name = "btnInsertPropDB";
            this.btnInsertPropDB.Size = new System.Drawing.Size(75, 23);
            this.btnInsertPropDB.TabIndex = 3;
            this.btnInsertPropDB.Text = "写入数据库";
            this.btnInsertPropDB.UseVisualStyleBackColor = true;
            // 
            // parserMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 445);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "parserMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "超哥辅助-时空单机修改器";
            this.Load += new System.EventHandler(this.parserMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpUserProp.ResumeLayout(false);
            this.gbPropDB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpUserInfo;
        private System.Windows.Forms.TabPage tpUserProp;
        private System.Windows.Forms.TabPage tpUserEquip;
        private System.Windows.Forms.TabPage tpUserPet;
        private System.Windows.Forms.TabPage tpUserTask;
        private System.Windows.Forms.GroupBox gbPropDB;
        private System.Windows.Forms.Button btnOpenPropDB;
        private System.Windows.Forms.Button btnInsertPropDB;
        private System.Windows.Forms.Button btnClearPropDB;
        private System.Windows.Forms.Button btnGetPropData;
    }
}

