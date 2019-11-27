using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
//using System.Net.Http;
using System.Collections.Specialized;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Newtonsoft.Json;
using System.Threading.Tasks;
using iTextSharp.text.html;
using Newtonsoft.Json.Linq;
using Microsoft;
using iTextSharp.text.html.simpleparser;
using System.Drawing;
using Word = Microsoft.Office.Interop.Word;

public partial class QuoteDetails : System.Web.UI.Page
{
    string documentId = string.Empty;
    string name = string.Empty;
    string value = string.Empty;
    string date = string.Empty;
    string name2 = string.Empty;
    string Detail = string.Empty;
    string area = string.Empty;
    string hsal = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { }
    }

    public void InsertSiteSchedule()
    {
        try
        {
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
                    DataTable dt = new DataTable();
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
                        JArray array = JArray.Parse(line);

                        foreach (JObject o in array.Children<JObject>())
                        {
                            foreach (JProperty p in o.Properties())
                            {
                                string property = p.Name;

                                DataLayerClass.DatalayerClass dlc = new DataLayerClass.DatalayerClass();

                                if (property.Equals("site_owner")
                                    || property.Equals("site_rasgis_id")
                                    || property.Equals("document_id")
                                    || property.Equals("site_stack_code")
                                    || property.Equals("date_completed")
                                    || property.Equals("contract_start_date")
                                    || property.Equals("type_of_lease")
                                    || property.Equals("nrse_ref")
                                    || property.Equals("ac_electricity_requirement")
                                    || property.Equals("broll_ref")
                                    || property.Equals("ac_electricity_phase_requirement")
                                    || property.Equals("contract_no")
                                    || property.Equals("ac_circuit_breaker_requirement")
                                    || property.Equals("nrse_contact")
                                    || property.Equals("standby_power_requirement")
                                    || property.Equals("nrse_verified")
                                    || property.Equals("electricity__standby_comments")
                                    || property.Equals("broll_verified")
                                    || property.Equals("access_road_requirements")
                                    || property.Equals("company_name")
                                    || property.Equals("special_contractual_requirements")
                                    || property.Equals("contact_person")
                                    || property.Equals("application__site_survey_fee")
                                    || property.Equals("site_name")
                                    || property.Equals("telkom_region")
                                    || property.Equals("latitude")
                                    || property.Equals("longitude")
                                    || property.Equals("site_total_hasl")
                                    || property.Equals("site_total_hasl")
                                    || property.Equals("structure_name")
                                    || property.Equals("structure_owner")
                                    || property.Equals("structure_class")
                                    || property.Equals("structure_total_hagl")
                                    || property.Equals("structure_category")
                                    || property.Equals("number_of_antennas")
                                    || property.Equals("hagl_count")
                                    || property.Equals("area_in_m")
                                    || property.Equals("all_charges")
                                    || property.Equals("total")
                                    || property.Equals("cousers_containers"))
                                {
                                    if (p.Value.ToString().Contains("["))
                                    {
                                        JArray items = (JArray)o[p.Name];
                                        foreach (JObject oo in items.Children<JObject>())
                                        {
                                            foreach (JProperty pp in oo.Properties())
                                            {
                                                string v = (string)pp.Value;
                                                string result = pp.Name;
                                                string val1 = v;
                                                if (result != null && val1 != null)
                                                {
                                                    dlc.runQuery("InsertSiteSchedule_isp '" + documentId.Replace("'", "''") + "','" + result + "','" + val1 + "'");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string vv = (string)p.Value;
                                        name = p.Name;
                                        value = vv;

                                        if (name != null && value != null)
                                        {
                                            dlc.runQuery("InsertSiteSchedule_isp '" + documentId.Replace("'", "''") + "','" + name + "','" + value + "'");
                                            MsgBox("Information saved into database, name...value pair !", this.Page, this);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception err)
        {

        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Bind();
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

                        //System.IO.File.WriteAllText(@"C:\Users\CMqulo\Desktop\Edcon\path.txt", line);

                        JArray array = JArray.Parse(line);

                        foreach (JObject o in array.Children<JObject>())
                        {
                            foreach (JProperty p in o.Properties())
                            {
                                string property = p.Name;
                                if (property.Equals("site_owner")
                                    || property.Equals("site_rasgis_id")
                                    || property.Equals("document_id")
                                    || property.Equals("site_stack_code")
                                    || property.Equals("date_completed")
                                    //|| property.Equals("contract_start_date")
                                    || property.Equals("type_of_lease")
                                    || property.Equals("nrse_ref")
                                    || property.Equals("ac_electricity_requirement")
                                    || property.Equals("broll_ref")
                                    || property.Equals("ac_electricity_phase_requirement")
                                    || property.Equals("contract_no")
                                    || property.Equals("ac_circuit_breaker_requirement")
                                    || property.Equals("nrse_contact")
                                    || property.Equals("standby_power_requirement")
                                    || property.Equals("nrse_verified")
                                    || property.Equals("electricitystand_by_requirements")
                                    || property.Equals("broll_verified")
                                    || property.Equals("access_road_requirements")
                                    || property.Equals("company_name")
                                    //|| property.Equals("special_contractual_requirements")
                                    || property.Equals("contact_person")
                                    || property.Equals("application__site_survey_fee")
                                    || property.Equals("site_name")
                                    || property.Equals("telkom_region")
                                    || property.Equals("latitude")
                                    || property.Equals("longitude")
                                    || property.Equals("site_total_hasl")
                                    || property.Equals("site_total_hasl")
                                    || property.Equals("structure_name")
                                    || property.Equals("structure_owner")
                                    || property.Equals("structure_class")
                                    || property.Equals("structure_total_hagl")
                                    || property.Equals("structure_category")
                                    || property.Equals("structural_analysis_fees")
                                    || property.Equals("applicationsite_fee")
                                    //|| property.Equals("cousers_containers")
                                    )
                                {

                                    string pV = (string)p.Value;
                                    row = dt.NewRow();
                                    row["name"] = property;
                                    row["value"] = pV;
                                    dt.Rows.Add(row);
                                }
                                else if (property.Equals("number_of_antennas"))
                                {
                                    StringBuilder sb = new StringBuilder();
                                    if (p.Value.ToString().Contains("["))
                                    {
                                        JArray items = (JArray)o[p.Name];
                                        foreach (JObject oo in items.Children<JObject>())
                                        {
                                            foreach (JProperty pp in oo.Properties())
                                            {
                                                name = pp.Name;
                                                value = (string)pp.Value;

                                                row = dt.NewRow();
                                                row["name"] = name;
                                                row["value"] = value;
                                                dt.Rows.Add(row);

                                                name2 = name;
                                                // Template(name2);
                                            }
                                        }
                                    }

                                    //Detail = name;
                                    // lTable.Text += sb.ToString();
                                }
                                else if (property.Equals("tarea"))
                                {
                                    StringBuilder sb = new StringBuilder();
                                    if (p.Value.ToString().Contains("["))
                                    {
                                        JArray items = (JArray)o[p.Name];
                                        foreach (JObject oo in items.Children<JObject>())
                                        {
                                            foreach (JProperty pp in oo.Properties())
                                            {
                                                name = pp.Name;
                                                value = (string)pp.Value;
                                                row = dt.NewRow();
                                                row["name"] = name;
                                                row["value"] = value;
                                                dt.Rows.Add(row);

                                                Detail = value;
                                                //  Template(Detail);
                                            }
                                        }
                                    }
                                    // lTable.Text += sb.ToString();
                                }
                                else if (property.Equals("area_in_m"))
                                {
                                    StringBuilder sb = new StringBuilder();
                                    if (p.Value.ToString().Contains("["))
                                    {
                                        JArray items = (JArray)o[p.Name];
                                        foreach (JObject oo in items.Children<JObject>())
                                        {
                                            foreach (JProperty pp in oo.Properties())
                                            {
                                                name = pp.Name;
                                                value = (string)pp.Value;
                                                row = dt.NewRow();
                                                row["name"] = name;
                                                row["value"] = value;
                                                dt.Rows.Add(row);

                                                area = value;
                                                // Template(area);
                                            }
                                        }
                                    }
                                    // lTable.Text += sb.ToString();
                                }
                                else if (property.Equals("hagl_count"))
                                {
                                    StringBuilder sb = new StringBuilder();
                                    if (p.Value.ToString().Contains("["))
                                    {
                                        JArray items = (JArray)o[p.Name];
                                        foreach (JObject oo in items.Children<JObject>())
                                        {
                                            foreach (JProperty pp in oo.Properties())
                                            {
                                                name = pp.Name;
                                                value = (string)pp.Value;
                                                row = dt.NewRow();
                                                row["name"] = name;
                                                row["value"] = value;
                                                dt.Rows.Add(row);
                                            }
                                        }
                                    }
                                    // lTable.Text += sb.ToString();
                                }
                                else if (property.Equals("all_charges"))
                                {
                                    StringBuilder sb = new StringBuilder();
                                    if (p.Value.ToString().Contains("["))
                                    {
                                        JArray items = (JArray)o[p.Name];
                                        foreach (JObject oo in items.Children<JObject>())
                                        {
                                            foreach (JProperty pp in oo.Properties())
                                            {
                                                name = pp.Name;
                                                value = (string)pp.Value;
                                                row = dt.NewRow();
                                                row["name"] = name;
                                                row["value"] = value;
                                                dt.Rows.Add(row);
                                            }
                                        }
                                    }
                                    //  lTable.Text += sb.ToString();
                                }
                                else if (property.Equals("site_total_hasl"))
                                {
                                    hsal = p.Value.ToString();
                                    //Template(hsal);
                                }
                                else if (property.Equals("contract_start_date"))
                                {
                                    date = p.Value.ToString();
                                    //Template(date);
                                }
                                ListViewResult.DataSource = dt;
                                ListViewResult.DataBind();
                            }
                        }
                    }
                }
            }
        }
        catch (Exception err)
        {
            throw;
        }
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)ViewState["data"];
            string File = "PDFDetails";
            PDFDisplay(dt, File);
            MsgBox("Information saved into PDF File !!", this.Page, this);
        }
        catch (Exception err)
        {
            throw;
        }
    }

    private void PDFDisplay(DataTable dt, string File)
    {
        try
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachement;filename=" + File + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            panelResult.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdf = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlpaser = new HTMLWorker(pdf);
            PdfWriter.GetInstance(pdf, Response.OutputStream);
            pdf.Open();
            htmlpaser.Parse(sr);
            pdf.Close();
            Response.Write(pdf);
            Response.Flush();
            Response.End();

        }
        catch (Exception err)
        {
            throw;
        }
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        InsertSiteSchedule();

    }

    // Save and display on PDF file

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUploadResult.HasFile)
            {
                string path = System.IO.Path.Combine(Server.MapPath("~/FileUpload/"), FileUploadResult.FileName);
                FileUploadResult.SaveAs(path);
                myFrame.Attributes["src"] = @"/FileUpload/" + FileUploadResult.FileName;

                PdfReader reader = new PdfReader(@"C:\Users\CMqulo\Documents\Source Code\AppSiteSchedule\Application\Application\FileUpload\" + FileUploadResult.FileName);
                int intPage = reader.NumberOfPages;
                string[] words;
                string line;
                string text = null;

                for (int i = 1; i <= intPage; i++)
                {
                    text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
                    words = text.Split('\n');

                    for (int j = 0, len = words.Length; j < len; j++)
                    {
                        line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j]));
                        StringBuilder sb = new StringBuilder();

                        sb.AppendFormat("<table style='color:red;'>");
                        sb.AppendFormat("<tr><td>" + line + "</td></tr>");
                        sb.AppendFormat("</table>");
                    }
                }
            }
        }
        catch (Exception err)
        {
            throw;
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }
}