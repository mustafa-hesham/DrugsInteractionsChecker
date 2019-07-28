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
    public partial class editPregCat : Form
    {
        Gethtml source = new Gethtml();
        public editPregCat()
        {
            InitializeComponent();
            AutoCompleteName();
        }

        public void AutoCompleteName()
        {
            drugNametxtbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            drugNametxtbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            drugNametxtbx.AutoCompleteCustomSource = coll;

        }

        private void DrugNametxtbx_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView();
            DV.RowFilter = string.Format("name like '%{0}%'", drugNametxtbx.Text);
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            source.Conn.Close();
            source.MySqlCon();
            MySqlCommand Icom1 = source.Conn.CreateCommand();
            Icom1.CommandText = "UPDATE drugsbasic2 SET pregnancyCat = @cat WHERE name = @name";
            Icom1.Parameters.AddWithValue("@cat", PregCattxtbx.Text);
            Icom1.Parameters.AddWithValue("@name", drugNametxtbx.Text);
            Icom1.ExecuteNonQuery();
            source.Conn.Close();
            string command1 = "SELECT pregnancyCat FROM drugsbasic2 WHERE name = @name";
            MySqlCommand Comm1 = new MySqlCommand(command1, source.Conn);
            source.MySqlCon();
            Comm1.Parameters.AddWithValue("@name", drugNametxtbx.Text);
            MySqlDataReader Reader1 = Comm1.ExecuteReader();
            Reader1.Read();
            string tempName = Reader1["pregnancyCat"].ToString();
            source.Conn.Close();
            if (tempName == PregCattxtbx.Text)
            {
                DialogResult edited = MessageBox.Show("You have edited this drug pregnancy category successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (edited == DialogResult.OK) Close();
            }
            else
            {
                DialogResult failed = MessageBox.Show("Database error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (failed == DialogResult.OK) drugNametxtbx.Focus();
            }
        }

        private void DrugNametxtbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                source.Conn.Close();
                string command12 = "SELECT pregnancyCat FROM drugsbasic2 WHERE name = @name";
                MySqlCommand Comm12 = new MySqlCommand(command12, source.Conn);
                source.MySqlCon();
                Comm12.Parameters.AddWithValue("@name", drugNametxtbx.Text);
                MySqlDataReader Reader12 = Comm12.ExecuteReader();
                Reader12.Read();
                string tempName2 = Reader12["pregnancyCat"].ToString();
                source.Conn.Close();
                PregCattxtbx.Text = tempName2;
            }
        }
    }
}
