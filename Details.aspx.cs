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
using System.Web.UI.WebControls;

public partial class Details : System.Web.UI.Page
{
    public int id;
    public string sex;
    public string country;
    public string city;
    public Bitmap bitmap;
    public string imgUrl;
    public string firstName;
    public string lastName;
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

            SqlConnection con = operateData.createCon();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow row = dt.Rows[0];
            byte[] imgBytes = (byte[])row["img"];
            System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();

            string filePath = Server.MapPath("temp") + "//" + "img" + DateTime.Now.Ticks.ToString() + ".png";
            FileStream fs = File.Create(filePath);
            fs.Write(imgBytes, 0, imgBytes.Length);
            fs.Flush();
            fs.Close();

            profileImage.ImageUrl = filePath;
            
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
            /*
             * MemoryStream ms = new MemoryStream(bytes);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            Response.ContentType = "image/jpeg"; //or whatever mime type you have
            img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
             * /
             */
            MemoryStream ms = new MemoryStream(FileUpload.FileBytes);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            /*INSERT INTO Customers (CustomerName, Country)
SELECT SupplierName, Country FROM Suppliers
WHERE Country='Germany';*/

            string sql = "update profiles set img='" + img+"' where userId='" + id + "'";
            operateData.execSql(sql);
            
        }
    }
}