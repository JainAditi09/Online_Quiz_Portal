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
    public partial class GiveTest : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user"] == null)
            //{
            //    Response.Redirect("~/Home.aspx");
            //}
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        public void BindGrid()
        {
            string tab = Session["tablename"].ToString();
            
            string q = "Select * from  " + tab  ;
            SqlDataAdapter da = new SqlDataAdapter(q, ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            
        }
       
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
           // Response.Redirect("http://www.google.com");
            SqlCommand cmd = null;
            ////ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

            try
            {
               con = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);
               string tab = Session["tablename"].ToString();


            

                int rows = GridView1.Rows.Count;
                int count = 0;
                string a = "";
                int i = 1;
              // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' outside Record Inserted Successfully')", true);
               con.Open();
                foreach (GridViewRow oldrow in GridView1.Rows)
                {
                   // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' i m in for Record Inserted Successfully')", true);
                    
                    string q = "select answer from " + tab + " where questionno = '" + i + "'";

                    cmd = new SqlCommand(q, con);

                    SqlDataReader rd =  cmd.ExecuteReader();
                    string s = "";
                    while (rd.Read())
                    {
                        s = rd.GetValue(0).ToString();
                    }
                    rd.Close();
                    
                   
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted '" + s + "'Successfully')", true);
                    if (((RadioButton)oldrow.FindControl("RadioButton1")).Checked)
                    {
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' outside Record Inserted Successfully')", true);
                        a = ((RadioButton)oldrow.FindControl("RadioButton1")).Text.ToString();
                    }
                    else if (((RadioButton)oldrow.FindControl("RadioButton2")).Checked)
                    {
                        a = ((RadioButton)oldrow.FindControl("RadioButton2")).Text.ToString();
                    }
                    else if (((RadioButton)oldrow.FindControl("RadioButton3")).Checked)
                    {
                        a = ((RadioButton)oldrow.FindControl("RadioButton3")).Text.ToString();
                    }
                    else if (((RadioButton)oldrow.FindControl("RadioButton4")).Checked)
                    {
                        a = ((RadioButton)oldrow.FindControl("RadioButton4")).Text.ToString();
                    }
                   // Response.Write("<br />value of a  " + a + "value of s : " + s);
                    if (a == s)
                    {
                        count++;
                    }
                    i++;
                    
                   
                }
                
                addResult(count);
                
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message); 
                Response.Write(ex);
            }
            finally
            {
                con.Close();
            }
            //Response.Write("<script>alert(`Score is ${count}`)</script>");
            Response.Redirect("~/User.aspx");
        }
        protected void addResult(int count)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);
            string tab = Session["tablename"].ToString() + "res";
            con.Open();
            string s = Session["user"].ToString();
            
            string query = "insert into " + tab + "(username,marks) values('"+s+"','"+count+"')";
            
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
      
    }
}