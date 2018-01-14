using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace project
{
    public partial class Test : System.Web.UI.Page
    {
        
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
        }

        protected void login_clicked(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                String s = Session["username"].ToString();
                Response.Redirect("NewQuestion.aspx");
            }
            catch(Exception ex)
            {
                //Label1.Text = ex.Message;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please login first')", true);
                //Response.Redirect("Login.aspx");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Session["quesID"] = index;
            //Label1.Text = index+"";
            Response.Redirect("CommentsPage.aspx");
        }

        protected void logout_clicked(object sender, EventArgs e)
        {
            Session.RemoveAll(); Response.Redirect("Login.aspx");
        }

        
    }
}