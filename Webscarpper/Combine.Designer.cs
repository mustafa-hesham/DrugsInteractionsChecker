namespace Webscarpper
{
    partial class Combine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Combine));
            this.label1 = new System.Windows.Forms.Label();
            this.searchAItxtbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.itemsListbox = new System.Windows.Forms.ListBox();
            this.combinebtn = new System.Windows.Forms.Button();
            this.removeItembtn = new System.Windows.Forms.Button();
            this.removeAllbtn = new System.Windows.Forms.Button();
            this.newCombinationtxtbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(186, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Combine ingredients";
            // 
            // searchAItxtbx
            // 
            this.searchAItxtbx.Location = new System.Drawing.Point(233, 83);
            this.searchAItxtbx.Name = "searchAItxtbx";
            this.searchAItxtbx.Size = new System.Drawing.Size(252, 20);
            this.searchAItxtbx.TabIndex = 1;
            this.searchAItxtbx.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            this.searchAItxtbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchAItxtbx_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Active ingredient";
            // 
            // itemsListbox
            // 
            this.itemsListbox.FormattingEnabled = true;
            this.itemsListbox.Location = new System.Drawing.Point(87, 123);
            this.itemsListbox.Name = "itemsListbox";
            this.itemsListbox.Size = new System.Drawing.Size(398, 69);
            this.itemsListbox.TabIndex = 3;
            // 
            // combinebtn
            // 
            this.combinebtn.Location = new System.Drawing.Point(64, 261);
            this.combinebtn.Name = "combinebtn";
            this.combinebtn.Size = new System.Drawing.Size(119, 41);
            this.combinebtn.TabIndex = 4;
            this.combinebtn.Text = "Combine";
            this.combinebtn.UseVisualStyleBackColor = true;
            this.combinebtn.Click += new System.EventHandler(this.Combinebtn_Click);
            // 
            // removeItembtn
            // 
            this.removeItembtn.Location = new System.Drawing.Point(225, 261);
            this.removeItembtn.Name = "removeItembtn";
            this.removeItembtn.Size = new System.Drawing.Size(119, 41);
            this.removeItembtn.TabIndex = 5;
            this.removeItembtn.Text = "Remove item";
            this.removeItembtn.UseVisualStyleBackColor = true;
            this.removeItembtn.Click += new System.EventHandler(this.RemoveItembtn_Click);
            // 
            // removeAllbtn
            // 
            this.removeAllbtn.Location = new System.Drawing.Point(386, 260);
            this.removeAllbtn.Name = "removeAllbtn";
            this.removeAllbtn.Size = new System.Drawing.Size(119, 41);
            this.removeAllbtn.TabIndex = 6;
            this.removeAllbtn.Text = "Remove all";
            this.removeAllbtn.UseVisualStyleBackColor = true;
            this.removeAllbtn.Click += new System.EventHandler(this.RemoveAllbtn_Click);
            // 
            // newCombinationtxtbx
            // 
            this.newCombinationtxtbx.Location = new System.Drawing.Point(233, 214);
            this.newCombinationtxtbx.Name = "newCombinationtxtbx";
            this.newCombinationtxtbx.Size = new System.Drawing.Size(252, 20);
            this.newCombinationtxtbx.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(103, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Combination";
            // 
            // Combine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 338);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newCombinationtxtbx);
            this.Controls.Add(this.removeAllbtn);
            this.Controls.Add(this.removeItembtn);
            this.Controls.Add(this.combinebtn);
            this.Controls.Add(this.itemsListbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchAItxtbx);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Combine";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Combine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchAItxtbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox itemsListbox;
        private System.Windows.Forms.Button combinebtn;
        private System.Windows.Forms.Button removeItembtn;
        private System.Windows.Forms.Button removeAllbtn;
        private System.Windows.Forms.TextBox newCombinationtxtbx;
        private System.Windows.Forms.Label label3;
    }
}