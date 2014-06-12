using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_FindCommentsAndListControl : System.Web.UI.UserControl
{
    public int videoId;
    public int userId;
    public string username;
    public string content;
    public DateTime date;
    public string imgPath;

    protected void Page_Load(object sender, EventArgs e)
    {
        generateComment.Controls.Add(new LiteralControl("<br/>"));
        videoId = Int32.Parse(Request.QueryString["id"].ToString()); //TODO: check if not int is input

        string sql = "select * from comments where videoId='"+videoId+"'";
        DataTable dt = operateData.getRows(sql);
        dt.Columns.Add(new DataColumn("userName", typeof(string)));
        foreach (DataRow item in dt.Rows)
        {
            userId = Int32.Parse(item["userId"].ToString());
            sql = "select userName, imgPath from users, profiles where users.id='"+userId+"' and profiles.userId='"+userId+"'";

            SqlConnection con = operateData.createCon();
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader sdr = com.ExecuteReader();
            sdr.Read();
            item["userName"] = sdr["userName"].ToString();
            username = item["userName"].ToString();
            date = (DateTime)item["date"];
            imgPath = sdr["imgPath"].ToString();
            ListCommentsBelow(item);

            con.Close();
        }

    }

    private void ListCommentsBelow(DataRow item)
    {
        string userLink = "<a href='../user.aspx?id=" + userId + "'>" + username + "</a>";
        //string outUserLink = "</a>";
        generateComment.Controls.Add(new LiteralControl("<a href='user.aspx?id="+userId+"'><img src='Pictures/" + imgPath + "' width='100px' height='100px'/></a>"));
        generateComment.Controls.Add(new LiteralControl("<br/>"));
        generateComment.Controls.Add(new LiteralControl("<div id='commentedUser'>" + userLink + "</div>"));
        generateComment.Controls.Add(new LiteralControl("<br/>"));
        generateComment.Controls.Add(new LiteralControl("<div id='commentDate'>" + date + "</div>"));
        generateComment.Controls.Add(new LiteralControl("<br/>"));
        generateComment.Controls.Add(new LiteralControl("<div id='commentContent'>" + item["content"] + "</div>"));
        generateComment.Controls.Add(new LiteralControl("<br/>"));
    }
}