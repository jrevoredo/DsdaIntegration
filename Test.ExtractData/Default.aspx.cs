using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test.ExtractData
{
    public partial class Default : System.Web.UI.Page
    {

        private string extractRecordUrl = "https://uat-3pa.dmotorworks.com/pip-extract/servicesalesclosed/extract";
        private string extractCustomerUrl = "https://uat-3pa.dmotorworks.com/pip-extract/help-customer/extract";
        private string username = "amscanning";
        private string password = "000309f17e";

        protected void Page_Load(object sender, EventArgs e)
        {
            // TO ENCODE ANY URL, USE: Uri.EscapeUriString(...);

        }

        protected void butSend_Click(object sender, EventArgs e)
        {
//            string url = @”testurl”;
//            System.Net.WebClient client = new System.Net.WebClient();
//            string userName = “testusername”;
//            string passWord = “testpass”;

//client.Credentials =  new System.Net.NetworkCredential(userName,passWord);

//string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + “:” + passWord));
// webClient.Headers[HttpRequestHeader.Authorization] = “Basic ” + credentials;

//var result = webClient.DownloadString(url);

//Response.Write(result);



            //Response.ContentType = "application/x-www-form-urlencoded";
            //string usernamePassword = "amscanning:000309f17e";
            //Response.AddHeader("Authorization", "Basic " + Convert.ToBase64String(new System.Text.ASCIIEncoding().GetBytes(usernamePassword)));

            //System.Net.WebRequest request = null;
            //System.Net.WebResponse response = null;
            //System.IO.Stream stream = null;
            //string extractCustomerUrl = "https://uat-3pa.dmotorworks.com/pip-extract/help-customer/extract";
            //string dealerID = "3PAAMSCAN1";
            //string queryId = "HelpCustomerCustNo";
            //string Customers = "15937””114526””23539";
            //string postData = string.Format("dealerId={0}&queryId={1}&qparamCustomerNumber={2}",
            //    dealerID.ToString(), queryId.ToString(),
            //    Customers.ToString());

            //// Encode post data
            //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            //byte[] data = encoding.GetBytes(postData);
            //request = System.Net.HttpWebRequest.Create(extractCustomerUrl);
            //request.Method = "POST";
            //request.ContentLength = data.Length;
            //request.ContentType = "application/x-www-form-urlencoded";

            //string username = "amscanning";
            //string password = "000309f17e";

            //System.Net.CredentialCache mycache = new System.Net.CredentialCache();
            //mycache.Add(new Uri(extractCustomerUrl), "Basic", new System.Net.NetworkCredential(username, password));
            //request.Credentials = mycache;
            //string usernamePassword = username + ":" + password;
            //request.Headers.Add("Authorization",
            //                    "Basic " + Convert.ToBase64String(new System.Text.ASCIIEncoding().GetBytes(usernamePassword)));

            //System.IO.Stream newStream = request.GetRequestStream();

            //// Send the post data.
            //newStream.Write(data, 0, data.Length);
            //newStream.Close();

            //stream = response.GetResponseStream();
            //StreamReader sr = new StreamReader(stream);

            //// Get data in text plain
            //resultData = sr.ReadToEnd();
            //stream.Close();
            //stream.Dispose();
            //response.Close();
        
        }


        protected void butGetOneCustomer_Click(object sender, EventArgs e)
        {
            lblTitleResults.Text = "GET ONE CUSTOMER";
            string dealerID = "3PAAMSCAN1";
            string queryId = "HelpCustomerCustNo";
            string Customers = "114526";
            string postData = string.Format("dealerId={0}&queryId={1}&qparamCustomerNumber={2}",
                dealerID.ToString(), queryId.ToString(),
                Customers.ToString());
            string resultData = string.Empty;
            System.Net.WebRequest request = null;
            System.Net.WebResponse response = null;
            System.IO.Stream stream = null;

            try
            {
                this.lblResults.Text = string.Empty;

                // Encode post data
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] data = encoding.GetBytes(postData);
                request = System.Net.HttpWebRequest.Create(extractCustomerUrl);
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/x-www-form-urlencoded";

                System.Net.CredentialCache mycache = new System.Net.CredentialCache();
                mycache.Add(new Uri(extractCustomerUrl), "Basic", new System.Net.NetworkCredential(username, password));
                request.Credentials = mycache;
                string usernamePassword = username + ":" + password;
                request.Headers.Add("Authorization",
                                    "Basic " + Convert.ToBase64String(new System.Text.ASCIIEncoding().GetBytes(usernamePassword)));

                System.IO.Stream newStream = request.GetRequestStream();

                // Send the post data.
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                response = request.GetResponse();
                stream = response.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(stream);

                // Get data in text plain
                resultData = sr.ReadToEnd();
                stream.Close();
                stream.Dispose();
                response.Close();
                this.lblResults.Text += FormatResultXML(resultData);
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Response != null)
                {
                    System.IO.Stream errorStream = ex.Response.GetResponseStream();
                    System.IO.StreamReader sr = new System.IO.StreamReader(errorStream);
                    string errordata = sr.ReadToEnd();
                    this.lblResults.Text += string.Format("Failure to get record by DealNo: {0}", errordata);
                }
                if (stream != null)
                {
                    stream.Dispose();
                }
                this.lblResults.Text += string.Format("Failure to get data from Pip-Extract service '{0}': {1}", queryId, ex.Message);
            }
            catch (Exception ex)
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
                this.lblResults.Text += string.Format("Failure to get data from Pip-Extract service: '{0}': {1}", queryId, ex.Message);
            }
        }

        protected void butGetManyCustomers_Click(object sender, EventArgs e)
        {
            lblTitleResults.Text = "GET MANY CUSTOMERS";
            string dealerID = "3PAAMSCAN1";
            string queryId = "HelpCustomerCustNo";
            string Customers = "15937””114526””23539";
            string postData = string.Format("dealerId={0}&queryId={1}&qparamCustomerNumber={2}",
                dealerID.ToString(), queryId.ToString(),
                Customers.ToString());
            string resultData = string.Empty;
            System.Net.WebRequest request = null;
            System.Net.WebResponse response = null;
            System.IO.Stream stream = null;

            try
            {
                this.lblResults.Text = string.Empty;

                // Encode post data
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] data = encoding.GetBytes(postData);
                request = System.Net.HttpWebRequest.Create(extractCustomerUrl);
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/x-www-form-urlencoded";

                System.Net.CredentialCache mycache = new System.Net.CredentialCache();
                mycache.Add(new Uri(extractCustomerUrl), "Basic", new System.Net.NetworkCredential(username, password));
                request.Credentials = mycache;
                string usernamePassword = username + ":" + password;
                request.Headers.Add("Authorization",
                                    "Basic " + Convert.ToBase64String(new System.Text.ASCIIEncoding().GetBytes(usernamePassword)));

                System.IO.Stream newStream = request.GetRequestStream();

                // Send the post data.
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                response = request.GetResponse();
                stream = response.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(stream);

                // Get data in text plain
                resultData = sr.ReadToEnd();
                stream.Close();
                stream.Dispose();
                response.Close();
                this.lblResults.Text += FormatResultXML(resultData);
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Response != null)
                {
                    System.IO.Stream errorStream = ex.Response.GetResponseStream();
                    System.IO.StreamReader sr = new System.IO.StreamReader(errorStream);
                    string errordata = sr.ReadToEnd();
                    this.lblResults.Text += string.Format("Failure to get record by DealNo: {0}", errordata);
                }
                if (stream != null)
                {
                    stream.Dispose();
                }
                this.lblResults.Text += string.Format("Failure to get data from Pip-Extract service '{0}': {1}", queryId, ex.Message);
            }
            catch (Exception ex)
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
                this.lblResults.Text += string.Format("Failure to get data from Pip-Extract service: '{0}': {1}", queryId, ex.Message);
            }
        }

        protected void butGetOneRO_Click(object sender, EventArgs e)
        {
            lblTitleResults.Text = "GET ONE RO";
            string dealerID = "3PAAMSCAN1";
            string queryId = "ClosedROHeader";
            string RONumbers = "183118";
            string postData = string.Format("dealerId={0}&queryId={1}&qparamRONumber={2}",
                dealerID.ToString(), queryId.ToString(),
                RONumbers.ToString());
            string resultData = string.Empty;
            System.Net.WebRequest request = null;
            System.Net.WebResponse response = null;
            System.IO.Stream stream = null;

            try
            {
                this.lblResults.Text = string.Empty;

                // Encode post data
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] data = encoding.GetBytes(postData);
                request = System.Net.HttpWebRequest.Create(extractRecordUrl);
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/x-www-form-urlencoded";

                System.Net.CredentialCache mycache = new System.Net.CredentialCache();
                mycache.Add(new Uri(extractRecordUrl), "Basic", new System.Net.NetworkCredential(username, password));
                request.Credentials = mycache;
                string usernamePassword = username + ":" + password;
                request.Headers.Add("Authorization",
                                    "Basic " + Convert.ToBase64String(new System.Text.ASCIIEncoding().GetBytes(usernamePassword)));

                System.IO.Stream newStream = request.GetRequestStream();

                // Send the post data.
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                response = request.GetResponse();
                stream = response.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(stream);

                // Get data in text plain
                resultData = sr.ReadToEnd();
                stream.Close();
                stream.Dispose();
                response.Close();
                this.lblResults.Text += FormatResultXML(resultData);
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Response != null)
                {
                    System.IO.Stream errorStream = ex.Response.GetResponseStream();
                    System.IO.StreamReader sr = new System.IO.StreamReader(errorStream);
                    string errordata = sr.ReadToEnd();
                    this.lblResults.Text += string.Format("Failure to get record by DealNo: {0}", errordata);
                }
                if (stream != null)
                {
                    stream.Dispose();
                }
                this.lblResults.Text += string.Format("Failure to get data from Pip-Extract service '{0}': {1}", queryId, ex.Message);
            }
            catch (Exception ex)
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
                this.lblResults.Text += string.Format("Failure to get data from Pip-Extract service: '{0}': {1}", queryId, ex.Message);
            }
        }

        protected void butGetManyROs_Click(object sender, EventArgs e)
        {
            lblTitleResults.Text = "GET MANY ROS";
            string dealerID = "3PAAMSCAN1";
            string queryId = "ClosedROHeader";
            string RONumbers = "183118””182774””183172";
            string postData = string.Format("dealerId={0}&queryId={1}&qparamRONumber={2}",
                dealerID.ToString(), queryId.ToString(),
                RONumbers.ToString());
            string resultData = string.Empty;
            System.Net.WebRequest request = null;
            System.Net.WebResponse response = null;
            System.IO.Stream stream = null;

            try
            {
                this.lblResults.Text = string.Empty;

                // Encode post data
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] data = encoding.GetBytes(postData);
                request = System.Net.HttpWebRequest.Create(extractRecordUrl);
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/x-www-form-urlencoded";

                System.Net.CredentialCache mycache = new System.Net.CredentialCache();
                mycache.Add(new Uri(extractRecordUrl), "Basic", new System.Net.NetworkCredential(username, password));
                request.Credentials = mycache;
                string usernamePassword = username + ":" + password;
                request.Headers.Add("Authorization",
                                    "Basic " + Convert.ToBase64String(new System.Text.ASCIIEncoding().GetBytes(usernamePassword)));

                System.IO.Stream newStream = request.GetRequestStream();

                // Send the post data.
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                response = request.GetResponse();
                stream = response.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(stream);

                // Get data in text plain
                resultData = sr.ReadToEnd();
                stream.Close();
                stream.Dispose();
                response.Close();
                this.lblResults.Text += FormatResultXML(resultData);
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Response != null)
                {
                    System.IO.Stream errorStream = ex.Response.GetResponseStream();
                    System.IO.StreamReader sr = new System.IO.StreamReader(errorStream);
                    string errordata = sr.ReadToEnd();
                    this.lblResults.Text += string.Format("Failure to get record by DealNo: {0}", errordata);
                }
                if (stream != null)
                {
                    stream.Dispose();
                }
                this.lblResults.Text += string.Format("Failure to get data from Pip-Extract service '{0}': {1}", queryId, ex.Message);
            }
            catch (Exception ex)
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
                this.lblResults.Text += string.Format("Failure to get data from Pip-Extract service: '{0}': {1}", queryId, ex.Message);
            }
        }

        private string FormatResultXML(string resultDataIni)
        {
            string formatXML = string.Empty;
            bool opentag = false;
            string resultData = string.Empty;
            for (int counter = 0; counter < resultDataIni.Length; counter++)
            {
                if (resultDataIni[counter].Equals('<')) opentag = true;
                if (resultDataIni[counter].Equals('>')) opentag = false;
                resultData += (opentag ? resultDataIni[counter].ToString() : resultDataIni[counter].ToString().Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace(Environment.NewLine, ""));
            }

            int indent = 0;
            for (int counter = 0; counter < resultData.Length; counter++)
            {
                if (resultData[counter].Equals('<') && counter - 1 >= 0)
                {
                    if (resultData[counter - 1].Equals('>'))
                    {
                        if (counter + 1 < resultData.Length)
                            if (!(resultData[counter + 1].Equals('/')))
                                indent += 2;
                        formatXML += "</br>";
                        for (int subcounter = 0; subcounter < indent; subcounter++)
                            formatXML += "&nbsp;";
                    }
                }
                if (resultData[counter].Equals('<') && counter + 1 < resultData.Length)
                    if (resultData[counter + 1].Equals('/'))
                        indent -= 2;
                if (resultData[counter].Equals('/') && counter + 1 < resultData.Length)
                    if (resultData[counter + 1].Equals('>'))
                        indent -= 2;
                formatXML += HttpUtility.HtmlEncode(resultData[counter].ToString());
            }
            return formatXML;
        }

    }
}