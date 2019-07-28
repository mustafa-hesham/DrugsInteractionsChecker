using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webscarpper
{
    public partial class editProduct : Form
    {
        Gethtml source1 = new Gethtml();
        MainPage MainPage = new MainPage();
        string idnorepeat;
        string repeatedname;
        string foreigID;

        public editProduct()
        {
            InitializeComponent();
            AutoCompleteProductName();
            AutoCompleteProductactiveingredient();
        }
        public void AutoCompleteProductName()
        {
            Nametxtbx22.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Nametxtbx22.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            source1.Conn.Close();
            string command52 = "SELECT productname FROM products ;";
            MySqlCommand Comm52 = new MySqlCommand(command52, source1.Conn);
            source1.MySqlCon();
            MySqlDataReader Reader52 = Comm52.ExecuteReader();
            while (Reader52.Read())
            {
                coll.Add(Reader52["productname"].ToString());
            }
            source1.Conn.Close();
            Nametxtbx22.AutoCompleteCustomSource = coll;

        }

        public void AutoCompleteProductactiveingredient()
        {
            Activeingredienttxtbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Activeingredienttxtbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll1 = new AutoCompleteStringCollection();

            source1.Conn.Close();
            string command521 = "SELECT name FROM drugsbasic2 ;";
            MySqlCommand Comm521 = new MySqlCommand(command521, source1.Conn);
            source1.MySqlCon();
            MySqlDataReader Reader521 = Comm521.ExecuteReader();
            while (Reader521.Read())
            {
                coll1.Add(Reader521["name"].ToString());
            }
            source1.Conn.Close();
            Activeingredienttxtbx.AutoCompleteCustomSource = coll1;

        }



        private void EditProduct_Load(object sender, EventArgs e)
        {
            Nametxtbx22.Focus();
        }

        private void Nametxtbx22_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView();
            DV.RowFilter = string.Format("productname like '%{0}%'", Nametxtbx22.Text);
        }

        private void Nametxtbx22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                source1.Conn.Close();
                string command53 = "SELECT id, barcode, foreignID FROM products WHERE productname = @productname";
                MySqlCommand Comm53 = new MySqlCommand(command53, source1.Conn);
                Comm53.Parameters.AddWithValue("@productname", Nametxtbx22.Text);
                source1.MySqlCon();
                MySqlDataReader Reader53 = Comm53.ExecuteReader();
                Reader53.Read();
                ProductIdtxtbx.Text = Reader53["id"].ToString();
                barcodetxtbx.Text = Reader53["barcode"].ToString();
                string activeIng = Reader53["foreignID"].ToString();
                source1.Conn.Close();

                source1.Conn.Close();
                string command54 = "SELECT name FROM drugsbasic2 WHERE id = @id";
                MySqlCommand Comm54 = new MySqlCommand(command54, source1.Conn);
                Comm54.Parameters.AddWithValue("@id", activeIng);
                source1.MySqlCon();
                MySqlDataReader Reader54 = Comm54.ExecuteReader();
                Reader54.Read();
                Activeingredienttxtbx.Text = Reader54["name"].ToString();
                source1.Conn.Close();

            }
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {

            source1.Conn.Close();
            string command55 = "SELECT id FROM drugsbasic2 WHERE name = @name";
            MySqlCommand Comm55 = new MySqlCommand(command55, source1.Conn);
            Comm55.Parameters.AddWithValue("@name", Activeingredienttxtbx.Text);
            source1.MySqlCon();
            MySqlDataReader Reader55 = Comm55.ExecuteReader();
            if (Reader55.HasRows)
            {
                Reader55.Read();
                foreigID = Reader55["id"].ToString();
                source1.Conn.Close();
                
                    string command1 = "SELECT id, productname FROM products WHERE id = @id";
                    MySqlCommand Comm1 = new MySqlCommand(command1, source1.Conn);
                    Comm1.Parameters.AddWithValue("@id", ProductIdtxtbx.Text);
                    source1.MySqlCon();
                    MySqlDataReader Reader1 = Comm1.ExecuteReader();
                    Reader1.Read();
                    idnorepeat = Reader1["id"].ToString();
                    repeatedname = Reader1["productname"].ToString();
                    source1.Conn.Close();
                //}

                if (idnorepeat == ProductIdtxtbx.Text && repeatedname == Nametxtbx22.Text && barcodetxtbx.Text != "")
                {
                    source1.Conn.Close();
                    source1.MySqlCon();
                    MySqlCommand Icom1 = source1.Conn.CreateCommand();
                    Icom1.CommandText = "UPDATE products SET productname = @productname, barcode = @barcode, foreignID = @foreignID WHERE id = @id";
                    Icom1.Parameters.AddWithValue("@productname", Nametxtbx22.Text);
                    Icom1.Parameters.AddWithValue("@barcode", barcodetxtbx.Text);
                    Icom1.Parameters.AddWithValue("@foreignID", foreigID);
                    Icom1.Parameters.AddWithValue("@id", ProductIdtxtbx.Text);
                    Icom1.ExecuteNonQuery();
                    source1.Conn.Close();

                    DialogResult Updated = MessageBox.Show("This product is successfully updated!", "Successful update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Updated == DialogResult.OK)
                    {
                        Close();
                        MainPage.AutoCompleteName();
                    }
                }
                else if (idnorepeat != ProductIdtxtbx.Text && barcodetxtbx.Text != "")
                {
                    source1.Conn.Close();
                    string command12 = "SELECT productname FROM products WHERE barcode = @barcode";
                    MySqlCommand Comm12 = new MySqlCommand(command12, source1.Conn);
                    Comm12.Parameters.AddWithValue("@barcode", barcodetxtbx.Text);
                    source1.MySqlCon();
                    MySqlDataReader Reader12 = Comm12.ExecuteReader();
                    Reader12.Read();
                    string repeatedbarcodename = Reader12["productname"].ToString();
                    source1.Conn.Close();
                    MessageBox.Show("This barcode is assigned to another product!" + "\n" + repeatedbarcodename, "Barcode error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (idnorepeat == ProductIdtxtbx.Text && repeatedname == Nametxtbx22.Text && barcodetxtbx.Text == "")
                {
                    source1.Conn.Close();
                    source1.MySqlCon();
                    MySqlCommand Icom1 = source1.Conn.CreateCommand();
                    Icom1.CommandText = "UPDATE products SET productname = @productname, barcode = NULL ,foreignID = @foreignID WHERE id = @id";
                    Icom1.Parameters.AddWithValue("@productname", Nametxtbx22.Text);
                    Icom1.Parameters.AddWithValue("@foreignID", foreigID);
                    Icom1.Parameters.AddWithValue("@id", ProductIdtxtbx.Text);
                    Icom1.ExecuteNonQuery();
                    source1.Conn.Close();

                    DialogResult Updated = MessageBox.Show("This product is successfully updated!", "Successful update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Updated == DialogResult.OK)
                    {
                        Close();
                        MainPage.AutoCompleteName();
                    }
                }
                else if (idnorepeat == ProductIdtxtbx.Text && repeatedname != Nametxtbx22.Text && barcodetxtbx.Text != "")
                {
                    DialogResult changename = MessageBox.Show("Are you sure you want to change the name of this product?", "Record name change", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (changename == DialogResult.Yes)
                    {
                        source1.Conn.Close();
                        source1.MySqlCon();
                        MySqlCommand Icom1 = source1.Conn.CreateCommand();
                        Icom1.CommandText = "UPDATE products SET productname = @productname, barcode = @barcode, foreignID = @foreignID WHERE id = @id";
                        Icom1.Parameters.AddWithValue("@productname", Nametxtbx22.Text);
                        Icom1.Parameters.AddWithValue("@barcode", barcodetxtbx.Text);
                        Icom1.Parameters.AddWithValue("@foreignID", foreigID);
                        Icom1.Parameters.AddWithValue("@id", ProductIdtxtbx.Text);
                        Icom1.ExecuteNonQuery();
                        source1.Conn.Close();

                        DialogResult Updated = MessageBox.Show("This product is successfully updated!", "Successful update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Updated == DialogResult.OK)
                        {
                            Close();
                            MainPage.AutoCompleteName();
                        }
                    }

                    else if (changename == DialogResult.No)
                    {
                        Nametxtbx22.Focus();
                    }
                    else if (changename == DialogResult.Cancel)
                    {
                        Close();
                    }

                }
                else if (idnorepeat == ProductIdtxtbx.Text && repeatedname != Nametxtbx22.Text && barcodetxtbx.Text == "")
                {
                    DialogResult changename = MessageBox.Show("Are you sure you want to change the name of this product?", "Record name change", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (changename == DialogResult.Yes)
                    {
                        source1.Conn.Close();
                        source1.MySqlCon();
                        MySqlCommand Icom1 = source1.Conn.CreateCommand();
                        Icom1.CommandText = "UPDATE products SET productname = @productname, foreignID = @foreignID WHERE id = @id";
                        Icom1.Parameters.AddWithValue("@productname", Nametxtbx22.Text);
                        Icom1.Parameters.AddWithValue("@foreignID", foreigID);
                        Icom1.Parameters.AddWithValue("@id", ProductIdtxtbx.Text);
                        Icom1.ExecuteNonQuery();
                        source1.Conn.Close();

                        DialogResult Updated = MessageBox.Show("This product is successfully updated!", "Successful update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Updated == DialogResult.OK)
                        {
                            Close();
                        }
                    }

                    else if (changename == DialogResult.No)
                    {
                        Nametxtbx22.Focus();
                    }
                    else if (changename == DialogResult.Cancel)
                    {
                        Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("Enter a valid active ingredient name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Activeingredienttxtbx.Focus();
                source1.Conn.Close();
            }
 
        }

        private void Activeingredienttxtbx_TextChanged(object sender, EventArgs e)
        {
            DataView DV1 = new DataView();
            DV1.RowFilter = string.Format("name like '%{0}%'", Activeingredienttxtbx.Text);
        }
        //Fucntion ends here
    }
}
