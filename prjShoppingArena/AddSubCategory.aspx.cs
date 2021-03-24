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
    public partial class AddSubCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

                con.Open();
                string sql = "Select * from tblCategory";

                SqlCommand mycmd = new SqlCommand(sql, con);

                SqlDataAdapter myAdapter = new SqlDataAdapter(mycmd);

                DataTable tabCategory = new DataTable();
                myAdapter.Fill(tabCategory);

                if (tabCategory.Rows.Count != 0)
                {

                    cboCatId.DataSource = tabCategory;
                    cboCatId.DataTextField = "CatName";
                    cboCatId.DataValueField = "CatId";
                    cboCatId.DataBind();
                    cboCatId.Items.Insert(0, new ListItem("Select", "0"));
                }
                
                    BindSubCategoryReapter();
                
                con.Close();

            }

        }

        protected void btnAddSubCat_Click(object sender, EventArgs e)
        {
           

        }

        private void BindSubCategoryReapter()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("select A.*,B.* from tblSubCategory A inner join tblCategory B on B.CatId  =A.CatId ", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            rptrCategory.DataSource = dt;
            rptrCategory.DataBind();


        }

        protected void btnAddSubCat_Click1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

            con.Open();

            string sql = "Insert into tblSubCategory(SubCatName,CatId) Values('" + txtSubCategory.Text + "','" + cboCatId.SelectedItem.Value + "')";

            SqlCommand mycmd = new SqlCommand(sql, con);

            mycmd.ExecuteNonQuery();

            Response.Write("<script> alert('SubCategory Added Successfully done');  </script>");
            txtSubCategory.Text = "";

            con.Close();
            txtSubCategory.Focus();
            cboCatId.ClearSelection();
            cboCatId.Items.FindByValue("0").Selected = true;
            BindSubCategoryReapter();
        }
    }

   
}