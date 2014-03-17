using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manage_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAdmin"] != null)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["activate"] != null)
                {
                    int cat = Int32.Parse(Request.QueryString["activate"].ToString());
                    ActivateUserId(cat);
                }
                if (Request.QueryString["deactivate"] != null)
                {
                    int cat = Int32.Parse(Request.QueryString["deactivate"].ToString());
                    DeactivateUserId(cat);
                }
            }

            ListUsersTable();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        
    }

    private void DeactivateUserId(int cat)
    {
        string sql = "update users set isActive = '0' where Id ='" + cat + "'";
        operateData.execSql(sql);
    }

    private void ActivateUserId(int cat)
    {
        string sql = "update users set isActive = '1' where Id ='" + cat + "'";
        operateData.execSql(sql);
    }

    private void ListUsersTable()
    {
        string sql = "select Id, username, isAdmin, isActive from users";
        DataTable dt = operateData.getRows(sql);
        if (dt.Rows.Count > 0)
        {
            dt.Columns.Add(new DataColumn("activation", typeof(string)));
            dt.Columns.Add(new DataColumn("view", typeof(string)));

            int c = 0;
            foreach (DataRow item in dt.Rows)
            {
                dt.Rows[c].SetField("view", "<a href='../user.aspx?id=" + item["Id"] +"'>View</a>");
                if (item["isActive"].ToString() == "False")
                {                    
                    dt.Rows[c].SetField("activation", "<a href='../manage/users.aspx?activate=" + item["Id"] + "'>Activate</a>");
                }
                else
                {
                    dt.Rows[c].SetField("activation", "<a href='../manage/users.aspx?deactivate=" + item["Id"] + "'>Deactivate</a>");
                }
                c++;
            }

            VideoTable.DataSource = dt;
            VideoTable.DataBind();
        }
        else
        {
            NoTextMessage.Visible = true;
        }
    }


    protected void VideoTable_RowDataBound(object sender, GridViewRowEventArgs e)
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