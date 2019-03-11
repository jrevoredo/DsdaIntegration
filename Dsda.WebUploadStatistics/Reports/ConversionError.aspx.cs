using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dsda.WebUploadStatistics.Reports
{
    public partial class ConversionError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnExportXLS_Click(object sender, EventArgs e)
        {
            this.grdExpConversionError.WriteXlsToResponse();
        }

        protected void grdConversionError_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            try
            {
                int l_KeyId = e.Keys["id"].Equals(System.DBNull.Value) ? 0 : Convert.ToInt32(e.Keys["id"]);
                string l_FileName = e.Values["fileName"].Equals(System.DBNull.Value) ? string.Empty : e.Values["fileName"].ToString();
                Dsda.WebUploadStatistics._Class.LinqDataClassesDataContext l_Context = new Dsda.WebUploadStatistics._Class.LinqDataClassesDataContext();
                List<Dsda.WebUploadStatistics._Class.ASconversionError> l_ListRecords =
                    (from l_TableObj in l_Context.ASconversionErrors
                     where l_TableObj.fileName == l_FileName
                     select l_TableObj).ToList();

                foreach (Dsda.WebUploadStatistics._Class.ASconversionError l_Record in l_ListRecords)
                    l_Context.ASconversionErrors.DeleteOnSubmit(l_Record);

                l_Context.SubmitChanges();
            }
            catch (Exception) { }
            //this.grdConversionError.DataBind();
            this.grdConversionError.CancelEdit();
        }
    }
}