using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manage_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAdmin"] != null)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["delete"] != null)
                {
                    int cat = Int32.Parse(Request.QueryString["delete"].ToString());
                    DeleteComment(cat);
                }
            }

            ListAllRecentComments();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    private void DeleteComment(int cat)
    {
        string sql = "delete from comments where id='"+cat+"'";
        operateData.execSql(sql);
    }

    private void ListAllRecentComments()
    {
        string sql = "select comments.Id, videoId, date, username  from comments, users, profiles where comments.userId=users.Id and profiles.userId=users.Id order by comments.date DESC";
        DataTable dt = operateData.getRows(sql);
        if (dt.Rows.Count > 0)
        {
            dt.Columns.Add(new DataColumn("view", typeof(string)));
            dt.Columns.Add(new DataColumn("deletion", typeof(string)));

            int c = 0;
            foreach (DataRow item in dt.Rows)
            {
                dt.Rows[c].SetField("view", "<a href='../watch.aspx?id=" + item["videoId"] + "'>View</a>");
                dt.Rows[c].SetField("deletion", "<a href='comments.aspx?delete=" + item["id"] + "'>Delete</a>");
                c++;
            }

            CommentTable.DataSource = dt;
            CommentTable.DataBind();
        }
        else
        {
            NoTextMessage.Visible = true;
        }
    }

    protected void CommentTable_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int j = 0; j < e.Row.Cells.Count; j++)
            {
                string encoded = e.Row.Cells[j].Text;
                e.Row.Cells[j].Text = Context.Server.HtmlDecode(encoded);
            }
        }
    }
}