using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication62
{
    public partial class Quiz : System.Web.UI.Page
    {
        // ✔ move inside class
        int index = 0;
        int score = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["score"] = 0;
                Session["index"] = 0;
                LoadQuestion();
            }
        }

        void LoadQuestion()
        {
            int i = Convert.ToInt32(Session["index"]);

            string conStr = "data source=127.0.0.1\\SQLEXPRESS;initial catalog=QuizDB;integrated security=true";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            string q = "select * from Questions";
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            da.Fill(dt);


            Label1.Text = dt.Rows[i]["Question"].ToString();

            rblOptions.Items.Clear();
            rblOptions.Items.Add("A. " + dt.Rows[i]["OptionA"]);
            rblOptions.Items.Add("B. " + dt.Rows[i]["OptionB"]);
            rblOptions.Items.Add("C. " + dt.Rows[i]["OptionC"]);
            rblOptions.Items.Add("D. " + dt.Rows[i]["OptionD"]);

            Session["correct"] = dt.Rows[i]["CorrectAnswer"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (rblOptions.SelectedValue.StartsWith(Session["correct"].ToString()))
            {
                int s = Convert.ToInt32(Session["score"]);
                Session["score"] = s + 1;
            }

            int i = Convert.ToInt32(Session["index"]);
            Session["index"] = i + 1;

            LoadQuestion();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int score = Convert.ToInt32(Session["score"]);
            int userId = Convert.ToInt32(Session["user"]);

            string conStr = "data source=127.0.0.1\\SQLEXPRESS;initial catalog=QuizDB;integrated security=true";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            string q = $"insert into Results values({userId},{score})";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();

            Response.Write("Your Score: " + score);
            Response.Redirect("Result.aspx");
        }
    }
}