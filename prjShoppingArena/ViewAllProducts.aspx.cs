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
    public partial class ViewAllProducts : System.Web.UI.Page
    {
        //  SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

            BindProducts();



            }
        }

        private void BindProducts()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");



            string sql;

            // sql = "select A.*,B.* from tblProducts A cross apply (select top 1 * from tblProductImages where Pid=A.PId order by Pid desc)B order by A.PId desc";
            sql = "select A.*,B.*,C.Name as BrandName, B.Name as ImageName,A.PPrice-A.PselPrice as DiscountAmount from tblProducts A inner join tblBrands C on C.BrandId=A.PBrandId cross apply(select top 1 * from tblProductImages where Pid = A.PId order by Pid desc)B order by A.PId desc";

                SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);
           rptrProducts.DataSource = dt;
            rptrProducts.DataBind();
        }
    }
    }
