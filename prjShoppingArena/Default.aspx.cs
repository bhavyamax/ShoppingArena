using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjShoppingArena
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCartNumber();
            if (Session["Username"] != null)
            {
                // lblSuccess.Text = "Login Success, Welcome " + Session["Username"].ToString();
                btnSignUP.Visible = false;
                btnSignIN.Visible = false;
                btnLogout.Visible = true;
            }

            else
            {
                
                btnSignUP.Visible = true;
                btnSignIN.Visible = true;
                btnLogout.Visible = false;
                //  Response.Redirect("SignIn.aspx");
                //Response.Redirect("Default.aspx");
            }
        }


        public void BindCartNumber()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] ProductArray = CookiePID.Split(',');
                int ProductCount = ProductArray.Length;
                pCount.InnerText = ProductCount.ToString();
            }
            else
            {
                pCount.InnerText = "0";
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["Username"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}