using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace frontend
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txt_Username_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            if (ModelState.IsValid)
            {
                UserService.UserServiceClient client = new UserService.UserServiceClient("BasicHttpBinding_IUserService");

                string email = txt_Username.Text;
                string Password = txt_password.Text;

                if (client.Signin(email, Password))
                {
                    Session.Add("email", email);
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    txt_error.Text = "Invalid Credentials";
                    txt_error.Visible = true;
                }

                client.Close();
            }
        }

        protected void btn_SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }
}