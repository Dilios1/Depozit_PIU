using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    partial class FormListaMobila
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
            this.listViewMobila = new System.Windows.Forms.ListView();
            this.btnStergeMobila = new System.Windows.Forms.Button();
            this.btnDetMobila = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewMobila
            // 
            this.listViewMobila.HideSelection = false;
            this.listViewMobila.Location = new System.Drawing.Point(20, 20);
            this.listViewMobila.Name = "listViewMobila";
            this.listViewMobila.Size = new System.Drawing.Size(360, 200);
            this.listViewMobila.TabIndex = 0;
            this.listViewMobila.UseCompatibleStateImageBehavior = false;
            this.listViewMobila.View = System.Windows.Forms.View.Details;
            // 
            // btnStergeMobila
            // 
            this.btnStergeMobila.Location = new System.Drawing.Point(136, 242);
            this.btnStergeMobila.Name = "btnStergeMobila";
            this.btnStergeMobila.Size = new System.Drawing.Size(75, 23);
            this.btnStergeMobila.TabIndex = 1;
            this.btnStergeMobila.Text = "Sterge";
            this.btnStergeMobila.UseVisualStyleBackColor = true;
            this.btnStergeMobila.Click += new System.EventHandler(this.btnStergeMobila_Click_1);
            // 
            // btnDetMobila
            // 
            this.btnDetMobila.Location = new System.Drawing.Point(20, 242);
            this.btnDetMobila.Name = "btnDetMobila";
            this.btnDetMobila.Size = new System.Drawing.Size(75, 23);
            this.btnDetMobila.TabIndex = 2;
            this.btnDetMobila.Text = "Detalii";
            this.btnDetMobila.UseVisualStyleBackColor = true;
            this.btnDetMobila.Click += new System.EventHandler(this.btnDetMobila_Click_1);
            // 
            // FormListaMobila
            // 
            this.ClientSize = new System.Drawing.Size(497, 325);
            this.Controls.Add(this.btnDetMobila);
            this.Controls.Add(this.btnStergeMobila);
            this.Controls.Add(this.listViewMobila);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormListaMobila";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista mobila";
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.Button btnStergeMobila;
        private System.Windows.Forms.Button btnDetMobila;
    }
}