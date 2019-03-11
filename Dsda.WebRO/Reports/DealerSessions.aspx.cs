using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dsda.WebRO.Reports
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
            using (var context = new Dsda.DataAccessRO.DataClassesDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["DsdaIntegrationConnectionString"].ConnectionString))
            {
                var l_USList = context.tblUploadSessions
                                    .OrderByDescending(order => order.DateCreated)
                                    .ToList();
                this.grdDealerSessions.DataSource = l_USList;
                this.grdDealerSessions.DataBind();
            }
        }
    }
}