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
    public partial class NewAnswer : System.Web.UI.Page
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
                String quesId = Session["quesID"].ToString();
                username = Session["username"].ToString();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnect1"].ConnectionString);
                con.Open();
                String select = "select * from comments";
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
                    String insert = "insert into comments (commentId,author,text) values(@cid,@a,@t)";
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2 = new SqlCommand(insert, con);
                    cmd2.Parameters.AddWithValue("@cid", index);
                    cmd2.Parameters.AddWithValue("@a", username);
                    cmd2.Parameters.AddWithValue("@t", ansText.Text);
                    cmd2.ExecuteNonQuery();

                    string update = "update questions set commentId = ISNULL(commentId,'')+@p where quesId=@b";
                    SqlCommand cmd3 = new SqlCommand(); 
                    cmd3 = new SqlCommand(update, con);
                    cmd3.Parameters.AddWithValue("@p", index.ToString()+",");
                    cmd3.Parameters.AddWithValue("@b", quesId);
                    cmd3.ExecuteNonQuery();


                    Label2.Text = "Done";
                }
                catch (Exception exc)
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
            Response.Redirect("CommentsPage.aspx");
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