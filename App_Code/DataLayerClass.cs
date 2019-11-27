using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;

/// <summary>
/// Summary description for DataLayerClass
/// </summary>
public class DataLayerClass
{
    public class DatalayerClass
    {
        private string dbConnect()
        {
            return ConfigurationManager.AppSettings["ConnectionString_CresOnline"].ToString();
        }

        public DataSet runQuery(string sQSQL)
        {
            SqlConnection conSQL = new SqlConnection();
            conSQL.ConnectionString = dbConnect();
            //conSQL.ConnectionTimeout=
            conSQL.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(sQSQL, conSQL);
            ad.Fill(ds);
            conSQL.Close();
            return ds;
        }

        public string GetVal(string sDocIndx, string sCol)
        {
            DataTable dt = runQuery("[LeaseRead_ssp_DataValXDocXcol] " + sDocIndx + ",'" + sCol + "'").Tables[0];
            if (dt.Rows.Count < 1)
            {
                return "";
            }
            else
            {
                return dt.Rows[0]["DataVal"].ToString();
            }
        }

        public DateTime ConvertToDate(string sDate)
        {
            try
            {
                return Convert.ToDateTime(sDate);
            }
            catch
            {
                return DateTime.Today;
            }
        }


        public int noOfMonths(string sStart, string sEnd)
        {
            try
            {
                DataTable dt = runQuery("tools_NoOFMonths '" + sStart + "','" + sEnd + "'").Tables[0];
                return Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            catch
            {
                return 0;
            }

        }

        public string findVal(string sText, string sSearch)
        {
            try
            {
                DataTable dt = runQuery("tool_searchForValue '" + sText.Replace("'", "''") + "','" + sSearch.Replace("'", "''") + "'").Tables[0];
                return dt.Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }

        }

        public DataTable PickList(string slistName)
        {
            try
            {
                return runQuery("PickLists_SSP '" + slistName + "'").Tables[0];
            }
            catch
            {
                return new DataTable();
            }
        }

        public void UploadTime(string processedAt, DateTime timezone, string documentId)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = dbConnect();
                SqlCommand cmd = null;
                cmd = new SqlCommand("InsertProcessing_isp", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter process = new SqlParameter("@processedAt", OleDbType.VarChar);
                process.Value = processedAt;

                SqlParameter timeZ = new SqlParameter("@timeZone", OleDbType.DBTime);
                timeZ.Value = Convert.ToDateTime(timezone);

                SqlParameter document = new SqlParameter("@documentId", OleDbType.VarChar);
                document.Value = documentId;

                cmd.Parameters.Add(process);
                cmd.Parameters.Add(timeZ);
                cmd.Parameters.Add(document);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

            }
        }

        public void UploadFile(string FK_Indx, string sSource, string Name, string DocType, byte[] Docu)
        {
            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = dbConnect();
                SqlCommand cmd = null;
                cmd = new SqlCommand("Documents_ISP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter FkIndx = new SqlParameter("@FK_Indx", OleDbType.Integer);
                FkIndx.Value = Convert.ToInt32(FK_Indx);

                SqlParameter dSource = new SqlParameter("@FK_Source", OleDbType.VarChar);
                dSource.Value = sSource;

                SqlParameter oName = new SqlParameter("@FileName", OleDbType.VarChar);
                oName.Value = Name;

                SqlParameter oType = new SqlParameter("@FileType", OleDbType.VarChar);
                oType.Value = DocType.Replace("'", "'");

                SqlParameter Doc = new SqlParameter("@Doc", OleDbType.VarBinary);
                Doc.Value = Docu;

                cmd.Parameters.Add(FkIndx);
                cmd.Parameters.Add(dSource);
                cmd.Parameters.Add(oName);
                cmd.Parameters.Add(oType);
                cmd.Parameters.Add(Doc);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

            }
        }
    }

}