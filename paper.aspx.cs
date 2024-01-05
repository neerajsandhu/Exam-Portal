using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class paper : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if (Session["sid"] == null)
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


                string query2 = @"select * from question where
                cid='" + Session["cid"].ToString() + "' and qid="+Convert.ToInt32(lblqno.Text)+"";

                con.Open();
                SqlCommand cmd2 = new SqlCommand(query2, con);
                SqlDataReader dr2 = cmd2.ExecuteReader();

                if(dr2.Read())
                {
                    lblqname.Text = dr2["qname"].ToString();
                    rbop1.Text = dr2["op1"].ToString();
                    rbop2.Text = dr2["op2"].ToString();
                    rbop3.Text = dr2["op3"].ToString();
                    rbop4.Text = dr2["op4"].ToString();
                    HiddenField1.Value = dr2["ans"].ToString();

                    //Label1.Text = dr2["ans"].ToString();


                }
                else
                {
                    Response.Write("DATA NOT FOUND");
                }
                con.Close();
            }
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        rbop1.Enabled = true;
        rbop2.Enabled = true;
        rbop3.Enabled = true;
        rbop4.Enabled = true;
        ViewState["next"] = lblqno.Text;
        if (Convert.ToInt32 (ViewState["next"].ToString()) < 5)
        {
            lblqno.Text = (Convert.ToInt32(ViewState["next"].ToString()) + 1).ToString();
        }
        else
        {
            Button2.Enabled = false;
            rbop1.Enabled = false;
            rbop2.Enabled = false;
            rbop3.Enabled = false;
            rbop4.Enabled = false;
            Button3.Enabled = true;
            Button3.Visible = true;
        }

        string query2 = @"select * from question where
                cid='" + Session["cid"].ToString() + "' and qid=" + Convert.ToInt32(lblqno.Text) + "";

        con.Open();
        SqlCommand cmd2 = new SqlCommand(query2, con);
        SqlDataReader dr2 = cmd2.ExecuteReader();

        if (dr2.Read())
        {
            lblqname.Text = dr2["qname"].ToString();
            rbop1.Text = dr2["op1"].ToString();
            rbop2.Text = dr2["op2"].ToString();
            rbop3.Text = dr2["op3"].ToString();
            rbop4.Text = dr2["op4"].ToString();
            HiddenField1.Value = dr2["ans"].ToString();
            //Label1.Text = dr2["ans"].ToString(); 

            rbop1.Checked = false;
            rbop2.Checked = false;
            rbop3.Checked = false;
            rbop4.Checked = false;




        }
        else
        {
            Response.Write("DATA NOT FOUND");
        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void rbop1_CheckedChanged(object sender, EventArgs e)
    {
        if(rbop1.Text.Equals(HiddenField1.Value))
        {
            ViewState["score"] = lblscore.Text;
            lblscore.Text=(Convert.ToInt32(ViewState["score"].ToString()) + 1).ToString();
            rbop1.Enabled = false;
            rbop2.Enabled = false;
            rbop3.Enabled = false;
            rbop4.Enabled = false;

        }
        else
        {
            rbop1.Enabled = false;
            rbop2.Enabled = false;
            rbop3.Enabled = false;
            rbop4.Enabled = false;


        }
    }
    protected void rbop2_CheckedChanged(object sender, EventArgs e)
    {
        if (rbop2.Text.Equals(HiddenField1.Value))
        {
            ViewState["score"] = lblscore.Text;
            lblscore.Text=(Convert.ToInt32(ViewState["score"].ToString())+ 1).ToString();
            rbop1.Enabled = false;
            rbop2.Enabled = false;
            rbop3.Enabled = false;
            rbop4.Enabled = false;

        }
        else
        {
            rbop1.Enabled = false;
            rbop2.Enabled = false;
            rbop3.Enabled = false;
            rbop4.Enabled = false;


        }
    }
    protected void rbop3_CheckedChanged(object sender, EventArgs e)
    {
        if (rbop3.Text.Equals(HiddenField1.Value))
        {
            ViewState["score"] = lblscore.Text;
            lblscore.Text=(Convert.ToInt32(ViewState["score"].ToString())+ 1).ToString();
            rbop1.Enabled = false;
            rbop2.Enabled = false;
            rbop3.Enabled = false;
            rbop4.Enabled = false;

        }
        else
        {
            rbop1.Enabled = false;
            rbop2.Enabled = false;
            rbop3.Enabled = false;
            rbop4.Enabled = false;


        }
    }
    protected void rbop4_CheckedChanged(object sender, EventArgs e)
    {
        if (rbop4.Text.Equals(HiddenField1.Value))
        {
            ViewState["score"] = lblscore.Text;
            lblscore.Text=(Convert.ToInt32(ViewState["score"].ToString())+ 1).ToString();
            rbop1.Enabled = false;
            rbop2.Enabled = false;
            rbop3.Enabled = false;
            rbop4.Enabled = false;

        }
        else
        {
            rbop1.Enabled = false;
            rbop2.Enabled = false;
            rbop3.Enabled = false;
            rbop4.Enabled = false;


        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
    //    Session["scr"] = lblscore.Text;
    //    Response.Redirect("result.aspx");

        Session["score"] = lblscore.Text;
        Response.Redirect("result.aspx");
    }
    protected void HiddenField1_ValueChanged(object sender, EventArgs e)
    {

    }
}