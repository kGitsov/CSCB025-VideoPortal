using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Embed : System.Web.UI.Page
{
    public string link;
    public string username;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        username = Session["userName"].ToString();
    }
    protected void embedButton_Click(object sender, EventArgs e)
    {
        int what = 0;
        link = linkToEmbed.Text;
        if (link.Contains("watch"))
        {
            what = 0;
            int index = link.IndexOf("=");
            string video = link.Substring(index+1, 11);

            link = "//www.youtube.com/v/" + video;
            EmbedVideoFromLink(link, video, what);
        }
        else if (link.Contains("vimeo"))
        {
            what = 1;
            int index = link.IndexOf("vimeo.com/");
            string video = link.Substring(index+10);
            link = video;
            EmbedVideoFromLink(link, video, what);
        }
    }

    private void EmbedVideoFromLink(string l, string v, int w)
    {
        string sql ="";
        string title = "";
        string content = "";
        int id =0;
        string url = "";
        string imgPath = "";
        if (w == 0)
        {

            sql = "select * from users where username='" + Session["userName"] + "'";
            SqlDataReader sdr = operateData.getRow(sql);
            sdr.Read();
            id = Int32.Parse(sdr["Id"].ToString());


            url = "http://gdata.youtube.com/feeds/api/videos/" + v;
            XmlTextReader xml = new XmlTextReader(url);
            
            
            while (xml.Read())
            {
                if (xml.Name == "title")
                {
                    title = xml.ReadString();
                }
                if (xml.Name == "content")
                {
                    content = xml.ReadString();
                }
            }

            imgPath = "http://img.youtube.com/vi/" + v + "/default.jpg";
        }
        else
        {
            sql = "select * from users where username='" + Session["userName"] + "'";
            SqlDataReader sdr = operateData.getRow(sql);
            sdr.Read();
            id = Int32.Parse(sdr["Id"].ToString());


            url = "http://vimeo.com/api/v2/video/" + v +".xml";
            XmlTextReader xml = new XmlTextReader(url);


            while (xml.Read())
            {
                if (xml.Name == "title")
                {
                    title = xml.ReadString();
                }
                if (xml.Name == "description")
                {
                    content = xml.ReadString();
                }
                if (xml.Name =="thumbnail_large")
                {
                    imgPath = xml.ReadString();
                }
            }
        }
        int type = categories.SelectedIndex;
        DateTime date = DateTime.Now;
        sql = "insert into videos values(@id,@title,@content,@date,@type,'0','0','False',@l,@imgPath,@what)";
        SqlConnection con = operateData.createCon();
        SqlCommand com = new SqlCommand(sql, con);

        com.Parameters.AddWithValue("@id", id);
        com.Parameters.AddWithValue("@title", title);
        com.Parameters.AddWithValue("@content", content);
        com.Parameters.AddWithValue("@date", date);
        com.Parameters.AddWithValue("@type", type);
        com.Parameters.AddWithValue("@l", l);
        com.Parameters.AddWithValue("@imgPath", imgPath);
        com.Parameters.AddWithValue("@what", w);

        con.Open();
        com.ExecuteNonQuery();
        con.Close();
        //operateData.execSql(sql);

    }
}