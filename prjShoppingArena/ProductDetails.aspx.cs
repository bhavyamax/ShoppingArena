using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace prjShoppingArena
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Pid"] != null)
            {
                if (IsPostBack == false)
                {

                    BindProductImage();


                    BindProductDetails();
                }
            }

            else
            {
                Response.Redirect("ViewAllProducts.aspx");
            }

          
        }

        private void BindProductDetails()
        {
            Int64 pId = Convert.ToInt64(Request.QueryString["Pid"]);
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

            string sql;
            sql = "select * from tblProducts where PId='" + pId + "'";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            rptrDetails.DataSource = dt;
            rptrDetails.DataBind();
        }

        private void BindProductImage()
        {

            Int64 pId=Convert.ToInt64(Request.QueryString["Pid"]);
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");
            string sql;
            sql = "select * from tblProductImages where Pid='" + pId+"'";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);
           rptrImage.DataSource = dt;
            rptrImage.DataBind();
        }

        protected string GetActiveImgClass(int ItemIndex)
        {

            if (ItemIndex == 0)
            {

                return "active";
            }
            else
            {
                return "";
            }
        }

        protected void rptrDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // to find different available sizes

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string brandID = (e.Item.FindControl("hfBrandID") as HiddenField).Value;
                string catID = (e.Item.FindControl("hfCatID") as HiddenField).Value;
                string subCatID = (e.Item.FindControl("hfSubCatID") as HiddenField).Value;
                string genderID = (e.Item.FindControl("hfGenderID") as HiddenField).Value;


                RadioButtonList radSizes = e.Item.FindControl("radSizes") as RadioButtonList;

                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");
                string sql;
                sql = "select * from tblSizes where BrandId='" + brandID + "' and CatId='"+catID+"' and SubCatId='"+subCatID+"' and GenderId='"+genderID+"'";
                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                radSizes.DataSource = dt;
                radSizes.DataTextField = "SizeName";
                radSizes.DataValueField = "SizeId";
                radSizes.DataBind();

            }
        }

        protected void btnAddtoCart_Click(object sender, EventArgs e)
        {
           


            string SelectedSize = string.Empty;
            foreach (RepeaterItem item in rptrDetails.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var rbList = item.FindControl("radSizes") as RadioButtonList;
                    SelectedSize = rbList.SelectedValue;
                    var lblError = item.FindControl("lblError") as Label;
                    lblError.Text = "";
                }
            }

            if (SelectedSize != "")
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["Pid"]);
                if (Request.Cookies["CartPID"] != null)
                {
                    string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                    CookiePID = CookiePID + "," + PID + "-" + SelectedSize;
                    HttpCookie CartProducts = new HttpCookie("CartPID");
                    CartProducts.Values["CartPID"] = CookiePID;
                    CartProducts.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(CartProducts);
                }
                else
                {
                    HttpCookie CartProducts = new HttpCookie("CartPID");
                    CartProducts.Values["CartPID"] = PID.ToString() + "-" + SelectedSize;
                    CartProducts.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(CartProducts);
                }
                Response.Redirect("~/ProductDetails.aspx?Pid=" + PID);
            }
            else
            {
                foreach (RepeaterItem item in rptrDetails.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var lblError = item.FindControl("lblError") as Label;
                        lblError.Text = "Please select a size";
                    }
                }

            }

        }
    }
}