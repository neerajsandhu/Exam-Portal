using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class start_exam : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            dropdownlistfill();
            if(Session["sid"]==null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                int sid;
               
                sid = Convert.ToInt32(Session["sid"].ToString());
              
                string query = "select * from sreg where sid=" + sid + "";
                con.Open();


                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    lblname.Text = dr["sname"].ToString();
                    lblemail.Text = dr["semail"].ToString();
                    lbluid.Text = dr["sid"].ToString();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Login Failure...! ')</script>");

                }
                con.Close();

            }
        }

    }
    public void dropdownlistfill()
    {
        string query= "Select * from  course";
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataTable course = new DataTable();
        da.Fill(course);
        DropDownList1.DataSource = course;
        DropDownList1.DataTextField="cname";
        DropDownList1.DataValueField = "cid";
        DropDownList1.DataBind();

        ListItem selectedItem = new ListItem("Select Exam");
        selectedItem.Selected = true;
        DropDownList1.Items.Insert(0, selectedItem);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(Session["sid"]!=null)
        {
            Session["sid"] = null;
            Response.Redirect("login.aspx");
            
           
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["cid"]= DropDownList1.SelectedValue;
        
        Response.Redirect("paper.aspx");
    }
}