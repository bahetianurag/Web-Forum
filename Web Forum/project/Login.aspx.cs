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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnect1"].ConnectionString);
                con.Open();
                string select = "select * from users";
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int flag = 0;
                Label1.Text = String.Empty;
                while (reader.Read())
                {
                    if (reader[0].ToString() == user.Text && reader[2].ToString() == pass.Text)
                    {
                        Session.RemoveAll();
                        flag = 1;
                        Session["username"] = reader[0].ToString();
                        Response.Redirect("MainForum.aspx");
                        break;
                    }
                }

                if (flag == 0)
                {
                    Label1.Text = "Incorrect Details";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Incorrect Details')", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("LandingPage.aspx");
        }
    }
}

