using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Dsda.WebUploadRO.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckCredentials(tbUserName.Text, tbPassword.Text))
            {
                if (string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                {
                    FormsAuthentication.SetAuthCookie(tbUserName.Text, false);
                    Response.Redirect("~/");
                }
                else
                    FormsAuthentication.RedirectFromLoginPage(tbUserName.Text, false);
            }
            else
            {
                tbUserName.ErrorText = "Invalid user";
                tbUserName.IsValid = false;
            }
            //if (Membership.ValidateUser(tbUserName.Text, tbPassword.Text)) {
            //    if(string.IsNullOrEmpty(Request.QueryString["ReturnUrl"])) {
            //        FormsAuthentication.SetAuthCookie(tbUserName.Text, false);
            //        Response.Redirect("~/");
            //    }
            //    else
            //        FormsAuthentication.RedirectFromLoginPage(tbUserName.Text, false);
            //}
            //else {
            //    tbUserName.ErrorText = "Invalid user";
            //    tbUserName.IsValid = false;
            //}
        }

        private bool CheckCredentials(string p_UserName, string p_Password)
        {
            string l_UserName = string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["AUTH_USERNAME"]) ? string.Empty : System.Configuration.ConfigurationManager.AppSettings["AUTH_USERNAME"].ToString();
            string l_Password = string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["AUTH_PASSWORD"]) ? string.Empty : System.Configuration.ConfigurationManager.AppSettings["AUTH_PASSWORD"].ToString();
            return string.Equals(l_UserName.ToUpper(), p_UserName.ToUpper()) && string.Equals(l_Password, p_Password);
        }
    }
}