using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Register : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void btn_register_Click(object sender, EventArgs e)
    {
        string name, email, pwd, qualification, gender;
        int age;
        int sid;
        name = textuname.Text;
        email = textemail.Text;
        pwd = textpwd.Text;
        qualification = ddlqualification.SelectedItem.Text;
        gender = rbgender.SelectedItem.Text;
        age = Convert.ToInt32(textage.Text);

        string query_insert = "insert into sreg(sname,semail,spwd,squalification,sgender,sage) values ('" + name + "','" + email + "','" + pwd + "','" + qualification + "','" + gender + "'," + age + ")";
        con.Open();

        SqlCommand cmd = new SqlCommand(query_insert, con);
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert(' Registered successfully.. ')</script>");
            //textuname.Text = "";
            //textemail.Text = "";
            //textpwd.Text = "";


            con.Close();
            string select_id = "select * from sreg where sname='" + name + "' and semail='" + email + "'";
            con.Open();
            SqlCommand cm2 = new SqlCommand(select_id, con);


            SqlDataReader dr = cm2.ExecuteReader();
            if(dr.Read())
            {
                sid = Convert.ToInt32(dr["sid"].ToString());
                string myformatid = "Your Auto Generate Student Id is:" + sid;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert(' " + myformatid + "')</script>");
                //Response.Redirect("Login.aspx");

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Data not found.. ')</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Registered failure.. ')</script>");


        }

    }
    
}