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
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

  


                BindProductCart();
            }
        }

        private void BindProductCart()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                DataTable dt = new DataTable();
                string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];

                string[] CookieDataArray = CookieData.Split(',');

                if (CookieDataArray.Length > 0)
                {
                    numItems.InnerText = "My Cart (" + CookieDataArray.Length + " Items)";
                    Int64 CartTotal = 0;
                    Int64 Total = 0;
                    for (int i = 0; i < CookieDataArray.Length; i++)
                    {
                        string pId=CookieDataArray[i].ToString().Split('-')[0];
                        string sizeID= CookieDataArray[i].ToString().Split('-')[1];

                        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

                        string sql;
                        sql = "select A.*,dbo.getSizeName(" + sizeID + ") as SizeNamee, "+sizeID+" as SizeIDD, SizeData.Name,SizeData.Extension  from tblProducts A cross apply(select top 1 B.Name,Extension from tblProductImages B where B.Pid=A.PId ) SizeData where A.PId='" + pId + "'";
                        SqlCommand cmd = new SqlCommand(sql, con);

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);

                       
                        sda.Fill(dt);

                        CartTotal += Convert.ToInt64(dt.Rows[i]["PPrice"]);
                        Total += Convert.ToInt64(dt.Rows[i]["PSelPrice"]);

                    }
                    rptrCartProducts.DataSource = dt;
                    rptrCartProducts.DataBind();


                    spanCartTotal.InnerText = CartTotal.ToString();

                    spanTotal.InnerText = "$ " + Total.ToString();
                    spanDiscount.InnerText = "-" + (CartTotal - Total).ToString();
                }
                else
                {
                    numItems.InnerText = "Your Shopping Cart is Empty";
                    divpricedetails.Visible = false;
                }
                
            }
            else
            {
                numItems.InnerText = "Your Shopping Cart is Empty";
                divpricedetails.Visible = false;

            }
        }

        protected void btnRemoveCart_Click(object sender, EventArgs e)
        {
            string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];

            Button btn = (Button)(sender);

            string PIDSIZE = btn.CommandArgument;

            List<String> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
            CookiePIDList.Remove(PIDSIZE);
            string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());
            if (CookiePIDUpdated == "")
            {
                HttpCookie CartProducts = Request.Cookies["CartPID"];
                CartProducts.Values["CartPID"] = null;
                CartProducts.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(CartProducts);
            }
            else
            {
                HttpCookie CartProducts = Request.Cookies["CartPID"];
                CartProducts.Values["CartPID"] = CookiePIDUpdated;
                CartProducts.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProducts);
            }
            Response.Redirect("Cart.aspx");
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            if(Session["Username"]!= null)
            {

                Response.Redirect("Payment.aspx");
           }
            else
            {
                Response.Redirect("SignIn.aspx?rurl=cart");
            }


        }

        public string getSizeName(int sizeId)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");
            con.Open();
            string sql;

            //using (SqlCommand cmd = new SqlCommand("select A.*,dbo.getSizeName(" + SizeID + ") as SizeNamee,"
            //                          + SizeID + " as SizeIDD,SizeData.Name,SizeData.Extention from tblProducts A cross apply( select top 1 B.Name,Extention from tblProductImages B where B.PID=A.PID ) SizeData where A.PID="
            //                          + PID + "", con))
                sql = "select * from tblSizes where SizeId='" + sizeId + "'";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader myreader = cmd.ExecuteReader();
            myreader.Read();

            string sizeName="";
            if (myreader.HasRows)
            {
                sizeName = myreader["SizeName"].ToString();
                return sizeName;
            }
            return "no size";

        }
    }
}