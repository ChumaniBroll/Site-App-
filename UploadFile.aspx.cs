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
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public partial class UploadFile : System.Web.UI.Page
{
    public static class Http
    {
        public static byte[] Post(string uri, NameValueCollection pairs)
        {
            byte[] response = null;
            using (WebClient client = new WebClient())
            {
                response = client.UploadValues(uri, pairs);
            }
            return response;
        }
    }

    private void RefreshData(string sindx)
    {
        sindx = Request.QueryString["document"];
        // string sUser = ""; // HttpContext.Current.Request.Cookies["CresOnlineCurrUser"].Value.ToString();
        DataLayerClass.DatalayerClass dl = new DataLayerClass.DatalayerClass();

        // dl.runQuery("execute OCR_TelkomQuotations_Unpack");
        dlStatus.DataSource = dl.runQuery("Documents_SSP").Tables[0];
        //dlStatus.DataSource = dl.runQuery("OCR_TelkomQuotations_SSP_status '" + sUser + "','" + DateTime.Today.ToString("dd MMM yyyy") + "'").Tables[0];
        dlStatus.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string index = Request.QueryString["document"];
        if (!IsPostBack) RefreshData(index);
    }

    protected void dlStatus_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string item = e.Item.ItemIndex.ToString();
        bool clicked = false;
        if (e.CommandName == "Viewdoc")
        {
            Label labelText = (Label)dlStatus.Items[e.Item.ItemIndex].FindControl("Label1");
            string labelVal = labelText.Text;
            IframeDoc.Src = "docviewer.aspx?document=" + e.CommandArgument.ToString();
            clicked = true;
        }

        if (clicked == true)
        {
            this.Page.Response.Write("<script>window.open('" + "?index=" + item + "')</script>");
        }
    }

    protected void dlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        sSendFile(TextBox1.Text);
    }
    //Try to fix upload.. 
    private void sSendFile(string s)
    {
        var response = Http.Post("https://api.docparser.com/v1/document/fetch/vivdzezeaohb", new NameValueCollection()
       {
           { "api_key","bad3deaf63b862781472e89e19113f90acc4aaad"},
           { "url","https://cres.brollonline.co.za/cresonline/automation/colocations/docviewer.aspx?document=" + s.ToString() },
           {"remote_id", s }
       });
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        display("");
    }

    public void display(string index)
    {
        IframeDoc.Src = "docviewer.aspx?document=" + index;
    }

    public void DisplayGrid()
    {

    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string index = Request.QueryString["document"];
        RefreshData(index);
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (FileUpload.HasFile)
        {
            try
            {
                string strFilePath = FileUpload.PostedFile.FileName;
                string strFileName = Path.GetFileName(strFilePath);
                Int32 intFileSize = FileUpload.PostedFile.ContentLength;
                string strContentType = FileUpload.PostedFile.ContentType;

                Stream strmStream = FileUpload.PostedFile.InputStream;
                Int32 intFileLength = (Int32)strmStream.Length;
                byte[] bytUpfile = new byte[intFileLength + 1];

                strmStream.Read(bytUpfile, 0, intFileLength);
                strmStream.Close();

                DataLayerClass.DatalayerClass dl = new DataLayerClass.DatalayerClass();

                string sNewIndx = intFileLength.ToString();

                dl.UploadFile(sNewIndx, "1", strFileName, "PDF", bytUpfile);

                //Insert into database once
                display(sNewIndx);

                lblComms.Text = "Upload Success. File was uploaded and saved to the database.";

            }
            catch (Exception err)
            {
                lblComms.Text = "The file was not updloaded because the following error happened: " + err.ToString();
            }
        }
        else
        {
            lblComms.Text = "No file has been chosen";
        }
    }
}