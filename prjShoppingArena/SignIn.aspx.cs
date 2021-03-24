using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace prjShoppingArena
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if(Request.Cookies["UNAME"]!=null && Request.Cookies["UPWD"] != null)
                {
                    txtUsername.Text= Request.Cookies["UNAME"].Value;
                    txtPass.Text= Request.Cookies["UPWD"].Value;

                    chkUser.Checked = true; 
                }
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

            con.Open();

            string sql = "Select * from tblUsers where Username=@user and Password=@pwd";

            SqlCommand mycmd = new SqlCommand(sql, con);

            mycmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
            mycmd.Parameters.AddWithValue("@pwd", txtPass.Text.Trim());
            SqlDataAdapter myAdapter = new SqlDataAdapter(mycmd);
            DataTable tabUsers = new DataTable();

            myAdapter.Fill(tabUsers);

            if (tabUsers.Rows.Count != 0)
            {

                if (chkUser.Checked)
                {
                    // storing values in cookies
                    Response.Cookies["UNAME"].Value= tabUsers.Rows[0]["Username"].ToString();
                    Response.Cookies["UPWD"].Value= tabUsers.Rows[0]["Password"].ToString();

                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(10);
                    Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(10);
                }
                else
                {
                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);

                }

                string utype = tabUsers.Rows[0]["UserType"].ToString().Trim();

                if (utype == "User")
                {
                    Session["Username"] = tabUsers.Rows[0]["Username"].ToString();

                    //lblError.Text= tabUsers.Rows[0]["Username"].ToString();
                    if (Request.QueryString["rurl"] != null)
                    {
                        if (Request.QueryString["rurl"] == "cart")
                        {
                            Response.Redirect("Cart.aspx");
                        }
                    }

                    else
                    {
                        Response.Redirect("Home.aspx");

                    }


                   
                }

                if (utype == "Admin")
                {
                    Session["Username"] = tabUsers.Rows[0]["Username"].ToString();

                    
                    Response.Redirect("AdminHome.aspx");
                }

            }


            else
            {
                lblError.Text = "Invalid Username or password";
            }

            //Response.Write("<script> alert('Login Failed');  </script>");

            clr();
            con.Close();
            //lblMsg.ForeColor = System.Drawing.Color.Green;
            //lblMsg.Text = "Registration Done ";
        }

        private void clr()
        {

            txtPass.Text = "";
            txtUsername.Text = "";
            txtUsername.Focus();
        }
    }
}