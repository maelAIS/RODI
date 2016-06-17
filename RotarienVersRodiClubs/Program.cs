#region Copyrights

// RODI - http://rodi.aisdev.net
// Copyright (c) 2012-2016
// by SAS AIS : http://www.aisdev.net
// supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730)
//
//GNU LESSER GENERAL PUBLIC LICENSE
//Version 3, 29 June 2007 Copyright (C) 2007
//Free Software Foundation, Inc. <http://fsf.org/> Everyone is permitted to copy and distribute verbatim copies of this license document, but changing it is not allowed.
//This version of the GNU Lesser General Public License incorporates the terms and conditions of version 3 of the GNU General Public License, supplemented by the additional permissions listed below.

//0. Additional Definitions.

//As used herein, "this License" refers to version 3 of the GNU Lesser General Public License, and the "GNU GPL" refers to version 3 of the GNU General Public License.
//"The Library" refers to a covered work governed by this License, other than an Application or a Combined Work as defined below.
//An "Application" is any work that makes use of an interface provided by the Library, but which is not otherwise based on the Library.Defining a subclass of a class defined by the Library is deemed a mode of using an interface provided by the Library.
//A "Combined Work" is a work produced by combining or linking an Application with the Library. The particular version of the Library with which the Combined Work was made is also called the "Linked Version".
//The "Minimal Corresponding Source" for a Combined Work means the Corresponding Source for the Combined Work, excluding any source code for portions of the Combined Work that, considered in isolation, are based on the Application, and not on the Linked Version.
//The "Corresponding Application Code" for a Combined Work means the object code and/or source code for the Application, including any data and utility programs needed for reproducing the Combined Work from the Application, but excluding the System Libraries of the Combined Work.

//1. Exception to Section 3 of the GNU GPL.

//You may convey a covered work under sections 3 and 4 of this License without being bound by section 3 of the GNU GPL.

//2. Conveying Modified Versions.

//If you modify a copy of the Library, and, in your modifications, a facility refers to a function or data to be supplied by an Application that uses the facility (other than as an argument passed when the facility is invoked), then you may convey a copy of the modified version:
//a) under this License, provided that you make a good faith effort to ensure that, in the event an Application does not supply the function or data, the facility still operates, and performs whatever part of its purpose remains meaningful, or
//b) under the GNU GPL, with none of the additional permissions of this License applicable to that copy.

//3. Object Code Incorporating Material from Library Header Files.

//The object code form of an Application may incorporate material from a header file that is part of the Library. You may convey such object code under terms of your choice, provided that, if the incorporated material is not limited to numerical parameters, data structure layouts and accessors, or small macros, inline functions and templates(ten or fewer lines in length), you do both of the following:
//a) Give prominent notice with each copy of the object code that the Library is used in it and that the Library and its use are covered by this License.
//b) Accompany the object code with a copy of the GNU GPL and this license document.

//4. Combined Works.

//You may convey a Combined Work under terms of your choice that, taken together, effectively do not restrict modification of the portions of the Library contained in the Combined Work and reverse engineering for debugging such modifications, if you also do each of the following:
//a) Give prominent notice with each copy of the Combined Work that the Library is used in it and that the Library and its use are covered by this License.
//b) Accompany the Combined Work with a copy of the GNU GPL and this license document.
//c) For a Combined Work that displays copyright notices during execution, include the copyright notice for the Library among these notices, as well as a reference directing the user to the copies of the GNU GPL and this license document.
//d) Do one of the following:
//0) Convey the Minimal Corresponding Source under the terms of this License, and the Corresponding Application Code in a form suitable for, and under terms that permit, the user to recombine or relink the Application with a modified version of the Linked Version to produce a modified Combined Work, in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.
//1) Use a suitable shared library mechanism for linking with the Library. A suitable mechanism is one that (a) uses at run time a copy of the Library already present on the user's computer system, and (b) will operate properly with a modified version of the Library that is interface-compatible with the Linked Version.
//e) Provide Installation Information, but only if you would otherwise be required to provide such information under section 6 of the GNU GPL, and only to the extent that such information is necessary to install and execute a modified version of the Combined Work produced by recombining or relinking the Application with a modified version of the Linked Version. (If you use option 4d0, the Installation Information must accompany the Minimal Corresponding Source and Corresponding Application Code. If you use option 4d1, you must provide the Installation Information in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.)

//5. Combined Libraries.

//You may place library facilities that are a work based on the Library side by side in a single library together with other library facilities that are not Applications and are not covered by this License, and convey such a combined library under terms of your choice, if you do both of the following:
//a) Accompany the combined library with a copy of the same work based on the Library, uncombined with any other library facilities, conveyed under the terms of this License.
//b) Give prominent notice with the combined library that part of it is a work based on the Library, and explaining where to find the accompanying uncombined form of the same work.

//6. Revised Versions of the GNU Lesser General Public License.

//The Free Software Foundation may publish revised and/or new versions of the GNU Lesser General Public License from time to time. Such new versions will be similar in spirit to the present version, but may differ in detail to address new problems or concerns.
//Each version is given a distinguishing version number. If the Library as you received it specifies that a certain numbered version of the GNU Lesser General Public License "or any later version" applies to it, you have the option of following the terms and conditions either of that published version or of any later version published by the Free Software Foundation. If the Library as you received it does not specify a version number of the GNU Lesser General Public License, you may choose any version of the GNU Lesser General Public License ever published by the Free Software Foundation.
//If the Library as you received it specifies that a proxy can decide whether future versions of the GNU Lesser General Public License shall apply, that proxy's public statement of acceptance of any version is permanent authorization for you to choose that version for the Library.

#endregion Copyrights

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotarienVersRodiClubs
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (args.Length == 0 || args[0] == "")
            //{
            //    Console.WriteLine("Aucun name de fichier en parametres");
            //    Console.ReadLine();
            //    return;
            //}

            string dir_source = Properties.Settings.Default.dir_source;
            string dir_filter = Properties.Settings.Default.dir_filter;

            DirectoryInfo di = new DirectoryInfo(dir_source);
            FileInfo[] fichiers = di.GetFiles(dir_filter);
            FileInfo fichiermembres = null;
            foreach (FileInfo fi in fichiers)
            {
                if (fichiermembres == null || fi.LastWriteTime > fichiermembres.LastWriteTime)
                    fichiermembres = fi;
            }


            SqlConnection conn = new SqlConnection("" + Properties.Settings.Default["conn"]);
            SqlTransaction trans = null;
            try
            {
                Console.WriteLine("Lecture fichier : " + fichiermembres.FullName);
                string[] fichier = File.ReadAllLines(fichiermembres.FullName,Encoding.UTF7);

                Console.WriteLine("Connexion à la bdd : " + Properties.Settings.Default["conn"]);
                conn.Open();
                trans = conn.BeginTransaction();

                Console.WriteLine("Preparation de l'import");

                string champsfile = File.ReadAllText("champs.txt");
                string[] fln = champsfile.Split(new string[]{Environment.NewLine   },StringSplitOptions.None);
                string query = GetInsertQuery("ais_clubs_import", fln);

                List<SqlCommand> requetes = new List<SqlCommand>();

                requetes.Add(new SqlCommand("DELETE FROM ais_clubs_import", conn, trans));

                for (int i = 0; i < fichier.Length; i++)
                {
                    if (fichier[i] != "")
                    {
                        SqlCommand sql = new SqlCommand(query, conn, trans);
                        string[] champs = fichier[i].Split('\t');
                        for (int j = 0; j < fln.Length; j++)
                        {
                            if (fln[j]=="")
                            {
                            }else if ("cric".IndexOf(fln[j]) > -1)
                            {
                                // champs int
                                int n = 0;
                                int.TryParse(champs[j], out n);
                                sql.Parameters.AddWithValue(fln[j], n);
                            }
                            else
                            {
                                if (champs[j].StartsWith("\""))
                                    champs[j] = champs[j].Substring(1);
                                if (champs[j].EndsWith("\""))
                                    champs[j] = champs[j].Substring(0, champs[j].Length - 1);
                                if (champs[j].Length == 1 && (champs[j].Equals("t") || champs[j].Equals("f")))
                                {
                                    champs[j] = champs[j].Replace("t", "O").Replace("f", "N");
                                }
                                sql.Parameters.AddWithValue(fln[j], champs[j]);
                            }

                        }
                        requetes.Add(sql);
                    }
                }

                Console.WriteLine("Import de "+(requetes.Count-1)+" clubs");
                for (int i = 0; i < requetes.Count; i++)
                {
                    Console.Write(".");
                    requetes[i].ExecuteNonQuery();
                }
                Console.WriteLine();

                

                #region clubs rotarien vers district
                Console.WriteLine("Mise a jour des clubs district");

                
                SqlCommand sq = new SqlCommand("SELECT * FROM ais_clubs_import", conn, trans);
                SqlDataAdapter da = new SqlDataAdapter(sq);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                    throw new Exception("Aucun club mis a jour");
                int nbupdate = 0;
                int nbinsert = 0;
                int nbdelete = 0;
               
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                {
                    
                    DataRow row = ds.Tables[0].Rows[i];
                    Console.Write(".");

                    int cric = (int)row["cric"];

                    // recherche d'un club déjà dans la bdd pour récupérer son id
                    sq = new SqlCommand("SELECT cric FROM ais_clubs WHERE cric=@cric ", conn, trans);
                    sq.Parameters.AddWithValue("cric", cric);
                  
                    string id = "" + sq.ExecuteScalar();


                    // creation ou maj ?
                    string c = "";
                    foreach (DataColumn col in ds.Tables[0].Columns)
                       c += col.Caption + ",";
                    string[] cols = c.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    if (id != "")
                    {
                        
                            // on met le membre a jour
                            //Console.WriteLine("\t... Mise à jour");
                            query = GetUpdateQuery("ais_clubs", cols);
                            sq = new SqlCommand(query, conn, trans);
                            SetQueryParameters(sq, row, cols);
                            sq.ExecuteNonQuery();
                            if (sq.ExecuteNonQuery() == 0)
                                throw new Exception("Erreur mise à jour : " +row["name"]);
                            nbupdate++;
                        
                    }
                    else
                    {
                        // on cree le membre 
                        //Console.WriteLine("\t... Création");
                       
                            query = GetInsertQuery("ais_clubs", cols);
                            sq = new SqlCommand(query, conn, trans);
                            SetQueryParameters(sq, row, cols);
                            if (sq.ExecuteNonQuery() == 0)
                                throw new Exception("Erreur ajout : " + row["name"]);
                            nbinsert++;
                        

                    }
                }

                sq = new SqlCommand("SELECT cric,name FROM ais_clubs WHERE type_club='rotary'", conn, trans);
                SqlDataAdapter da1 = new SqlDataAdapter(sq);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {

                    DataRow r = ds1.Tables[0].Rows[j];
                    int cric = (int)r["cric"];

                    bool trouve = false;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        DataRow row = ds.Tables[0].Rows[i];
                        if ((int)row["cric"] == cric)
                        {
                            trouve = true;
                            break;
                        }
                    }
                    if (!trouve)
                    {
                        Console.Write("Effacement club : "+r["name"]);
                        sq = new SqlCommand("DELETE FROM ais_clubs WHERE cric="+cric, conn, trans);
                        sq.ExecuteNonQuery();
                        nbdelete++;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Ajouté(s) : " + nbinsert + "\tMis à jour : " + nbupdate + "\tSupprimé(s) : " + nbdelete + "\tTotal : " + (nbinsert + nbupdate+nbdelete));
                #endregion 

                trans.Commit();
            }
            catch (Exception ee)
            {
                if (trans != null)
                {
                    try
                    {
                        trans.Rollback();
                    }
                    catch (Exception eee)
                    {
                        Console.WriteLine(eee.Message);
                    }
                }
                Console.WriteLine(ee.Message+Environment.NewLine+ee.StackTrace);

            }
            finally
            {
                conn.Close();
            }
            //Console.WriteLine("Presse moi dit la touche");
            //Console.ReadLine();
        }

        static string GetInsertQuery(string table, string[] fields)
        {
            string query = "INSERT INTO ["+table+"] (";
            foreach (string f in fields)
                if(f!="")
                    query += f + ",";
            query = query.Substring(0, query.Length - 1) + ") VALUES (";
            foreach (string f in fields)
                if(f!="")
                    query += "@" + f + ",";
            query = query.Substring(0, query.Length - 1) + ")";
            return query;
        }
        static string GetUpdateQuery(string table, string[] fields)
        {
            string query = "UPDATE [" + table + "] SET ";
            foreach (string f in fields)
                query += f + "=@"+f+",";
            query = query.Substring(0, query.Length - 1) + " WHERE cric = @cric ";
            return query;
        }
        static void SetQueryParameters(SqlCommand sql, DataRow row, string[] fields)
        {
            foreach(string f in fields)
                sql.Parameters.AddWithValue(f, row[f]);
        }
    }
}
