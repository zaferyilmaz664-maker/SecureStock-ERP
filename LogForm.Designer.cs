namespace SecureStock.UI
{
    partial class LogForm
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
            this.dgvLoglar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoglar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLoglar
            // 
            this.dgvLoglar.AllowUserToAddRows = false;
            this.dgvLoglar.AllowUserToDeleteRows = false;
            this.dgvLoglar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoglar.Location = new System.Drawing.Point(0, -1);
            this.dgvLoglar.Name = "dgvLoglar";
            this.dgvLoglar.ReadOnly = true;
            this.dgvLoglar.RowHeadersWidth = 51;
            this.dgvLoglar.RowTemplate.Height = 24;
            this.dgvLoglar.Size = new System.Drawing.Size(687, 450);
            this.dgvLoglar.TabIndex = 0;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvLoglar);
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.Load += new System.EventHandler(this.LogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoglar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoglar;
    }
}