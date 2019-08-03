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
    public partial class AddProduct : Form
    {
        
        Gethtml source = new Gethtml();
        bool idlength, idlength2;
        bool idrep = false;
        bool barcoderep = false;
        public AddProduct()
        {
            InitializeComponent();
            AutoCompleteName();
        }

        public void AutoCompleteName()
        {
            activeIngtxtbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            activeIngtxtbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            source.Conn.Close();
            string command14 = "SELECT name FROM drugsbasic2 ;";
            MySqlCommand Comm14 = new MySqlCommand(command14, source.Conn);
            //Comm4.Parameters.AddWithValue("@name", drugNametxtbx.Text);
            source.MySqlCon();
            MySqlDataReader Reader14 = Comm14.ExecuteReader();
            while (Reader14.Read())
            {

                coll.Add(Reader14["name"].ToString());
            }

            source.Conn.Close();
            activeIngtxtbx.AutoCompleteCustomSource = coll;

        }
        private void ActiveIngtxtbx_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView();
            DV.RowFilter = string.Format("name like '%{0}%'", activeIngtxtbx.Text);
        }

        private void Saveproductbtn_Click(object sender, EventArgs e)
        {
            string tempName3 = activeIngtxtbx.Text;
            source.Conn.Close();
            string command2 = "SELECT id FROM drugsbasic2 WHERE name = @name";
            MySqlCommand Comm2 = new MySqlCommand(command2, source.Conn);
            Comm2.Parameters.AddWithValue("@name", tempName3);
            source.MySqlCon();
            MySqlDataReader Reader2 = Comm2.ExecuteReader();
            Reader2.Read();
            if (Reader2.HasRows)
            {
                string id = Reader2["id"].ToString();
                if (id.Length > 0) idlength = true;
            }
            else
            {
                idlength = false;
            }
            
            source.Conn.Close();
            if (tempName3 == "" || tempName3 == " " || !idlength)
            {
                MessageBox.Show("Enter a valid active ingredient name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                activeIngtxtbx.Focus();
            }

            else
            { 
            source.Conn.Close();
            string command21 = "SELECT id FROM drugsbasic2 WHERE name = @name";
            MySqlCommand Comm21 = new MySqlCommand(command21, source.Conn);
            Comm21.Parameters.AddWithValue("@name", tempName3);
            source.MySqlCon();
            MySqlDataReader Reader21 = Comm21.ExecuteReader();
            Reader21.Read();
            string id2 = Reader21["id"].ToString();
            if (id2.Length > 0) idlength2 = true;
            source.Conn.Close();
            string command3 = "SELECT barcode FROM products WHERE barcode = @barcode";
            MySqlCommand Comm3 = new MySqlCommand(command3, source.Conn);
            Comm3.Parameters.AddWithValue("@barcode", barcodeTxtbx.Text);
            source.MySqlCon();
            MySqlDataReader Reader3 = Comm3.ExecuteReader();
                if (Reader3.HasRows)
                {
                    barcoderep = true;
                }
                else
                {
                    barcoderep = false;
                }
            source.Conn.Close();
                string command31 = "SELECT id FROM products WHERE productname = @productname";
                MySqlCommand Comm31 = new MySqlCommand(command31, source.Conn);
                Comm31.Parameters.AddWithValue("@productname", productNametxtbx.Text);
                source.MySqlCon();
                MySqlDataReader Reader31 = Comm31.ExecuteReader();
                Reader31.Read();
                if (Reader31.HasRows)
                {
                    string repeatedid = Reader31["id"].ToString();
                    if (repeatedid.Length > 0) idrep = true;
                }
                else
                    {
                    idrep = false;
                }
                
                source.Conn.Close();

                if (idlength2 && !barcoderep && !idrep && barcodeTxtbx.Text != "")
            {
                source.Conn.Close();
                source.MySqlCon();
                MySqlCommand Icom = source.Conn.CreateCommand();
                Icom.CommandText = "INSERT INTO products (productname, barcode, foreignID) VALUES(@Insertedname, @barcode, @foreigndrugID)";
                Icom.Parameters.AddWithValue("@Insertedname", productNametxtbx.Text);
                Icom.Parameters.AddWithValue("@barcode", barcodeTxtbx.Text);
                Icom.Parameters.AddWithValue("@foreigndrugID", id2);
                Icom.ExecuteNonQuery();
                source.Conn.Close();
                DialogResult added = MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (added == DialogResult.OK)
                {
                        DialogResult another = MessageBox.Show("Do you want to add another product?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (another == DialogResult.Yes)
                        {
                            activeIngtxtbx.Clear();
                            productNametxtbx.Clear();
                            barcodeTxtbx.Clear();
                            activeIngtxtbx.Focus();
                        }

                        else if (another == DialogResult.No)
                        {
                            Close();
                            
                        }
                    }


            }
            else if (idlength2 && !barcoderep && !idrep && barcodeTxtbx.Text == "")
                {
                    source.Conn.Close();
                    source.MySqlCon();
                    MySqlCommand Icom = source.Conn.CreateCommand();
                    Icom.CommandText = "INSERT INTO products (productname, foreignID) VALUES(@Insertedname, @foreigndrugID)";
                    Icom.Parameters.AddWithValue("@Insertedname", productNametxtbx.Text);
                    //Icom.Parameters.AddWithValue("@barcode", barcodeTxtbx.Text);
                    Icom.Parameters.AddWithValue("@foreigndrugID", id2);
                    Icom.ExecuteNonQuery();
                    source.Conn.Close();
                    DialogResult added = MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (added == DialogResult.OK)
                    {
                        DialogResult another = MessageBox.Show("Do you want to add another product?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (another == DialogResult.Yes)
                        {
                            activeIngtxtbx.Clear();
                            productNametxtbx.Clear();
                            barcodeTxtbx.Clear();
                            activeIngtxtbx.Focus();
                        }

                        else if (another == DialogResult.No)
                        {
                            Close();
                            
                        }
                    }
                }
            else
            {
                DialogResult present = MessageBox.Show("This product is already in the database!", "Duplicate record", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (present == DialogResult.OK)
                {
                    Close();
                }
                else if (present == DialogResult.Cancel) productNametxtbx.Focus();
            }
        }
        }
    }
}
