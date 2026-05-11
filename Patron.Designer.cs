namespace SecureStock.UI
{
    partial class PatronForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblGunlukCiro = new System.Windows.Forms.Label();
            this.lblKritikStok = new System.Windows.Forms.Label();
            this.chartEnCokSatanlar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnYeniPersonel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartEnCokSatanlar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGunlukCiro
            // 
            this.lblGunlukCiro.AutoSize = true;
            this.lblGunlukCiro.Location = new System.Drawing.Point(67, 33);
            this.lblGunlukCiro.Name = "lblGunlukCiro";
            this.lblGunlukCiro.Size = new System.Drawing.Size(50, 16);
            this.lblGunlukCiro.TabIndex = 0;
            this.lblGunlukCiro.Text = "0.00 TL";
            // 
            // lblKritikStok
            // 
            this.lblKritikStok.AutoSize = true;
            this.lblKritikStok.Location = new System.Drawing.Point(199, 45);
            this.lblKritikStok.Name = "lblKritikStok";
            this.lblKritikStok.Size = new System.Drawing.Size(45, 16);
            this.lblKritikStok.TabIndex = 1;
            this.lblKritikStok.Text = "0 Ürün";
            // 
            // chartEnCokSatanlar
            // 
            chartArea1.Name = "ChartArea1";
            this.chartEnCokSatanlar.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartEnCokSatanlar.Legends.Add(legend1);
            this.chartEnCokSatanlar.Location = new System.Drawing.Point(103, 98);
            this.chartEnCokSatanlar.Name = "chartEnCokSatanlar";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartEnCokSatanlar.Series.Add(series1);
            this.chartEnCokSatanlar.Size = new System.Drawing.Size(300, 300);
            this.chartEnCokSatanlar.TabIndex = 2;
            this.chartEnCokSatanlar.Text = "chart1";
            // 
            // btnYeniPersonel
            // 
            this.btnYeniPersonel.Location = new System.Drawing.Point(496, 72);
            this.btnYeniPersonel.Name = "btnYeniPersonel";
            this.btnYeniPersonel.Size = new System.Drawing.Size(201, 49);
            this.btnYeniPersonel.TabIndex = 3;
            this.btnYeniPersonel.Text = "Yeni Personel Ekle";
            this.btnYeniPersonel.UseVisualStyleBackColor = true;
            this.btnYeniPersonel.Click += new System.EventHandler(this.btnYeniPersonel_Click);
            // 
            // PatronForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnYeniPersonel);
            this.Controls.Add(this.chartEnCokSatanlar);
            this.Controls.Add(this.lblKritikStok);
            this.Controls.Add(this.lblGunlukCiro);
            this.Name = "PatronForm";
            this.Text = "Patron";
            this.Load += new System.EventHandler(this.PatronForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.chartEnCokSatanlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGunlukCiro;
        private System.Windows.Forms.Label lblKritikStok;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEnCokSatanlar;
        private System.Windows.Forms.Button btnYeniPersonel;
    }
}