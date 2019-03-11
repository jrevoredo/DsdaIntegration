using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dsda.WebUploadStatistics.Reports
{
    public partial class IngestionError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnExportXLS_Click(object sender, EventArgs e)
        {
            this.grdExpIngestionError.WriteXlsToResponse();
        }

        protected void grdIngestionError_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            try
            {
                string l_TenantName = e.Keys["tenantName"].Equals(System.DBNull.Value) ? string.Empty : e.Keys["tenantName"].ToString();
                string l_StoreName = e.Keys["storeName"].Equals(System.DBNull.Value) ? string.Empty : e.Keys["storeName"].ToString();
                string l_DealNumber = e.Keys["dealNumber"].Equals(System.DBNull.Value) ? string.Empty : e.Keys["dealNumber"].ToString();
                string l_ErrorMessage = e.Keys["error_message"].Equals(System.DBNull.Value) ? string.Empty : e.Keys["error_message"].ToString();
                Dsda.WebUploadStatistics._Class.LinqDataClassesDataContext l_Context = new Dsda.WebUploadStatistics._Class.LinqDataClassesDataContext();
                List<Dsda.WebUploadStatistics._Class.ASingestionError> l_ListRecords =
                    (from l_TableObj in l_Context.ASingestionErrors
                     where l_TableObj.dealNumber == l_DealNumber
                     select l_TableObj).ToList();

                foreach (Dsda.WebUploadStatistics._Class.ASingestionError l_Record in l_ListRecords)
                    l_Context.ASingestionErrors.DeleteOnSubmit(l_Record);

                l_Context.SubmitChanges();
            }
            catch (Exception ex) { throw ex; }
            //this.grdIngestionError.DataBind();
            this.grdIngestionError.CancelEdit();
        }
    }
}