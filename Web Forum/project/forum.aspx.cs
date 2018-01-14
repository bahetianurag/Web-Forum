using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace project
{
    public partial class forum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         //   string user = Session["login"].ToString();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnect1"].ConnectionString);
                con.Open();
               
                string command = "select * from users";//"+user+"'";
                SqlCommand cmd = new SqlCommand(command, con);
                SqlDataReader read = cmd.ExecuteReader();
                Label1.Text = "HELLO";
                Label2.Text = String.Empty;
                while (read.Read())
                {
                    Label2.Text += read[0].ToString() + read[1].ToString() + read[2].ToString() + "********";
                }
                read.Close();

                /*string query = "truncate table users";
                SqlCommand cmd1 = new SqlCommand(query, con);
                cmd1.ExecuteNonQuery(); 
                */


                //Response.Redirect("forum.aspx");
                con.Close();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Retry with different username", "", true);
            }

        }



    }
}