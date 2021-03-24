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
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategoryReapter();
            }
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

            con.Open();

            string sql = "Insert into tblCategory(CatName) Values('" + txtCategory.Text + "')";

            SqlCommand mycmd = new SqlCommand(sql, con);

            mycmd.ExecuteNonQuery();

            Response.Write("<script> alert('Category Added Successfully done');  </script>");
            txtCategory.Text = "";

            con.Close();
            txtCategory.Focus();
            BindCategoryReapter();
        }

        private void BindCategoryReapter()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("select * from tblCategory", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrCategory.DataSource = dt;
                        rptrCategory.DataBind();
                    
                
            }
        }
    }
