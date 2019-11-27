using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using Word = Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading;
using System.Reflection;


public partial class CreateSitSchedule : System.Web.UI.Page
{
    string documentId = string.Empty;
    string name = string.Empty;
    string value = string.Empty;
    //result declare 
    string site = string.Empty;
    string date = string.Empty;
    string date2 = string.Empty;
    string name2 = string.Empty;
    string Detail = string.Empty;
    string area = string.Empty;
    string hsal = string.Empty;
    string structuralfee = string.Empty;
    string applicafee = string.Empty;
    string road = string.Empty;
    string stand = string.Empty;
    string latitude = string.Empty;
    string longitude = string.Empty;
    string region = string.Empty;
    string siteid = string.Empty;
    string stackcode = string.Empty;
    string category = string.Empty;
    string electricity = string.Empty;
    string str1 = string.Empty;
    string str2 = string.Empty;
    string str3 = string.Empty;
    string str4 = string.Empty;
    string str5 = string.Empty;
    string str6 = string.Empty;
    string str7 = string.Empty;
    string str8 = string.Empty;

    Word.MailMergeField myMerge;

    Stopwatch sw = new Stopwatch();
    string els = string.Empty;
    string total = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        RefreshData();
        if (!Page.IsPostBack)
        {
            RefreshData();
        }
    }

    private void Bind()
    {
        try
        {
            DataTable dt = new DataTable();
            documentId = TextBoxDcoumentId.Text;

            var request = (HttpWebRequest)WebRequest.Create("https://api.docparser.com/v1/results/vivdzezeaohb/" + documentId);
            string user = "bad3deaf63b862781472e89e19113f90acc4aaad";
            string pass = "";
            string credential = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(user + ":" + pass));
            request.Headers.Add("Authorization", "Basic " + credential);
            request.ContentType = "application/text";
            var response = (HttpWebResponse)request.GetResponse();
            string res = string.Empty;

            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    string line;

                    dt.Columns.Add(new DataColumn("name", typeof(string)));
                    dt.Columns.Add(new DataColumn("value", typeof(string)));

                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadToEnd();

                        if (line != null)
                        {
                            var a = JsonConvert.DeserializeObject(line);
                        }
                        DataRow row = null;

                        DataTable data = new DataTable();

                        data = JsonToDataTable(line);

                        // Read Method create 
                        Template("", data);

                        JArray array = JArray.Parse(line);


                        /*
                          //foreach (JObject o in array.Children<JObject>())
                          //{
                          //    foreach (JProperty p in o.Properties())
                          //    {
                          //        string property = p.Name;

                          //        switch (property)
                          //        {
                          //            case "site_name":
                          //                site = p.Value.ToString();
                          //                Template(site);
                          //                break;
                          //            case "site_rasgis_id":
                          //                siteid = p.Value.ToString();
                          //                Template(siteid);
                          //                break;
                          //            case "latitude":
                          //                latitude = p.Value.ToString();
                          //                Template(latitude);
                          //                break;
                          //            case "longitude":
                          //                longitude = p.Value.ToString();
                          //                Template(longitude);
                          //                break;
                          //            case "site_stack_code":
                          //                stackcode = p.Value.ToString();
                          //                Template(stackcode);
                          //                break;
                          //            case "telkom_region":
                          //                region = p.Value.ToString();
                          //                Template(region);
                          //                break;
                          //            case "contract_start_date":
                          //                date = p.Value.ToString();
                          //                Template(date);
                          //                break;
                          //            case "date_completed":
                          //                date2 = p.Value.ToString();
                          //                Template(p.Value.ToString());
                          //                break;
                          //            case "structure_category":
                          //                category = p.Value.ToString();
                          //                Template(category);
                          //                break;
                          //            case "site_total_hasl":
                          //                hsal = p.Value.ToString();
                          //                Template(hsal);
                          //                break;
                          //            case "structure_total_hagl":
                          //                str8 = p.Value.ToString();
                          //                Template(str8);
                          //                break;
                          //            case "equipmentaccommodation":
                          //                str5 = p.Value.ToString();
                          //                Template(str5);
                          //                break;
                          //            case "otherantenna":
                          //                str6 = p.Value.ToString();
                          //                Template(str6);
                          //                break;
                          //            case "electricitystand_by_requirements":
                          //                str4 = p.Value.ToString();
                          //                Template(str4);
                          //                break;
                          //            case "area_in_m":
                          //                if (p.Value.ToString().Contains("["))
                          //                {
                          //                    JArray items = (JArray)o[p.Name];
                          //                    foreach (JObject oo in items.Children<JObject>())
                          //                    {
                          //                        foreach (JProperty pp in oo.Properties())
                          //                        {
                          //                            name = pp.Name;
                          //                            value = (string)pp.Value;
                          //                            row = dt.NewRow();
                          //                            row["name"] = name;
                          //                            row["value"] = value;
                          //                            dt.Rows.Add(row);

                          //                            area = value;
                          //                            Template(area);
                          //                        }
                          //                    }
                          //                }
                          //                break;
                          //            case "access_road_requirements":
                          //                str3 = p.Value.ToString();
                          //                Template(str3);
                          //                break;
                          //            case "applicationsite_fee":
                          //                str7 = p.Value.ToString();
                          //                Template(str7);
                          //                break;
                          //            case "structural_analysis_fees":
                          //                str1 = p.Value.ToString();
                          //                Template(str1);
                          //                break;
                          //            default:
                          //                break;
                          //        }
                          //    }
                          //}
                          */
                    }
                }
            }
        }
        catch (Exception err)
        {
            //throw;
        }
    }


    //For reading nested Json
    public void Template(string result, DataTable dtvalues)
    {

        //Method to create template 
        try
        {
            Object oMissing = System.Reflection.Missing.Value;
            Object oTrue = true;
            Object oFalse = true;
            Object savechanges = true;

            Word.ApplicationClass wordapp = new Word.ApplicationClass();
            Word.Document wordDoc = new Word.Document();
            Object oTemp = @"C:\Users\CMqulo\Documents\Source Code\AppSiteSchedule\Application\Application\SITE SCHEDULE AGREEMENT.dotx";

            wordDoc = wordapp.Documents.Add(ref oTemp, ref oMissing, ref oMissing, ref oMissing);


            foreach (Word.Field myMergeField in wordDoc.Fields)
            {
                //create range 
                Word.Range rngFieldcode = myMergeField.Code;
                //Method 
                string fieldText = rngFieldcode.Text;

                if (fieldText.StartsWith(" MERGEFIELD"))
                {
                    Int32 endMerge = fieldText.IndexOf("\\");
                    Int32 fieldNamelength = fieldText.Length - endMerge;
                    var fieldName = string.Empty;

                    if (endMerge > 0)
                    {
                        fieldName = fieldText.Substring(11, endMerge - 11);
                    }
                    else
                    {
                        fieldName = fieldText;
                    }

                    var code = fieldName.Replace("MERGEFIELD", string.Empty).Replace('"', ' ').Trim();

                    var chras = code.IndexOf(" ");

                    if (chras < 0)
                        chras = code.IndexOf(@"\");

                    chras = chras > 0 ? chras : code.Length;

                    code = code.Substring(0, chras);

                    bool found = false;

                    int i = 0;
                    string value = string.Empty;

                    // Loop through function for creating template

                    foreach (var item in code)
                    {
                        switch (code)
                        {

                            case "Co_locate_ID":
                                break;
                            case "Site_Name":
                                var query1 = (from x in dtvalues.Rows.OfType<DataRow>()
                                              where x.Field<string>("Name") == "site_name"
                                              select x).ToList();

                                if (query1.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query1[0].ItemArray[1].ToString();
                                }
                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                found = true;
                                break;
                            case "Site_ID":
                                var query2 = (from x in dtvalues.Rows.OfType<DataRow>()
                                              where x.Field<string>("Name") == "site_rasgis_id"
                                              select x).ToList();

                                if (query2.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query2[0].ItemArray[1].ToString();
                                }
                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Code_Ref":

                                var query3 = (from x in dtvalues.Rows.OfType<DataRow>()
                                              where x.Field<string>("Name") == "site_stack_code"
                                              select x).ToList();

                                if (query3.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query3[0].ItemArray[1].ToString();
                                }
                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Area_m":
                                var query4 = (from x in dtvalues.Rows.OfType<DataRow>()
                                              where x.Field<string>("Name") == "area_in_m"
                                              select x).ToList();

                                if (query4.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query4[0].ItemArray[1].ToString();
                                }

                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "SITE_TOTAL_HASL":
                                var query5 = (from x in dtvalues.Rows.OfType<DataRow>()
                                              where x.Field<string>("Name") == "site_total_hasl"
                                              select x).ToList();

                                if (query5.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query5[0].ItemArray[1].ToString();
                                }


                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Commencement_Date":
                                var query6 = (from x in dtvalues.Rows.OfType<DataRow>()
                                              where x.Field<string>("Name") == "contract_start_date"
                                              select x).ToList();

                                if (query6.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query6[0].ItemArray[1].ToString();
                                }



                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Structural_fee":
                                var query7 = (from x in dtvalues.Rows.OfType<DataRow>()
                                              where x.Field<string>("Name") == "structural_analysis_fees"
                                              select x).ToList();

                                if (query7.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query7[0].ItemArray[1].ToString();
                                }


                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Application_site_fee":
                                var query8 = (from x in dtvalues.Rows.OfType<DataRow>()
                                              where x.Field<string>("Name") == "applicationsite_fee"
                                              select x).ToList();


                                if (query8.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query8[0].ItemArray[1].ToString();
                                }


                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "AccessRoad":
                                var query9 = (from x in dtvalues.Rows.OfType<DataRow>()
                                              where x.Field<string>("Name") == "access_road_requirements"
                                              select x).ToList();


                                if (query9.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query9[0].ItemArray[1].ToString();
                                }



                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "StandBy_":
                                var query10 = (from x in dtvalues.Rows.OfType<DataRow>()
                                               where x.Field<string>("Name") == "standby_power_requirement"
                                               select x).ToList();


                                if (query10.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query10[0].ItemArray[1].ToString();
                                }


                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Electricity":
                                var query11 = (from x in dtvalues.Rows.OfType<DataRow>()
                                               where x.Field<string>("Name") == "ac_electricity_phase_requirement"
                                               select x).ToList();


                                if (query11.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query11[0].ItemArray[1].ToString();
                                }



                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Latitude_":
                                var query12 = (from x in dtvalues.Rows.OfType<DataRow>()
                                               where x.Field<string>("Name") == "latitude"
                                               select x).ToList();


                                if (query12.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query12[0].ItemArray[1].ToString();
                                }


                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Longitude":
                                var query13 = (from x in dtvalues.Rows.OfType<DataRow>()
                                               where x.Field<string>("Name") == "longitude"
                                               select x).ToList();


                                if (query13.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query13[0].ItemArray[1].ToString();
                                }


                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Region":
                                var query14 = (from x in dtvalues.Rows.OfType<DataRow>()
                                               where x.Field<string>("Name") == "telkom_region"
                                               select x).ToList();



                                if (query14.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query14[0].ItemArray[1].ToString();
                                }


                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Expiry_Date":
                                var query15 = (from x in dtvalues.Rows.OfType<DataRow>()
                                               where x.Field<string>("Name") == "date_completed"
                                               select x).ToList();



                                if (query15.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query15[0].ItemArray[1].ToString();
                                }


                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Mast_Category":
                                var query16 = (from x in dtvalues.Rows.OfType<DataRow>()
                                               where x.Field<string>("Name") == "structure_category"
                                               select x).ToList();


                                if (query16.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query16[0].ItemArray[1].ToString();
                                }


                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "TotalHASL":
                                var query17 = (from x in dtvalues.Rows.OfType<DataRow>()
                                               where x.Field<string>("Name") == "structure_total_hagl"
                                               select x).ToList();



                                if (query17.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query17[0].ItemArray[1].ToString();
                                }


                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Equipmentaccommodation":
                                var query18 = (from x in dtvalues.Rows.OfType<DataRow>()
                                               where x.Field<string>("Name") == "equipmentaccommodation"
                                               select x).ToList();



                                if (query18.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query18[0].ItemArray[1].ToString();
                                }

                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Otherantenna":
                                var query19 = (from x in dtvalues.Rows.OfType<DataRow>()
                                               where x.Field<string>("Name") == "otherantenna"
                                               select x).ToList();



                                if (query19.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query19[0].ItemArray[1].ToString();
                                }



                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Electricitystandbyrequirements":
                                var query20 = (from x in dtvalues.Rows.OfType<DataRow>()
                                               where x.Field<string>("Name") == "electricity__standby_comments"
                                               select x).ToList();




                                if (query20.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query20[0].ItemArray[1].ToString();
                                }


                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Accessroadrequirements":
                                var query21 = (from x in dtvalues.Rows.OfType<DataRow>()
                                               where x.Field<string>("Name") == "access_road_requirements"
                                               select x).ToList();



                                if (query21.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query21[0].ItemArray[1].ToString();
                                }


                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Applicationsitefee":
                                var query22 = (from x in dtvalues.Rows.OfType<DataRow>()
                                               where x.Field<string>("Name") == "application__site_survey_fee"
                                               select x).ToList();


                                if (query22.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query22[0].ItemArray[1].ToString();
                                }


                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            case "Structuralfees":
                                var query23 = (from x in dtvalues.Rows.OfType<DataRow>()
                                               where x.Field<string>("Name") == "structural_analysis_fees"
                                               select x).ToList();



                                if (query23.Count == 0)
                                {
                                    value = "";
                                }
                                else
                                {
                                    value = query23[0].ItemArray[1].ToString();
                                }


                                myMergeField.Select();
                                wordapp.Selection.Font.Color = Word.WdColor.wdColorRed;
                                wordapp.Selection.TypeText(value);
                                break;
                            default:
                                break;
                        }
                        found = true;
                        break;
                    }

                }
            }
            DateTime now = DateTime.Now;
            // Object oSaveAsFile = (Object)Server.MapPath(@"C: \Users\CMqulo\Documents\Source Code\AppSiteSchedule\Application\Application\MyFile.doc");
            wordDoc.SaveAs("MyFile.doc", ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);
            wordDoc.Close(ref savechanges, ref oMissing, ref oMissing);
            wordapp.Documents.Open("MyFile.doc");
            wordapp.Application.Quit();
        }
        catch
        {
            throw;
        }
    }

    private void RefreshData()
    {
        DataLayerClass.DatalayerClass dl = new DataLayerClass.DatalayerClass();
        DataList1.DataSource = dl.runQuery("ReturnProcessing_ssp").Tables[0];
        DataList1.DataBind();
    }

    public void CalculateTime(string time)
    {
        StringBuilder st = new StringBuilder();
        st.Append("<table><tr>");
        st.Append("<td>Runtime : </td>");
        st.Append("<td>" + els + "</td>");
        st.Append("</tr>");
        st.Append("</table>");
        Label1.Text = st.ToString();
    }

    public void Insert()
    {
        //Insert time
        DataLayerClass.DatalayerClass dl = new DataLayerClass.DatalayerClass();
        dl.UploadTime(els, DateTime.Now.ToLocalTime(), documentId);
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        sw.Start();
        Bind();
        System.Threading.Thread.Sleep(1000);
        sw.Stop();
        TimeSpan ts = sw.Elapsed;
        els = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        CalculateTime(els);
        Insert();
    }

    public static List<string> GetMergeFields(List<string> all)
    {
        var merges = new List<string>();

        foreach (var fields in all)
        {
            var isNest = false;
            foreach (var fieldChar in fields)
            {
                int charCode = fieldChar;
                if (charCode == 19 || charCode == 21)
                {
                    isNest = true;
                    break;
                }
            }
            if (!isNest)
            {
                var fieldCode = fields;
                if (fieldCode.Contains("MERGEFIELD"))
                {
                    var fieldName = fieldCode.Replace("MERGEFIELD", string.Empty).Replace('"', ' ').Trim();
                    var charsToGet = fieldName.IndexOf(" ");
                    if (charsToGet < 0)
                    {
                        charsToGet = fieldName.IndexOf(@"\");
                    }

                    charsToGet = charsToGet > 0 ? charsToGet : fieldName.Length;

                    fieldName = fieldName.Substring(0, charsToGet);

                    if (!merges.Contains(fieldName))
                    {
                        merges.Add(fieldName);
                    }
                }
            }
        }
        return merges;
    }

    public static void ReplaceMail(string msword, string mailMergeField, string mailMergeFieldVal)
    {
        object docName = msword;
        object missing = Missing.Value;
        Word.MailMerge mailMerge;
        Word.Document doc;
        Word.Application app = new Word.Application();
        app.Visible = false;

        doc = app.Documents.Open(ref docName,
            ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing);

        mailMerge = doc.MailMerge;

        foreach (Word.MailMergeField f in mailMerge.Fields)
        {
            if (f.Code.Text.IndexOf("MERGEFIELD \"" + mailMergeField + "\"") > -1)
            {
                f.Select();
                app.Selection.TypeText(mailMergeFieldVal);
            }
        }
        object saveChange = Word.WdSaveOptions.wdSaveChanges;
        doc.Close(ref saveChange, ref missing, ref missing);
        app.Quit();
    }

    public void ReplaceMethod(string fieldText)
    {
        Word.ApplicationClass wordapp = new Word.ApplicationClass();
        Word.Document wordDoc = new Word.Document();
    }

    public static string GetTextFromWordDocument(object filePath)
    {
        var filepathAsString = filePath as string;

        if (string.IsNullOrEmpty(filepathAsString))
        {
            throw new ArgumentException("filePath");
        }
        if (!File.Exists(filepathAsString))
        {
            throw new FileNotFoundException("Could Not find file", filepathAsString);
        }

        var textFromWordDocument = string.Empty;
        Word.Application wordapp = new Word.Application();
        Word.Document wordDocument = null;
        Word.Range wordContent = null;

        try
        {
            wordDocument = wordapp.Documents.Open(ref filePath, Missing.Value, true);
            wordContent = wordDocument.Content;
            textFromWordDocument = wordContent.Text;
        }
        catch
        {

        }
        finally
        {
            if (wordDocument != null) { wordDocument.Close(false); }
            if (wordapp != null) { wordapp.Quit(false); }

            // ReleaseComObject(wordDocument);
            // ReleaseComObject(wordContent);
            // ReleaseComObject(wordDocument);
            // ReleaseComObject(wordapp);
        }
        return textFromWordDocument;
    }

    public static void ReleaseComObject(Word.Application document)
    {
        throw new NotImplementedException();
    }

    protected void DataList1_ItemCreated(object sender, DataListItemEventArgs e)
    {

    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {

    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        DataLayerClass.DatalayerClass dl = new DataLayerClass.DatalayerClass();
        DataList1.DataSource = dl.runQuery("ReturnProcessing_ssp").Tables[0];
        DataList1.DataBind();
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            RefreshData();
            Label1.Text = string.Empty;
        }
        catch
        {
        }
    }

    public static void ConvertWord()
    {
        object str_letter_path = @"C:\Users\CMqulo\Documents\MyFile.doc";
        object output = @"C:\Users\CMqulo\Documents\result.pdf";

        Word.Application word = new Word.Application();
        word.Visible = false;
        word.ScreenUpdating = false;

        object oMissing = System.Reflection.Missing.Value;
        object fileFormat = Word.WdSaveFormat.wdFormatPDF;

        Word.Document doc = word.Documents.Open(ref str_letter_path, ref oMissing,
                          ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                          ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                          ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        doc.Activate();

        string format = string.Empty;

        switch (fileFormat)
        {
            case ".doc":
                fileFormat = Word.WdSaveFormat.wdFormatDocument;
                break;
            case ".docx":
                break;
            case ".dotx":
                break;
            case ".dotm":
                break;
            case ".docb":
                break;
            case ".pdf":
                fileFormat = Word.WdSaveFormat.wdFormatPDF;
                break;
            default:
                break;

        }
        doc.SaveAs(ref output, ref fileFormat, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing);

        object saveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
        if (doc != null)
        {
            ((Word._Document)doc).Close(ref saveChanges, ref oMissing, ref oMissing);
            ((Microsoft.Office.Interop.Word._Application)word).Quit(ref saveChanges, ref oMissing, ref oMissing);
        }
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        ConvertWord();
    }

    public static DataTable JsonToDataTable(string json)
    {

        try
        {
            string name = string.Empty;
            String value = string.Empty;
            DataRow rw = null;
            DataTable dt = new DataTable();

            //var jsonLinq = JObject.Parse(json);
            JArray jsonArray = JArray.Parse(json);
            // Find the first array using Linq
            var srcArray = jsonArray.Descendants().Where(d => d is JArray).First();
            var trgArray = new JArray();
            DataTable Jsondt = new DataTable();
            Jsondt.Clear();
            Jsondt.Columns.Add("Name");
            Jsondt.Columns.Add("Key");



            foreach (JObject row in srcArray.Root.ToArray())
            {
                var cleanRow = new JObject();
                foreach (JProperty column in row.Properties())
                {
                    DataRow dtrow = Jsondt.NewRow();
                    // Only include JValue types
                    if (column.Value is JValue)
                    {
                        cleanRow.Add(column.Name, column.Value);

                        //outputFile.WriteLine(column.Name + ":" + column.Value);

                        //string columnname = column.Name;

                    }
                    else
                    {
                        cleanRow.Add(column.Name, column.Value);


                    }
                    dtrow["Name"] = column.Name;
                    dtrow["Key"] = column.Value;
                    Jsondt.Rows.Add(dtrow);


                }

                trgArray.Add(cleanRow);
            }
            //}

            return Jsondt;  //JsonConvert.DeserializeObject<DataTable>(trgArray.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
