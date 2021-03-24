using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

using System.Net.Mail;
using System.Net;
namespace prjShoppingArena
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ShoppingArenaDB;Integrated Security=True");

            con.Open();

            string sql = "Select * from tblUsers where Email=@email";

            SqlCommand mycmd = new SqlCommand(sql, con);

            mycmd.Parameters.AddWithValue("email", txtEmailID.Text.Trim());

            SqlDataAdapter myAdapter = new SqlDataAdapter(mycmd);
            DataTable tabUsers = new DataTable();

            myAdapter.Fill(tabUsers);


            if (tabUsers.Rows.Count != 0)
            {
                string myGUID = Guid.NewGuid().ToString(); //makes an actual id with a unique value,
                int Uid = Convert.ToInt32(tabUsers.Rows[0]["Uid"]);

                SqlCommand cmd1 = new SqlCommand("Insert into ForgotPass values('" + myGUID + "','" + Uid + "',GETDATE())", con);
                cmd1.ExecuteNonQuery();


                string ToEmailAddress = tabUsers.Rows[0]["Email"].ToString();
                string UserName = tabUsers.Rows[0]["Username"].ToString();
                String EmailBody = "Hi ," + UserName + ",<br/><br/>Click the link below to reset your password<br/> <br/> http://localhost:56031/RecoverPassword.aspx?id=" + myGUID; // taking id to RecoverPassword page

                MailMessage PassRecMail = new MailMessage("shoppingarena.dummy@gmail.com", ToEmailAddress); //(sender,receiver)


                PassRecMail.Body = EmailBody;
                PassRecMail.IsBodyHtml = true;
                PassRecMail.Subject = "Reset Password";

                SmtpClient client = new SmtpClient();
                
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("shoppingarena.dummy@gmail.com", "shoppingarena123");
                   client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    client.Send(PassRecMail);

                lblResetPassMsg.Text = "Reset Link send ! Check YOur email for reset password";
                lblResetPassMsg.ForeColor = System.Drawing.Color.Green;
                txtEmailID.Text = "";
            }

            else
            {

                lblResetPassMsg.Text = "OOps! This Email Does not Exist...Try agian ";
                lblResetPassMsg.ForeColor = System.Drawing.Color.Red;
                txtEmailID.Text ="";
                txtEmailID.Focus();

            }
        }
    }
}