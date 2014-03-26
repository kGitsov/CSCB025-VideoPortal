using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User : System.Web.UI.Page
{
    public int userId;

    public string sex;
    public string country;
    public string city;
    public string imgUrl;
    public string firstName;
    public string lastName;
    public string folder_path;
    public DateTime registerDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            userId = Int32.Parse(Request.QueryString["id"].ToString());

            ViewProfileByUserId();
        }
        else
        {
            Response.Redirect("/Details.aspx");
        }
    }

    private void ViewProfileByUserId()
    {
        string sql = "select * from profiles where userId='" + userId + "'";
        SqlDataReader sdrPr = operateData.getRow(sql);
        sdrPr.Read();

        sex = sdrPr["sex"].ToString();
        country = sdrPr["country"].ToString();
        city = sdrPr["city"].ToString();
        firstName = sdrPr["firstName"].ToString();
        lastName = sdrPr["lastName"].ToString();
        registerDate = (DateTime)sdrPr["registerDate"];

        string folder_path = "/Pictures/";
        SqlConnection con = operateData.createCon();
        con.Open();
        SqlCommand com = new SqlCommand(sql, con);
        SqlDataReader sdrp = com.ExecuteReader();
        sdrp.Read();
        folder_path += sdrp["imgPath"].ToString();
        profileImage.ImageUrl = folder_path;
    }
}