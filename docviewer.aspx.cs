using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class docviewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sindx = Request.QueryString["document"];

        DataLayerClass.DatalayerClass dl = new DataLayerClass.DatalayerClass();
        DataTable dt = dl.runQuery("Documents_SSP_xIndx '" + sindx + "'").Tables[0];
        string sFileName = dt.Rows[0]["FileName"].ToString();

        Response.ClearContent();
        Response.AddHeader("Content-Disposition", "inline;filename=" + sFileName);
        string FileExt = sFileName.Substring(sFileName.IndexOf(".") + 1);
        Response.ClearContent();
        switch (FileExt.ToLower())
        {
            case "pdf": Response.ContentType = "application/pdf"; break;
            case "bmp": Response.ContentType = "image/bmp"; break;
            case "doc": Response.ContentType = "application/msword"; break;
            case "dot": Response.ContentType = "application/msword"; break;
            case "gif": Response.ContentType = "image/gif"; break;
            case "jpg": Response.ContentType = "image/jpeg"; break;
            case "mdi": Response.ContentType = "image/vnd.ms-modi"; break;
            case "peg": Response.ContentType = "image/jpeg"; break;
            case "pcx": Response.ContentType = "image/x-pcx"; break;
            case "pic": Response.ContentType = "image/pict"; break;
            case "png": Response.ContentType = "image/png"; break;
            case "pps": Response.ContentType = "application/vnd.ms-powerpoint"; break;
            case "ppt": Response.ContentType = "application/vnd.ms-powerpoint"; break;
            case "tif": Response.ContentType = "image/tiff"; break;
            case "iff": Response.ContentType = "image/tiff"; break;
            case "txt": Response.ContentType = "text/plain"; break;
            case "wpd": Response.ContentType = "application/wordperfect"; break;
            case "xls": Response.ContentType = "application/vnd.ms-excel"; break;
            case "xlsx": Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; break;
            case "docx": Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document"; break;
            default: Response.ContentType = "text/plain"; break;
        }
        HttpCookie cookie = new HttpCookie("ContentType", Response.ContentType);
        Response.AppendCookie(cookie);
        Response.BinaryWrite((byte[])dt.Rows[0]["doc"]); 
    }
}