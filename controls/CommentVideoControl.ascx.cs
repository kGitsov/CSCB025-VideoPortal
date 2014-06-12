using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_CommentVideoControl : System.Web.UI.UserControl
{
    public int videoId;
    public int userId;
    public DateTime date;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SubmitContent_Click(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            date = DateTime.Now;
            videoId = Int32.Parse(Request.QueryString["id"].ToString());
            string username = Session["userName"].ToString();

            string sql = "select Id from users where username='" + username + "'";
            SqlDataReader sdr = operateData.getRow(sql);
            sdr.Read();

            userId = Int32.Parse(sdr["Id"].ToString());

            sql = "insert into comments values ('" + videoId + "', '" + userId + "', '" + CommentContent.Text + "', '" + date + "')";

            operateData.execSql(sql);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}