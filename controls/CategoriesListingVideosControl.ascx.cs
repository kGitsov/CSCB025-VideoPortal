using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_CategoriesListingVideosControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "";
        sql = "select categoryName from categories where Id=" + Request.QueryString["id"].ToString();
        SqlConnection con = operateData.createCon();
        con.Open();
        SqlCommand com = new SqlCommand(sql, con);
        SqlDataReader sdrCat = com.ExecuteReader();
        sdrCat.Read();
        string name = sdrCat["categoryName"].ToString();

        generateVideo.Controls.Add(new LiteralControl("<div id='categoryTitle'>" + name + "</div>"));
        if (Request.QueryString["id"] != null)
        {
            int category = Int32.Parse(Request.QueryString["id"]);
            sql = "select * from videos where videoTypeId=" + category;
        }
        else
        {
            sql = "select * from videos where videoTypeId=1";
        }
        
        DataTable dt = operateData.getRows(sql);

        foreach (DataRow item in dt.Rows)
        {
            GenerateNewRowWithVideos(item);
        }

    }

    private void GenerateNewRowWithVideos(DataRow item)
    {
        string videoLink = "<a href = '../watch.aspx?id=" + item["Id"].ToString() + "'>";
        string outVideoLink = "</a>";
        generateVideo.Controls.Add(new LiteralControl("<div id='video'>" + videoLink));
        Image img = new Image();
        img.ImageUrl = item["videoPicture"].ToString();
        img.ID = "videoPicture";
        img.Width = 180;
        img.Height = 100;
        generateVideo.Controls.Add(img);

        generateVideo.Controls.Add(new LiteralControl(outVideoLink));

        generateVideo.Controls.Add(new LiteralControl("<br/>"));

        generateVideo.Controls.Add(new LiteralControl(videoLink));
        Label lbl = new Label();
        lbl.Text = item["videoTitle"].ToString();
        lbl.ID = "videoTitle";
        generateVideo.Controls.Add(lbl);
        generateVideo.Controls.Add(new LiteralControl(outVideoLink));

        generateVideo.Controls.Add(new LiteralControl("<br/>"));

        lbl = new Label();
        lbl.Text = item["videDate"].ToString();
        lbl.ID = "videoDate";
        generateVideo.Controls.Add(lbl);

        generateVideo.Controls.Add(new LiteralControl("<br/>"));

        lbl = new Label();
        lbl.Text = "author: ";
        lbl.ID = "videoAuthor";
        generateVideo.Controls.Add(lbl);

        HyperLink lnk = new HyperLink();
        lnk.NavigateUrl = "../user.aspx?id=" + item["userId"].ToString();
        lnk.ID = "videoAuthorLink";

        string sql = "select * from users where Id=" + item["userId"].ToString();
        SqlConnection con = operateData.createCon();
        con.Open();
        SqlCommand com = new SqlCommand(sql, con);
        SqlDataReader sdr = com.ExecuteReader();

        sdr.Read();


        lnk.Text = sdr["username"].ToString();
        generateVideo.Controls.Add(lnk);
        generateVideo.Controls.Add(new LiteralControl("</div>"));
        con.Close();
    }
}