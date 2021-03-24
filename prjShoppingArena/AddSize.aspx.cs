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
    public partial class AddSize : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {


               con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

                con.Open();

                BindCategory();
                BindBrand();

                BindGender();
                BindRptrSize();
                con.Close();

                  
                
            }
        }

        protected void btnAddSubCat_Click(object sender, EventArgs e) // ADD SIZE
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

            con.Open();

            // string sql = "Insert into tblSize(SizeName,BrandId) Values('" + txtSize.Text + "')";
             string sql= "Insert into tblSizes(SizeName, BrandId, CatId, SubCatId, GenderId) Values('" + txtSize.Text + "', '" + cboBrand.SelectedItem.Value + "', '" +cboCategory.SelectedItem.Value + "', '" + cboSubCategory.SelectedItem.Value + "', '" + cboGender.SelectedItem.Value + "')";

      //   string sql = Insert into tblSizes(SizeName, BrandId, CatId, SubCatId, GenderId) Values('" + txtSize.Text + "', '" + cboBrand.SelectedItem.Value + "', '" +cboCategory.SelectedItem.Value + "', '" + cboSubCategory.SelectedItem.Value + "', '" + cboGender.SelectedItem.Value + "'";
            SqlCommand mycmd = new SqlCommand(sql, con);

            mycmd.ExecuteNonQuery();

            Response.Write("<script> alert('Size Added Successfully done');  </script>");
         

            con.Close();
            cboBrand.ClearSelection();
            cboBrand.Items.FindByValue("0").Selected = true;

            cboCategory.ClearSelection();
            cboCategory.Items.FindByValue("0").Selected = true;


            cboSubCategory.ClearSelection();
            cboSubCategory.Items.FindByValue("0").Selected = true;

            cboGender.ClearSelection();
            cboGender.Items.FindByValue("0").Selected = true;

            BindRptrSize();
        }

        private void BindCategory()
        {

            string sql = "Select * from tblCategory";

            SqlCommand mycmd = new SqlCommand(sql, con);

            SqlDataAdapter myAdapter = new SqlDataAdapter(mycmd);

            DataTable tabCategory = new DataTable();
            myAdapter.Fill(tabCategory);

            if (tabCategory.Rows.Count != 0)
            {

                cboCategory.DataSource = tabCategory;
                cboCategory.DataTextField = "CatName";
                cboCategory.DataValueField = "CatId";
                cboCategory.DataBind();
                cboCategory.Items.Insert(0, new ListItem("Select", "0"));
            }

        }


        private void BindBrand()
        {

            string sql = "Select * from tblBrands";

            SqlCommand mycmd = new SqlCommand(sql, con);

            SqlDataAdapter myAdapter = new SqlDataAdapter(mycmd);

            DataTable tabBrands = new DataTable();
            myAdapter.Fill(tabBrands);

            if (tabBrands.Rows.Count != 0)
            {

                cboBrand.DataSource = tabBrands;
                cboBrand.DataTextField = "Name";
                cboBrand.DataValueField = "BrandId";
                cboBrand.DataBind();
                cboBrand.Items.Insert(0, new ListItem("Select", "0"));
            }

        }

        private void BindGender()
        {

            string sql = "Select * from tblGender";

            SqlCommand mycmd = new SqlCommand(sql, con);

            SqlDataAdapter myAdapter = new SqlDataAdapter(mycmd);

            DataTable tabGender = new DataTable();
            myAdapter.Fill(tabGender);

            if (tabGender.Rows.Count != 0)
            {

               cboGender.DataSource = tabGender;
                cboGender.DataTextField = "GenderName";
                cboGender.DataValueField = "GenderId";
                cboGender.DataBind();
                cboGender.Items.Insert(0, new ListItem("Select", "0"));
            }

        }

        protected void cboSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        protected void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");
            con.Open();
            int mainCatId = Convert.ToInt32(cboCategory.SelectedItem.Value);



            string sql = "Select * from tblSubCategory where CatId='" + cboCategory.SelectedItem.Value + "'";

            SqlCommand mycmd = new SqlCommand(sql, con);

            SqlDataAdapter myAdapter = new SqlDataAdapter(mycmd);

            DataTable tabSubCat = new DataTable();
            myAdapter.Fill(tabSubCat);

            if (tabSubCat.Rows.Count != 0)
            {

                cboSubCategory.DataSource = tabSubCat;
                cboSubCategory.DataTextField = "SubCatName";
                cboSubCategory.DataValueField = "SubCatId";
                cboSubCategory.DataBind();
                cboSubCategory.Items.Insert(0, new ListItem("Select", "0"));
            }
           // con.Close();
        }

       private void BindRptrSize()
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("select A.*,B.*,C.*,D.*,E.* from tblSizes A inner join tblCategory B on B.CatId =a.CatId  inner join tblBrands C on C.BrandId =A.BrandId inner join tblSubCategory D on D.SubCatId =A.SubCatId inner join tblGender E on E.GenderId =A.GenderId ", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            rptrSize.DataSource = dt;
            rptrSize.DataBind();
        }
    }
}