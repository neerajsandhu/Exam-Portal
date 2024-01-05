using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int sid;
        string spwd;
        sid = Convert.ToInt32(textuid.Text);
        spwd = textpwd.Text;
        string query = "select * from sreg where spwd='" + spwd + "' and sid=" + sid + "";
        con.Open();

        
        SqlCommand cmd = new SqlCommand(query, con);
        
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Login Successfully....!')</script>");
            //Response.Redirect("Login.aspx");
            Session["sid"] = sid;
            Response.Redirect("start_exam.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Login Failure...! ')</script>");

        }
        con.Close();
    }
}