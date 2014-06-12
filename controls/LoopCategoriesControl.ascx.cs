using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_LoopCategoriesControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuLeft.Items.Clear();

        MenuItem first = new MenuItem();
        first.Text = "For approval";
        first.NavigateUrl = "../manage/admin.aspx?category=0";
        MenuLeft.Items.Add(first);

        for (int i = 4; i > 0; i--)
        {
            string sql = "select * from categories where Id=" + i;
            SqlDataReader sdr = operateData.getRow(sql);
            sdr.Read();

            MenuItem temp = new MenuItem();
            temp.Text = sdr["categoryName"].ToString();
            temp.NavigateUrl = "../manage/admin.aspx?category="+ sdr["id"].ToString();
            MenuLeft.Items.Add(temp);
        }

        MenuItem users = new MenuItem();
        users.Text = "Users";
        users.NavigateUrl = "../manage/users.aspx";

        MenuLeft.Items.Add(users);

        MenuItem comments = new MenuItem();
        comments.Text = "Comments";
        comments.NavigateUrl = "../manage/comments.aspx";

        MenuLeft.Items.Add(comments);
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