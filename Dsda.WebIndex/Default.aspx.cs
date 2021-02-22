using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dsda.WebIndex
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string l_Localhost = string.Empty;
                string l_UploadStatistics = string.Empty;
                string l_ADPUpload = string.Empty;
                string l_ADPUploadRO = string.Empty;
                l_Localhost = (string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["Localhost"]) ? "" : System.Configuration.ConfigurationManager.AppSettings["Localhost"].ToString());
                if (l_Localhost.Trim().Equals(string.Empty))
                    l_Localhost = System.Environment.MachineName.Trim().ToLower();
                l_UploadStatistics = (string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["UploadStatistics"]) ? "" : System.Configuration.ConfigurationManager.AppSettings["UploadStatistics"].ToString());
                l_ADPUpload = (string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ADPUpload"]) ? "" : System.Configuration.ConfigurationManager.AppSettings["ADPUpload"].ToString());
                l_ADPUploadRO = (string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ADPUploadRO"]) ? "" : System.Configuration.ConfigurationManager.AppSettings["ADPUploadRO"].ToString());
                hypUploadStatistics.NavigateUrl = "http://" + (l_Localhost.Trim().Equals(string.Empty) ? "localhost" : l_Localhost.Trim()) + "/" + (l_UploadStatistics.Trim().Equals(string.Empty) ? "UploadStatistics" : l_UploadStatistics.Trim()) + "/";
                hypUploadStatistics.Text = "http://" + (l_Localhost.Trim().Equals(string.Empty) ? "localhost" : l_Localhost.Trim()) + "/" + (l_UploadStatistics.Trim().Equals(string.Empty) ? "UploadStatistics" : l_UploadStatistics.Trim());
                hypADPUpload.NavigateUrl = "http://" + (l_Localhost.Trim().Equals(string.Empty) ? "localhost" : l_Localhost.Trim()) + "/" + (l_ADPUpload.Trim().Equals(string.Empty) ? "ADPUpload" : l_ADPUpload.Trim()) + "/";
                hypADPUpload.Text = "http://" + (l_Localhost.Trim().Equals(string.Empty) ? "localhost" : l_Localhost.Trim()) + "/" + (l_ADPUpload.Trim().Equals(string.Empty) ? "ADPUpload" : l_ADPUpload.Trim());
                hypADPUploadRO.NavigateUrl = "http://" + (l_Localhost.Trim().Equals(string.Empty) ? "localhost" : l_Localhost.Trim()) + "/" + (l_ADPUploadRO.Trim().Equals(string.Empty) ? "ADPUploadRO" : l_ADPUploadRO.Trim()) + "/";
                hypADPUploadRO.Text = "http://" + (l_Localhost.Trim().Equals(string.Empty) ? "localhost" : l_Localhost.Trim()) + "/" + (l_ADPUploadRO.Trim().Equals(string.Empty) ? "ADPUploadRO" : l_ADPUploadRO.Trim());
            }
        }
    }
}