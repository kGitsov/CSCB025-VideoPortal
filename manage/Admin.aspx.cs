using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manage_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["isAdmin"] != null && Session["isAdmin"].ToString() == "True")
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["approve"] != null)
                {
                    int aprove = Int32.Parse(Request.QueryString["approve"].ToString());
                    ApproveVideoById(aprove);
                }
                if (Request.QueryString["category"] != null)
                {
                    int cat = Int32.Parse(Request.QueryString["category"].ToString());
                    if (Request.QueryString["category"] == "0")
                    {
                        LoadForApprovalTable();
                    }
                    else
                    {
                        LoadVideoTable(cat);
                    }
                }
            }
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
                
    }
      

    

    private void ApproveVideoById(int aprove)
    {
        string sql = "update videos set isApproved = '1' where Id ='" + aprove + "'";
        operateData.execSql(sql);
    }

    private void LoadForApprovalTable()
    {
        string sql = "select * from videos where isApproved='False'";
        DataTable dt = operateData.getRows(sql);
        if (dt.Rows.Count > 0)
        {
            dt.Columns.Add(new DataColumn("approve", typeof(string)));
            dt.Columns.Add(new DataColumn("view", typeof(string)));

            sql = "select Id from videos where isApproved='False'";
            DataTable dtIds = operateData.getRows(sql);

            int c = 0;
            foreach (DataRow item in dtIds.Rows)
            {
                dt.Rows[c].SetField("approve", "<a href='../manage/admin.aspx?approve=" + item["Id"].ToString() + "'>Approve</a>");
                dt.Rows[c].SetField("view", "<a href='../watch.aspx?id=" + item["Id"].ToString() + "'>View</a>");
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

    private void LoadVideoTable(int cat)
    {
        string sql = "select * from videos where videoTypeId=" + cat;
        DataTable dt = operateData.getRows(sql);
        if (dt.Rows.Count > 0)
        {            
            dt.Columns.Add(new DataColumn("view", typeof(string)));
            dt.Columns.Add(new DataColumn("approve", typeof(string)));
            
            sql = "select Id from videos where videoTypeId=" + cat;
            DataTable dtIds = operateData.getRows(sql);
            int c = 0;
            foreach (DataRow item in dtIds.Rows)
            {
                dt.Rows[c].SetField("view", "<a href='../watch.aspx?id="+item["Id"].ToString()+"'>View</a>");                    
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
        foreach (TableCell tableCell in e.Row.Cells)
        {
            DataControlFieldCell cell = (DataControlFieldCell)tableCell;
            if (cell.ContainingField.HeaderText == "Approve/Disapprove" && Request.QueryString["category"].ToString() !="0")
            {
                cell.Visible = false;
                continue;
            }
        }
    }
}