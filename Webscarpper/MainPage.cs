using HtmlAgilityPack;
using System;
using System.Windows;
using System.Data.Linq;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Net.Http;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace Webscarpper
{
    
    public partial class MainPage : Form
    {
        int currentinter = 0;
        string pregCatstr;
        Gethtml source = new Gethtml();
        List<string> interactions = new List<string>();
        List<string> severities = new List<string>();
        List<string> drug1 = new List<string>();
        List<string> drug2 = new List<string>();
        public MainPage()
        {
            InitializeComponent();
            AutoCompleteName();
            listBox1.Refresh();

        }

        public void CheckInteractions()
        {
            interactions.Clear();
            severities.Clear();
            drug1.Clear();
            drug2.Clear();
            currentinter = 0;

            for (int d = 0; d < listBox1.Items.Count; d++)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (d > i || d == i) continue;
                    else
                    {
                        source.Conn.Close();
                        string command = "SELECT drugsbasic2.name ,interactorsinfo2.drugname, interactorsinfo2.severity, interactorsinfo2.description  FROM drugsbasic2 LEFT JOIN interactorsinfo2 ON drugsbasic2.id = interactorsinfo2.foreigndrugID WHERE drugsbasic2.name = @insertedname AND interactorsinfo2.drugname = @secondname OR interactorsinfo2.drugname = @insertedname AND drugsbasic2.name = @secondname";
                        MySqlCommand Comm = new MySqlCommand(command, source.Conn);
                        string firstdrug = listBox1.Items[d].ToString();
                        string[] firstdrug1 = firstdrug.Split('(');
                        string firstdrug2 = firstdrug1[0].Trim();
                        string seconddrug = listBox1.Items[i].ToString();
                        string[] seconddrug1 = seconddrug.Split('(');
                        string seconddrug2 = seconddrug1[0].Trim();

                        Comm.Parameters.AddWithValue("@insertedname", firstdrug2);
                        Comm.Parameters.AddWithValue("@secondname", seconddrug2);
                        source.MySqlCon();
                        MySqlDataReader Reader = Comm.ExecuteReader();
                        while (Reader.Read())
                        {
                            interactions.Add(Reader["description"].ToString());
                            severities.Add(Reader["severity"].ToString());
                            drug1.Add(Reader["name"].ToString());
                            drug2.Add(Reader["drugname"].ToString());


                        }

                        source.Conn.Close();



                    }
                }
            }
            if (interactions.Count() == 0)
            {
                MessageBox.Show("There are no interactions recorded in the database between these drugs!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                descriptionTxt.Text = interactions[0].ToString();
                severityTXT.Text = severities[0].ToString();
                interactorsTX.Text = drug1[0].ToString() + " <> " + drug2[0].ToString();
            }

            for (int t = 0; t < (interactions.Count() - 1); t++)
            {
                if (interactions[t].ToString() == interactions[t + 1].ToString() && drug1[t].ToString() == drug2[t + 1].ToString())
                {
                    severities.RemoveAt(t);
                    interactions.RemoveAt(t);
                    drug1.RemoveAt(t);
                    drug2.RemoveAt(t);

                }
            }

            drugNametxtbx.Clear();
        }

        private void Invokebtn_Click(object sender, EventArgs e)
        {
            CheckInteractions();
            drugNametxtbx.Focus();
        }

       

        public void AutoCompleteName()
        {
            drugNametxtbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            drugNametxtbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            coll.Clear();
                source.Conn.Close();
                string command4 = "SELECT name FROM drugsbasic2 ;";
                MySqlCommand Comm4 = new MySqlCommand(command4, source.Conn);
                source.MySqlCon();
                MySqlDataReader Reader4 = Comm4.ExecuteReader();
                while (Reader4.Read())
                {
                    coll.Add(Reader4["name"].ToString());
                }

                source.Conn.Close();
                string command5 = "SELECT drugname FROM interactorsinfo2 ;";
                MySqlCommand Comm5 = new MySqlCommand(command5, source.Conn);
                //Comm4.Parameters.AddWithValue("@name", drugNametxtbx.Text);
                source.MySqlCon();
                MySqlDataReader Reader5 = Comm5.ExecuteReader();
                while (Reader5.Read())
                {
                    coll.Add(Reader5["drugname"].ToString());
                }
                source.Conn.Close();

                string command512 = "SELECT productname FROM products ;";
                MySqlCommand Comm512 = new MySqlCommand(command512, source.Conn);
                source.MySqlCon();
                MySqlDataReader Reader512 = Comm512.ExecuteReader();
                while (Reader512.Read())
                {
                    coll.Add(Reader512["productname"].ToString());
                }

            source.Conn.Close();
            drugNametxtbx.AutoCompleteCustomSource = coll;

        }

        

        private void DrugNametxtbx_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView();
                
                DV.RowFilter = string.Format("name like '%{0}%'", drugNametxtbx.Text);
                DV.RowFilter = string.Format("drugname like '%{0}%'", drugNametxtbx.Text);
                DV.RowFilter = string.Format("productname like '%{0}%'", drugNametxtbx.Text);
            
        }

        private void DrugNametxtbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !(int.TryParse(drugNametxtbx.Text.Substring(0, 2), out int n)))
            {
                try
                {
                    source.Conn.Close();
                    string command43 = "SELECT id FROM products WHERE productname = @name";
                    MySqlCommand Comm43 = new MySqlCommand(command43, source.Conn);
                    Comm43.Parameters.AddWithValue("@name", drugNametxtbx.Text);
                    source.MySqlCon();
                    MySqlDataReader Reader43 = Comm43.ExecuteReader();

                    if (Reader43.HasRows)
                    {
                        source.Conn.Close();
                        string command16 = "SELECT drugsbasic2.name ,drugsbasic2.pregnancyCat FROM drugsbasic2 LEFT JOIN products ON drugsbasic2.id = products.foreignID WHERE products.productname = @productname";
                        MySqlCommand Comm16 = new MySqlCommand(command16, source.Conn);
                        Comm16.Parameters.AddWithValue("@productname", drugNametxtbx.Text);
                        source.MySqlCon();
                        MySqlDataReader Reader16 = Comm16.ExecuteReader();
                        Reader16.Read();
                        string drugname16 = Reader16["name"].ToString();
                        string pregCat16 = Reader16["pregnancyCat"].ToString();
                        source.Conn.Close();
                        if (pregCat16 == "" || pregCat16 == " " || pregCat16 == "   ") pregCat16 = "N/A";
                        listBox1.Items.Add(drugname16 + " (FDA-PregCat: " + pregCat16 + ")");
                        listBox1.Refresh();
                        drugNametxtbx.Clear();
                        drugNametxtbx.Focus();
                    }
                    else
                    {
                        source.Conn.Close();
                        string command4 = "SELECT pregnancyCat FROM drugsbasic2 WHERE name = @name";
                        MySqlCommand Comm4 = new MySqlCommand(command4, source.Conn);
                        Comm4.Parameters.AddWithValue("@name", drugNametxtbx.Text);
                        source.MySqlCon();
                        MySqlDataReader Reader4 = Comm4.ExecuteReader();

                        if (Reader4.HasRows)
                        {
                            Reader4.Read();
                            pregCatstr = Reader4["pregnancyCAT"].ToString();
                            source.Conn.Close();
                            if (pregCatstr == "" || pregCatstr == " " || pregCatstr == "   ") pregCatstr = "N/A";
                            source.Conn.Close();
                        }
                        else
                        {
                            pregCatstr = "N/A";
                            source.Conn.Close();
                        }
                        source.Conn.Close();
                        listBox1.Items.Add(drugNametxtbx.Text + " (FDA-PregCat: " + pregCatstr + ")");
                        listBox1.Refresh();
                        drugNametxtbx.Clear();
                        drugNametxtbx.Focus();
                    }
                   
                }
                catch (Exception)
                {
                    ;
                }
            }

            else if (e.KeyCode == Keys.Enter && int.TryParse(drugNametxtbx.Text.Substring(0, 2), out int t))
            {
                source.Conn.Close();
                string command16 = "SELECT drugsbasic2.name ,drugsbasic2.pregnancyCat FROM drugsbasic2 LEFT JOIN products ON drugsbasic2.id = products.foreignID WHERE products.barcode = @barcode";
                MySqlCommand Comm16 = new MySqlCommand(command16, source.Conn);
                Comm16.Parameters.AddWithValue("@barcode", drugNametxtbx.Text);
                source.MySqlCon();
                MySqlDataReader Reader16 = Comm16.ExecuteReader();
                if (Reader16.HasRows) { 
                Reader16.Read();
                string drugname16 = Reader16["name"].ToString();
                string pregCat16 = Reader16["pregnancyCat"].ToString();
                source.Conn.Close();
                if (pregCat16 == "" || pregCat16 == " " || pregCat16 == "   ") pregCat16 = "N/A";
                listBox1.Items.Add(drugname16 + " (FDA-PregCat: " + pregCat16 + ")");
                listBox1.Refresh();
                drugNametxtbx.Clear();
                drugNametxtbx.Focus();
                }
                else
                {
                    MessageBox.Show("This barcode is not found in the database!", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    source.Conn.Close();
                }
            }

            if (e.KeyCode == Keys.F11)
            {
                CheckInteractions();
                drugNametxtbx.Focus();
            }
            if (e.KeyCode == Keys.Right)
            {
                try
                {

                    if (currentinter < (severities.Count - 1))
                    {
                        descriptionTxt.Text = interactions[currentinter + 1].ToString();
                        severityTXT.Text = severities[currentinter + 1].ToString();
                        interactorsTX.Text = drug1[currentinter + 1].ToString() + " <> " + drug2[currentinter + 1].ToString();
                        currentinter = currentinter + 1;
                    }
                }
                catch (Exception)
                {
                    ;
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                try
                {
                    if (currentinter > 0)

                    {
                        descriptionTxt.Text = interactions[currentinter - 1].ToString();
                        severityTXT.Text = severities[currentinter - 1].ToString();
                        interactorsTX.Text = drug1[currentinter - 1].ToString() + " <> " + drug2[currentinter - 1].ToString();
                        currentinter = currentinter - 1;
                    }
                }
                catch (Exception)
                {
                    ;
                }
            }

            if (e.KeyCode == Keys.F7)
            {
                try
                {
                    listBox1.Items.Clear();
                    descriptionTxt.Clear();
                    interactorsTX.Clear();
                    severityTXT.Clear();
                    severityTXT.BackColor = System.Drawing.Color.White;
                    drugNametxtbx.Focus();
                }
                catch (Exception)
                {
                    ;
                }
            }
            }


        private void RemoveItembtn_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                drugNametxtbx.Focus();
            }
            catch (Exception)
            {
                ;
            }
            
            
        }

        private void RemoveAllbtn_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                descriptionTxt.Clear();
                interactorsTX.Clear();
                severityTXT.Clear();
                severityTXT.BackColor = System.Drawing.Color.White;
                drugNametxtbx.Focus();
            }
            catch (Exception)
            {
                ;
            }
            
        }

        private void Nextbtn_Click(object sender, EventArgs e)
        {
            try
            {

            if (currentinter < (severities.Count-1))
            {
                descriptionTxt.Text = interactions[currentinter + 1].ToString();
                severityTXT.Text = severities[currentinter + 1].ToString();
                interactorsTX.Text = drug1[currentinter + 1].ToString() + " <> " + drug2[currentinter + 1].ToString();
                currentinter = currentinter + 1;
            }
            }
            catch (Exception)
            {
                ;
            }


        }

        private void Previousbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentinter > 0)

                {
                    descriptionTxt.Text = interactions[currentinter - 1].ToString();
                    severityTXT.Text = severities[currentinter - 1].ToString();
                    interactorsTX.Text = drug1[currentinter - 1].ToString() + " <> " + drug2[currentinter - 1].ToString();
                    currentinter = currentinter - 1;
                }
            }
            catch (Exception)
            {
                ;
            }

        }

        private void SeverityTXT_TextChanged(object sender, EventArgs e)
        {
            if (severityTXT.Text == "Minor") severityTXT.BackColor = System.Drawing.Color.Gray;
            else if (severityTXT.Text == "Moderate") severityTXT.BackColor = System.Drawing.Color.Orange;
            else if (severityTXT.Text == "Major") severityTXT.BackColor = System.Drawing.Color.OrangeRed;
            else severityTXT.BackColor = System.Drawing.Color.Wheat;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MainPage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes) Close();
            else if (dialogResult == DialogResult.No) drugNametxtbx.Focus();
            

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AddDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDrug addDrug = new AddDrug();
            addDrug.ShowDialog();
        }

        private void AddProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
        }

        private void EditDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editPregCat editPregCat = new editPregCat();
            editPregCat.ShowDialog();
        }
        ToolTip t1 = new ToolTip();
        ToolTip t2 = new ToolTip();
        private void Invokebtn_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Click here or press F11 to check for interactions.", invokebtn);
        }

        private void MainPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                try
                {

                    if (currentinter < (severities.Count - 1))
                    {
                        descriptionTxt.Text = interactions[currentinter + 1].ToString();
                        severityTXT.Text = severities[currentinter + 1].ToString();
                        interactorsTX.Text = drug1[currentinter + 1].ToString() + " <> " + drug2[currentinter + 1].ToString();
                        currentinter = currentinter + 1;
                    }
                }
                catch (Exception)
                {
                    ;
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                try
                {
                    if (currentinter > 0)

                    {
                        descriptionTxt.Text = interactions[currentinter - 1].ToString();
                        severityTXT.Text = severities[currentinter - 1].ToString();
                        interactorsTX.Text = drug1[currentinter - 1].ToString() + " <> " + drug2[currentinter - 1].ToString();
                        currentinter = currentinter - 1;
                    }
                }
                catch (Exception)
                {
                    ;
                }
            }
            }

        private void RemoveAllbtn_MouseHover(object sender, EventArgs e)
        {
            t2.Show("Click here or press F7 to clear list.", RemoveAllbtn);
        }

        private void EditBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editProduct editProduct = new editProduct();
            editProduct.ShowDialog();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about about = new about();
            about.ShowDialog();
        }
        //Function end.
    }
}
