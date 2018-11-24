namespace petShikongParser
{
    partial class fmShowData
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
            this.tbShowData = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbShowData
            // 
            this.tbShowData.Location = new System.Drawing.Point(12, 12);
            this.tbShowData.Multiline = true;
            this.tbShowData.Name = "tbShowData";
            this.tbShowData.ReadOnly = true;
            this.tbShowData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbShowData.Size = new System.Drawing.Size(384, 393);
            this.tbShowData.TabIndex = 0;
            // 
            // fmShowData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 417);
            this.Controls.Add(this.tbShowData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmShowData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForDebug";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbShowData;
    }
}