using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Webscarpper
{

    public class Gethtml
    {
        public static string conString = "datasource=127.0.0.1; port=3306;username=root; password=; database=druginteractions";
        public MySqlConnection Conn = new MySqlConnection(conString);
        public string show;

        public string GetHtmlCode(string url)
        {
            var link = url;
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(link);
            try
            {
                return html.Result;
            }


            catch (Exception e)
            {

                return null;
            }
        }
        public List<string> GetdrugsValues(List<HtmlNode> druglist, int z, int x)
        {
            List<string> newlist = new List<string>();
            for (x = 0; x < z; x++)
            {

                if (int.TryParse(druglist[x].InnerText.Substring(0, 1), out int n) && druglist[x].InnerText.Contains("-") == false)
                {
                    continue;
                }
                else
                {
                    newlist.Add(druglist[x].InnerText);
                }

            }

            return newlist;
        }

        public List<string> GetClass(List<string> druglist, int z, int r)
        {

            List<string> newlist = new List<string>();
            List<string> newlistfilter = new List<string>();

            for (int x = 0; x < z; x++)
            {

                if (int.TryParse(druglist[x].Substring(0, 1), out _) == true || druglist[x].Substring(0, 1) != "i")
                {
                    newlistfilter.Add(druglist[x]);
                }
                else
                {
                    newlist.Add(druglist[x]);
                }

            }
            newlist.RemoveRange(0, r);

            return newlist;
        }

        public List<string> SeverityDeg(List<string> intlist, int z)
        {
            List<string> mylist = new List<string>();
            for (int c = 0; c < z; c++)
            {
                switch (intlist[c])
                {
                    case "int_0":
                        mylist.Add("Unknown");
                        break;
                    case "int_1":
                        mylist.Add("Minor");
                        break;
                    case "int_2":
                        mylist.Add("Moderate");
                        break;
                    case "int_3":
                        mylist.Add("Major");
                        break;
                }

            }
            return mylist;
        }

        public List<string> GetDrugsDiseaseLinks(List<HtmlNode> druglist, int z, List<HtmlNode> druglist2, int z2)
        {
            List<string> newlist = new List<string>();

            for (int x = 0; x < z; x++)
            {

                string[] newLink = druglist[x].OuterHtml.Split('"');
                newlist.Add("https://www.drugs.com" + newLink[1]);

            }

            for (int i = 0; i < z2; i++)
            {
                string[] newLink = druglist2[i].OuterHtml.Split('"');
                newlist.Add("https://www.drugs.com" + newLink[1]);
            }
            return newlist;
        }

        public List<string> GetDescription(List<string> Links, int e, int d)
        {
            List<string> mylist = new List<string>();
            List<int> diseasedesc = new List<int>();
            for (int dox = 0; dox < (e - d); dox++)
            {
                string linkDisc = Links[dox];
                var LinkHTML = new HtmlAgilityPack.HtmlDocument();
                LinkHTML.LoadHtml(GetHtmlCode(linkDisc));
                var Describ = LinkHTML.DocumentNode.SelectNodes("//p").ToList();
                if (Describ[1].InnerText.Contains("Medically reviewed")) continue;
                if (Describ[1].InnerText.Contains("Edit")) mylist.Add(Describ[3].InnerText);
                else mylist.Add(Describ[1].InnerText);
                


            }


           // int x = 0;
            for (int c = mylist.Count(); c < e; c++)
            {

                string linkDisc = Links[c];
                var LinkHTML = new HtmlAgilityPack.HtmlDocument();
                LinkHTML.LoadHtml(GetHtmlCode(linkDisc));
                var Describ = LinkHTML.DocumentNode.SelectNodes("//p");
                for (int zd = 0; zd < Describ.Count(); zd++)
                {
                    if (Describ[zd].InnerText.Contains("Applies to:"))
                    {
                        diseasedesc.Add(zd+1);
                        
                    }
                }
                for (int v = 0; v < diseasedesc.Count(); v++)
                {
                    if (Describ[diseasedesc[v]].InnerText.Contains("Medically reviewed")) continue;
                    mylist.Add(Describ[diseasedesc[v]].InnerText);
                }
                

               
            }

            return mylist;

        }

        public void MySqlCon()
        {
            try
            {

                Conn.Open();

            }
            catch (Exception)
            {
                MessageBox.Show("Connection to database is unsuccessfull!", "Database Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public List<string> GetDrugsNamesList()
        {
            List<string> mylist = new List<string>();
            List<string> mylist2 = new List<string>();
            for (char w = 'y'; w <= 'z'; w++)
            {
                for (char q = 'a'; q <= 'z'; q++)

                {

                    try
                    {

                        string link4 = "https://www.drugs.com/alpha/" + w + q + ".html";
                        var agileHTML4 = new HtmlAgilityPack.HtmlDocument();
                        agileHTML4.LoadHtml(GetHtmlCode(link4));
                        var pageName = agileHTML4.DocumentNode.SelectNodes("//title").Where(r => r.InnerText.Contains(w.ToString().ToUpper() + q.ToString())).ToList();
                        if (pageName.Count() <= 0 || w == q) continue;

                        else
                        {
                            string link2 = "https://www.drugs.com/alpha/" + w + q + ".html";
                            var agileHTML2 = new HtmlAgilityPack.HtmlDocument();
                            agileHTML2.LoadHtml(GetHtmlCode(link2));
                            var DrugList2 = agileHTML2.DocumentNode.SelectNodes("//a").ToList();
                            List<string> drugnameslist1 = GetdrugsValues(DrugList2, DrugList2.Count(), 0);

                            for (int a = 0; a < drugnameslist1.Count(); a++)
                            {
                                string temp = drugnameslist1[a].ToLower();
                                string temp2 = temp.Replace("and-", "");
                                string temp3 = temp2.Replace("and", "");
                                string temp4 = temp3.Replace(",", "");
                                string temp5 = temp4.Replace(" ", "-");
                                string temp6 = temp5.Replace("--", "-");
                                mylist.Add(temp6);
                            }

                            for (int h = 0; h < mylist.Count(); h++)
                            {

                                string link3 = "https://www.drugs.com/drug-interactions/" + mylist[h] + "-index.html";
                                var agileHTML3 = new HtmlAgilityPack.HtmlDocument();
                                agileHTML3.LoadHtml(GetHtmlCode(link3));
                                mylist2.Add(mylist[h]);

                                string command = "SELECT name FROM drugsbasic2 WHERE name = @name";
                                MySqlCommand Comm = new MySqlCommand(command, Conn);
                                Comm.Parameters.AddWithValue("@name", mylist[h]);
                                MySqlCon();
                                MySqlDataReader Reader = Comm.ExecuteReader();
                                if (Reader.HasRows) Conn.Close();
                                else
                                {
                                    Conn.Close();
                                    MySqlCon();
                                    MySqlCommand Icom = Conn.CreateCommand();
                                    Icom.CommandText = "INSERT INTO drugsbasic2 (name) VALUES(@Insertedname)";
                                    Icom.Parameters.AddWithValue("@Insertedname", mylist[h]);
                                    Icom.ExecuteNonQuery();
                                    Conn.Close();
                                }
                            }




                        }

                    }



                    catch (Exception)
                    {
                        ;
                    }

                    mylist.RemoveRange(0, mylist.Count());
                }
            }

            return mylist2;
        }


        public void InsertInteractionstoSql()
        {
            int rowsCount;
            string command4 = "SELECT id FROM drugsbasic2 ORDER BY id DESC LIMIT 1";
            MySqlCommand Comm4 = new MySqlCommand(command4, Conn);
            MySqlCon();
            MySqlDataReader Reader4 = Comm4.ExecuteReader();
            Reader4.Read();
            rowsCount = Convert.ToInt32(Reader4["id"].ToString());
            Conn.Close();
            for (int r = 2193; r <= 2193; r++)
            {
                try
                {

                    Conn.Close();
                    string command = "SELECT name FROM drugsbasic2 WHERE id = @id";
                    MySqlCommand Comm = new MySqlCommand(command, Conn);
                    Comm.Parameters.AddWithValue("@id", r.ToString());
                    MySqlCon();
                    MySqlDataReader Reader3 = Comm.ExecuteReader();
                    Reader3.Read();
                    string tempName3 = Reader3["name"].ToString();
                    Conn.Close();
                    show = tempName3;


                    
                    string link1 = "https://www.drugs.com/drug-interactions/" + tempName3 + "-index.html";
                    var agileHTML = new HtmlAgilityPack.HtmlDocument();
                    agileHTML.LoadHtml(GetHtmlCode(link1));
                    var DrugList = agileHTML.DocumentNode.SelectNodes("//li").Where(node => node.GetAttributeValue("class", "").Contains("int_")).ToList();
                    var classint = agileHTML.DocumentNode.Descendants("li").Select(a => a.GetAttributeValue("class", null)).Where(u => !String.IsNullOrEmpty(u)).ToList();
                    var classfilter = agileHTML.DocumentNode.SelectNodes("//a").Where(s => s.GetAttributeValue("href", "").Contains(tempName3 + "-index.html?filter")).ToList();
                    var LinksList = agileHTML.DocumentNode.SelectNodes("//a").Where(node => node.GetAttributeValue("href", "").Contains("with")).ToList();
                    var DiseaseLink = agileHTML.DocumentNode.SelectNodes("//a").Where(node => node.GetAttributeValue("href", "").Contains("/disease-interactions/" + tempName3 + ".html#")).ToList();
                    List<string> drugnameslist = GetdrugsValues(DrugList, DrugList.Count(), 0);
                    List<string> DrugListerlist = GetClass(classint, classint.Count(), classfilter.Count());
                    List<string> SeverityList1 = SeverityDeg(DrugListerlist, DrugListerlist.Count());
                    List<string> InterLinks = GetDrugsDiseaseLinks(LinksList, LinksList.Count(), DiseaseLink, DiseaseLink.Count());
                    List<string> InterDisc = GetDescription(InterLinks, InterLinks.Count(), DiseaseLink.Count());

                    for (int w = 1; w < drugnameslist.Count(); w++)
                    {
                        string command2 = "SELECT id FROM drugsbasic2 WHERE name = @name";
                        MySqlCommand Comm2 = new MySqlCommand(command2, Conn);
                        Comm2.Parameters.AddWithValue("@name", tempName3);
                        MySqlCon();
                        MySqlDataReader Reader2 = Comm2.ExecuteReader();
                        Reader2.Read();
                        string tempid = Reader2["id"].ToString();
                        Conn.Close();
                        string command5 = "SELECT id FROM interactorsinfo2 WHERE drugname = @Insertedname AND foreigndrugID = @foreignID";
                        MySqlCommand Comm5 = new MySqlCommand(command5, Conn);
                        Comm5.Parameters.AddWithValue("@Insertedname", drugnameslist[w]);
                        Comm5.Parameters.AddWithValue("@foreignID", tempid);
                        //Comm5.Parameters.AddWithValue("@description", InterDisc[w]);
                        MySqlCon();
                        MySqlDataReader Reader5 = Comm5.ExecuteReader();

                        if (Reader5.HasRows)
                        {
                            Conn.Close();
                            continue;
                        }
                        else

                        {
                            Conn.Close();
                            MySqlCon();
                            MySqlCommand Icom = Conn.CreateCommand();
                            //Icom.CommandText = "UPDATE interactorsinfo2 SET drugname = @Insertedname, severity = @severity, description = @description, foreigndrugID = @foreignID";
                            Icom.CommandText = "INSERT INTO interactorsinfo2 (drugname, severity, description, foreigndrugID) VALUES(@Insertedname, @severity, @description, @foreignID)";
                            Icom.Parameters.AddWithValue("@Insertedname", drugnameslist[w]);
                            Icom.Parameters.AddWithValue("@severity", SeverityList1[w]);
                            Icom.Parameters.AddWithValue("@description", InterDisc[w]);
                            Icom.Parameters.AddWithValue("@foreignID", tempid);
                            Icom.ExecuteNonQuery();
                            Conn.Close();

                        }
                    }
                    //DataTable dt = new DataTable();
                    //drugInteractdgv.DataSource = dt;

                    //dt.Columns.Add("Serial");
                    //dt.Columns.Add("Name");
                    //dt.Columns.Add("Severity");
                    //dt.Columns.Add("Description of interaction");



                    //for (int s = 0; s < drugnameslist.Count(); s++)
                    //{
                    //    dt.Rows.Add((s + 1).ToString(), drugnameslist[s], SeverityList[s], InterDisc[s]);

                    //}
                    //}
                    //catch (Exception)
                    //{
                    //    //MessageBox.Show("This name doesn't exist in the database!", "Name Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    ;
                    //}
                }
                catch (Exception)
                {
                    continue;
                }


            }
        }

        public List<string> ErrorDrugs ()
        {
            int contains = 0;
            List<string> drugname = new List<string>();
            List<string> drugnameerrored = new List<string>();
            int totalRows;
            string command1 = "SELECT COUNT(*) FROM interactorsinfo2";
            

            using (MySqlCommand Comm1 = new MySqlCommand(command1, Conn))
            {
                Conn.Close();
                MySqlCon();
                totalRows = Convert.ToInt32(Comm1.ExecuteScalar());
            }

            Conn.Close();

            int rowsCount;
            string command4 = "SELECT id FROM drugsbasic2 ORDER BY id DESC LIMIT 1";
            MySqlCommand Comm4 = new MySqlCommand(command4, Conn);
            MySqlCon();
            MySqlDataReader Reader4 = Comm4.ExecuteReader();
            Reader4.Read();
            rowsCount = Convert.ToInt32(Reader4["id"].ToString());
            Conn.Close();

            for (int c = 10; c <= 200; c++)
            {
                Conn.Close();
                string command = "SELECT name FROM drugsbasic2 WHERE id = @id";
                MySqlCommand Comm = new MySqlCommand(command, Conn);
                Comm.Parameters.AddWithValue("@id", c.ToString());
                MySqlCon();
                MySqlDataReader Reader3 = Comm.ExecuteReader();
                Reader3.Read();
                string tempName3 = Reader3["name"].ToString();
                Conn.Close();

                string command5 = "SELECT drugname FROM interactorsinfo2 WHERE foreigndrugID = @foreignID";
                MySqlCommand Comm5 = new MySqlCommand(command5, Conn);
                Comm5.Parameters.AddWithValue("@foreignID", c.ToString());
                //Comm5.Parameters.AddWithValue("@foreignID", tempid);
                //Comm5.Parameters.AddWithValue("@description", InterDisc[w]);
                MySqlCon();
                MySqlDataReader Reader5 = Comm5.ExecuteReader();

                while (Reader5.Read())
                {
                    drugname.Add(Reader5["drugname"].ToString());

                }

                for (int y = 0; y < drugname.Count(); y++)
                {
                    Conn.Close();
                string command2 = "SELECT description FROM interactorsinfo2 WHERE drugname = @insertname";
                MySqlCommand Comm2 = new MySqlCommand(command2, Conn);
                Comm2.Parameters.AddWithValue("@insertname", drugname[y]);
                //Comm5.Parameters.AddWithValue("@foreignID", tempid);
                //Comm5.Parameters.AddWithValue("@description", InterDisc[w]);
                MySqlCon();
                MySqlDataReader Reader2 = Comm2.ExecuteReader();
                Reader2.Read();
                    string descript = Reader2["description"].ToString();
                    if (descript.Contains(drugname[y])) contains++;
                    if (contains > 2) y = drugname.Count() + 2;

            }
                if (contains == 0) drugnameerrored.Add(c.ToString() + " needs revision! Please delete then re-insert");
                else drugnameerrored.Add(c.ToString()+ " is ok!");
                contains = 0;
                drugname.RemoveRange(0, drugname.Count());
            }

            return drugnameerrored;

        }

        public List<string> PregCat()
        {
            List<string> myList = new List<string>();
            string finalResult = "";
            int rowsCount;
            string command = "SELECT id FROM drugsbasic2 ORDER BY id DESC LIMIT 1";
            MySqlCommand Comm = new MySqlCommand(command, Conn);

            MySqlCon();
            MySqlDataReader Reader = Comm.ExecuteReader();
            Reader.Read();
            rowsCount = Convert.ToInt32(Reader["id"].ToString());
            Conn.Close();

            for (int o = 1837; o <= rowsCount; o++)
            {
                string command1 = "SELECT name FROM drugsbasic2 WHERE id = @id";
                MySqlCommand Comm1 = new MySqlCommand(command1, Conn);
                MySqlCon();
                Comm1.Parameters.AddWithValue("@id", o.ToString());
                MySqlDataReader Reader1 = Comm1.ExecuteReader();
                Reader1.Read();
                string tempName = Reader1["name"].ToString();
                Conn.Close();

                string ingredName = tempName;
                string link4 = "https://www.drugs.com/pregnancy/" + ingredName + ".html";
                try
                {

                    var agileHTML4 = new HtmlAgilityPack.HtmlDocument();
                    agileHTML4.LoadHtml(GetHtmlCode(link4));
                    var DrugList4 = agileHTML4.DocumentNode.SelectNodes("//p").Where(r => r.InnerText.Contains("FDA")).ToList();

                    for (int p = 0; p < DrugList4.Count(); p++)
                    {

                        string temp3 = getBetween(DrugList4[p].InnerText, "US FDA pregnancy category ", ":");
                        int error = System.Text.RegularExpressions.Regex.Matches(temp3, @"[a-zA-Z]").Count;
                        if (error > 0)
                        {

                            finalResult = temp3;

                            break;
                        }

                        string temp4 = getBetween(DrugList4[p].InnerText, "US FDA pregnancy category: ", ".");
                        int error2 = System.Text.RegularExpressions.Regex.Matches(temp4, @"[a-zA-Z]").Count;

                        if (error2 > 0)
                        {
                            temp4 = temp4.Substring(0, 1);
                            if (temp4 == "N" || temp4 == "n") temp4 = "Not Assigned";
                            finalResult = temp4;
                            break;
                        }
                        string temp5 = getBetween(DrugList4[p].InnerText, "pregnancy category ", " by the FDA");
                        int error3 = System.Text.RegularExpressions.Regex.Matches(temp5, @"[a-zA-Z]").Count;

                        if (error3 < 15)
                        {

                            finalResult = temp5;
                            break;
                        }

                        string temp6 = getBetween(DrugList4[p].InnerText, "FDA pregnancy category ", ":");
                        int error4 = System.Text.RegularExpressions.Regex.Matches(temp6, @"[a-zA-Z]").Count;

                        if (error4 > 0)
                        {
                            temp6 = temp6.Substring(0, 1);
                            if (temp6 == "N" || temp6 == "n") temp6 = "Not Assigned";
                            finalResult = temp6;
                            break;
                        }

                        string temp7 = getBetween(DrugList4[p].InnerText, "has not been formally assigned", " by the FDA");
                        int error5 = System.Text.RegularExpressions.Regex.Matches(temp7, @"[a-zA-Z]").Count;

                        if (error5 > 0)
                        {

                            finalResult = "Not Assigned";
                            break;
                        }

                        else
                        {
                            continue;
                        }


                    }
                    if (finalResult == "") finalResult = "N/A";
                    //Insert Pregnancy category into the database table
                    //string command2 = "SELECT name FROM drugsbasic2 WHERE id = @id";
                    //MySqlCommand Comm2 = new MySqlCommand(command2, Conn);
                    //MySqlCon();
                    //Comm2.Parameters.AddWithValue("@id", o);
                    //MySqlDataReader Reader2 = Comm2.ExecuteReader();
                    //if (Reader2.HasRows) Conn.Close();
                    //else
                    //{
                    Conn.Close();
                    MySqlCon();
                    MySqlCommand Icom1 = Conn.CreateCommand();
                    Icom1.CommandText = "UPDATE drugsbasic2 SET pregnancyCat = @cat WHERE name = @name";
                    Icom1.Parameters.AddWithValue("@cat", finalResult);
                    Icom1.Parameters.AddWithValue("@name", tempName);
                    Icom1.ExecuteNonQuery();
                    Conn.Close();
                    //}

                    myList.Add(finalResult);
                }
                catch (Exception)
                {
                    myList.Add("N/A");


                }

            }

            return myList;

        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        //New Function Here
        public List<string> Testifstat()
        {
            List<string> mylist = new List<string>();
            string link6 = "https://www.drugs.com/alpha/df.html";
            var agileHTML6 = new HtmlAgilityPack.HtmlDocument();
            agileHTML6.LoadHtml(GetHtmlCode(link6));
            var pageName1 = agileHTML6.DocumentNode.SelectNodes("//title").Where(r => r.InnerText.Contains("Df")).ToList();
            if (pageName1.Count() <= 0) mylist.Add("False");
            else
            {
                string result = pageName1[0].InnerText;
                result = getBetween(result, "Drugs starting with '", "' - Drugs.com");
                mylist.Add("True");
                mylist.Add(result);
            }


            return mylist;

        }

        public List<string> correctDesc ()
        {
            List<string> wrongID = new List<string>();
            string command = "SELECT DISTINCT drugsbasic2.name, interactorsinfo2.foreigndrugID FROM drugsbasic2 LEFT JOIN interactorsinfo2 ON drugsbasic2.id = interactorsinfo2.foreigndrugID WHERE interactorsinfo2.description LIKE '%A total of%'";
            MySqlCommand Comm = new MySqlCommand(command, Conn);
            MySqlCon();
            MySqlDataReader Reader = Comm.ExecuteReader();
            while (Reader.Read())
            {
                wrongID.Add(Reader["foreigndrugID"].ToString());
            }
            Conn.Close();


            for (int a = 0; a < wrongID.Count(); a++)
            {
                string command1 = "SELECT name FROM drugsbasic2 WHERE id = @id";
                MySqlCommand Comm1 = new MySqlCommand(command1, Conn);
                MySqlCon();
                Comm1.Parameters.AddWithValue("@id", wrongID[a]);
                MySqlDataReader Reader1 = Comm1.ExecuteReader();
                Reader1.Read();
                string tempName = Reader1["name"].ToString();
                string tempname1 = "asparaginase-escherichia-coli";
                Conn.Close();
                string link1 = "https://www.drugs.com/drug-interactions/" + tempname1 + "-index.html";
                var agileHTML = new HtmlAgilityPack.HtmlDocument();
                agileHTML.LoadHtml(GetHtmlCode(link1));
                var DrugList = agileHTML.DocumentNode.SelectNodes("//li").Where(node => node.GetAttributeValue("class", "").Contains("int_")).ToList();
                var classint = agileHTML.DocumentNode.Descendants("li").Select(tw => tw.GetAttributeValue("class", null)).Where(u => !String.IsNullOrEmpty(u)).ToList();
                var classfilter = agileHTML.DocumentNode.SelectNodes("//a").Where(s => s.GetAttributeValue("href", "").Contains(tempname1 + "-index.html?filter")).ToList();
                var LinksList = agileHTML.DocumentNode.SelectNodes("//a").Where(node => node.GetAttributeValue("href", "").Contains("with")).ToList();
                var DiseaseLink = agileHTML.DocumentNode.SelectNodes("//a").Where(node => node.GetAttributeValue("href", "").Contains("/disease-interactions/" + tempname1 + ".html#")).ToList();
                List<string> drugnameslist = GetdrugsValues(DrugList, DrugList.Count(), 0);
                List<string> DrugListerlist = GetClass(classint, classint.Count(), classfilter.Count());
                List<string> SeverityList1 = SeverityDeg(DrugListerlist, DrugListerlist.Count());
                List<string> InterLinks = GetDrugsDiseaseLinks(LinksList, LinksList.Count(), DiseaseLink, DiseaseLink.Count());
                List<string> InterDisc = GetDescription(InterLinks, InterLinks.Count(), DiseaseLink.Count());


                for (int w = 0; w < drugnameslist.Count(); w++)
                {

                        Conn.Close();
                        MySqlCon();
                        MySqlCommand Icom = Conn.CreateCommand();
                        Icom.CommandText = "UPDATE interactorsinfo2 SET drugname = @Insertedname, severity = @severity, description = @description WHERE foreigndrugID = @foreignID";
                       // Icom.CommandText = "INSERT INTO interactorsinfo2 (drugname, severity, description, foreigndrugID) VALUES(@Insertedname, @severity, @description, @foreignID)";
                        Icom.Parameters.AddWithValue("@Insertedname", drugnameslist[w]);
                        Icom.Parameters.AddWithValue("@severity", SeverityList1[w]);
                        Icom.Parameters.AddWithValue("@description", InterDisc[w]);
                        Icom.Parameters.AddWithValue("@foreignID", wrongID[a]);
                        Icom.ExecuteNonQuery();
                        Conn.Close();

                    
                }

            }

            return wrongID;
        }


    }
   
    


        
    }