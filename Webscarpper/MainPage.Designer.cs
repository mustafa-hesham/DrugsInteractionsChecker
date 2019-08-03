namespace Webscarpper
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.invokebtn = new System.Windows.Forms.Button();
            this.drugNametxtbx = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.interactorsTX = new System.Windows.Forms.TextBox();
            this.descriptionTxt = new System.Windows.Forms.TextBox();
            this.severityTXT = new System.Windows.Forms.TextBox();
            this.RemoveItembtn = new System.Windows.Forms.Button();
            this.RemoveAllbtn = new System.Windows.Forms.Button();
            this.Previousbtn = new System.Windows.Forms.Button();
            this.Nextbtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDrugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDrugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Closebtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editBarcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // invokebtn
            // 
            this.invokebtn.Location = new System.Drawing.Point(28, 207);
            this.invokebtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.invokebtn.Name = "invokebtn";
            this.invokebtn.Size = new System.Drawing.Size(446, 44);
            this.invokebtn.TabIndex = 0;
            this.invokebtn.Text = "Check for interactions";
            this.invokebtn.UseVisualStyleBackColor = true;
            this.invokebtn.Click += new System.EventHandler(this.Invokebtn_Click);
            this.invokebtn.MouseHover += new System.EventHandler(this.Invokebtn_MouseHover);
            // 
            // drugNametxtbx
            // 
            this.drugNametxtbx.Location = new System.Drawing.Point(28, 168);
            this.drugNametxtbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.drugNametxtbx.Name = "drugNametxtbx";
            this.drugNametxtbx.Size = new System.Drawing.Size(445, 22);
            this.drugNametxtbx.TabIndex = 5;
            this.drugNametxtbx.TextChanged += new System.EventHandler(this.DrugNametxtbx_TextChanged);
            this.drugNametxtbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DrugNametxtbx_KeyDown);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(29, 266);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(445, 334);
            this.listBox1.TabIndex = 8;
            // 
            // interactorsTX
            // 
            this.interactorsTX.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interactorsTX.Location = new System.Drawing.Point(515, 168);
            this.interactorsTX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.interactorsTX.Name = "interactorsTX";
            this.interactorsTX.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.interactorsTX.Size = new System.Drawing.Size(543, 23);
            this.interactorsTX.TabIndex = 10;
            this.interactorsTX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // descriptionTxt
            // 
            this.descriptionTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.descriptionTxt.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTxt.Location = new System.Drawing.Point(515, 266);
            this.descriptionTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.descriptionTxt.Multiline = true;
            this.descriptionTxt.Name = "descriptionTxt";
            this.descriptionTxt.ReadOnly = true;
            this.descriptionTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTxt.Size = new System.Drawing.Size(543, 334);
            this.descriptionTxt.TabIndex = 11;
            // 
            // severityTXT
            // 
            this.severityTXT.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.severityTXT.Location = new System.Drawing.Point(690, 218);
            this.severityTXT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.severityTXT.Name = "severityTXT";
            this.severityTXT.Size = new System.Drawing.Size(153, 27);
            this.severityTXT.TabIndex = 10;
            this.severityTXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.severityTXT.TextChanged += new System.EventHandler(this.SeverityTXT_TextChanged);
            // 
            // RemoveItembtn
            // 
            this.RemoveItembtn.Location = new System.Drawing.Point(313, 627);
            this.RemoveItembtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RemoveItembtn.Name = "RemoveItembtn";
            this.RemoveItembtn.Size = new System.Drawing.Size(161, 54);
            this.RemoveItembtn.TabIndex = 12;
            this.RemoveItembtn.Text = "Remove item";
            this.RemoveItembtn.UseVisualStyleBackColor = true;
            this.RemoveItembtn.Click += new System.EventHandler(this.RemoveItembtn_Click);
            // 
            // RemoveAllbtn
            // 
            this.RemoveAllbtn.Location = new System.Drawing.Point(28, 627);
            this.RemoveAllbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RemoveAllbtn.Name = "RemoveAllbtn";
            this.RemoveAllbtn.Size = new System.Drawing.Size(161, 54);
            this.RemoveAllbtn.TabIndex = 12;
            this.RemoveAllbtn.Text = "Remove all";
            this.RemoveAllbtn.UseVisualStyleBackColor = true;
            this.RemoveAllbtn.Click += new System.EventHandler(this.RemoveAllbtn_Click);
            this.RemoveAllbtn.MouseHover += new System.EventHandler(this.RemoveAllbtn_MouseHover);
            // 
            // Previousbtn
            // 
            this.Previousbtn.Location = new System.Drawing.Point(554, 627);
            this.Previousbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Previousbtn.Name = "Previousbtn";
            this.Previousbtn.Size = new System.Drawing.Size(161, 54);
            this.Previousbtn.TabIndex = 13;
            this.Previousbtn.Text = "<< Previous";
            this.Previousbtn.UseVisualStyleBackColor = true;
            this.Previousbtn.Click += new System.EventHandler(this.Previousbtn_Click);
            // 
            // Nextbtn
            // 
            this.Nextbtn.Location = new System.Drawing.Point(838, 627);
            this.Nextbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Nextbtn.Name = "Nextbtn";
            this.Nextbtn.Size = new System.Drawing.Size(161, 54);
            this.Nextbtn.TabIndex = 14;
            this.Nextbtn.Text = "Next >>";
            this.Nextbtn.UseVisualStyleBackColor = true;
            this.Nextbtn.Click += new System.EventHandler(this.Nextbtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.productToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1082, 25);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDrugToolStripMenuItem,
            this.editDrugToolStripMenuItem});
            this.mainToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(79, 21);
            this.mainToolStripMenuItem.Text = "Ingredient";
            // 
            // addDrugToolStripMenuItem
            // 
            this.addDrugToolStripMenuItem.Name = "addDrugToolStripMenuItem";
            this.addDrugToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.addDrugToolStripMenuItem.Text = "Add drug";
            this.addDrugToolStripMenuItem.Click += new System.EventHandler(this.AddDrugToolStripMenuItem_Click);
            // 
            // editDrugToolStripMenuItem
            // 
            this.editDrugToolStripMenuItem.Name = "editDrugToolStripMenuItem";
            this.editDrugToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.editDrugToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.editDrugToolStripMenuItem.Text = "Edit drug pregnancy category";
            this.editDrugToolStripMenuItem.Click += new System.EventHandler(this.EditDrugToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Enter an ingredient, a product name, a barcode or a disease";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::Webscarpper.Properties.Resources.medicine_drugs_stock_illustration_2907548_1;
            this.pictureBox1.Location = new System.Drawing.Point(332, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.BackgroundImage = global::Webscarpper.Properties.Resources.download__2_;
            this.button1.Location = new System.Drawing.Point(997, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Closebtn
            // 
            this.Closebtn.BackColor = System.Drawing.Color.White;
            this.Closebtn.BackgroundImage = global::Webscarpper.Properties.Resources.download1;
            this.Closebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Closebtn.Location = new System.Drawing.Point(1035, 4);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(35, 32);
            this.Closebtn.TabIndex = 15;
            this.Closebtn.UseVisualStyleBackColor = false;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(432, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Drugs interactions checker";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProductToolStripMenuItem,
            this.editBarcodeToolStripMenuItem});
            this.productToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.productToolStripMenuItem.Text = "Product";
            // 
            // addProductToolStripMenuItem
            // 
            this.addProductToolStripMenuItem.Name = "addProductToolStripMenuItem";
            this.addProductToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.addProductToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addProductToolStripMenuItem.Text = "Add product";
            this.addProductToolStripMenuItem.Click += new System.EventHandler(this.AddProductToolStripMenuItem_Click_1);
            // 
            // editBarcodeToolStripMenuItem
            // 
            this.editBarcodeToolStripMenuItem.Name = "editBarcodeToolStripMenuItem";
            this.editBarcodeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editBarcodeToolStripMenuItem.Text = "Edit product";
            this.editBarcodeToolStripMenuItem.Click += new System.EventHandler(this.EditBarcodeToolStripMenuItem_Click_1);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 700);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Closebtn);
            this.Controls.Add(this.Nextbtn);
            this.Controls.Add(this.Previousbtn);
            this.Controls.Add(this.RemoveAllbtn);
            this.Controls.Add(this.RemoveItembtn);
            this.Controls.Add(this.descriptionTxt);
            this.Controls.Add(this.severityTXT);
            this.Controls.Add(this.interactorsTX);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.drugNametxtbx);
            this.Controls.Add(this.invokebtn);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drug interactions checker";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainPage_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPage_MouseDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button invokebtn;
        private System.Windows.Forms.TextBox drugNametxtbx;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox interactorsTX;
        private System.Windows.Forms.TextBox descriptionTxt;
        private System.Windows.Forms.TextBox severityTXT;
        private System.Windows.Forms.Button RemoveItembtn;
        private System.Windows.Forms.Button RemoveAllbtn;
        private System.Windows.Forms.Button Previousbtn;
        private System.Windows.Forms.Button Nextbtn;
        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDrugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDrugToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editBarcodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

