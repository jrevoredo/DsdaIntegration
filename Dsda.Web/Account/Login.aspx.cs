using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dsda.Web.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            e.Authenticated = CheckCredentials(LoginUser.UserName, LoginUser.Password);
        }

        private bool CheckCredentials(string userName, string password)
        {
            string confUserName = WebConfigurationManager.AppSettings["UserName"];
            string confPassword = WebConfigurationManager.AppSettings["Password"];

            return string.Equals(confUserName, userName) && string.Equals(confPassword, password);
        }
    }
}
