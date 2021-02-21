using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace frontend
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;

            CarService.CarServiceClient obj = new CarService.CarServiceClient("BasicHttpBinding_ICarService");

            obj.AddCar(name);
            obj.Close();

            bindData();
        }

        void bindData()
        {
            CarService.CarServiceClient obj = new CarService.CarServiceClient("BasicHttpBinding_ICarService");

            GridView1.DataSource = obj.GetCars();

            GridView1.DataBind();
            obj.Close();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CarService.CarServiceClient obj = new CarService.CarServiceClient("BasicHttpBinding_ICarService");

            int id = int.Parse(e.Keys[0].ToString());

            obj.DeleteCar(id);
            obj.Close();
            bindData();

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }
}