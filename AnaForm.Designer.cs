namespace SecureStock.UI
{
    partial class AnaForm
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
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.dgvSepet = new System.Windows.Forms.DataGridView();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.btnSatisTamamla = new System.Windows.Forms.Button();
            this.btnLoglariGor = new System.Windows.Forms.Button();
            this.btnPatronEkranı = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSepet)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(33, 50);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(100, 22);
            this.txtBarkod.TabIndex = 0;
            this.txtBarkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // dgvSepet
            // 
            this.dgvSepet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSepet.Location = new System.Drawing.Point(33, 96);
            this.dgvSepet.Name = "dgvSepet";
            this.dgvSepet.RowHeadersWidth = 51;
            this.dgvSepet.RowTemplate.Height = 24;
            this.dgvSepet.Size = new System.Drawing.Size(352, 177);
            this.dgvSepet.TabIndex = 1;
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.Location = new System.Drawing.Point(468, 133);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(44, 16);
            this.lblToplamTutar.TabIndex = 2;
            this.lblToplamTutar.Text = "label1";
            // 
            // btnSatisTamamla
            // 
            this.btnSatisTamamla.Location = new System.Drawing.Point(436, 215);
            this.btnSatisTamamla.Name = "btnSatisTamamla";
            this.btnSatisTamamla.Size = new System.Drawing.Size(75, 23);
            this.btnSatisTamamla.TabIndex = 3;
            this.btnSatisTamamla.Text = "button1";
            this.btnSatisTamamla.UseVisualStyleBackColor = true;
            this.btnSatisTamamla.Click += new System.EventHandler(this.btnSatisTamamla_Click);
            // 
            // btnLoglariGor
            // 
            this.btnLoglariGor.Location = new System.Drawing.Point(646, 148);
            this.btnLoglariGor.Name = "btnLoglariGor";
            this.btnLoglariGor.Size = new System.Drawing.Size(77, 40);
            this.btnLoglariGor.TabIndex = 4;
            this.btnLoglariGor.Text = "button1";
            this.btnLoglariGor.UseVisualStyleBackColor = true;
            this.btnLoglariGor.Click += new System.EventHandler(this.btnLoglariGor_Click);
            // 
            // btnPatronEkranı
            // 
            this.btnPatronEkranı.Location = new System.Drawing.Point(642, 250);
            this.btnPatronEkranı.Name = "btnPatronEkranı";
            this.btnPatronEkranı.Size = new System.Drawing.Size(112, 36);
            this.btnPatronEkranı.TabIndex = 5;
            this.btnPatronEkranı.Text = "patron ekranı";
            this.btnPatronEkranı.UseVisualStyleBackColor = true;
            this.btnPatronEkranı.Click += new System.EventHandler(this.btnPatronEkranı_Click);
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPatronEkranı);
            this.Controls.Add(this.btnLoglariGor);
            this.Controls.Add(this.btnSatisTamamla);
            this.Controls.Add(this.lblToplamTutar);
            this.Controls.Add(this.dgvSepet);
            this.Controls.Add(this.txtBarkod);
            this.Name = "AnaForm";
            this.Text = "AnaForm";
            this.Load += new System.EventHandler(this.AnaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSepet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.DataGridView dgvSepet;
        private System.Windows.Forms.Label lblToplamTutar;
        private System.Windows.Forms.Button btnSatisTamamla;
        private System.Windows.Forms.Button btnLoglariGor;
        private System.Windows.Forms.Button btnPatronEkranı;
    }
}