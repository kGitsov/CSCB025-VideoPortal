using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_AutheticationControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            //you are in
            Nickname.Text = Session["userName"].ToString();
            WelcomePanel.Visible = true;
            LoginPanel.Visible = false;
            uploadpanel.Visible = true;
        }
        else
        {
            Session["userName"] = null;
            Nickname.Text = "Guest";
            WelcomePanel.Visible = false;
            LoginPanel.Visible = true;
            adminpanel.Visible = false;
            uploadpanel.Visible = false;
            //Response.Redirect("~/Login.aspx");
        }
        if (Session["isAdmin"] != null && Session["isAdmin"].ToString() == "True")
        {
            adminpanel.Visible = true; 
            homepanel.Visible = true;
            uploadpanel.Visible = true;
        }
        else
        {
            adminpanel.Visible = false;
            homepanel.Visible = true;
            //uploadpanel.Visible = true;
        }
    }

    //logout button
    protected void LinkBtnLogout_Click(object sender, EventArgs e)
    {
        Session["userName"] = null;
        Session["isAdmin"] = null;
        Nickname.Text = "Guest";
        WelcomePanel.Visible = false;
        LoginPanel.Visible = true;
        adminpanel.Visible = false;
        Response.Redirect("~/Default.aspx");
        uploadpanel.Visible = false;
        
    }
}