using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace prjShoppingArena
{
    public partial class Add_Product : System.Web.UI.Page
    {
      
        public static string conStr = "Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                cboGender.Enabled = false;
                cboSubCategory.Enabled = false;
                BindBrand();
                BindCategory();
                BindGender();

            }
        }


        private void BindBrand()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
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

        private void BindCategory()
        {
          
            string sql = "Select * from tblCategory";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
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

        private void BindGender()
        {

            string sql = "Select * from tblGender";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
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

        protected void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSubCategory.Enabled = true;
            SqlConnection con = new SqlConnection(conStr);
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
        }

        protected void cboSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubCategory.SelectedIndex != 0)
            {
                cboGender.Enabled = true;
            }
            else
            {
                cboGender.Enabled = false;
            }
        }

        protected void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
           



            string sql = "Select * from tblSizes where BrandId='" + cboBrand.SelectedItem.Value + "' and CatId='" + cboCategory.SelectedItem.Value + "' and SubCatId='" + cboSubCategory.SelectedItem.Value + "' and GenderId='" + cboGender.SelectedItem.Value + "'";

            SqlCommand mycmd = new SqlCommand(sql, con);

            SqlDataAdapter myAdapter = new SqlDataAdapter(mycmd);

            DataTable tabSize = new DataTable();
            myAdapter.Fill(tabSize);

            if (tabSize.Rows.Count != 0)
            {

                lstSize.DataSource = tabSize;
                lstSize.DataTextField = "SizeName";
                lstSize.DataValueField = "SizeId";
                lstSize.DataBind();
              //  lstSize.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            string sql = "insert into tblProducts values (@pname,@price,@sprice,@brandid,@catid,@subcatid,@genderid,@description,@productdetails,@productmaterial,@freedelivery,@return,@cod)";

            SqlCommand mycmd = new SqlCommand(sql, con);

            mycmd.Parameters.AddWithValue("@pname", txtProductName.Text);
            mycmd.Parameters.AddWithValue("@price", txtPrice.Text);
            mycmd.Parameters.AddWithValue("@sprice", txtsellPrice.Text);
            mycmd.Parameters.AddWithValue("@brandid", cboBrand.SelectedItem.Value);
            mycmd.Parameters.AddWithValue("@catid", cboCategory.SelectedItem.Value);
            mycmd.Parameters.AddWithValue("@subcatid", cboSubCategory.SelectedItem.Value);
            mycmd.Parameters.AddWithValue("@genderid", cboGender.SelectedItem.Value);
            mycmd.Parameters.AddWithValue("@description", txtDescription.Text);
            mycmd.Parameters.AddWithValue("@productdetails", txtPDetail.Text);
            mycmd.Parameters.AddWithValue("@productmaterial", txtMatCare.Text);

            if (chkFDelivery.Checked == true)
            {
                mycmd.Parameters.AddWithValue("@freedelivery", "1");
            }
            else
            {
                mycmd.Parameters.AddWithValue("@freedelivery", "0");
            }

            if (chkReturn.Checked == true)
            {
                mycmd.Parameters.AddWithValue("@return", "1");
            }
            else
            {
                mycmd.Parameters.AddWithValue("@return", "0");
            }


            if (chkCod.Checked == true)
            {
                mycmd.Parameters.AddWithValue("@cod", "1");
            }
            else
            {
                mycmd.Parameters.AddWithValue("@cod", "0");
            }


            mycmd.ExecuteNonQuery();

            Response.Write("<script> alert('Product Added Successfully ');  </script>");
            string sql2 = "SELECT * FROM tblProducts WHERE PId=(SELECT max(PId) FROM tblProducts)";

            SqlCommand cmd2 = new SqlCommand(sql2, con);

            SqlDataReader myreader = cmd2.ExecuteReader();
            myreader.Read();

            Int64 pid = Convert.ToInt64(myreader["PId"].ToString());

            // lblError.Text = pid.ToString();
            // insert size quantity
            myreader.Close();
            for (int i = 0; i < lstSize.Items.Count; i++)
            {

                Int64 sizeId = Convert.ToInt64(lstSize.Items[i].Value);
                int quantity = Convert.ToInt32(txtQuantity.Text);

                SqlCommand cmd3 = new SqlCommand("insert into tblProductSizeQuantity values('" + pid + "','" + sizeId + "','" + quantity + "')", con);
                cmd3.ExecuteNonQuery();

            }

            // insert image

            if (uploadImg01.HasFile)
            {
                string savePath = Server.MapPath("~/Images/ProductImages/")+pid;

                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);

                }

                string Extention = Path.GetExtension(uploadImg01.PostedFile.FileName);
                uploadImg01.SaveAs(savePath + "\\" + txtProductName.Text.ToString().Trim() + "01" + Extention);

                SqlCommand cmd4 = new SqlCommand("insert into tblProductImages values('" + pid + "','" + txtProductName.Text.ToString().Trim() + "01" + "','" + Extention + "')", con);
                cmd4.ExecuteNonQuery();
            }

            // img2
            if (uploadImg02.HasFile)
            {
                string savePath = Server.MapPath("~/Images/ProductImages/") + pid;

                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);

                }

                string Extention = Path.GetExtension(uploadImg02.PostedFile.FileName);
                uploadImg02.SaveAs(savePath + "\\" + txtProductName.Text.ToString().Trim() + "02" + Extention);

                SqlCommand cmd5 = new SqlCommand("insert into tblProductImages values('" + pid + "','" + txtProductName.Text.ToString().Trim() + "02" + "','" + Extention + "')", con);
                cmd5.ExecuteNonQuery();
            }


            // img3
            if (uploadImg03.HasFile)
            {
                string savePath = Server.MapPath("~/Images/ProductImages/") + pid;

                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);

                }

                string Extention = Path.GetExtension(uploadImg03.PostedFile.FileName);
                uploadImg03.SaveAs(savePath + "\\" + txtProductName.Text.ToString().Trim() + "03" + Extention);

                SqlCommand cmd6 = new SqlCommand("insert into tblProductImages values('" + pid + "','" + txtProductName.Text.ToString().Trim() + "03" + "','" + Extention + "')", con);
                cmd6.ExecuteNonQuery();
            }


            // img4
            if (uploadImg04.HasFile)
            {
                string savePath = Server.MapPath("~/Images/ProductImages/") + pid;

                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);

                }

                string Extention = Path.GetExtension(uploadImg04.PostedFile.FileName);
                uploadImg04.SaveAs(savePath + "\\" + txtProductName.Text.ToString().Trim() + "04" + Extention);

                SqlCommand cmd7= new SqlCommand("insert into tblProductImages values('" + pid + "','" + txtProductName.Text.ToString().Trim() + "04" + "','" + Extention + "')", con);
                cmd7.ExecuteNonQuery();
            }


            // img5
            if (uploadImg05.HasFile)
            {
                string savePath = Server.MapPath("~/Images/ProductImages/") + pid;

                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);

                }

                string Extention = Path.GetExtension(uploadImg05.PostedFile.FileName);
                uploadImg05.SaveAs(savePath + "\\" + txtProductName.Text.ToString().Trim() + "05" + Extention);

                SqlCommand cmd8 = new SqlCommand("insert into tblProductImages values('" + pid + "','" + txtProductName.Text.ToString().Trim() + "05" + "','" + Extention + "')", con);
                cmd8.ExecuteNonQuery();
            }

        }
    }
}