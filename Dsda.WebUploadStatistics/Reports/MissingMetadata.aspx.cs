using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dsda.WebUploadStatistics.Reports
{
    public partial class MissingMetadata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnExportXLS_Click(object sender, EventArgs e)
        {
            this.grdExpMissingMetadata.WriteXlsToResponse();
        }
    }
}