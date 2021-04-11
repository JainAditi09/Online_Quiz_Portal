using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz_Project
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Session["user"] = null;
                Response.Redirect("~/Home.aspx");
            }
            if (Session["admin"] != null)
            {
                Session["admin"] = null;
                Response.Redirect("~/Home.aspx");
            }
        }
    }
}