using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ReturnValues : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { }
    }

    public void ReturnAll(string search)
    {
        try
        {
            DataLayerClass.DatalayerClass dll = new DataLayerClass.DatalayerClass();
            //dll.runQuery("execute ReturnValue_sp '" + search);
            ListView1.DataSource = dll.runQuery("ReturnValue_sp '" + search + "'");
            ListView1.DataBind();
        }
        catch (Exception err)
        {

        }
    }

    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string result = TextBox1.Text;
            if (result == "")
            {
                ListView1.DataSource = null;
                ListView1.DataBind();
                throw new Exception("no entry");
            }
            else
            {
                ReturnAll(result);
            }

        }
        catch (Exception err)
        {
        }
    }
}