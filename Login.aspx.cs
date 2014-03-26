using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manage_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string user = txtName.Text;
        string pass = txtPass.Text;
        byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(pass);
        pass = Convert.ToBase64String(passBytes);
        string sqlSel = "select * from users where username=@user and password=@pass";

        if (operateData.adminLogin(sqlSel, user, pass))
        {
            Session["userName"] = txtName.Text;
            string sql = "select * from users where username='" + Session["userName"] + "'";
            SqlDataReader sdr = operateData.getRow(sql);
            sdr.Read();
            Session["userName"] = sdr["username"];
            string temp = sdr["isAdmin"].ToString();
            Session["isAdmin"] = sdr["isAdmin"].ToString();
            
            RegisterStartupScript("true", "<script>alert('Hi administrator!'); location='../manage/Admin.aspx'</script>");
        }
        else if (operateData.login(sqlSel, user, pass))
        {
            Session["userName"] = txtName.Text;
            string sql = "select * from users where username='" + Session["userName"] + "'";
            SqlDataReader sdr = operateData.getRow(sql);
            sdr.Read();
            Session["userName"] = sdr["username"];
            string temp = sdr["isAdmin"].ToString();
            Session["isAdmin"] = sdr["isAdmin"].ToString();
            RegisterStartupScript("false", "<script>alert('Hi user!'); location='/Default.aspx'</script>");
        }
        else
        {
            RegisterStartupScript("false", "<script>alert('Login FAILED!'); location='/Login.aspx'</script>");
        
        }
    }
}