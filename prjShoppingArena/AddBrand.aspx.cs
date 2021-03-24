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
    public partial class AddBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrandRepeater();
            }
        }


        private void BindBrandRepeater()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("select * from tblBrands", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrBrands.DataSource = dt;
                        rptrBrands.DataBind();
                    
                
            
        }
        protected void btnAddBrand_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

            con.Open();

            string sql = "Insert into tblBrands(Name) Values('" + txtBrand.Text + "')";

            SqlCommand mycmd = new SqlCommand(sql, con);

            mycmd.ExecuteNonQuery();

            Response.Write("<script> alert('Brand Added Successfully done');  </script>");
            txtBrand.Text = "";
     
            con.Close();
            txtBrand.Focus();

          //  Response.Redirect("SignIn.aspx");

        }
    }
}