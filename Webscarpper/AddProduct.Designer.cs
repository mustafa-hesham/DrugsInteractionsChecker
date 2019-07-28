namespace Webscarpper
{
    partial class AddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            this.label1 = new System.Windows.Forms.Label();
            this.activeIngtxtbx = new System.Windows.Forms.TextBox();
            this.productNametxtbx = new System.Windows.Forms.TextBox();
            this.barcodeTxtbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Saveproductbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add new commercial product";
            // 
            // activeIngtxtbx
            // 
            this.activeIngtxtbx.Location = new System.Drawing.Point(216, 104);
            this.activeIngtxtbx.Name = "activeIngtxtbx";
            this.activeIngtxtbx.Size = new System.Drawing.Size(299, 20);
            this.activeIngtxtbx.TabIndex = 1;
            this.activeIngtxtbx.TextChanged += new System.EventHandler(this.ActiveIngtxtbx_TextChanged);
            // 
            // productNametxtbx
            // 
            this.productNametxtbx.Location = new System.Drawing.Point(216, 158);
            this.productNametxtbx.Name = "productNametxtbx";
            this.productNametxtbx.Size = new System.Drawing.Size(299, 20);
            this.productNametxtbx.TabIndex = 2;
            // 
            // barcodeTxtbx
            // 
            this.barcodeTxtbx.Location = new System.Drawing.Point(216, 212);
            this.barcodeTxtbx.Name = "barcodeTxtbx";
            this.barcodeTxtbx.Size = new System.Drawing.Size(299, 20);
            this.barcodeTxtbx.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Active Ingredient(s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Product name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(95, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Barcode";
            // 
            // Saveproductbtn
            // 
            this.Saveproductbtn.Location = new System.Drawing.Point(223, 269);
            this.Saveproductbtn.Name = "Saveproductbtn";
            this.Saveproductbtn.Size = new System.Drawing.Size(119, 41);
            this.Saveproductbtn.TabIndex = 5;
            this.Saveproductbtn.Text = "Save";
            this.Saveproductbtn.UseVisualStyleBackColor = true;
            this.Saveproductbtn.Click += new System.EventHandler(this.Saveproductbtn_Click);
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 334);
            this.Controls.Add(this.Saveproductbtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.barcodeTxtbx);
            this.Controls.Add(this.productNametxtbx);
            this.Controls.Add(this.activeIngtxtbx);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox activeIngtxtbx;
        private System.Windows.Forms.TextBox productNametxtbx;
        private System.Windows.Forms.TextBox barcodeTxtbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Saveproductbtn;
    }
}