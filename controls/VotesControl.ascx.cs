using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_VotesControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string sql = "select count(userId) from votes where videoId='"+Request.QueryString["id"]+"'";
        SqlConnection con = operateData.createCon();
        con.Open();
        SqlCommand com = new SqlCommand(sql, con);
        int count = (int)com.ExecuteScalar();

        if (count > 0)
        {
            VotesNumber.Text = count.ToString();
        }
        else
        {
            VotesNumber.Text = "0";
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            string userId = operateData.getUserId(Session["userName"].ToString());

            string sql = "select Id from votes where userId='" + userId + "' AND videoId='" + Request.QueryString["id"] + "'";
            int count = operateData.getCount(sql);

            if (count > 0)
            {
                //Nothing;
            }
            else
            {
                sql = "insert into votes values ('" + userId + "', '" + Request.QueryString["id"] + "')";
                operateData.execSql(sql);
                Button1.Enabled = false;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
        
    }
}