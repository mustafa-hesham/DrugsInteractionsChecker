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
    public partial class AddDrug : Form
    {
        Gethtml Gethtml = new Gethtml();
        string tempid;
        
        public AddDrug()
        {
            InitializeComponent();
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            Gethtml.Conn.Close();
            string tempName3 = nametxtbx.Text;
            string command2 = "SELECT id FROM drugsbasic2 WHERE name = @name";
            MySqlCommand Comm2 = new MySqlCommand(command2, Gethtml.Conn);
            Comm2.Parameters.AddWithValue("@name", tempName3);
            Gethtml.MySqlCon();
            MySqlDataReader Reader2 = Comm2.ExecuteReader();
            if (Reader2.HasRows)
            {
                MessageBox.Show("This drug is already present in the database!", "Duplicate record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Gethtml.Conn.Close();
                

            }
            else
            {
                Gethtml.Conn.Close();
                Gethtml.MySqlCon();
                MySqlCommand Icom = Gethtml.Conn.CreateCommand();
                //Icom.CommandText = "UPDATE interactorsinfo2 SET drugname = @Insertedname, severity = @severity, description = @description, foreigndrugID = @foreignID";
                Icom.CommandText = "INSERT INTO drugsbasic2 (name, pregnancyCat) VALUES(@Insertedname, @pregcat)";
                Icom.Parameters.AddWithValue("@Insertedname", nametxtbx.Text);
                Icom.Parameters.AddWithValue("@pregcat", Pregcattxtbx.Text);
                Icom.ExecuteNonQuery();
                Gethtml.Conn.Close();
                MessageBox.Show("This drug is saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Addinterbtn_Click(object sender, EventArgs e)
        {

            string tempName3 = nametxtbx.Text;
            if (nametxtbx.Text == "") MessageBox.Show("Enter a valid drug name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Gethtml.Conn.Close();
            string command87 = "SELECT interactorsinfo2.id FROM interactorsinfo2 LEFT JOIN drugsbasic2 ON drugsbasic2.id = interactorsinfo2.foreigndrugID WHERE drugsbasic2.name = @instertedname";
            MySqlCommand Comm87 = new MySqlCommand(command87, Gethtml.Conn);
            Comm87.Parameters.AddWithValue("@instertedname", tempName3);
            Gethtml.MySqlCon();
            MySqlDataReader Reader87 = Comm87.ExecuteReader();
            if (Reader87.HasRows)
            {
                MessageBox.Show("This drug interactions are already added to the database!", "Duplicate record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Gethtml.Conn.Close();
            }

            else
            {

                try
                {

                    string link1 = "https://www.drugs.com/drug-interactions/" + tempName3 + "-index.html";
                    var agileHTML = new HtmlAgilityPack.HtmlDocument();
                    agileHTML.LoadHtml(Gethtml.GetHtmlCode(link1));
                    var DrugList = agileHTML.DocumentNode.SelectNodes("//li").Where(node => node.GetAttributeValue("class", "").Contains("int_")).ToList();
                    var classint = agileHTML.DocumentNode.Descendants("li").Select(a => a.GetAttributeValue("class", null)).Where(u => !String.IsNullOrEmpty(u)).ToList();
                    var classfilter = agileHTML.DocumentNode.SelectNodes("//a").Where(s => s.GetAttributeValue("href", "").Contains(tempName3 + "-index.html?filter")).ToList();
                    var LinksList = agileHTML.DocumentNode.SelectNodes("//a").Where(node => node.GetAttributeValue("href", "").Contains("with")).ToList();
                    var DiseaseLink = agileHTML.DocumentNode.SelectNodes("//a").Where(node => node.GetAttributeValue("href", "").Contains("/disease-interactions/" + tempName3 + ".html#")).ToList();
                    List<string> drugnameslist = Gethtml.GetdrugsValues(DrugList, DrugList.Count(), 0);
                    List<string> DrugListerlist = Gethtml.GetClass(classint, classint.Count(), classfilter.Count());
                    List<string> SeverityList1 = Gethtml.SeverityDeg(DrugListerlist, DrugListerlist.Count());
                    List<string> InterLinks = Gethtml.GetDrugsDiseaseLinks(LinksList, LinksList.Count(), DiseaseLink, DiseaseLink.Count());
                    List<string> InterDisc = Gethtml.GetDescription(InterLinks, InterLinks.Count(), DiseaseLink.Count());

                    for (int w = 1; w < drugnameslist.Count(); w++)
                    {
                        Gethtml.Conn.Close();
                        string command2 = "SELECT id FROM drugsbasic2 WHERE name = @name";
                        MySqlCommand Comm2 = new MySqlCommand(command2, Gethtml.Conn);
                        Comm2.Parameters.AddWithValue("@name", tempName3);
                        Gethtml.MySqlCon();
                        MySqlDataReader Reader2 = Comm2.ExecuteReader();
                        if (!(Reader2.HasRows))
                        {
                            MessageBox.Show("This drug is not present in the database!", "No record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Gethtml.Conn.Close();
                        }
                        else
                        {
                            Reader2.Read();
                            tempid = Reader2["id"].ToString();
                            Gethtml.Conn.Close();
                        }
                        Gethtml.Conn.Close();
                        string command5 = "SELECT id FROM interactorsinfo2 WHERE drugname = @Insertedname AND foreigndrugID = @foreignID";
                        MySqlCommand Comm5 = new MySqlCommand(command5, Gethtml.Conn);
                        Comm5.Parameters.AddWithValue("@Insertedname", drugnameslist[w]);
                        Comm5.Parameters.AddWithValue("@foreignID", tempid);
                        //Comm5.Parameters.AddWithValue("@description", InterDisc[w]);
                        Gethtml.MySqlCon();
                        MySqlDataReader Reader5 = Comm5.ExecuteReader();

                        if (Reader5.HasRows)
                        {
                            Gethtml.Conn.Close();
                            MessageBox.Show("This drug is already present in the database!", "Duplicate record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else

                        {
                            Gethtml.Conn.Close();
                            Gethtml.MySqlCon();
                            MySqlCommand Icom = Gethtml.Conn.CreateCommand();
                            //Icom.CommandText = "UPDATE interactorsinfo2 SET drugname = @Insertedname, severity = @severity, description = @description, foreigndrugID = @foreignID";
                            Icom.CommandText = "INSERT INTO interactorsinfo2 (drugname, severity, description, foreigndrugID) VALUES(@Insertedname, @severity, @description, @foreignID)";
                            Icom.Parameters.AddWithValue("@Insertedname", drugnameslist[w]);
                            Icom.Parameters.AddWithValue("@severity", SeverityList1[w]);
                            Icom.Parameters.AddWithValue("@description", InterDisc[w]);
                            Icom.Parameters.AddWithValue("@foreignID", tempid);
                            Icom.ExecuteNonQuery();
                            Gethtml.Conn.Close();
                        }
                    }
                    MessageBox.Show("Interactions saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception)
                {
                    ;
                }
            }
        
        }
    }
}
