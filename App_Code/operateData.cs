using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for operateData
/// </summary>
public class operateData
{
	public operateData()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //connection to SQL
    public static SqlConnection createCon()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString());
        return con;
    }

    public static SqlDataReader getRow(string sql)
    {
        SqlConnection con = createCon();
        con.Open();
        SqlCommand com = new SqlCommand(sql, con);
        SqlDataReader sdr = com.ExecuteReader();
        //con.Close();
        return sdr;
    }

    public static bool execSql(string sql)
    {
        SqlConnection con = createCon();
        con.Open();
        SqlCommand com = new SqlCommand(sql, con);
        int Ex = com.ExecuteNonQuery();
        con.Close();
        if (Ex > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public static DataTable getRows(string sql)
    {
        DataSet ds;
        SqlConnection con = createCon();
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter(sql, con);
        ds = new DataSet();
        sda.Fill(ds);
        con.Close();

        return ds.Tables[0];
    }

    public static int getCount(string sql)
    {
        SqlConnection con = createCon();
        con.Open();
        SqlCommand com = new SqlCommand(sql, con);

        int Ex = Convert.ToInt32(com.ExecuteScalar());
        con.Close();
        return Ex;
    }

    public static string getTier(string sql)
    {

        SqlConnection con = createCon();
        con.Open();
        SqlCommand com = new SqlCommand(sql, con);
        SqlDataReader sdr = com.ExecuteReader();
        sdr.Read();
        string tier = sdr[0].ToString();
        con.Close();
        return tier;
    }

    public static bool login(string sql, string name, string pass)
    {
        SqlConnection con = createCon();
        con.Open();
        SqlCommand com = new SqlCommand(sql, con);
        com.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar, 50));
        com.Parameters["@user"].Value = name;
        com.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar, 50));
        com.Parameters["@pass"].Value = pass;
        int Ex = Convert.ToInt32(com.ExecuteScalar());
        con.Close();
        if (Ex > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool adminLogin(string sql, string name, string pass)
    {
        SqlConnection con = createCon();
        con.Open();
        SqlCommand com = new SqlCommand(sql, con);
        com.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar, 50));
        com.Parameters["@user"].Value = name;
        com.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar, 50));
        com.Parameters["@pass"].Value = pass;
        int Ex = Convert.ToInt32(com.ExecuteScalar());
        if (Ex > 0)
        {
            string admin = "select * from users where username='" + name + "'";
            SqlDataReader sdr = operateData.getRow(admin);
            sdr.Read();
            string u = sdr["username"].ToString();
            string c = sdr["isAdmin"].ToString();
            if (sdr["isAdmin"].ToString() == "True")
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        else
        {
            con.Close();
            return false;
        }
    }
}