using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

public partial class Details : System.Web.UI.Page
{
    public int id;
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
        

        if (Session["userName"] != null)
        {
            string sql = "select * from users where username='" + Session["userName"]+"'";
            SqlDataReader sdr = operateData.getRow(sql);
            sdr.Read();
            id = Int32.Parse(sdr["Id"].ToString());

            sql = "select * from profiles where userId='" + id+"'";  
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
        else
        {
            Response.Redirect("Login.aspx");
        }       
    }
    protected void ChangeImage_Click(object sender, EventArgs e)
    {
        FileUpload.Visible = true;
        UploadImage.Visible = true;
    }
    protected void UploadImage_Click(object sender, EventArgs e)
    {
        if (FileUpload.HasFile)
        {
            string sql = "select * from users where username='" + Session["userName"] + "'";
            SqlDataReader sdr = operateData.getRow(sql);
            sdr.Read();
            id = Int32.Parse(sdr["Id"].ToString());

            sql = "select * from profiles where userId='" + id + "'";
            SqlDataReader sdrPr = operateData.getRow(sql);
            sdrPr.Read();

            if (sdrPr["imgPath"]!= null)
            {
                string oldName = sdrPr["imgPath"].ToString();
                File.Delete(Server.MapPath(Request.ApplicationPath) + "Pictures/" + oldName);
            }
            
            string newName = DateTime.Now.ToString("mmddyyyy_HHmmss") + Path.GetExtension(FileUpload.FileName);
            string folder_path = Server.MapPath("~\\Pictures\\");
            FileUpload.SaveAs(folder_path + newName);
            sql = "update profiles set imgPath='" + newName + "' where userId='" + id + "'";
            operateData.execSql(sql);
            
        }
    }
    protected void EditProfile_Click(object sender, EventArgs e)
    {
        if (EditPanel.Visible == false)
        {
            EditPanel.Visible = true;
        }
        else
        {
            EditPanel.Visible = false;
        }        
    }
    protected void SaveProfile_Click(object sender, EventArgs e)
    {
        firstName = EditFirstName.Text.ToString();
        lastName = EditLastName.Text.ToString();
        country = EditCountry.Text.ToString();
        city = EditCity.Text.ToString();
        if (MaleRadio.Checked)
        {
            sex = "male";
        }
        else
        {
            sex = "female";
        }

        string sql = "update profiles set firstName='" + firstName +
                                        "', lastName='" + lastName +
                                        "', country='" + country +
                                        "', city='" + city +
                                        "', sex='" + sex + "'";
        operateData.execSql(sql);
    }
}