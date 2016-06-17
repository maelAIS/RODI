
#region Copyrights

//
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Log.EventLog;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Xml.Serialization;
using DotNetNuke.Services.Mail;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Users;
using System.Web;
using DotNetNuke.Entities.Tabs;
using Aspose.Pdf.Facades;
using System.Text.RegularExpressions;
using System.IO.Compression;

namespace AIS
{
    public static class Functions
    {
        public static TextBox getTextBox(string name, ControlCollection controls)
        {
            name = name.ToLower();
            foreach (Control ctrl in controls)
            {
                if (ctrl.Controls.Count > 0)
                {
                    Control ret = getTextBox(name, ctrl.Controls);
                    if (ret != null)
                    {
                        return (TextBox)ret;
                    }
                }
                else
                {
                    if (ctrl.GetType().Name.Equals("TextBox"))
                    {
                        if (ctrl.ID.ToLower().Equals(name))
                        {
                            return (TextBox)ctrl;
                        }
                    }
                }
            }
            return null;
        }
        public static RadioButtonList getRadioButtonList(string name, ControlCollection controls)
        {
            name = name.ToLower();
            foreach (Control ctrl in controls)
            {
                if (ctrl.Controls.Count > 0)
                {
                    Control ret = getRadioButtonList(name, ctrl.Controls);
                    if (ret != null)
                    {
                        return (RadioButtonList)ret;
                    }
                }
                else
                {
                    if (ctrl is RadioButtonList)
                    {
                        if (ctrl.ID.ToLower().Equals(name))
                        {
                            return (RadioButtonList)ctrl;
                        }
                    }
                }
            }
            return null;
        }
        public static DropDownList getDropDownList(string name, ControlCollection controls)
        {
            name = name.ToLower();
            foreach (Control ctrl in controls)
            {
                if (ctrl.Controls.Count > 0)
                {
                    Control ret = getDropDownList(name, ctrl.Controls);
                    if (ret != null)
                    {
                        return (DropDownList)ret;
                    }
                }
                else
                {
                    if (ctrl.GetType().Name.Equals("DropDownList"))
                    {
                        if (ctrl.ID.ToLower().Equals(name))
                        {
                            return (DropDownList)ctrl;
                        }
                    }
                }
            }
            return null;
        }

        public static void MessageBoxShow(string message, Control owner)
        {
            Page page = (owner as Page) ?? owner.Page;
            if (page == null) return;

            page.ClientScript.RegisterStartupScript(owner.GetType(),
                "ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
                message));
        }

        /// <summary>
        /// Get a list of items using the tabid
        /// </summary>
        /// <param name="selectedtabid"></param>
        /// <returns></returns>
        public static List<ListItem> GetListItemsFromTabs(int selectedtabid)
        {
            List<ListItem> liste = new List<ListItem>();
            List<TabInfo> tabs = TabController.GetPortalTabs(Globals.GetPortalSettings().PortalId, 0, false, null, true, false, false, false, false);

            foreach (TabInfo t in tabs)
            {
                ListItem li = new ListItem();
                li.Text = (new String('.', 3 * t.Level)) + t.TabName;
                li.Value = "" + t.TabID;
                if (t.TabID == selectedtabid)
                    li.Selected = true;

                liste.Add(li);
            }
            return liste;
        }


        /// <summary>
        /// Get the rotary year
        /// </summary>
        /// <returns></returns>
        public static int GetRotaryYear()
        {
            int annee = DateTime.Now.Year;
            if (DateTime.Now < new DateTime(annee, 7, 1))
                annee--;
            return annee;
        }

        /// <summary>
        /// Get the member
        /// </summary>
        /// <returns></returns>
        public static Member GetCurrentMember()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return DataMapping.GetMemberByUserID(Globals.GetPortalSettings().UserInfo.UserID);
            }
            return null;
        }

        /// <summary>
        /// Get the user club
        /// </summary>
        public static Club CurrentClub
        {
            get
            {
                Member member = GetCurrentMember();
                if (member != null)
                {
                    if (!DataMapping.IsMemberInRole(member.id, Const.ROLE_ADMIN_DISTRICT) && !DataMapping.IsMemberInRole(member.id, Const.ADMIN_ROLE) && !DataMapping.IsMemberInRole(member.id, Const.ROLE_ADMIN_ROTARACT) && !DataMapping.isADG(member.id))
                    {
                        Club club = DataMapping.GetClub(member.cric);
                        HttpContext.Current.Session["Club"] = club;
                    }
                }
                return HttpContext.Current.Session["Club"] as Club;
            }
            set
            {
                HttpContext.Current.Session["Club"] = value;
            }
        }

        /// <summary>
        /// Get the cric of the user club
        /// </summary>
        public static int CurrentCric
        {
            get
            {
                int cric = 0;
                if (Functions.CurrentClub != null)
                    cric = Functions.CurrentClub.cric;
                return cric;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string ClearFileName(string filename)
        {
            filename = filename.Replace(" ", "-");
            filename = filename.Replace("é", "e");
            filename = filename.Replace("è", "e");
            filename = filename.Replace("à", "a");
            filename = filename.Replace("ù", "u");
            return filename;
        }

        public static string YESNO2UF(string yesno)
        {
            if (yesno == Const.YES)
                return Const.YES_UF;
            if (yesno == Const.NO)
                return Const.NO_UF;
            return "";
        }
        public static Bitmap Thumb(Bitmap bmp, int newWidth, int newHeight)
        {
            Bitmap bmpOut = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(bmpOut);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.FillRectangle(Brushes.White, 0, 0, newWidth, newHeight);
            g.DrawImage(bmp, 0, 0, newWidth, newHeight);
            return bmpOut;
        }
        public static Bitmap ThumbByWidth(Bitmap bmp, int width)
        {
            double ratio = (double)bmp.Height / (double)bmp.Width;

            int newWidth = width;
            int newHeight = (int)(width * ratio);

            bmp = AIS.Functions.Thumb(bmp, newWidth, newHeight);
            return bmp;
        }

        public static string UrlAddParam(string url, string param, string valeur)
        {

            if (url.IndexOf("?") > -1)
            {
                string[] prms = url.Substring(url.IndexOf("?") + 1).Split('&');
                url = url.Substring(0, url.IndexOf("?") + 1);
                foreach (string s in prms)
                {
                    if (!s.StartsWith(param)) // supprime l'eventuelle presence du meme param
                        url += s + "&";
                }
                url += param + "=" + valeur;
            }
            else
                url += "?" + param + "=" + valeur;


            return url;
        }

        /// <summary>
        /// Get the culture
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentCulture()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.Name;
        }
        public static void SendMail(string email, string subject, string body)
        {
            try
            {
                PortalSettings ps = Globals.GetPortalSettings();
                Mail.SendEmail(ps.Email, email, subject, body);
            }
            catch (Exception ee)
            {
                Error(ee);
            }
        }

        public static UserInfo GetProvider(int PortalId, int UserID)
        {
            return UserController.GetUserById(PortalId, UserID);
        }
        public static string GetCorrectUrl(string url)
        {
            url = url.ToLower();
            if (url.StartsWith("http://"))
                return url;
            return "http://" + url;
        }
        /// <summary>
        /// Send exception detail into DNN's event log
        /// </summary>
        /// <param name="e"></param>
        public static void Error(Exception e)
        {
            DotNetNuke.Services.Log.EventLog.EventLogController eventLog = new DotNetNuke.Services.Log.EventLog.EventLogController();
            LogInfo logInfo = new LogInfo();

            logInfo.LogUserID = -1;
            logInfo.LogPortalID = Globals.GetPortalSettings().PortalId;
            logInfo.LogTypeKey = EventLogController.EventLogType.HOST_ALERT.ToString();
            logInfo.AddProperty("Source de l'erreur", e.Source);
            logInfo.AddProperty("Message d'erreur", e.Message);
            logInfo.AddProperty("Pile d'appel", e.StackTrace);
            logInfo.AddProperty("Erreur complete", e.ToString());

            eventLog.AddLog(logInfo);
        }


        public static Bitmap GetBitmapFromMedia(Media media)
        {
            Bitmap bmp = new Bitmap(1, 1);
            try
            {

                MemoryStream ms = new MemoryStream(media.content);

                DataMapping.InitLicenceAsposePdf();

                PdfConverter objConverter = new PdfConverter();
                objConverter.BindPdf(ms);
                objConverter.DoConvert();

                if (objConverter.HasNextImage())
                {
                    //read image into memory stream
                    MemoryStream memoryStream = new MemoryStream();
                    objConverter.GetNextImage(memoryStream);


                    bmp = new Bitmap(memoryStream);
                }
                objConverter.Close();

            }
            catch (Exception ee)
            {
                Error(ee);
            }
            return bmp;
        }

        public static String BytesToString(byte[] bytes)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetString(bytes);
        }
        public static byte[] StringToBytes(string chaine)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(chaine);
        }
        public static Object Deserialize(String str, Type t)
        {
            XmlSerializer serializer = new XmlSerializer(t);
            StringReader reader = new StringReader(str);

            Object obj = serializer.Deserialize(reader);

            return obj;
        }
        public static String Serialize(Object Obj)
        {
            XmlSerializer serializer = new XmlSerializer(Obj.GetType());

            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            serializer.Serialize(writer, Obj, namespaces);
            writer.Close();
            writer.Dispose();
            return sb.ToString();
        }
        public static T DeepCopy<T>(T obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, obj);
                memoryStream.Position = 0;
                return (T)formatter.Deserialize(memoryStream);
            }
        }
        public static string CalculateMD5Hash(byte[] inputBytes)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public static bool UseBinarySerialization = true;
        public static byte[] Decompress(byte[] gzip)
        {
            if (gzip == null)
                return null;
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            using (GZipStream stream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }
        public static Object DeserialiseFromBytes(byte[] bytes, Type t)
        {
            if (UseBinarySerialization)
            {
                BinaryFormatter b = new BinaryFormatter();
                MemoryStream m = new MemoryStream(Decompress(bytes));
                Object o = b.Deserialize(m);
                return o;

            }
            else
            {
                string serialise = BytesToString(Decompress(bytes));
                return Deserialize(serialise, t);
            }

        }
        public static byte[] SerializeToBytes(Object Obj)
        {
            if (UseBinarySerialization)
            {
                MemoryStream m = new MemoryStream();
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(m, Obj);
                byte[] ba = m.ToArray();
                m.Close();
                return Compress(ba);
            }
            else
            {
                string ret = Serialize(Obj);
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                return Compress(encoding.GetBytes(ret));
            }
        }
        public static byte[] Compress(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream();

            using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
            {
                zip.Write(bytes, 0, bytes.Length);
            }

            return ms.ToArray();
        }

        /// <summary>
        /// Check if the file's name and extension are valid
        /// Return file's name if correct
        /// or return file's edited name (forbidden caracters replaced with _)
        /// or return null with error message
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="Erreur"></param>
        /// <returns></returns>
        public static string Check_File_Name_Valid(string filename, string content_type, out string Erreur)
        {
            Erreur = "";
            string patternStrict = @"^([A-Z]|[a-z]|[0-9]|_|-|\.|\s)$";

            try
            {
                if (!string.IsNullOrEmpty(filename) && !string.IsNullOrEmpty(content_type))
                {
                    Regex emailregex = new Regex(patternStrict);
                    Match match = emailregex.Match(filename);
                    if (match.Success)
                    {
                        string test_extension = Check_File_Ext_by_Mime(filename, content_type, out Erreur);
                        if (test_extension == null)
                        {
                            throw new Exception(Erreur);
                        }
                        else
                        {
                            return test_extension;
                        }
                    }
                    else
                    {
                        string new_Filename = "";

                        char[] tab_char = filename.ToCharArray();
                        foreach (char c in tab_char)
                        {
                            Match match_char = emailregex.Match(c.ToString());
                            if (match_char.Success)
                            {
                                new_Filename = new_Filename + c.ToString();
                            }
                            else
                            {
                                new_Filename = new_Filename + "_";
                            }
                        }

                        string test_extension = Check_File_Ext_by_Mime(new_Filename, content_type, out Erreur);
                        if (test_extension == null)
                        {
                            throw new Exception(Erreur);
                        }
                        else
                        {
                            return test_extension;
                        }
                    }
                }
                else
                {
                    Erreur = "Nom de fichier ou type MIME vide !";
                    return null;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                Erreur = ee.Message;
                return null;
            }
        }

        /// <summary>
        /// Check if the file's name contains the right extension according to the content type
        /// return the file's name with the right extension
        /// or return NULL with an error message 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="mime"></param>
        /// <param name="Erreur"></param>
        /// <returns></returns>
        public static string Check_File_Ext_by_Mime(string filename, string mime, out string Erreur) //Liste des mime http://www.freeformatter.com/mime-types-list.html
        {
            Erreur = "";
            try
            {
                if (!string.IsNullOrEmpty(filename) && !string.IsNullOrEmpty(mime))
                {
                    string[] splits = mime.ToLower().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

                    if (splits.Count() == 2)
                    {
                        switch (splits[0])
                        {
                            #region AUDIO
                            case "audio":
                                switch (splits[1])
                                {
                                    case "basic":
                                        if (!filename.ToLower().EndsWith(".au") && !filename.ToLower().EndsWith(".snd"))
                                        {
                                            filename += ".au";
                                        }
                                        break;
                                    case "L24":
                                        if (!filename.ToLower().EndsWith(".pcm"))
                                        {
                                            filename += ".pcm";
                                        }
                                        break;
                                    case "mid":
                                        if (!filename.ToLower().EndsWith(".mid") && !filename.ToLower().EndsWith(".rmi"))
                                        {
                                            filename += ".mid";
                                        }
                                        break;
                                    case "mpeg":
                                        if (!filename.ToLower().EndsWith(".mp3"))
                                        {
                                            filename += ".mp3";
                                        }
                                        break;
                                    case "mp4":
                                        if (!filename.ToLower().EndsWith(".mp4"))
                                        {
                                            filename += ".mp4";
                                        }
                                        break;
                                    case "x-aiff":
                                        if (!filename.ToLower().EndsWith(".aif") && !filename.ToLower().EndsWith(".aifc") && !filename.ToLower().EndsWith(".aiff"))
                                        {
                                            filename += ".aif";
                                        }
                                        break;
                                    case "x-mpegurl":
                                        if (!filename.ToLower().EndsWith(".m3u"))
                                        {
                                            filename += ".m3u";
                                        }
                                        break;
                                    case "vnd.rn-realaudio":
                                        if (!filename.ToLower().EndsWith(".ra") && !filename.ToLower().EndsWith(".ram"))
                                        {
                                            filename += ".ram";
                                        }
                                        break;
                                    case "ogg":
                                        if (!filename.ToLower().EndsWith(".ogg") && !filename.ToLower().EndsWith(".oga"))
                                        {
                                            filename += ".ogg";
                                        }
                                        break;
                                    case "vorbis":
                                        if (!filename.ToLower().EndsWith(".vorbis"))
                                        {
                                            filename += ".vorbis";
                                        }
                                        break;
                                    case "vnd.wav":
                                        if (!filename.ToLower().EndsWith(".wav"))
                                        {
                                            filename += ".wav";
                                        }
                                        break;
                                    case "x-ms-wma":
                                        if (!filename.ToLower().EndsWith(".wma"))
                                        {
                                            filename += ".wma";
                                        }
                                        break;
                                    case "midi":
                                        if (!filename.ToLower().EndsWith(".mid"))
                                        {
                                            filename += ".mid";
                                        }
                                        break;
                                }
                                break;
                            #endregion AUDIO

                            #region IMAGE
                            case "image":
                                switch (splits[1])
                                {
                                    case "bmp":
                                        if (!filename.ToLower().EndsWith(".bmp"))
                                        {
                                            filename += ".bmp";
                                        }
                                        break;
                                    case "x-portable-graymap":
                                        if (!filename.ToLower().EndsWith(".pgm"))
                                        {
                                            filename += ".pgm";
                                        }
                                        break;
                                    case "x-portable-pixmap":
                                        if (!filename.ToLower().EndsWith(".ppm"))
                                        {
                                            filename += ".ppm";
                                        }
                                        break;
                                    case "g3fax":
                                        if (!filename.ToLower().EndsWith(".g3"))
                                        {
                                            filename += ".g3";
                                        }
                                        break;
                                    case "cis-cod":
                                        if (!filename.ToLower().EndsWith(".cod"))
                                        {
                                            filename += ".cod";
                                        }
                                        break;
                                    case "gif":
                                        if (!filename.ToLower().EndsWith(".gif"))
                                        {
                                            filename += ".gif";
                                        }
                                        break;
                                    case "ief":
                                        if (!filename.ToLower().EndsWith(".ief"))
                                        {
                                            filename += ".ief";
                                        }
                                        break;
                                    case "jpeg":
                                    case "pjpeg":
                                    case "jpg":
                                        if (!filename.ToLower().EndsWith(".jpe") && !filename.ToLower().EndsWith(".jpeg") && !filename.ToLower().EndsWith(".jpg"))
                                        {
                                            filename += ".jpg";
                                        }
                                        break;
                                    case "pipeg":
                                        if (!filename.ToLower().EndsWith(".jfif"))
                                        {
                                            filename += ".jfif";
                                        }
                                        break;
                                    case "svg+xml":
                                        if (!filename.ToLower().EndsWith(".svg"))
                                        {
                                            filename += ".svg";
                                        }
                                        break;
                                    case "tiff":
                                        if (!filename.ToLower().EndsWith(".tiff") && !filename.ToLower().EndsWith(".tif"))
                                        {
                                            filename += ".tif";
                                        }
                                        break;
                                    case "png":
                                    case "x-png":
                                        if (!filename.ToLower().EndsWith(".png"))
                                        {
                                            filename += ".png";
                                        }
                                        break;
                                    case "x-cmu-raster":
                                        if (!filename.ToLower().EndsWith(".ras"))
                                        {
                                            filename += ".ras";
                                        }
                                        break;
                                    case "x-cmx":
                                        if (!filename.ToLower().EndsWith(".cmx"))
                                        {
                                            filename += ".cmx";
                                        }
                                        break;
                                    case "x-icon":
                                    case "vnd.microsoft.icon":
                                        if (!filename.ToLower().EndsWith(".ico"))
                                        {
                                            filename += ".ico";
                                        }
                                        break;
                                    case "x-portable-anymap":
                                        if (!filename.ToLower().EndsWith(".pnm"))
                                        {
                                            filename += ".pnm";
                                        }
                                        break;
                                    case "x-portable-bitmap":
                                        if (!filename.ToLower().EndsWith(".pbm"))
                                        {
                                            filename += ".pbm";
                                        }
                                        break;
                                    case "x-rgb":
                                        if (!filename.ToLower().EndsWith(".rgb"))
                                        {
                                            filename += ".rgb";
                                        }
                                        break;
                                    case "x-xbitmap":
                                        if (!filename.ToLower().EndsWith(".xbm"))
                                        {
                                            filename += ".xbm";
                                        }
                                        break;
                                    case "x-xpixmap":
                                        if (!filename.ToLower().EndsWith(".xpm"))
                                        {
                                            filename += ".xpm";
                                        }
                                        break;
                                    case "x-xwindowdump":
                                        if (!filename.ToLower().EndsWith(".xwd"))
                                        {
                                            filename += ".xwd";
                                        }
                                        break;
                                }
                                break;
                            #endregion IMAGE

                            #region APPLICATION
                            case "application":
                                switch (splits[1])
                                {
                                    case "pdf":
                                        if (!filename.ToLower().EndsWith(".pdf"))
                                        {
                                            filename += ".pdf";
                                        }
                                        break;
                                    case "xhtml+xml":
                                        if (!filename.ToLower().EndsWith(".xhtml"))
                                        {
                                            filename += ".xhtml";
                                        }
                                        break;
                                    case "xml":
                                        if (!filename.ToLower().EndsWith(".xml"))
                                        {
                                            filename += ".xml";
                                        }
                                        break;
                                    case "vnd.android.package-archive":
                                        if (!filename.ToLower().EndsWith(".apk"))
                                        {
                                            filename += ".apk";
                                        }
                                        break;
                                    case "epub+zip":
                                        if (!filename.ToLower().EndsWith(".epub"))
                                        {
                                            filename += ".epub";
                                        }
                                        break;
                                    case "x-msdownload":
                                        if (!filename.ToLower().EndsWith(".exe"))
                                        {
                                            filename += ".exe";
                                        }
                                        break;
                                    case "vnd.ms-htmlhelp":
                                        if (!filename.ToLower().EndsWith(".chm"))
                                        {
                                            filename += ".chm";
                                        }
                                        break;
                                    case "x-mswrite":
                                        if (!filename.ToLower().EndsWith(".wri"))
                                        {
                                            filename += ".wri";
                                        }
                                        break;
                                    case "vnd.ms-works":
                                        if (!filename.ToLower().EndsWith(".wps"))
                                        {
                                            filename += ".wps";
                                        }
                                        break;
                                    #region ADOBE
                                    case "x-shockwave-flash":
                                        if (!filename.ToLower().EndsWith(".swf"))
                                        {
                                            filename += ".swf";
                                        }
                                        break;
                                    case "vnd.adobe.fxp":
                                        if (!filename.ToLower().EndsWith(".fxp"))
                                        {
                                            filename += ".fxp";
                                        }
                                        break;
                                    case "vnd.cups-ppd":
                                        if (!filename.ToLower().EndsWith(".ppd"))
                                        {
                                            filename += ".ppd";
                                        }
                                        break;
                                    case "vnd.adobe.xfdf":
                                        if (!filename.ToLower().EndsWith(".xfdf"))
                                        {
                                            filename += ".xfdf";
                                        }
                                        break;
                                    #endregion ADOBE
                                    #region COMPRESSE
                                    case "zip":
                                        if (!filename.ToLower().EndsWith(".zip"))
                                        {
                                            filename += ".zip";
                                        }
                                        break;
                                    case "x-7z-compressed":
                                        if (!filename.ToLower().EndsWith(".7z"))
                                        {
                                            filename += ".7z";
                                        }
                                        break;
                                    case "x-rar-compressed":
                                        if (!filename.ToLower().EndsWith(".rar"))
                                        {
                                            filename += ".rar";
                                        }
                                        break;
                                    case "x-ace-compressed":
                                        if (!filename.ToLower().EndsWith(".ace"))
                                        {
                                            filename += ".ace";
                                        }
                                        break;
                                    case "x-tar":
                                        if (!filename.ToLower().EndsWith(".tar"))
                                        {
                                            filename += ".tar";
                                        }
                                        break;
                                    #endregion COMPRESSE
                                    #region OPEN DOCUMENT
                                    case "vnd.oasis.opendocument.text":
                                        if (!filename.ToLower().EndsWith(".odt"))
                                        {
                                            filename += ".odt";
                                        }
                                        break;
                                    case "vnd.oasis.opendocument.spreadsheet":
                                        if (!filename.ToLower().EndsWith(".ods"))
                                        {
                                            filename += ".ods";
                                        }
                                        break;
                                    case "vnd.oasis.opendocument.presentation":
                                        if (!filename.ToLower().EndsWith(".odp"))
                                        {
                                            filename += ".odp";
                                        }
                                        break;
                                    case "vnd.oasis.opendocument.graphics":
                                        if (!filename.ToLower().EndsWith(".odg"))
                                        {
                                            filename += ".odg";
                                        }
                                        break;
                                    case "vnd.oasis.opendocument.chart":
                                        if (!filename.ToLower().EndsWith(".odc"))
                                        {
                                            filename += ".odc";
                                        }
                                        break;
                                    case "vnd.oasis.opendocument.formula":
                                        if (!filename.ToLower().EndsWith(".odf"))
                                        {
                                            filename += ".odf";
                                        }
                                        break;
                                    case "vnd.oasis.opendocument.database":
                                        if (!filename.ToLower().EndsWith(".odb"))
                                        {
                                            filename += ".odb";
                                        }
                                        break;
                                    case "vnd.oasis.opendocument.image":
                                        if (!filename.ToLower().EndsWith(".odi"))
                                        {
                                            filename += ".odi";
                                        }
                                        break;
                                    case "vnd.oasis.opendocument.text-master":
                                        if (!filename.ToLower().EndsWith(".odm"))
                                        {
                                            filename += ".odm";
                                        }
                                        break;
                                    case "vnd.oasis.opendocument.text-template":
                                        if (!filename.ToLower().EndsWith(".ott"))
                                        {
                                            filename += ".ott";
                                        }
                                        break;
                                    case "vnd.oasis.opendocument.spreadsheet-template":
                                        if (!filename.ToLower().EndsWith(".ots"))
                                        {
                                            filename += ".ots";
                                        }
                                        break;
                                    case "vnd.oasis.opendocument.presentation-template":
                                        if (!filename.ToLower().EndsWith(".otp"))
                                        {
                                            filename += ".otp";
                                        }
                                        break;
                                    case "vnd.oasis.opendocument.graphics-template":
                                        if (!filename.ToLower().EndsWith(".otg"))
                                        {
                                            filename += ".otg";
                                        }
                                        break;
                                    #endregion OPEN DOCUMENT
                                    #region OFFICE
                                    case "msword":
                                        if (!filename.ToLower().EndsWith(".doc") && !filename.ToLower().EndsWith(".dot"))
                                        {
                                            filename += ".doc";
                                        }
                                        break;
                                    case "vnd.openxmlformats-officedocument.wordprocessingml.document":
                                        if (!filename.ToLower().EndsWith(".docx"))
                                        {
                                            filename += ".docx";
                                        }
                                        break;
                                    case "vnd.openxmlformats-officedocument.wordprocessingml.template":
                                        if (!filename.ToLower().EndsWith(".dotx"))
                                        {
                                            filename += ".dotx";
                                        }
                                        break;
                                    case "vnd.ms-word.document.macroEnabled.12":
                                        if (!filename.ToLower().EndsWith(".docm"))
                                        {
                                            filename += ".docm";
                                        }
                                        break;
                                    case "vnd.ms-word.template.macroEnabled.12":
                                        if (!filename.ToLower().EndsWith(".dotm"))
                                        {
                                            filename += ".dotm";
                                        }
                                        break;
                                    case "ms-excel":
                                        if (!filename.ToLower().EndsWith(".xls") && !filename.ToLower().EndsWith(".xlt") && !filename.ToLower().EndsWith(".xla"))
                                        {
                                            filename += ".xls";
                                        }
                                        break;
                                    case "vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                                        if (!filename.ToLower().EndsWith(".xlsx"))
                                        {
                                            filename += ".xlsx";
                                        }
                                        break;
                                    case "vnd.openxmlformats-officedocument.spreadsheetml.template":
                                        if (!filename.ToLower().EndsWith(".xltx"))
                                        {
                                            filename += ".xltx";
                                        }
                                        break;
                                    case "vnd.ms-excel.sheet.macroEnabled.12":
                                        if (!filename.ToLower().EndsWith(".xlsm"))
                                        {
                                            filename += ".xlsm";
                                        }
                                        break;
                                    case "vnd.ms-excel.template.macroEnabled.12":
                                        if (!filename.ToLower().EndsWith(".xltm"))
                                        {
                                            filename += ".xltm";
                                        }
                                        break;
                                    case "vnd.ms-excel.addin.macroEnabled.12":
                                        if (!filename.ToLower().EndsWith(".xlam"))
                                        {
                                            filename += ".xlam";
                                        }
                                        break;
                                    case "vnd.ms-excel.sheet.binary.macroEnabled.12":
                                        if (!filename.ToLower().EndsWith(".xlsb"))
                                        {
                                            filename += ".xlsb";
                                        }
                                        break;
                                    case "vnd.ms-powerpoint":
                                        if (!filename.ToLower().EndsWith(".ppt") && !filename.ToLower().EndsWith(".pot") && !filename.ToLower().EndsWith(".pps") && !filename.ToLower().EndsWith(".ppa"))
                                        {
                                            filename += ".ppt";
                                        }
                                        break;
                                    case "vnd.openxmlformats-officedocument.presentationml.presentation":
                                        if (!filename.ToLower().EndsWith(".pptx"))
                                        {
                                            filename += ".pptx";
                                        }
                                        break;
                                    case "vnd.openxmlformats-officedocument.presentationml.template":
                                        if (!filename.ToLower().EndsWith(".potx"))
                                        {
                                            filename += ".potx";
                                        }
                                        break;
                                    case "vnd.openxmlformats-officedocument.presentationml.slideshow":
                                        if (!filename.ToLower().EndsWith(".ppsx"))
                                        {
                                            filename += ".ppsx";
                                        }
                                        break;
                                    case "vnd.ms-powerpoint.addin.macroEnabled.12":
                                        if (!filename.ToLower().EndsWith(".ppam"))
                                        {
                                            filename += ".ppam";
                                        }
                                        break;
                                    case "vnd.ms-powerpoint.presentation.macroEnabled.12":
                                        if (!filename.ToLower().EndsWith(".pptm"))
                                        {
                                            filename += ".pptm";
                                        }
                                        break;
                                    case "vnd.ms-powerpoint.template.macroEnabled.12":
                                        if (!filename.ToLower().EndsWith(".potm"))
                                        {
                                            filename += ".potm";
                                        }
                                        break;
                                    case "vnd.ms-powerpoint.slideshow.macroEnabled.12":
                                        if (!filename.ToLower().EndsWith(".ppsm"))
                                        {
                                            filename += ".ppsm";
                                        }
                                        break;
                                    case "x-mspublisher":
                                        if (!filename.ToLower().EndsWith(".pub"))
                                        {
                                            filename += ".pub";
                                        }
                                        break;
                                    #endregion OFFICE
                                }
                                break;
                            #endregion APPLICATION

                            #region VIDEO
                            case "video":
                                switch (splits[1])
                                {
                                    case "x-matroska":
                                        if (!filename.ToLower().EndsWith(".mkv"))
                                        {
                                            filename += ".mkv";
                                        }
                                        break;
                                    case "3gpp":
                                        if (!filename.ToLower().EndsWith(".3gp"))
                                        {
                                            filename += ".3gp";
                                        }
                                        break;
                                    case "3gpp2":
                                        if (!filename.ToLower().EndsWith(".3g2"))
                                        {
                                            filename += ".3g2";
                                        }
                                        break;
                                    case "x-msvideo":
                                        if (!filename.ToLower().EndsWith(".avi"))
                                        {
                                            filename += ".avi";
                                        }
                                        break;
                                    case "x-flv":
                                        if (!filename.ToLower().EndsWith(".flv"))
                                        {
                                            filename += ".flv";
                                        }
                                        break;
                                    case "x-f4v":
                                        if (!filename.ToLower().EndsWith(".f4v"))
                                        {
                                            filename += ".f4v";
                                        }
                                        break;
                                    case "h261":
                                        if (!filename.ToLower().EndsWith(".h261"))
                                        {
                                            filename += ".h261";
                                        }
                                        break;
                                    case "h263":
                                        if (!filename.ToLower().EndsWith(".h263"))
                                        {
                                            filename += ".h263";
                                        }
                                        break;
                                    case "h264":
                                        if (!filename.ToLower().EndsWith(".h264"))
                                        {
                                            filename += ".h264";
                                        }
                                        break;
                                    case "x-ms-asf":
                                        if (!filename.ToLower().EndsWith(".asf"))
                                        {
                                            filename += ".asf";
                                        }
                                        break;
                                    case "x-ms-wmv":
                                        if (!filename.ToLower().EndsWith(".wmv"))
                                        {
                                            filename += ".wmv";
                                        }
                                        break;
                                    case "mpeg":
                                        if (!filename.ToLower().EndsWith(".mpeg"))
                                        {
                                            filename += ".mpeg";
                                        }
                                        break;
                                    case "mp4":
                                        if (!filename.ToLower().EndsWith(".mp4"))
                                        {
                                            filename += ".mp4";
                                        }
                                        break;
                                }
                                break;
                            #endregion VIDEO

                            #region TEXTE
                            case "text":
                                switch (splits[1])
                                {
                                    case "csv":
                                        if (!filename.ToLower().EndsWith(".csv"))
                                        {
                                            filename += ".csv";
                                        }
                                        break;
                                    case "html":
                                        if (!filename.ToLower().EndsWith(".html"))
                                        {
                                            filename += ".html";
                                        }
                                        break;
                                    case "plain":
                                        if (!filename.ToLower().EndsWith(".txt"))
                                        {
                                            filename += ".txt";
                                        }
                                        break;
                                    case "x-vcard":
                                        if (!filename.ToLower().EndsWith(".vcf"))
                                        {
                                            filename += ".vcf";
                                        }
                                        break;
                                    case "css":
                                        if (!filename.ToLower().EndsWith(".css"))
                                        {
                                            filename += ".css";
                                        }
                                        break;
                                    case "tab-separated-values":
                                        if (!filename.ToLower().EndsWith(".tsv"))
                                        {
                                            filename += ".tsv";
                                        }
                                        break;
                                }
                                break;
                            #endregion TEXTE

                            #region MESSAGE
                            case "message":
                                switch (splits[1])
                                {
                                    case "rfc822":
                                        if (!filename.ToLower().EndsWith(".eml"))
                                        {
                                            filename += ".eml";
                                        }
                                        break;
                                }
                                break;
                            #endregion MESSAGE
                        }

                        return filename;
                    }
                    else
                    {
                        Erreur = "Erreur lors de la lecture du MIME !";
                        return null;
                    }
                }
                else
                {
                    Erreur = "Nom de fichier ou type MIME vide !";
                    return null;
                }
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                Erreur = ee.Message;
                return null;
            }
        }

    }
}
