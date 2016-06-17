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
using System.Linq;
using System.Text;

namespace Imap
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.conn);

                SqlCommand sql;

                Chilkat.Imap imap = new Chilkat.Imap();

                bool success;

                // Anything unlocks the component and begins a fully-functional 30-day trial.
                success = imap.UnlockComponent("rodi");
                if (success != true)
                {
                    throw new Exception(imap.LastErrorText);
                }

                // Connect to an IMAP server.
                success = imap.Connect(Properties.Settings.Default.mail_host);
                if (success != true)
                {
                    throw new Exception(imap.LastErrorText);
                }

                // Login
                success = imap.Login(Properties.Settings.Default.mail_user, Properties.Settings.Default.mail_pass);
                if (success != true)
                {
                    throw new Exception(imap.LastErrorText);
                }

                // Select an IMAP mailbox
                success = imap.SelectMailbox("Inbox");
                if (success != true)
                {
                    throw new Exception(imap.LastErrorText);
                }

                Chilkat.MessageSet messageSet;


                #region traitement des delivery failures

                // We can choose to fetch UIDs or sequence numbers.
                bool fetchUids;
                fetchUids = true;
                // Get the message IDs of all the emails in the mailbox
                messageSet = imap.Search("BODY \"Reason: Remote host said: 421\"", fetchUids);
                messageSet = imap.Search("SUBJECT \"Delivery Failure\"", fetchUids);
                if (messageSet == null)
                {
                    throw new Exception(imap.LastErrorText);
                }

                // Fetch the emails into a bundle object:
                Chilkat.EmailBundle bundle;
                bundle = imap.FetchHeaders(messageSet);
                if (bundle == null)
                {

                    throw new Exception(imap.LastErrorText);
                }

                //if(!imap.CopyMultiple(messageSet, "Delivery Failure"))
                //    Console.WriteLine("Erreur copy");


                //success = imap.SetFlags(messageSet, "Deleted", 1);
                //if (success != true)
                //{
                //    Console.WriteLine("Erreur effacement");
                //}


                //success = imap.SelectMailbox("Delivery Failure");
                //if (success != true)
                //{
                //    throw new Exception(imap.LastErrorText);

                //}


                bundle = imap.FetchBundle(messageSet);
                if (bundle == null)
                {

                    throw new Exception(imap.LastErrorText);

                }


                #region clear delivery failure

                //  Loop over the bundle and display the FROM and SUBJECT of each.
                int i;
                for (i = 0; i <= bundle.MessageCount - 1; i++)
                {
                    Chilkat.Email email;
                    email = bundle.GetEmail(i);


                    try
                    {
                        if (conn.State != System.Data.ConnectionState.Open)
                            conn.Open();

                        // Console.WriteLine(email.From + " : " + email.Subject + " : "+email.ReplyTo);
                        string body = email.GetPlainTextBody();
                        string ch = "Failed Recipient:";
                        string recipient = "";
                        int index = body.IndexOf(ch);
                        int index1 = 0;
                        if (index > 0)
                        {
                            index1 = body.IndexOf("\r", index);
                            index += ch.Length;
                            recipient = body.Substring(index, index1 - index).Trim();
                        }

                        ch = "Reason:";
                        string reason = "";
                        index = body.IndexOf(ch);
                        if (index > 0)
                        {
                            index1 = body.IndexOf("\r", index);
                            index += ch.Length;
                            reason = body.Substring(index, index1 - index).Trim();
                        }
                        ch = "X-AIS-Ref:";
                        string reference = "";
                        index = body.IndexOf(ch);
                        if (index > 0)
                        {
                            index1 = body.IndexOf("\r", index);
                            index += ch.Length;
                            reference = body.Substring(index, index1 - index).Trim();
                        }
                        Console.WriteLine(recipient + " : " + reason);

                        sql = new SqlCommand("insert into ais_newsletters_error (dt,reference,recipient,reason) values (@dt,@reference,@recipient,@reason)", conn);
                        sql.Parameters.AddWithValue("dt", email.EmailDate);
                        sql.Parameters.AddWithValue("reference", reference);
                        sql.Parameters.AddWithValue("recipient", recipient);
                        sql.Parameters.AddWithValue("reason", reason);
                        if (sql.ExecuteNonQuery() == 0)
                            throw new Exception("Erreur insertion");

                        success = imap.SetMailFlag(email, "Deleted", 1);
                        if (success != true)
                        {
                            throw new Exception(imap.LastErrorText);
                        }





                    }
                    catch (Exception ee)
                    {
                        Console.WriteLine(ee.Message);
                    }

                    //textBox1.Text += email.From + "\r\n";
                    //textBox1.Refresh();
                    //textBox1.Text += email.Subject + "\r\n";
                    //textBox1.Refresh();
                    //textBox1.Text += "--" + "\r\n";
                    //textBox1.Refresh();

                }



                success = imap.ExpungeAndClose();
                if (success != true)
                {
                    throw new Exception("Erreur ExpungeAndClose");
                }
                #endregion



                #region clear of correctly delivered and been read

                messageSet = null;

                //  Select an IMAP mailbox
                success = imap.SelectMailbox("Inbox");
                if (success != true)
                {
                    throw new Exception(imap.LastErrorText);
                }

                fetchUids = true;
                messageSet = imap.Search("ALL", fetchUids);
                if (messageSet == null)
                {
                    throw new Exception(imap.LastErrorText);
                }

                // Fetch the emails into a bundle object:
                bundle = imap.FetchHeaders(messageSet);
                if (bundle == null)
                {
                    throw new Exception(imap.LastErrorText);
                }

                bundle = imap.FetchBundle(messageSet);
                if (bundle == null)
                {

                    throw new Exception(imap.LastErrorText);

                }
                String[] prefixes = new String[] { "Lu: ", "Lu : ", "Lu :", "Read: ", "Read: ", "Confirmation de lecture : ", "lu :", "Lu :***SPAM*** ", "lu :*** SPAM *** ", "Lu :***SPAM*** ", "Confirmation de lecture : ", "Read-Receipt: ","Accusé de réception (lu): ","Confirmation de lecture : " };
                String[] prefixes_nonlus = new String[] { "Not read: " };

                for (i = 0; i <= bundle.MessageCount - 1; i++)
                {
                    Chilkat.Email email;
                    email = bundle.GetEmail(i);

                    bool lu=false;

                    string subject = email.Subject;
                    string dest = email.FromAddress;

                    Console.WriteLine(subject + "\t" + dest);
                    foreach (string prefixe in prefixes_nonlus)
                        if (subject.StartsWith(prefixe))
                        {
                            subject = subject.Substring(prefixe.Length);
                            break;
                        }
                    foreach (string prefixe in prefixes)
                        if (subject.StartsWith(prefixe))
                        {
                            subject = subject.Substring(prefixe.Length);
                            lu = true;
                            break;
                        }
                    
                        try
                        {
                            if (conn.State != System.Data.ConnectionState.Open)
                                conn.Open();
                            sql = new SqlCommand("select id from ais_newsletters where title=@title", conn);
                            sql.Parameters.AddWithValue("title", subject);
                            string res = "" + sql.ExecuteScalar();
                            if (res != "")
                            {
                                if(lu)
                                { 
                                    sql = new SqlCommand("Update ais_newsletters_out set [read]='Y' where status='T' and email=@email and newsletter_id=@id", conn);
                                    sql.Parameters.AddWithValue("id", res);
                                    sql.Parameters.AddWithValue("email", dest);
                                    int nb = sql.ExecuteNonQuery();
                                }

                                imap.SetMailFlag(email, "Deleted", 1);

                            }
                        }
                        catch
                        { }

                    
                      }
                  
                success = imap.ExpungeAndClose();



                #endregion


                #endregion

                imap.Disconnect();


                if (conn.State != ConnectionState.Open)
                    conn.Open();

                sql = new SqlCommand("SELECT * FROM ais_newsletters_error ", conn);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {

                        string reference = ("" + row["reference"]).Trim() ;
                        if(!reference.Equals(""))
                        {
                            if (("" + row["reason"]).StartsWith("Remote host said: 421") )
                            {
                                sql = new SqlCommand("UPDATE ais_newsletters_out SET status='A' WHERE email =@email AND newsletter_id =@reference", conn);
                                sql.Parameters.AddWithValue("email", row["recipient"]);
                                sql.Parameters.AddWithValue("reference", new Guid(reference));
                                if (sql.ExecuteNonQuery() > 0)
                                {
                                    sql = new SqlCommand("DELETE ais_newsletters_error WHERE id =@id", conn);
                                    sql.Parameters.AddWithValue("id", row["id"]);
                                    sql.ExecuteNonQuery();

                                    sql = new SqlCommand("UPDATE ais_newsletters SET status='E' WHERE id =@reference", conn);
                                    sql.Parameters.AddWithValue("reference", new Guid("" + row["reference"]));
                                    sql.ExecuteNonQuery();

                                }
                            }
                            else
                            {
                                sql = new SqlCommand("UPDATE ais_newsletters_out SET status='E',error=@error WHERE email =@email AND newsletter_id =@reference", conn);
                                sql.Parameters.AddWithValue("error", row["reason"]);
                                sql.Parameters.AddWithValue("email", row["recipient"]);
                                sql.Parameters.AddWithValue("reference", new Guid(reference));
                                if (sql.ExecuteNonQuery() > 0)
                                {
                                    sql = new SqlCommand("DELETE ais_newsletters_error WHERE id =@id", conn);
                                    sql.Parameters.AddWithValue("id", row["id"]);
                                    sql.ExecuteNonQuery();
                                }

                            }
                        }
                    }
                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                Console.WriteLine("--- Press Me ---");
                Console.ReadLine();
            }
           

        }
    }
}
