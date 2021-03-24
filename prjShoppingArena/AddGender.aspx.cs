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
    public partial class AddGender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               BindGenderReapter();
            }
        }

        protected void btnAddGender_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

            con.Open();

            string sql = "Insert into tblGender(GenderName) Values('" + txtGender.Text + "')";

            SqlCommand mycmd = new SqlCommand(sql, con);

            mycmd.ExecuteNonQuery();

            Response.Write("<script> alert('Gender Added Successfully done');  </script>");
            txtGender.Text = "";

            con.Close();
            txtGender.Focus();
            BindGenderReapter();
        }

        private void BindGenderReapter()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("select * from tblGender", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            rptrGender.DataSource = dt;
            rptrGender.DataBind();


        }
    }
}