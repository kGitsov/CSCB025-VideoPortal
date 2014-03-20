using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Watch : System.Web.UI.Page
{
    public string srcLink;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            GetSrcLinkForVideo(Int32.Parse(Request.QueryString["id"].ToString()));
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
    }

    private void GetSrcLinkForVideo(int id)
    {
        string sql = "select * from videos where Id=" + id;
        SqlDataReader sdr = operateData.getRow(sql);
        sdr.Read();

        srcLink = sdr["embedLink"].ToString();
    }
}