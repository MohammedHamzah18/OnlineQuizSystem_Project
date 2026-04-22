using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication62
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string conStr = "data source=127.0.0.1\\SQLEXPRESS;initial catalog=QuizDB;integrated security=true";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            string q = $"select * from Users where Username='{TextBox1.Text}' and Password='{TextBox2.Text}'";
            SqlCommand cmd = new SqlCommand(q, con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Session["user"] = dr["UserId"].ToString();
                Response.Redirect("Quiz.aspx");
            }
        }
    }
}