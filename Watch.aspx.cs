using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Watch : System.Web.UI.Page
{
    public string srcLink;
    public string player;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            GetSrcLinkForVideo(Int32.Parse(Request.QueryString["id"].ToString()));
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
    }

    private void GetSrcLinkForVideo(int id)
    {
        string sql = "select * from videos where Id=" + id;
        SqlDataReader sdr = operateData.getRow(sql);
        sdr.Read();
        int what = Int32.Parse(sdr["what"].ToString());
        srcLink = sdr["embedLink"].ToString();

        if (what == 0)
        {
            player = "<object width='560' height='315'><param name='movie' value='" + srcLink +
            "'></param><param name='allowscriptaccess' value='always'></param><embed src='" + srcLink +
            "' type='application/x-shockwave-flash' width='560' height='315' allowscriptaccess='always' allowfullscreen='true'></embed></object>";
        }
        else
        {
            player = "<object width='500' height='281'><param name='allowfullscreen' value='true' /><param name='allowscriptaccess' value='always' /><param name='movie' value='http://vimeo.com/moogaloop.swf?clip_id= " 
                + srcLink + "&amp;force_embed=1&amp;server=vimeo.com&amp;show_title=0&amp;show_byline=0&amp;show_portrait=0&amp;color=00adef&amp;fullscreen=1&amp;autoplay=0&amp;loop=0' /><embed src='http://vimeo.com/moogaloop.swf?clip_id="
                + srcLink + "&amp;force_embed=1&amp;server=vimeo.com&amp;show_title=0&amp;show_byline=0&amp;show_portrait=0&amp;color=00adef&amp;fullscreen=1&amp;autoplay=0&amp;loop=0' type='application/x-shockwave-flash' allowfullscreen='true' allowscriptaccess='always' width='500' height='281'></embed></object>";
        }
        

    
    }
}