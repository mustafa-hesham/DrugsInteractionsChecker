namespace Webscarpper
{
    partial class AddDrug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDrug));
            this.Namelbl = new System.Windows.Forms.Label();
            this.nametxtbx = new System.Windows.Forms.TextBox();
            this.titlelbl = new System.Windows.Forms.Label();
            this.Pregcattxtbx = new System.Windows.Forms.TextBox();
            this.Pregcatlbl = new System.Windows.Forms.Label();
            this.Savebtn = new System.Windows.Forms.Button();
            this.Addinterbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Namelbl
            // 
            this.Namelbl.AutoSize = true;
            this.Namelbl.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Namelbl.Location = new System.Drawing.Point(80, 94);
            this.Namelbl.Name = "Namelbl";
            this.Namelbl.Size = new System.Drawing.Size(48, 16);
            this.Namelbl.TabIndex = 0;
            this.Namelbl.Text = "Name";
            // 
            // nametxtbx
            // 
            this.nametxtbx.Location = new System.Drawing.Point(280, 93);
            this.nametxtbx.Name = "nametxtbx";
            this.nametxtbx.Size = new System.Drawing.Size(254, 20);
            this.nametxtbx.TabIndex = 1;
            // 
            // titlelbl
            // 
            this.titlelbl.AutoSize = true;
            this.titlelbl.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelbl.Location = new System.Drawing.Point(199, 18);
            this.titlelbl.Name = "titlelbl";
            this.titlelbl.Size = new System.Drawing.Size(217, 34);
            this.titlelbl.TabIndex = 0;
            this.titlelbl.Text = "Add new drug";
            // 
            // Pregcattxtbx
            // 
            this.Pregcattxtbx.Location = new System.Drawing.Point(280, 134);
            this.Pregcattxtbx.Name = "Pregcattxtbx";
            this.Pregcattxtbx.Size = new System.Drawing.Size(254, 20);
            this.Pregcattxtbx.TabIndex = 2;
            // 
            // Pregcatlbl
            // 
            this.Pregcatlbl.AutoSize = true;
            this.Pregcatlbl.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pregcatlbl.Location = new System.Drawing.Point(80, 135);
            this.Pregcatlbl.Name = "Pregcatlbl";
            this.Pregcatlbl.Size = new System.Drawing.Size(194, 16);
            this.Pregcatlbl.TabIndex = 0;
            this.Pregcatlbl.Text = "FDA Pregnancy category";
            // 
            // Savebtn
            // 
            this.Savebtn.Location = new System.Drawing.Point(355, 199);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(126, 42);
            this.Savebtn.TabIndex = 3;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // Addinterbtn
            // 
            this.Addinterbtn.Location = new System.Drawing.Point(133, 199);
            this.Addinterbtn.Name = "Addinterbtn";
            this.Addinterbtn.Size = new System.Drawing.Size(126, 42);
            this.Addinterbtn.TabIndex = 4;
            this.Addinterbtn.Text = "Add interactions";
            this.Addinterbtn.UseVisualStyleBackColor = true;
            this.Addinterbtn.Click += new System.EventHandler(this.Addinterbtn_Click);
            // 
            // AddDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 276);
            this.Controls.Add(this.Addinterbtn);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.Pregcattxtbx);
            this.Controls.Add(this.nametxtbx);
            this.Controls.Add(this.titlelbl);
            this.Controls.Add(this.Pregcatlbl);
            this.Controls.Add(this.Namelbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDrug";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add new drug";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Namelbl;
        private System.Windows.Forms.TextBox nametxtbx;
        private System.Windows.Forms.Label titlelbl;
        private System.Windows.Forms.TextBox Pregcattxtbx;
        private System.Windows.Forms.Label Pregcatlbl;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.Button Addinterbtn;
    }
}