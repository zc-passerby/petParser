namespace petShikongParser
{
    partial class forDebug
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
            this.tbFroDebug = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbFroDebug
            // 
            this.tbFroDebug.Location = new System.Drawing.Point(12, 12);
            this.tbFroDebug.Multiline = true;
            this.tbFroDebug.Name = "tbFroDebug";
            this.tbFroDebug.ReadOnly = true;
            this.tbFroDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbFroDebug.Size = new System.Drawing.Size(586, 326);
            this.tbFroDebug.TabIndex = 0;
            // 
            // forDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 350);
            this.Controls.Add(this.tbFroDebug);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "forDebug";
            this.Text = "forDebug";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFroDebug;
    }
}