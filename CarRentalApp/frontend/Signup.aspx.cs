using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace frontend
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btn_SignUp_Click(object sender, EventArgs e)
        {
            if (ModelState.IsValid)
            {
                UserService.UserServiceClient client = new UserService.UserServiceClient("BasicHttpBinding_IUserService");

               
                string email = txt_email.Text;                               
                string Password = password.Text;                
                

                if (client.Signup(email, Password))
                {
                    txt_error.Text = "Registered Successfully";
                    txt_error.Visible = true;
                }
                else
                {
                    txt_error.Text = "Unable to Register";
                    txt_error.Visible = true;
                }

                client.Close();
            }
        }
    }
}