using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace project
{
    public partial class NewQuestion : System.Web.UI.Page
    {
        String username;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                username = Session["username"].ToString();
                Button b = new Button();
                b.Text = "Logout";
                b.Click += new EventHandler(logout_clicked);
                this.form1.Controls.Add(b);
            }
            catch (Exception ex)
            {
                Button b = new Button();
                b.Text = "Login";
                b.Click += new EventHandler(login_clicked);
                this.form1.Controls.Add(b);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try 
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnect1"].ConnectionString);
                con.Open();
                String select = "select * from questions";
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int index = -1;
                Label2.Text = String.Empty;
                while (reader.Read())
                {
                    index = int.Parse(reader[0].ToString());
                }
                reader.Close();
                index += 1;
                try
                {
                    String insert = "insert into questions (quesId,question,commentId,author) values(@qid,@q,@cid,@a)";
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2 = new SqlCommand(insert, con);
                    cmd2.Parameters.AddWithValue("@qid", index);
                    cmd2.Parameters.AddWithValue("@q", quesText.Text);
                    cmd2.Parameters.AddWithValue("@cid", DBNull.Value);
                    cmd2.Parameters.AddWithValue("@a", username);
                    cmd2.ExecuteNonQuery();
                    Label2.Text = "Done";
                }
                catch(Exception exc)
                {
                    Label2.Text = exc.Message;
                }
                con.Close();
                Response.Redirect("MainForum.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please login first')", true);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainForum.aspx");
        }
        protected void login_clicked(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void logout_clicked(object sender, EventArgs e)
        {
            Session.RemoveAll(); Response.Redirect("Login.aspx");
        }
    }
}