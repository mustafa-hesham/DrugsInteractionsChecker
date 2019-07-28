namespace Webscarpper
{
    partial class editProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editProduct));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.updatebtn = new System.Windows.Forms.Button();
            this.ProductIdtxtbx = new System.Windows.Forms.TextBox();
            this.Nametxtbx22 = new System.Windows.Forms.TextBox();
            this.Activeingredienttxtbx = new System.Windows.Forms.TextBox();
            this.barcodetxtbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(182, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Edit product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Product name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Active ingredient";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Barcode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Product ID";
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(194, 295);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(127, 46);
            this.updatebtn.TabIndex = 7;
            this.updatebtn.Text = "Update";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.Updatebtn_Click);
            // 
            // ProductIdtxtbx
            // 
            this.ProductIdtxtbx.Location = new System.Drawing.Point(209, 75);
            this.ProductIdtxtbx.Name = "ProductIdtxtbx";
            this.ProductIdtxtbx.ReadOnly = true;
            this.ProductIdtxtbx.Size = new System.Drawing.Size(191, 20);
            this.ProductIdtxtbx.TabIndex = 8;
            // 
            // Nametxtbx22
            // 
            this.Nametxtbx22.Location = new System.Drawing.Point(209, 130);
            this.Nametxtbx22.Name = "Nametxtbx22";
            this.Nametxtbx22.Size = new System.Drawing.Size(191, 20);
            this.Nametxtbx22.TabIndex = 9;
            this.Nametxtbx22.TextChanged += new System.EventHandler(this.Nametxtbx22_TextChanged);
            this.Nametxtbx22.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nametxtbx22_KeyDown);
            // 
            // Activeingredienttxtbx
            // 
            this.Activeingredienttxtbx.Location = new System.Drawing.Point(209, 185);
            this.Activeingredienttxtbx.Name = "Activeingredienttxtbx";
            this.Activeingredienttxtbx.Size = new System.Drawing.Size(191, 20);
            this.Activeingredienttxtbx.TabIndex = 10;
            this.Activeingredienttxtbx.TextChanged += new System.EventHandler(this.Activeingredienttxtbx_TextChanged);
            // 
            // barcodetxtbx
            // 
            this.barcodetxtbx.Location = new System.Drawing.Point(209, 240);
            this.barcodetxtbx.Name = "barcodetxtbx";
            this.barcodetxtbx.Size = new System.Drawing.Size(191, 20);
            this.barcodetxtbx.TabIndex = 11;
            // 
            // editProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 363);
            this.Controls.Add(this.barcodetxtbx);
            this.Controls.Add(this.Activeingredienttxtbx);
            this.Controls.Add(this.Nametxtbx22);
            this.Controls.Add(this.ProductIdtxtbx);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "editProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit product";
            this.Load += new System.EventHandler(this.EditProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.TextBox ProductIdtxtbx;
        private System.Windows.Forms.TextBox Nametxtbx22;
        private System.Windows.Forms.TextBox Activeingredienttxtbx;
        private System.Windows.Forms.TextBox barcodetxtbx;
    }
}