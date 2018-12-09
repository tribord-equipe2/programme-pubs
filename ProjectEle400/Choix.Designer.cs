namespace ProjectEle400
{
    partial class Choix
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblTim = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMcDo = new System.Windows.Forms.Label();
            this.lblLevis = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(517, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vous avez le droit aux recompenses ci-dessous. Veuillez cliquer sur une.";
            // 
            // lblTim
            // 
            this.lblTim.AutoSize = true;
            this.lblTim.Enabled = false;
            this.lblTim.Location = new System.Drawing.Point(17, 67);
            this.lblTim.Name = "lblTim";
            this.lblTim.Size = new System.Drawing.Size(83, 20);
            this.lblTim.TabIndex = 1;
            this.lblTim.Text = "TimHorton";
            this.lblTim.Click += new System.EventHandler(this.lblTim_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(559, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Vous devez par la suite prendre en photo le QrCode et aller au magasin choisi.";
            // 
            // lblMcDo
            // 
            this.lblMcDo.AutoSize = true;
            this.lblMcDo.Enabled = false;
            this.lblMcDo.Location = new System.Drawing.Point(17, 103);
            this.lblMcDo.Name = "lblMcDo";
            this.lblMcDo.Size = new System.Drawing.Size(81, 20);
            this.lblMcDo.TabIndex = 1;
            this.lblMcDo.Text = "McDonald";
            this.lblMcDo.Click += new System.EventHandler(this.lblMcDo_Click);
            // 
            // lblLevis
            // 
            this.lblLevis.AutoSize = true;
            this.lblLevis.Enabled = false;
            this.lblLevis.Location = new System.Drawing.Point(17, 144);
            this.lblLevis.Name = "lblLevis";
            this.lblLevis.Size = new System.Drawing.Size(48, 20);
            this.lblLevis.TabIndex = 1;
            this.lblLevis.Text = "Levi\'s";
            this.lblLevis.Click += new System.EventHandler(this.lblLevis_Click);
            // 
            // Choix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 198);
            this.Controls.Add(this.lblLevis);
            this.Controls.Add(this.lblMcDo);
            this.Controls.Add(this.lblTim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Choix";
            this.Text = "Choix";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblTim;
        public System.Windows.Forms.Label lblMcDo;
        public System.Windows.Forms.Label lblLevis;
    }
}