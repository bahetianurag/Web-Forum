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
    public partial class LandingPage : System.Web.UI.Page
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
                string insert = "insert into users (username,name,password) values(@u,@n,@p)";
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.Parameters.AddWithValue("@u", TextBox2.Text);
                cmd.Parameters.AddWithValue("@n", TextBox1.Text);
                cmd.Parameters.AddWithValue("@p", TextBox3.Text);
                cmd.ExecuteNonQuery();
                Response.Redirect("Login.aspx");
                con.Close();
                //Session["login"] = TextBox2.Text;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Retry with different username", "", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}