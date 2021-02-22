using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dsda.WebUpload.Reports
{
    public partial class DealerSessionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        protected void btnExportXLS_Click(object sender, EventArgs e)
        {
            this.grdExpDealerSessionDetails.WriteXlsToResponse();
        }

        protected void grdDealerSessionDetails_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "MessageTypeDescr")
            {
                int l_MessageType = Convert.ToInt32(e.GetListSourceFieldValue("MessageType"));
                string l_DescrMessageType = string.Empty;
                switch (l_MessageType)
                {
                    case 0:
                        l_DescrMessageType = "INFO";
                        break;
                    case 1:
                        l_DescrMessageType = "ERROR";
                        break;
                    default:
                        l_DescrMessageType = "INFO";
                        break;
                }
                e.Value = l_DescrMessageType;
            }
        }

        private void LoadData()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["UploadSessionId"]))
            {
                int l_UploadSessionId = 0;
                Int32.TryParse(Request.QueryString["UploadSessionId"], out l_UploadSessionId);

                using (var context = new Dsda.DataAccess.DataClassesDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["Dsda.DataAccessMain.Properties.Settings.DsdaIntegrationConnectionString"].ConnectionString))
                {
                    var l_USDList = context.tblUploadSessionDetails
                                        .OrderByDescending(order => order.MessageType)
                                        .OrderByDescending(order => order.UploadSessionDetailId)
                                        .Where(w => w.UploadSessionId == l_UploadSessionId)
                                        .ToList();
                    this.grdDealerSessionDetails.DataSource = l_USDList;
                    this.grdDealerSessionDetails.DataBind();
                }
            }
        }
    }
}