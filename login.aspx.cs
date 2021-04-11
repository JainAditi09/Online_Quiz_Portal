using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Quiz_Project
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            
            string m = txtmail.Text.Trim();
            string p = txtpass.Text.Trim();
            if(m.Equals("admin") && p.Equals("admin") )
             {
                    //Response.Write("<script>alert('User Login Successfully')</script>");
                 Session["admin"] = "admin";
                     Response.Redirect("~/SAdmin.aspx");
             }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);
                string query = "select * from usertable";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.CommandText = "select count(username) from usertable where (username = @m and password = @p)";
                cmd.Parameters.AddWithValue("@m", txtmail.Text.Trim());
                cmd.Parameters.AddWithValue("@p", txtpass.Text.Trim());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count != 0)
                {

                    Session["user"] = txtmail.Text.Trim();
                    //Response.Write("<script>alert('User Login Successfully')</script>");
                    Response.Redirect("~/User.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials')</script>");
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }
          }
    }
}