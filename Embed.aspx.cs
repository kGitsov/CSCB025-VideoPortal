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
        link = linkToEmbed.Text;
        if (link.Contains("watch"))
        {
            int index = link.IndexOf("=");
            string video = link.Substring(index+1, 11);

            link = "//www.youtube.com/v/" + video;
            EmbedVideoFromLink(link, video);
        }
        else if (link.Contains("/v/"))
        {

        }
    }

    private void EmbedVideoFromLink(string l, string v)
    {
        string sql = "select * from users where username='" + Session["userName"] + "'";
        SqlDataReader sdr = operateData.getRow(sql);
        sdr.Read();
        int id = Int32.Parse(sdr["Id"].ToString());

        
        string url = "http://gdata.youtube.com/feeds/api/videos/" + v;
        XmlTextReader xml = new XmlTextReader(url);
        string title = "";
        string content = "";
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

        string imgPath = "http://img.youtube.com/vi/" + v + "/default.jpg";
        int type = categories.SelectedIndex;
        DateTime date = DateTime.Now;
        sql = "insert into videos values(@id,@title,@content,@date,@type,'0','0','False',@l,@imgPath)";
        SqlConnection con = operateData.createCon();
        SqlCommand com = new SqlCommand(sql, con);

        com.Parameters.AddWithValue("@id", id);
        com.Parameters.AddWithValue("@title", title);
        com.Parameters.AddWithValue("@content", content);
        com.Parameters.AddWithValue("@date", date);
        com.Parameters.AddWithValue("@type", type);
        com.Parameters.AddWithValue("@l", l);
        com.Parameters.AddWithValue("@imgPath", imgPath);

        con.Open();
        com.ExecuteNonQuery();
        con.Close();
        //operateData.execSql(sql);

    }
}