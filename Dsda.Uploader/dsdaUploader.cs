using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using Dsda.DataAccess;
using Dsda.DataAccess.Objects;

namespace Dsda.Uploader
{
    public class dsdaUploader
    {
        private Logger _logger;
        private string extractRecordUrl = ConfigurationManager.AppSettings["ExtractRecordUrl"];
        private string _sourceDir;
        private string _destinationDir;
        public int _totalFiles = 0;
        public int _movedFiles = 0;
        public int _uploadedFiles = 0;
        public int _failureUpload = 0;
        public DsdaServiceReference.DsdaUploadClient _dsda = new DsdaServiceReference.DsdaUploadClient();
        public DsdaServiceReference.authenticationToken _authToken = new DsdaServiceReference.authenticationToken { username = ConfigurationManager.AppSettings["dsdaUser"], password = ConfigurationManager.AppSettings["dsdaPassword"] };

        public dsdaUploader(Logger logger, string sDir, string copyDir)
        {
            _logger = logger;
            _sourceDir = sDir;
            _destinationDir = copyDir;
        }

        public void ProcessMove()
        {
            var dir = new DirectoryInfo(_sourceDir);

            foreach (var dirInfo in dir.GetDirectories())
            {
                var dealerID = dirInfo.Name;
                _logger.InitDealerSessionLog(dealerID);

                ProcessMove(dirInfo.FullName, Path.Combine(_destinationDir, dirInfo.Name), dealerID);

                _logger.SaveStatistics(_totalFiles, _uploadedFiles, _movedFiles, _failureUpload);
                _totalFiles = 0;
                _uploadedFiles = 0;
                _movedFiles = 0;
                _failureUpload = 0;

                try
                {
                    dirInfo.Delete();
                }
                catch { }

            }
        }

        private void ProcessMove(string sDir, string copyDir, string dealerID)
        {

            foreach (string dir in Directory.GetDirectories(sDir))
            {
                try
                {
                    string copyPath = Path.Combine(copyDir, Path.GetFileName(dir));

                    if (!Directory.Exists(copyPath))
                        Directory.CreateDirectory(copyPath);

                    foreach (string f in Directory.GetFiles(dir))
                    {
                        _totalFiles++;
                        try
                        {
                            _logger.Debug(string.Format("Start processing file {0}", f));
                            _logger.InitProcessingDoc(dir, Path.GetFileNameWithoutExtension(f));

                            if (FillAndSend(f, dealerID))
                            {
                                var destination = Path.Combine(copyPath, Path.GetFileName(f));

                                if (File.Exists(destination))
                                {
                                    File.Delete(destination);
                                }

                                File.Move(f, destination);
                                _movedFiles++;
                                _logger.ProcessingDoc.DocFolder = copyPath;
                                _logger.ProcessingDoc.IsProcessed = true;
                                _logger.Info(string.Format("File {0} moved to {1}", f, copyPath + @"\" + Path.GetFileName(f)));
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(string.Format("File processing Exception : {0}", ex.Message));
                        }
                        _logger.SaveStatistics(_totalFiles, _uploadedFiles, _movedFiles, _failureUpload);
                    }

                    ProcessMove(dir, copyPath, dealerID);

                    try
                    {
                        if (Directory.GetFiles(dir).Length == 0 && Directory.GetDirectories(dir).Length == 0)
                            Directory.Delete(dir);
                    }
                    catch (Exception /*ex*/)
                    {
                        //_logger.Debug(string.Format("Delete directory exception : {0} Directory: '{1}'", ex.Message, dir));
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Directory processing exception : {0} Directory: '{1}'", ex.Message, dir));
                }
            }
        }

        public bool FillAndSend(string filePath, string dealerID)
        {
            var dealID = Path.GetFileNameWithoutExtension(filePath);
            //string dealer = Path.GetFileName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(filePath)))));
            string folder = Path.GetFileName(Path.GetDirectoryName(Path.GetDirectoryName(filePath)));
            string cab = Path.GetFileName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(filePath))));
            string ext = Path.GetExtension(filePath);
            long fileSize = new FileInfo(filePath).Length;
            string docDate = DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            _logger.ProcessingDoc.CabId = cab;
            _logger.ProcessingDoc.DocDate = docDate;
            _logger.ProcessingDoc.DocType = ext;

            string docDescr = GetDescription(dealID, dealerID);

            var dealerId = new DsdaServiceReference.dealerId { dealerId1 = dealerID };
            var fileMetaData = new DsdaServiceReference.dsdaFileMetaData
            {
                annotation = "0",
                cabid = cab,
                docdate = docDate,
                docdesc = docDescr.Replace("\"", "").Replace("'", "").Replace("|", "").Replace("&", ""),
                docid = "D" + dealID,
                docsstype = ext,
                foldesc = folder,
                folid = folder,
                fileSize = fileSize,
                docflags = "",
                folflags = "",
                fileSizeSpecified = true
            };

            _logger.Debug(string.Format("Prepared FileMetaData[ annotation: \"{0}\", cabid: \"{1}\", docdate: \"{2}\", docdesc: \"{3}\", docid: \"{4}\", docsstype: \"{5}\", foldesc: \"{6}\", folid: \"{7}\", fileSize: \"{8}\", docflags: \"{9}\", folflags: \"{10}\", fileSizeSpecified: \"{11}\"]"
                                        , fileMetaData.annotation, fileMetaData.cabid, fileMetaData.docdate, fileMetaData.docdesc, fileMetaData.docid, fileMetaData.docsstype, fileMetaData.foldesc, fileMetaData.folid, fileMetaData.fileSize, fileMetaData.docflags, fileMetaData.folflags, fileMetaData.fileSizeSpecified));

            byte[] arr = File.ReadAllBytes(filePath);
            try
            {
                if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["DisableUpload"])
                    || ConfigurationManager.AppSettings["DisableUpload"] != "true")
                {
                    var replay = _dsda.DsdaUpload(_authToken, dealerId, fileMetaData, arr);
                    if (replay.status.status1 == DsdaServiceReference.resultCode.failure)
                    {
                        _failureUpload++;
                        _logger.Error(string.Format("Failure upload ({0}). Error Code ({1}), Error ({2})",
                                                    filePath.Replace(_sourceDir, string.Empty), replay.status.errorCode,
                                                    replay.status.message));
                        return false;
                    }
                }
                _uploadedFiles++;
                return true;
            }
            catch (Exception)
            {
                _failureUpload++;
                _logger.Error(string.Format("Failure upload ({0}), deal ID ({1})", filePath.Replace(_sourceDir, string.Empty), dealID));
                throw;
            }
        }

        public string GetDescription(string dealNo, string dialerID)
        {
            string postData = string.Format("dealerId={0}&queryId=FISC_ByItem&qparamDealNo={1}", dialerID, dealNo);
            string resultData = "";
            WebRequest request = null;
            WebResponse response = null;
            Stream stream = null;
            try
            {
                //encode post data
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(postData);
                request = HttpWebRequest.Create(extractRecordUrl);
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/x-www-form-urlencoded";

                string username = ConfigurationManager.AppSettings["dsdaUser"];
                string password = ConfigurationManager.AppSettings["dsdaPassword"];

                CredentialCache mycache = new CredentialCache();
                mycache.Add(new Uri(extractRecordUrl), "Basic", new NetworkCredential(username, password));
                request.Credentials = mycache;
                string usernamePassword = username + ":" + password;
                request.Headers.Add("Authorization",
                                    "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword)));

                Stream newStream = request.GetRequestStream();
                // Send the post data.
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                response = request.GetResponse();
                stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                resultData = sr.ReadToEnd();
                stream.Close();
                stream.Dispose();
                response.Close();
                _logger.Debug(string.Format("Pip-Extract service request: {0}", extractRecordUrl + "?" + postData));
                _logger.Debug(string.Format("Pip-Extract service response: {0}", resultData));
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Response != null)
                {
                    Stream errorStream = ex.Response.GetResponseStream();
                    StreamReader sr = new StreamReader(errorStream);
                    string errordata = sr.ReadToEnd();
                    _logger.Debug(string.Format("Failure to get record by DealNo: {0}", errordata));
                    throw new Exception(string.Format("Failure to get record by DealNo: {0}", errordata));
                }
                if (stream != null)
                {
                    stream.Dispose();
                }

                throw new Exception(string.Format("Failure to get data from Pip-Extract service: {0}", ex.Message));
            }
            catch (Exception ex)
            {
                if (stream != null)
                {
                    stream.Dispose();
                }

                throw new Exception(string.Format("Failure to get data from Pip-Extract service: {0}", ex.Message));
            }
            ////resultData =
            ////            "<VehicleSales xmlns=\"http://www.dmotorworks.com/pip-extract-fisales\">" + "\n" +
            ////            "  <VehicleSale>" + "\n" +
            ////            "    <ContractDate>2003-04-09</ContractDate>" + "\n" +
            ////            "    <CustNo>27048</CustNo>" + "\n" +
            ////            "    <DealNo>27048</DealNo>" + "\n" +
            ////            "    <Name>CYPHER,CRAIG/BOBBI JO</Name>" + "\n" +
            ////            "    <StockNo>P3849A</StockNo>" + "\n" +
            ////            "    <VIN>1J4GZ58Y0VC567126</VIN>" + "\n" +
            ////            "  </VehicleSale>" + "\n" +
            ////            "  <ErrorCode>0</ErrorCode>" + "\n" +
            ////            "  <ErrorMessage/>" + "\n" +
            ////            "</VehicleSales>" + "\n";

            string description = "";

            if (!string.IsNullOrWhiteSpace(resultData))
                description = ParseExtractServiceResponse(resultData, dealNo);

            _logger.Debug(string.Format("Formatted description: {0}", description));

            return description;
        }

        private string ParseExtractServiceResponse(string resultXml, string dealNo)
        {
            string description = string.Empty;
            //string errorCode = string.Empty;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(resultXml);

                description = AddDescrItem(description, xmlDoc, "ContractDate");
                description = AddDescrItem(description, xmlDoc, "CustNo");
                description = AddDescrItem(description, xmlDoc, "Name");
                description = AddDescrItem(description, xmlDoc, "StockNo");
                description = AddDescrItem(description, xmlDoc, "VIN");
                description += ((!string.IsNullOrWhiteSpace(description)) ? " " : "") + "" + dealNo.Replace("\"", "").Replace("'", "").Replace("|", "").Replace("&", "");

                if (string.IsNullOrWhiteSpace(dealNo.Replace("\"", "").Replace("'", "").Replace("|", "").Replace("&", "")))
                    throw new Exception("Deal is required");
            }
            catch (Exception ex)
            {
                _logger.Debug(string.Format("Can't parse response from pip-extract service: '{0}'", ex.Message));
                description = "";
            }

            if (string.IsNullOrWhiteSpace(description.Trim())/* && errorCode.Trim() == "0"*/)
            {
                _failureUpload++;
                throw new Exception(string.Format("PIP Sales Extract data not available or incomplete for {0}", dealNo));
            }

            return description;
        }

        private string AddDescrItem(string descr, XmlDocument xmlDoc, string nodeName)
        {
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(nodeName);

            if (nodeList.Count > 0)
            {
                string value = nodeList[0].InnerText;
                if (string.IsNullOrWhiteSpace(value))
                    return descr; // if any of values not exist - the original description is returned

                switch (nodeName)
                {
                    case "ContractDate":
                        try
                        {
                            DateTime dt = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            var newValue = dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                            _logger.ProcessingDoc.ContractDate = newValue;
                            value = newValue;
                            value = "" + value;
                        }
                        catch (Exception ex) { throw ex; }
                        break;
                    case "CustNo":
                        _logger.ProcessingDoc.CustNo = value;
                        value = "" + value;
                        break;
                    //case "Name":
                    //    _logger.ProcessingDoc.CustName = value;
                    //    value = "" + value;
                    //    break;
                    case "StockNo":
                        _logger.ProcessingDoc.Stock = value;
                        value = "" + value;
                        break;
                    case "VIN":
                        _logger.ProcessingDoc.Vin = value;
                        value = "" + value;
                        break;
                    default:
                        return descr;
                }

                return descr += ((!string.IsNullOrWhiteSpace(descr)) ? " " : "") + value.Replace("\"", "").Replace("'", "").Replace("|", "").Replace("&", "");
            }

            return descr; // if any of values not exist - the original description is returned
        }
    }
}
