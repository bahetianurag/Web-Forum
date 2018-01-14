using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace project
{
    public partial class CommentsPage : System.Web.UI.Page
    {
        StringBuilder htmlTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String s = Session["username"].ToString();
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
            try
            {

                string question = "", commentID = "",author="";
                int quesID  = Convert.ToInt32(Session["quesID"]);
                //Label1.Text = quesID + "";
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnect1"].ConnectionString);
                con.Open();
                string insert = "select question,commentId,author from questions where quesId=@u";
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.Parameters.AddWithValue("@u", quesID);
                SqlDataReader reader = cmd.ExecuteReader();
                int flag = 1;
                while (reader.Read())
                {
                    question = reader[0].ToString();
                    commentID = reader[1].ToString();
                    if(reader[1] == DBNull.Value)
                    {
                        flag = 0;
                        //Label3.Text = "Null";
                    }
                    author = reader[2].ToString();
                }
                Label1.Text = author+" posted: "+question;
                reader.Close();
                try
                {
                    if (flag == 1)
                    {
                        char splitChar = ',';
                        string[] c = (commentID.Split(splitChar));
                        Label2.Text = String.Empty;
                        //int f = 0;
                        htmlTable.Append("<table border='1'>");
                        htmlTable.Append("<tr><th align='centre'>Comment</th><th align='centre'>Posted by</th></tr>");
                        foreach (string ci in c)
                        {
                            if (ci == "")
                                break;
                            insert = "select * from comments where commentId=@c";
                            cmd = new SqlCommand(insert, con);
                            cmd.Parameters.AddWithValue("@c", Convert.ToInt32(ci));
                            SqlDataReader nr = cmd.ExecuteReader();
                            while (nr.Read())
                            {
                                htmlTable.Append("<tr>");
                                htmlTable.Append("<td>" + nr[2] + "</td>");
                                htmlTable.Append("<td>" + nr[1] + "</td>");
                                htmlTable.Append("</tr>");
                                //Label2.Text += nr[0] + "***" + nr[1] + "***" + nr[2] + "*";
                            }
                            //Label2.Text += "-------Finish comment ----------";
                            nr.Close();
                        }
                        htmlTable.Append("</table>");
                        CommentsPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });  
                    }

                    else
                        Label2.Text = "No Replies Yet";
                    //                Response.Redirect("forum.aspx");
                    con.Close();
                }
                catch (Exception ex)
                {
                    Label2.Text = ex.Message;
                }

            }
            catch (Exception ex)
            {
                Label2.Text = ex.Message;
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please login first')", true);
            }
        }
        protected void login_clicked(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("NewAnswer.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('')", true);
            }
        }

        protected void logout_clicked(object sender, EventArgs e)
        {
            Session.RemoveAll(); Response.Redirect("Login.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainForum.aspx");
        }
    }
}