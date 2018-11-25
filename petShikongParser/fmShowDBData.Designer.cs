namespace petShikongParser
{
    partial class fmShowDBData
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
            this.dgvShowData = new System.Windows.Forms.DataGridView();
            this.tbCellData = new System.Windows.Forms.TextBox();
            this.btnCellData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShowData
            // 
            this.dgvShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowData.Location = new System.Drawing.Point(12, 12);
            this.dgvShowData.Name = "dgvShowData";
            this.dgvShowData.RowTemplate.Height = 23;
            this.dgvShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvShowData.Size = new System.Drawing.Size(644, 261);
            this.dgvShowData.TabIndex = 0;
            this.dgvShowData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvShowData_CellMouseClick);
            // 
            // tbCellData
            // 
            this.tbCellData.Location = new System.Drawing.Point(12, 279);
            this.tbCellData.Multiline = true;
            this.tbCellData.Name = "tbCellData";
            this.tbCellData.ReadOnly = true;
            this.tbCellData.Size = new System.Drawing.Size(644, 63);
            this.tbCellData.TabIndex = 1;
            // 
            // btnCellData
            // 
            this.btnCellData.Location = new System.Drawing.Point(13, 13);
            this.btnCellData.Name = "btnCellData";
            this.btnCellData.Size = new System.Drawing.Size(40, 20);
            this.btnCellData.TabIndex = 2;
            this.btnCellData.Text = "文本";
            this.btnCellData.UseVisualStyleBackColor = true;
            this.btnCellData.Click += new System.EventHandler(this.btnCellData_Click);
            // 
            // fmShowDBData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 348);
            this.Controls.Add(this.btnCellData);
            this.Controls.Add(this.tbCellData);
            this.Controls.Add(this.dgvShowData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmShowDBData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmShowDBData";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShowData;
        private System.Windows.Forms.TextBox tbCellData;
        private System.Windows.Forms.Button btnCellData;
    }
}