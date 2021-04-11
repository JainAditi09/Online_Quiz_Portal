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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
       
        protected void submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);
            string query = "select * from usertable";
            SqlCommand cmd = new SqlCommand(query, con);
            string m = txtmail.Text.Trim();
            string u = txtname.Text.Trim();
            con.Open();

            cmd.CommandText = "select count(username) from usertable where  username = @u";
            cmd.Parameters.AddWithValue("@m", txtmail.Text.Trim());
            cmd.Parameters.AddWithValue("@u", txtname.Text.Trim());
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0)
            {
                cmd.CommandText = "Insert into usertable(username,email,password) values(@username,@mail,@pass)";
                cmd.Parameters.AddWithValue("@username", txtname.Text.Trim());
                cmd.Parameters.AddWithValue("@mail", txtmail.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", txtpass.Text.Trim());
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('User Added')</script>");
            }
            else
            {
                Response.Write("<script>alert('User Already Exists')</script>");
            }
            clearAll();
            con.Close(); 
        }

        public void clearAll()
        {
            txtmail.Text = "";
            txtname.Text = "";
            txtpass.Text = "";
            confirm.Text = "";
        }
    }
}