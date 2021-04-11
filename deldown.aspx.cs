using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Quiz_Project
{
    public partial class deldown : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/Home.aspx");
            }
            else
            {
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!DropDownList1.SelectedValue.ToString().Equals("-1"))
            {
                string tab = DropDownList1.SelectedValue.ToString();
                binddowngrid();
                Response.ClearContent();
                Response.AppendHeader("content-disposition", "attachment;filename = "+ tab +".xls");
                Response.ContentType = "application/excel";
                StringWriter stringwriter = new StringWriter();
                HtmlTextWriter htmlwriter = new HtmlTextWriter(stringwriter);
                GridView1.RenderControl(htmlwriter);
                Response.Write(stringwriter.ToString());
                Response.End();
            }
        }
        protected void binddowngrid()
        {
            string tab = DropDownList1.SelectedValue.ToString() + "res";
            string q = "Select * from " +  tab;
           
            SqlDataAdapter da = new SqlDataAdapter(q, ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            if (!DropDownList1.SelectedValue.ToString().Equals("-1"))
            {
                string tab = DropDownList1.SelectedValue.ToString();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);
                con.Open();
                string q = "delete  from testtable where testname = '" + tab + "'";
                SqlCommand cmd = new SqlCommand(q,con);
                cmd.ExecuteNonQuery();

                q = "drop table " + tab;
                SqlCommand cmd1 = new SqlCommand(q, con);
                cmd1.ExecuteNonQuery();


                string l = tab + "res";
                q = "drop table " + l;
                SqlCommand cmd2 = new SqlCommand(q, con);
                cmd2.ExecuteNonQuery();

                DropDownList1.SelectedValue = "-1";
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }
        
    }
}