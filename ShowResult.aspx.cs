using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Quiz_Project
{
    public partial class ShowResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {

            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
            if (!IsPostBack)
            {
                bind();
                bindData();
            }
        }
        protected void bind()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);
            string q = "select count(username) from usertable";
            con.Open();
            SqlCommand cmd = new SqlCommand(q, con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            lbluser.Text = count.ToString();


            q = "select count(testname) from testtable";

            SqlCommand cmd1 = new SqlCommand(q, con);
            int count1 = Convert.ToInt32(cmd1.ExecuteScalar());
            lbltest.Text = count1.ToString();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // string 
            if (!DropDownList1.SelectedValue.ToString().Equals("-1"))
            {

                bindGrid();
            }
        }
        protected void bindData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);
            con.Open();


            SqlDataAdapter adapter = new SqlDataAdapter("select testname from testtable", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DropDownList1.DataSource = dt;

            DropDownList1.DataValueField = "testname";
            DropDownList1.DataTextField = "testname";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("----Select Test Name----", "-1"));

            con.Close();
        }
        protected void bindGrid()
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);
            string s = DropDownList1.SelectedValue.ToString().Trim() + "res";
            //Response.Write(s);
            string q = "select * from " + s;
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            if (email.Text != "")
            {

                bindbtn();
            }
        }
        protected void bindbtn()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);
            string s = DropDownList1.SelectedValue.ToString().Trim() + "res";
            string m = email.Text.ToString();
            string qu = "select * from " + s + " where username like '%" + m + "%'";
            SqlCommand cmd = new SqlCommand(qu, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
    }
}