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
    public partial class Combine : Form
    {

        Gethtml source = new Gethtml();
        string newCombination;
        string pregcategory = "A";
        bool Severe = false;
        bool repeatedID = false;
        bool presentName = false;
        string newCombinationID;
        string tempfoundname;
        bool namerepeated;
       
        public List<bool> temp = new List<bool>();
        public Combine()
        {
            InitializeComponent();
            AutoCompleteName();
        }
        public void AutoCompleteName()
        {
            searchAItxtbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchAItxtbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            searchAItxtbx.AutoCompleteCustomSource = coll;

        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView();
            DV.RowFilter = string.Format("name like '%{0}%'", searchAItxtbx.Text);
        }

        private void SearchAItxtbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                source.Conn.Close();
                string command2 = "SELECT id FROM drugsbasic2 WHERE name = @name";
                MySqlCommand Comm2 = new MySqlCommand(command2, source.Conn);
                Comm2.Parameters.AddWithValue("@name", searchAItxtbx.Text);
                source.MySqlCon();
                MySqlDataReader Reader2 = Comm2.ExecuteReader();
                if (Reader2.HasRows)
                {
                    itemsListbox.Items.Add(searchAItxtbx.Text);
                    searchAItxtbx.Clear();
                    searchAItxtbx.Focus();
                }
                else
                {
                    MessageBox.Show("Enter a valid active ingredient name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    searchAItxtbx.Clear();
                    searchAItxtbx.Focus();
                }
                
            }
        }

        private void RemoveItembtn_Click(object sender, EventArgs e)
        {
            try
            {
                itemsListbox.Items.RemoveAt(itemsListbox.SelectedIndex);
                searchAItxtbx.Focus();
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
                itemsListbox.Items.Clear();
                searchAItxtbx.Focus();
                newCombinationtxtbx.Clear();
                pregcategory = "A";
                newCombination = "";
            }
            catch (Exception)
            {
                ;
            }
        }

        private void Combinebtn_Click(object sender, EventArgs e)
        {
            List<string> drugnames = new List<string>();
            List<string> pregCats = new List<string>();
            List<string> interactionsSever = new List<string>();
            List<string> drugID = new List<string>();
            List<string> severities = new List<string>();
            List<string> descriptions = new List<string>();
            List<string> drugName = new List<string>();
            List<string> searchingforrepeated = new List<string>();
            
            presentName = false;
            Severe = false;
            namerepeated = false;

            try
            {
                for (int x = 0; x < itemsListbox.Items.Count; x++)
            {
                source.Conn.Close();
                string command3 = "SELECT id, pregnancyCat FROM drugsbasic2 WHERE name = @name";
                MySqlCommand Comm3 = new MySqlCommand(command3, source.Conn);
                Comm3.Parameters.AddWithValue("@name", itemsListbox.Items[x].ToString());
                source.MySqlCon();
                MySqlDataReader Reader3 = Comm3.ExecuteReader();
                while (Reader3.Read())
                {
                    drugnames.Add(Reader3["id"].ToString());
                    pregCats.Add(Reader3["pregnancyCat"].ToString());
                }
            }

            for (int x = 0; x < itemsListbox.Items.Count; x++)
            {
                newCombination += itemsListbox.Items[x].ToString() + "-";
                if (pregCats[x] == "")
                {
                    pregcategory = "Not Assigned";
                }
                else if (pregCats[x] != "")
                {

                    if (pregcategory[0] < pregCats[x][0] && pregCats[x][0] != 'N' && pregcategory[0] != 'N')
                    {
                        pregcategory = pregCats[x];
                    }
                    else if (pregCats[x][0] == 'N' && pregcategory[0] != 'N')
                    {
                        pregcategory = "Not Assigned";
                    }
                    else if (pregCats[x][0] != 'N' && pregcategory[0] == 'N')
                    {

                        pregcategory = "Not Assigned";
                    }
                }

            }

            newCombinationtxtbx.Clear();
            //newCombinationtxtbx.Text = pregcategory;
            newCombination = newCombination.Remove(newCombination.Length - 1);
            newCombinationtxtbx.Text = newCombination;

            DialogResult result = MessageBox.Show("Are you sure you want to insert this combination?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                itemsListbox.Items.Clear();
                searchAItxtbx.Focus();
                newCombinationtxtbx.Clear();
                pregcategory = "A";
            }

            else if (result == DialogResult.No)
            {
                Close();

            }

            else if (result == DialogResult.Yes)
            {

                for (int r = 0; r < itemsListbox.Items.Count; r++)
                {
                    for (int x = 0; x < itemsListbox.Items.Count; x++)
                    {
                        source.Conn.Close();
                        string command = "SELECT drugsbasic2.name ,interactorsinfo2.drugname, interactorsinfo2.severity, interactorsinfo2.description  FROM drugsbasic2 LEFT JOIN interactorsinfo2 ON drugsbasic2.id = interactorsinfo2.foreigndrugID WHERE drugsbasic2.name = @insertedname AND interactorsinfo2.drugname = @secondname OR interactorsinfo2.drugname = @insertedname AND drugsbasic2.name = @secondname";
                        MySqlCommand Comm = new MySqlCommand(command, source.Conn);
                        Comm.Parameters.AddWithValue("@insertedname", itemsListbox.Items[r]);
                        Comm.Parameters.AddWithValue("@secondname", itemsListbox.Items[x]);
                        source.MySqlCon();
                        MySqlDataReader Reader = Comm.ExecuteReader();
                        while (Reader.Read())
                        {
                            interactionsSever.Add(Reader["severity"].ToString());
                        }
                        source.Conn.Close();
                    }


                }

                for (int d = 0; d < interactionsSever.Count(); d++)
                {
                    if (interactionsSever[d] == "Moderate" || interactionsSever[d] == "Major")
                    {
                        Severe = true;
                    }
                }

                if (Severe == true)
                {
                    MessageBox.Show("This combination has severe interactions!", "Antagonism", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    itemsListbox.Items.Clear();
                    searchAItxtbx.Focus();
                    newCombinationtxtbx.Clear();
                    pregcategory = "A";
                    newCombination = "";
                }

                else
                {
                    //source.Conn.Close();
                    //string tempName3 = newCombination;
                    //string command2 = "SELECT id FROM drugsbasic2 WHERE name = @name";
                    //MySqlCommand Comm2 = new MySqlCommand(command2, source.Conn);
                    //Comm2.Parameters.AddWithValue("@name", tempName3);
                    //source.MySqlCon();
                    //MySqlDataReader Reader2 = Comm2.ExecuteReader();

                    //if (Reader2.HasRows)
                    //{
                    //    presentName = true;
                    //    MessageBox.Show("This drug is already present in the database!", "Duplicate record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    source.Conn.Close();
                    //    itemsListbox.Items.Clear();
                    //    searchAItxtbx.Focus();
                    //    newCombinationtxtbx.Clear();
                    //    pregcategory = "A";
                    //    newCombination = "";

                    //}

                    //else
                    //{
                    //    source.Conn.Close();
                    //    source.MySqlCon();
                    //    MySqlCommand Icom = source.Conn.CreateCommand();
                    //    //Icom.CommandText = "UPDATE interactorsinfo2 SET drugname = @Insertedname, severity = @severity, description = @description, foreigndrugID = @foreignID";
                    //    Icom.CommandText = "INSERT INTO drugsbasic2 (name, pregnancyCat) VALUES(@Insertedname, @pregcat)";
                    //    Icom.Parameters.AddWithValue("@Insertedname", newCombination);
                    //    Icom.Parameters.AddWithValue("@pregcat", pregcategory);
                    //    Icom.ExecuteNonQuery();
                    //    source.Conn.Close();
                    //    MessageBox.Show("This drug is saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    //itemsListbox.Items.Clear();
                    //    //searchAItxtbx.Focus();
                    //    //newCombinationtxtbx.Clear();

                    //}

                        //New experimental function to find any entry which contains the inserted combination
                        source.Conn.Close();
                        string command25 = "SELECT name FROM drugsbasic2 WHERE name LIKE @name";
                        MySqlCommand Comm25 = new MySqlCommand(command25, source.Conn);
                        Comm25.Parameters.AddWithValue("@name", "%"+itemsListbox.Items[0]+"%");
                        source.MySqlCon();
                        MySqlDataReader Reader25 = Comm25.ExecuteReader();
                        while (Reader25.Read())
                        {
                            searchingforrepeated.Add(Reader25["name"].ToString());
                            

                        }
                        source.Conn.Close();

                        for (int f = 0; f < searchingforrepeated.Count(); f++)
                        {

                            for (int l = 0; l < itemsListbox.Items.Count; l++)
                            {
                                if (searchingforrepeated[f].Contains(itemsListbox.Items[l].ToString()))
                                     {

                                    temp.Add(true);
                                    tempfoundname = searchingforrepeated[f];

                                }
                                else if (!(searchingforrepeated[f].Contains(itemsListbox.Items[l].ToString())))
                                {

                                    temp.Add(false);

                                    namerepeated = false;
                                }

                            }

                            string[] splitted = searchingforrepeated[f].Split('-');

                            if (!(temp.Contains(false)) && splitted.Count() == itemsListbox.Items.Count)
                                {
                                namerepeated = true;
                                tempfoundname = searchingforrepeated[f].ToString();
                                f = searchingforrepeated.Count() + 2;
                            }
                            
                            temp.Clear();
                        }


                        if (namerepeated == false)
                        {
                            source.Conn.Close();
                            source.MySqlCon();
                            MySqlCommand Icom = source.Conn.CreateCommand();
                            //Icom.CommandText = "UPDATE interactorsinfo2 SET drugname = @Insertedname, severity = @severity, description = @description, foreigndrugID = @foreignID";
                            Icom.CommandText = "INSERT INTO drugsbasic2 (name, pregnancyCat) VALUES(@Insertedname, @pregcat)";
                            Icom.Parameters.AddWithValue("@Insertedname", newCombination);
                            Icom.Parameters.AddWithValue("@pregcat", pregcategory);
                            Icom.ExecuteNonQuery();
                            source.Conn.Close();
                            MessageBox.Show("This drug is saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //itemsListbox.Items.Clear();
                        }
                        else if (namerepeated == true)
                        {
                            presentName = true;
                            MessageBox.Show("This drug is already present in the database!"+"\n"+"Name: " +tempfoundname, "Duplicate record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            source.Conn.Close();
                            searchAItxtbx.Focus();
                            newCombinationtxtbx.Text = tempfoundname;
                            pregcategory = "A";
                            newCombination = "";
                        }


                        string tempName4 = newCombinationtxtbx.Text;
                    if (newCombinationtxtbx.Text == "") MessageBox.Show("Enter a valid drug name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    source.Conn.Close();
                    string command87 = "SELECT interactorsinfo2.id FROM interactorsinfo2 LEFT JOIN drugsbasic2 ON drugsbasic2.id = interactorsinfo2.foreigndrugID WHERE drugsbasic2.name = @instertedname";
                    MySqlCommand Comm87 = new MySqlCommand(command87, source.Conn);
                    Comm87.Parameters.AddWithValue("@instertedname", tempName4);
                    source.MySqlCon();
                    MySqlDataReader Reader87 = Comm87.ExecuteReader();
                    if (Reader87.HasRows)
                    {
                        MessageBox.Show("This drug interactions are already added to the database!", "Duplicate record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        source.Conn.Close();
                    }
                    else
                    {
                        for (int id = 0; id < itemsListbox.Items.Count; id++)
                        {
                            source.Conn.Close();
                            string command21 = "SELECT id FROM drugsbasic2 WHERE name = @name";
                            MySqlCommand Comm21 = new MySqlCommand(command21, source.Conn);
                            Comm21.Parameters.AddWithValue("@name", itemsListbox.Items[id]);
                            source.MySqlCon();
                            MySqlDataReader Reader21 = Comm21.ExecuteReader();
                            if (!(Reader21.HasRows))
                            {
                                MessageBox.Show("This drug is not present in the database!", "No record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                source.Conn.Close();
                            }
                            else
                            {
                                Reader21.Read();
                                drugID.Add(Reader21["id"].ToString());
                                source.Conn.Close();
                            }
                            source.Conn.Close();
                        }

                            for (int q = 0; q < drugID.Count(); q++)
                            {
                                source.Conn.Close();
                                string command5 = "SELECT drugname, severity, description FROM interactorsinfo2 WHERE foreigndrugID = @foreignID";
                                MySqlCommand Comm5 = new MySqlCommand(command5, source.Conn);
                                Comm5.Parameters.AddWithValue("@foreignID", drugID[q]);
                                source.MySqlCon();
                                MySqlDataReader Reader = Comm5.ExecuteReader();
                                while (Reader.Read())
                                {
                                    drugName.Add(Reader["drugname"].ToString());
                                    severities.Add(Reader["severity"].ToString());
                                    descriptions.Add(Reader["description"].ToString());

                                }

                                source.Conn.Close();

                            }


                        }

                    source.Conn.Close();
                    
                        string command23 = "SELECT id FROM drugsbasic2 WHERE name = @name";
                        MySqlCommand Comm23 = new MySqlCommand(command23, source.Conn);
                        Comm23.Parameters.AddWithValue("@name", newCombinationtxtbx.Text.Trim());
                        source.MySqlCon();
                        MySqlDataReader Reader23 = Comm23.ExecuteReader();
                        Reader23.Read();
                        newCombinationID = Reader23["id"].ToString();
                        source.Conn.Close();
                    

                    string command22 = "SELECT drugname FROM interactorsinfo2 WHERE foreigndrugID = @id";
                    MySqlCommand Comm22 = new MySqlCommand(command22, source.Conn);
                    Comm22.Parameters.AddWithValue("@id", newCombinationID);
                    source.MySqlCon();
                    MySqlDataReader Reader22 = Comm22.ExecuteReader();
                    if (Reader22.HasRows) repeatedID = true;
                    else repeatedID = false;
                        source.Conn.Close();
                        if (repeatedID == false && newCombinationtxtbx.Text !="")
                        {
                            DialogResult inserttointeract = MessageBox.Show("Do you want to add it to the interactions database?", "Interactions addition", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (inserttointeract == DialogResult.No)
                            {
                                itemsListbox.Items.Clear();
                                searchAItxtbx.Focus();
                                newCombinationtxtbx.Clear();
                                pregcategory = "A";
                                newCombination = "";
                            }
                            else if (inserttointeract == DialogResult.Yes && repeatedID == false)
                            { 

                            for (int i = 0; i < drugName.Count(); i++)
                            {
                                source.Conn.Close();
                                source.MySqlCon();
                                MySqlCommand Icom = source.Conn.CreateCommand();
                                //Icom.CommandText = "UPDATE interactorsinfo2 SET drugname = @Insertedname, severity = @severity, description = @description, foreigndrugID = @foreignID";
                                Icom.CommandText = "INSERT INTO interactorsinfo2 (drugname, severity, description, foreigndrugID) VALUES(@Insertedname, @severity, @description, @foreignID)";
                                Icom.Parameters.AddWithValue("@Insertedname", drugName[i]);
                                Icom.Parameters.AddWithValue("@severity", severities[i]);
                                Icom.Parameters.AddWithValue("@description", descriptions[i]);
                                Icom.Parameters.AddWithValue("@foreignID", newCombinationID);
                                Icom.ExecuteNonQuery();
                                source.Conn.Close();
                                
                            }
                                MessageBox.Show("This drug interactions are added to the database successfully!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                itemsListbox.Items.Clear();
                                searchAItxtbx.Focus();
                                newCombinationtxtbx.Clear();
                                pregcategory = "A";
                                newCombination = "";
                            }
                    }
                    else if (repeatedID == true)
                    {
                        MessageBox.Show("This drug is already present in the database!", "Duplicate record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        source.Conn.Close();
                        itemsListbox.Items.Clear();
                        searchAItxtbx.Focus();
                        newCombinationtxtbx.Clear();
                        pregcategory = "A";
                        newCombination = "";
                    }


                }
            }


        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                searchAItxtbx.Focus();
            }
}



        //End of functions.
    }
}
