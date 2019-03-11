using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

namespace Dsda.WebRO
{
    public partial class RootMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            splRoot.GetPaneByName("Header").Size = ASPxWebControl.GlobalTheme == "Moderno" ? 95 : 83;
            splRoot.GetPaneByName("Header").MinSize = ASPxWebControl.GlobalTheme == "Moderno" ? 95 : 83;

            // Get the user logged in and the related role
            string l_UserID = string.Empty;
            string l_UserName = string.Empty;
            int l_RoleID = 0;
            if (Page.User.Identity != null)
            {
                if (!(Page.User.Identity.Name.Equals(string.Empty)))
                    l_RoleID = 1;
            }
            switch (l_RoleID)
            {
                case 1:
                    this.XmlDataSourceHeader.DataFile = "~/App_Data/UserMenu.xml";
                    this.XmlDataSourceHeader.XPath = "/items/*";
                    break;
                default:
                    this.XmlDataSourceHeader.DataFile = "~/App_Data/EmptyMenu.xml";
                    this.XmlDataSourceHeader.XPath = "/items/*";
                    break;
            }

            Page.Title = "ADP RO Upload Statistics";
        }
    }
}