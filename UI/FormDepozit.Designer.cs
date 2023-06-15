namespace UI
{
    partial class FormDepozit
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
            this.listViewClienti = new System.Windows.Forms.ListView();
            this.listViewMobila = new System.Windows.Forms.ListView();
            this.listViewAtribuiri = new System.Windows.Forms.ListView();
            this.buttonCumpara = new System.Windows.Forms.Button();
            this.buttonDetalii = new System.Windows.Forms.Button();
            this.btnInapoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewClienti
            // 
            this.listViewClienti.HideSelection = false;
            this.listViewClienti.Location = new System.Drawing.Point(29, 12);
            this.listViewClienti.Name = "listViewClienti";
            this.listViewClienti.Size = new System.Drawing.Size(432, 178);
            this.listViewClienti.TabIndex = 0;
            this.listViewClienti.UseCompatibleStateImageBehavior = false;
            this.listViewClienti.SelectedIndexChanged += new System.EventHandler(this.listViewClienti_SelectedIndexChanged);
            // 
            // listViewMobila
            // 
            this.listViewMobila.HideSelection = false;
            this.listViewMobila.Location = new System.Drawing.Point(553, 12);
            this.listViewMobila.Name = "listViewMobila";
            this.listViewMobila.Size = new System.Drawing.Size(469, 178);
            this.listViewMobila.TabIndex = 1;
            this.listViewMobila.UseCompatibleStateImageBehavior = false;
            this.listViewMobila.SelectedIndexChanged += new System.EventHandler(this.listViewMobila_SelectedIndexChanged);
            // 
            // listViewAtribuiri
            // 
            this.listViewAtribuiri.HideSelection = false;
            this.listViewAtribuiri.Location = new System.Drawing.Point(572, 315);
            this.listViewAtribuiri.Name = "listViewAtribuiri";
            this.listViewAtribuiri.Size = new System.Drawing.Size(430, 184);
            this.listViewAtribuiri.TabIndex = 2;
            this.listViewAtribuiri.UseCompatibleStateImageBehavior = false;
            this.listViewAtribuiri.SelectedIndexChanged += new System.EventHandler(this.listViewAtribuiri_SelectedIndexChanged);
            // 
            // buttonCumpara
            // 
            this.buttonCumpara.Location = new System.Drawing.Point(60, 404);
            this.buttonCumpara.Name = "buttonCumpara";
            this.buttonCumpara.Size = new System.Drawing.Size(91, 50);
            this.buttonCumpara.TabIndex = 3;
            this.buttonCumpara.Text = "Cumpara";
            this.buttonCumpara.UseVisualStyleBackColor = true;
            this.buttonCumpara.Click += new System.EventHandler(this.buttonCumpara_Click);
            // 
            // buttonDetalii
            // 
            this.buttonDetalii.Location = new System.Drawing.Point(221, 404);
            this.buttonDetalii.Name = "buttonDetalii";
            this.buttonDetalii.Size = new System.Drawing.Size(95, 50);
            this.buttonDetalii.TabIndex = 4;
            this.buttonDetalii.Text = "Detalii";
            this.buttonDetalii.UseVisualStyleBackColor = true;
            this.buttonDetalii.Click += new System.EventHandler(this.buttonDetalii_Click);
            // 
            // btnInapoi
            // 
            this.btnInapoi.Location = new System.Drawing.Point(360, 401);
            this.btnInapoi.Name = "btnInapoi";
            this.btnInapoi.Size = new System.Drawing.Size(101, 57);
            this.btnInapoi.TabIndex = 5;
            this.btnInapoi.Text = "Revenire Meniu ";
            this.btnInapoi.UseVisualStyleBackColor = true;
            this.btnInapoi.Click += new System.EventHandler(this.btnInapoi_Click);
            // 
            // FormDepozit
            // 
            this.ClientSize = new System.Drawing.Size(1045, 537);
            this.Controls.Add(this.btnInapoi);
            this.Controls.Add(this.buttonDetalii);
            this.Controls.Add(this.buttonCumpara);
            this.Controls.Add(this.listViewAtribuiri);
            this.Controls.Add(this.listViewMobila);
            this.Controls.Add(this.listViewClienti);
            this.Name = "FormDepozit";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewClienti;
        private System.Windows.Forms.ListView listViewMobila;
        private System.Windows.Forms.ListView listViewAtribuiri;
        private System.Windows.Forms.Button buttonCumpara;
        private System.Windows.Forms.Button buttonDetalii;
        private System.Windows.Forms.Button btnInapoi;
    }
}