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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSignup_Click(object sender, EventArgs e)
        {

            if (isformvalid() == true)
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

                con.Open();

                string sql = "Insert into tblUsers(Username,Password,Email,Name,UserType) Values('" + txtUname.Text + "','" + txtPass.Text + "','" + txtEmail.Text + "','" + txtName.Text + "','User' )";

                SqlCommand mycmd = new SqlCommand(sql, con);

                mycmd.ExecuteNonQuery();

                Response.Write("<script> alert('Registration Successfully done');  </script>");

                clr();
                con.Close();
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Registration Done ";

                Response.Redirect("SignIn.aspx");
            }

            else
            {
                
                    Response.Write("<script> alert('Registration failed');  </script>");
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                
            }

     
        }

        private bool isformvalid()
        {
            if (txtUname.Text == "")
            {
                Response.Write("<script> alert('username not valid');  </script>");
                txtUname.Focus();

                return false;
            }
            else if (txtPass.Text == "")
            {
                Response.Write("<script> alert('Password not valid');  </script>");
                txtPass.Focus();
                return false;
            }
            else if (txtPass.Text != txtCPass.Text)
            {
                Response.Write("<script> alert('confirm Password not valid');  </script>");
                txtCPass.Focus();
                return false;
            }
            else if (txtEmail.Text == "")
            {
                Response.Write("<script> alert('Email not valid');  </script>");
                txtEmail.Focus();
                return false;
            }
            else if (txtName.Text == "")
            {
                Response.Write("<script> alert('Name not valid');  </script>");
                txtName.Focus();
                return false;
            }

            return true;
        }


        private void clr()
        {
            txtName.Text = "";
            txtPass.Text = "";
            txtUname.Text = "";
            txtEmail.Text = "";
            txtCPass.Text = "";
        }
    }
}