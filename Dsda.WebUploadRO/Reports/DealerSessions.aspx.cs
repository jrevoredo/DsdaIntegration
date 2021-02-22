using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dsda.WebUploadRO.Reports
{
    public partial class DealerSessions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        protected void btnExportXLS_Click(object sender, EventArgs e)
        {
            this.grdExpDealerSessions.WriteXlsToResponse();
        }

        private void LoadData()
        {
            using (var context = new Dsda.DataAccessRO.DataClassesDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["Dsda.DataAccessMain.Properties.Settings.DsdaIntegrationConnectionString"].ConnectionString))
            {
                var l_USList = context.tblUploadSessions
                                    .OrderByDescending(order => order.DateCreated)
                                    .ToList();
                this.grdDealerSessions.DataSource = l_USList;
                this.grdDealerSessions.DataBind();
            }
        }

        // ***** For object:
        //       <dx:EntityServerModeDataSource ID="esmDealerSessions" runat="server" ContextTypeName="Dsda.DataAccessRO.DataClassesDataContext" TableName="tblUploadSessions" OnSelecting="esmDealerSessions_Selecting" OnInit="esmDealerSessions_Init" />
        //protected void esmDealerSessions_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        //{
        //    e.KeyExpression = "UploadSessionId";
        //    e.DefaultSorting = "DateCreated DESC";
        //}
    }
}