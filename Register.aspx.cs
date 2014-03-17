using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"]!=null)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void register_Click(object sender, EventArgs e)
    {
        bool accept = acceptTerms.Checked;

        if (accept)
        {
            string username = usrname.Text.ToString();
            string password = pssword.Text.ToString();
            string confirmPassword = cpssword.Text.ToString();
            string email = mail.Text.ToString();
            
            bool isAdmin = false;
            bool isActive = false;
            if (username != "" && password != "" && confirmPassword != "" && email != "" )
            {
                if (password == confirmPassword)
                {  
                    string sql = "select * from users where username=@username OR email=@email";

                    SqlConnection con = operateData.createCon();
                    SqlCommand com = new SqlCommand(sql, con);
                    com.Parameters.AddWithValue("@username", username);
                    com.Parameters.AddWithValue("@email", email);
                    con.Open();
                    SqlDataReader reader = com.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(password);
                        password = Convert.ToBase64String(passBytes);
                        sql = "insert into users(username, password, isAdmin, isActive, email) values(@username,@password,@isAdmin,@isActive,@email)";
                        con = operateData.createCon();
                        com = new SqlCommand(sql, con);
                        com.Parameters.AddWithValue("@username", username);
                        com.Parameters.AddWithValue("@email", email);
                        com.Parameters.AddWithValue("@password", password);
                        com.Parameters.AddWithValue("@isAdmin", isAdmin);
                        com.Parameters.AddWithValue("@isActive", isActive);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();

                        //add to profiles new user
                        int id = 0;
                        sql = "select Id from users where username=@username";
                        con = operateData.createCon();
                        com = new SqlCommand(sql, con);
                        com.Parameters.AddWithValue("@username", username);
                        con.Open();
                        SqlDataReader read = com.ExecuteReader();
                        read.Read();
                        id=Int32.Parse(read.GetValue(0).ToString());

                        sql = "insert into profiles(userId,registerDate) values (@id,@date)";
                        con = operateData.createCon();
                        com = new SqlCommand(sql, con);

                        com.Parameters.AddWithValue("@id", id);
                        com.Parameters.AddWithValue("@date", DateTime.Now);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("../Default.aspx");
                    }
                    else
                    {
                        //usrname
                        RegisterStartupScript("true", "<script>alert('username or email already taken'); </script>");
                    }
                }
                else
                {                    
                    RegisterStartupScript("true", "<script>alert('password mismatch');</script>");
                }
            }
            else
            {
                if (username =="")
                {
                    usrname.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                }
                if (password == "")
                {
                    pssword.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                }
                if (confirmPassword == "")
                {
                    cpssword.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                }
                if (email == "")
                {
                    mail.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                }
            }
        }
        else
        {
            acceptTerms.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
        }
    }
}