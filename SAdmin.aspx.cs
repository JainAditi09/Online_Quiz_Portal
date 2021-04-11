using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;


namespace Quiz_Project
{
    public partial class SAdmin : System.Web.UI.Page
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

        protected void add_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);
            string query = "select * from testtable";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            string test = testName.Text.Trim();
            cmd.CommandText = "select count(testname) from testtable where testname = @test";
            cmd.Parameters.AddWithValue("@test", testName.Text.Trim());
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0)
            {
                cmd.CommandText = "insert into testtable(testname) values(@name)";
                cmd.Parameters.AddWithValue("@name", testName.Text.Trim());
                cmd.ExecuteNonQuery();

                cmd.CommandText = "create table " + testName.Text.Trim() + "(QuestionNo int  primary key ,Question varchar(500),choice1 varchar(50),choice2 varchar(50),choice3 varchar(50),choice4 varchar(50),answer varchar(50))";
                cmd.ExecuteNonQuery();


                string tab = testName.Text.Trim();
                tab = tab + "res";
                cmd.CommandText = "create table " + tab + "(Id int Identity(1,1) primary key  ,username varchar(50),marks int)";
                cmd.ExecuteNonQuery();


               lblmsg.Text = "Added Successfully";
            }
            else
            {
               lblmsg.Text = "Already exits";
                testName.Text = "";
            }

            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int QuestionNo;
            string Question;
            string choice1;
            string choice2;
            string choice3;
            string choice4;
            string answer;
            string path = Path.GetFileName(FileUpload1.FileName);
            path = path.Replace(" ", "");
            FileUpload1.SaveAs(Server.MapPath("~/Excel File/") + path);
            String ExcelPath = Server.MapPath("~/Excel File/") + path;
            OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
            mycon.Open();
            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                // Response.Write("<br/>"+dr[0].ToString());
                QuestionNo = Convert.ToInt32(dr[0].ToString());
                Question = dr[1].ToString();
                choice1 = dr[2].ToString();
                choice2 = dr[3].ToString();
                choice3 = dr[4].ToString();
                choice4 = dr[5].ToString();
                answer = dr[6].ToString();
                savedata(QuestionNo, Question, choice1, choice2, choice3, choice4, answer);

            }
           lbl.Text = "Data Has Been Saved Successfully";
            testName.Text = "";
            lblmsg.Text = "";
        }
        private void savedata(int QuestionNo, string Question, string choice1, string choice2, string choice3, string choice4, string answer)
        {
            string tt = testName.Text.Trim();
            String query = "insert into " + tt + "(QuestionNo,Question,choice1,choice2,choice3,choice4,answer) values('" + QuestionNo + "','" + Question + "','" + choice1 + "','" + choice2 + "','" + choice3 + "','" + choice4 + "','" + answer + "')";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            //cmd.CommandText = query;
            //cmd.Connection = con;
            //cmd.ExecuteNonQuery();
        }
    }
}