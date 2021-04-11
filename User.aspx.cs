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
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                string user = Session["user"].ToString();
                lluser.Text = user;
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
            con.Open();
           

            string q = "select count(testname) from testtable";

            SqlCommand cmd = new SqlCommand(q, con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            lbltest.Text = count.ToString();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // string 
            if (!DropDownList1.SelectedValue.ToString().Equals("-1"))
            {

               // bindGrid();
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

        protected void btnattempt_Click(object sender, EventArgs e)
        {
            if (!DropDownList1.SelectedValue.ToString().Equals("-1"))
            {
                Session["tablename"] = DropDownList1.SelectedValue.ToString();
                Response.Redirect("~/GiveTest.aspx");
            }
        }
        

    }
}