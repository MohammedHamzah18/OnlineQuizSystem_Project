using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication62
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string conStr = "data source=127.0.0.1\\SQLEXPRESS;initial catalog=QuizDB;integrated security=true";

                SqlConnection con = new SqlConnection(conStr);
                con.Open();

                string q2 = "select * from Results";
                SqlDataAdapter da = new SqlDataAdapter(q2, con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();

                con.Close(); // ✔ good practice
            }
        }
    }
}