namespace petShikongParser
{
    partial class beforeRun
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(beforeRun));
            this.tbSetDir = new System.Windows.Forms.TextBox();
            this.btnSetDir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbSetDir
            // 
            this.tbSetDir.Location = new System.Drawing.Point(12, 12);
            this.tbSetDir.Name = "tbSetDir";
            this.tbSetDir.Size = new System.Drawing.Size(267, 21);
            this.tbSetDir.TabIndex = 0;
            this.tbSetDir.Text = "E:\\vsProject\\口袋时空单机9.2.5.4[精简版]";
            // 
            // btnSetDir
            // 
            this.btnSetDir.Location = new System.Drawing.Point(285, 11);
            this.btnSetDir.Name = "btnSetDir";
            this.btnSetDir.Size = new System.Drawing.Size(115, 23);
            this.btnSetDir.TabIndex = 1;
            this.btnSetDir.Text = "设置口袋单机路径";
            this.btnSetDir.UseVisualStyleBackColor = true;
            this.btnSetDir.Click += new System.EventHandler(this.btnSetDir_Click);
            // 
            // beforeRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 45);
            this.Controls.Add(this.btnSetDir);
            this.Controls.Add(this.tbSetDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "beforeRun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "超哥辅助";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSetDir;
        private System.Windows.Forms.Button btnSetDir;
    }
}