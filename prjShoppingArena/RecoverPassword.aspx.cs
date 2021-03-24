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
    public partial class RecoverPassword : System.Web.UI.Page
    {

        String guid;
        int Uid;
        DataTable tabUsers;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");
            tabUsers = new DataTable();
            con.Open();
            guid = Request.QueryString["id"];

            if (guid != null)
            {
                string sql = "Select * from ForgotPass where Id=@id";

                SqlCommand mycmd = new SqlCommand(sql, con);

                mycmd.Parameters.AddWithValue("@id", guid);
                SqlDataAdapter myadapter = new SqlDataAdapter(mycmd);

                myadapter.Fill(tabUsers);
                Uid = Convert.ToInt32(tabUsers.Rows[0]["Uid"]);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }


            if (IsPostBack == false) // user coming for the first time
            {

                if (tabUsers.Rows.Count!=0) {

                    txtConfirmPwd.Visible = true;
                    txtNewPass.Visible = true;
                    lblNewPwd.Visible = true;
                    lblConfirmPwd.Visible = true;
                    btnResetPass.Visible = true;
                }

                else
                {
                    lblmsg.Text = "Your Password Reset Link is Expired or Invalid...try again";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            con.Close();


        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {

            if (txtNewPass.Text != "" && txtConfirmPwd.Text != "" && txtNewPass.Text == txtConfirmPwd.Text)
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");
                
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update tblUsers set Password=@pwd where Uid=@Uid", con);
                    cmd.Parameters.AddWithValue("@pwd", txtNewPass.Text);
                    cmd.Parameters.AddWithValue("@Uid", Uid);
                    cmd.ExecuteNonQuery();


                    SqlCommand cmd2 = new SqlCommand("delete from ForgotPass where Uid='" + Uid + "'", con);
                    cmd2.ExecuteNonQuery();
                    Response.Write("<script> alert('Password Reset Successfully done');  </script>");
                    Response.Redirect("SignIn.aspx");
                
            }
        }
    }
}