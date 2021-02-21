using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace frontend
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindData();
                bindCars();
            }
        }

        void bindData()
        {
            CarService.CarServiceClient obj = new CarService.CarServiceClient("BasicHttpBinding_ICarService");

            DataSet ds = obj.GetUserCar(Session["email"].ToString());            

            if(ds.Tables[0].Rows.Count > 0)
            {                
                Label1.Visible = false;
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.Visible = true;
            } 
            else
            {
                Label1.Visible = true;
                GridView1.Visible = false;
            }
            
            obj.Close();
        }

        void bindCars()
        {
            CarService.CarServiceClient obj = new CarService.CarServiceClient("BasicHttpBinding_ICarService");

            string[] ds = obj.GetCarNames();

            DropDownList1.DataSource = ds.ToList();
            DropDownList1.DataBind();

            obj.Close();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CarService.CarServiceClient obj = new CarService.CarServiceClient("BasicHttpBinding_ICarService");

            obj.AssignCar(Session["email"].ToString(), DropDownList1.SelectedValue);

            obj.Close();

            bindData();
            bindCars();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CarService.CarServiceClient obj = new CarService.CarServiceClient("BasicHttpBinding_ICarService");            

            obj.ReturnCar(Session["email"].ToString(), e.Keys[0].ToString());
            obj.Close();
            bindData();
            bindCars();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}