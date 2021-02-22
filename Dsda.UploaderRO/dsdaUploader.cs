using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using Dsda.DataAccessRO;
using Dsda.DataAccessRO.Objects;

namespace Dsda.UploaderRO
{
    public class dsdaUploader
    {
        private Logger _logger;
        private string extractRecordUrl = ConfigurationManager.AppSettings["ExtractRecordUrl"];
        private string _sourceDir;
        private string _destinationDir;
        public int _totalFilesAllDealers = 0;
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
            _totalFilesAllDealers = 0;

            var dir = new DirectoryInfo(_sourceDir);
            foreach (var dirInfo in dir.GetDirectories())
            {
                var dealerID = dirInfo.Name;
                _logger.InitDealerSessionLog(dealerID);

                ProcessMove(dirInfo.FullName, Path.Combine(_destinationDir, dirInfo.Name), dealerID);

                _totalFilesAllDealers += _totalFiles;
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

            if (_totalFilesAllDealers == 0)
                _logger.Debug("No files to upload.");

        }

        private void ProcessMove(string sDir, string copyDir, string dealerID)
        {

            foreach (string dir in Directory.GetDirectories(sDir))
            {
                try
                {
                    string copyPath = Path.Combine(copyDir, Path.GetFileName(dir));
                    foreach (string f in Directory.GetFiles(dir))
                    {
                        _totalFiles++;
                        try
                        {
                            _logger.Debug(string.Format("Start processing file {0}", f));
                            _logger.InitProcessingDoc(dir, Path.GetFileNameWithoutExtension(f));

                            if (FillAndSend(f, dealerID))
                            {
                                string orig_filenamewithoutext = Path.GetFileNameWithoutExtension(f);
                                string orig_extension = Path.GetExtension(f);
                                string destination = Path.Combine(copyPath, orig_filenamewithoutext  + orig_extension);
                                if (File.Exists(destination))
                                {
                                    int copynumber = 1;
                                    bool newfile = false;
                                    while (!newfile)
                                    {
                                        destination = Path.Combine(copyPath, orig_filenamewithoutext + "_" + copynumber.ToString() + orig_extension);
                                        if (!File.Exists(destination))
                                            newfile = true;
                                        else
                                            copynumber++;
                                    }
                                }
                                if (!Directory.Exists(copyPath))
                                    Directory.CreateDirectory(copyPath);
                                File.Move(f, destination);
                                _movedFiles++;
                                _logger.ProcessingDoc.DocFolder = copyPath;
                                _logger.ProcessingDoc.IsProcessed = true;
                                _logger.Info(string.Format("File {0} moved to {1}", f, copyPath + @"\" + Path.GetFileName(destination)));
                            }
                        }
                        catch (Exception ex)
                        {
                            _failureUpload++;
                            _logger.Error(string.Format("File processing exception: {0}", ex.Message));
                        }
                    }

                    ProcessMove(dir, copyPath, dealerID);

                    try
                    {
                        if (Directory.GetFiles(dir).Length == 0 && Directory.GetDirectories(dir).Length == 0)
                            Directory.Delete(dir);
                    }
                    catch (Exception ex)
                    {
                        _logger.Debug(string.Format("Delete directory exception: {0} Directory: '{1}'", ex.Message, dir));
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Directory processing exception: {0} Directory: '{1}'", ex.Message, dir));
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

            List<string> lstDescr = GetDescriptionAndTagNames(dealID, dealerID);

            string docDescr = (lstDescr.Count >= 1) ? lstDescr[0] : string.Empty;
            string docTagNames = (lstDescr.Count >= 2) ? lstDescr[1] : string.Empty;

            var dealerId = new DsdaServiceReference.dealerId { dealerId1 = dealerID };
            var fileMetaData = new DsdaServiceReference.dsdaFileMetaData
            {
                annotation = "0",
                cabid = cab,
                docdate = docDate,
                docdesc = docDescr.Replace("\"", "").Replace("'", "").Replace("|", "").Replace("&", ""),
                tagNames = docTagNames.Replace("\"", "").Replace("'", "").Replace("|", "").Replace("&", ""),
                docid = "D" + dealID,
                docsstype = ext,
                foldesc = folder,
                folid = folder,
                fileSize = fileSize,
                docflags = "",
                folflags = "",
                fileSizeSpecified = true
            };

            _logger.Debug(string.Format("Prepared FileMetaData[ annotation: \"{0}\", cabid: \"{1}\", docdate: \"{2}\", docdesc: \"{3}\", tagNames: \"{4}\", docid: \"{5}\", docsstype: \"{6}\", foldesc: \"{7}\", folid: \"{8}\", fileSize: \"{9}\", docflags: \"{10}\", folflags: \"{11}\", fileSizeSpecified: \"{12}\"]",
                                        fileMetaData.annotation, fileMetaData.cabid, fileMetaData.docdate, fileMetaData.docdesc, fileMetaData.tagNames, fileMetaData.docid,
                                        fileMetaData.docsstype, fileMetaData.foldesc, fileMetaData.folid, fileMetaData.fileSize, fileMetaData.docflags, fileMetaData.folflags, fileMetaData.fileSizeSpecified));

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
                        _logger.Error(string.Format("Failure upload ({0}), deal ID ({1}), error code ({2}), error description ({3})",
                                                    filePath.Replace(_sourceDir, string.Empty), dealID, replay.status.errorCode,
                                                    replay.status.message));
                        return false;
                    }
                    _uploadedFiles++;
                }                
                return true;
            }
            catch (Exception ex)
            {
                _failureUpload++;
                _logger.Error(string.Format("Failure upload ({0}), deal ID ({1}), exception: {2}", filePath.Replace(_sourceDir, string.Empty), dealID, ex.Message));
                return false;
            }
        }

        public List<string> GetDescriptionAndTagNames(string dealNo, string dealerID)
        {
            // Query IDs
            // 1.- ClosedROHeader   https://uat-3pa.dmotorworks.com/pip-extract/servicesalesclosed/extract
            // 2.- SSC_ByItem_H     https://uat-3pa.dmotorworks.com/pip-extract/servicesalesclosedext/extract

            List<string> lstDescrTagNames = new List<string>();
            string postData = string.Format("dealerId={0}&queryId=SSC_ByItem_H&qparamRONumber={1}", dealerID, dealNo);
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
                _logger.Debug(string.Format("Pip-Extract service request for GetDescription: {0}", extractRecordUrl + "?" + postData));
                _logger.Debug(string.Format("Pip-Extract service response for GetDescription: {0}", resultData));
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Response != null)
                {
                    Stream errorStream = ex.Response.GetResponseStream();
                    StreamReader sr = new StreamReader(errorStream);
                    string errordata = sr.ReadToEnd();
                    _logger.Debug(string.Format("Failure to get record, deal ID ({0}), error data: {1}", dealNo, errordata));
                    throw new Exception(string.Format("Failure to get record, deal ID ({0}), error data: {1}", dealNo, errordata));
                }
                if (stream != null)
                {
                    stream.Dispose();
                }
                throw new Exception(string.Format("Failure to get data from Pip-Extract service, deal ID ({0}), exception: {1}", dealNo, ex.Message));
            }
            catch (Exception ex)
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
                throw new Exception(string.Format("Failure to get data from Pip-Extract service, deal ID ({0}), exception: {1}", dealNo, ex.Message));
            }

            //****** Result Data of Query ID 1
            //       <ServiceSales xmlns="http://www.dmotorworks.com/pip-extract-servicesales">
            //         <ServiceSalesClosed>
            //           <ErrorLevel>0</ErrorLevel>
            //           <ErrorMessage />
            //           <CloseDate>2009-04-16</CloseDate>
            //           <CustNo>23325</CustNo>
            //           <Name1 />
            //           <OpenDate>2009-04-15</OpenDate>
            //           <RONumber>156060</RONumber>
            //           <VehID>14244788</VehID>
            //           <VIN>1G4HP54K714244788</VIN>
            //         </ServiceSalesClosed>
            //         <ErrorCode>0</ErrorCode>
            //         <ErrorMessage/>
            //       </ServiceSales>

            //****** Result Data of Query ID 2
            //       <ServiceSalesClosed xmlns="http://www.dmotorworks.com/pip-extract-service-sales-closed">
            //         <ServiceSalesClosed>
            //           <ErrorLevel>0</ErrorLevel>
            //           <ErrorMessage />
            //           <Name1 />
            //           <OpenDate>2019-02-20</OpenDate>
            //           <RONumber>25001</RONumber>
            //           <CustNo>418601</CustNo>
            //           <CloseDate>2019-02-20</CloseDate>
            //           <VIN>1G2HX54KX14282282</VIN>
            //           <VehID>14282282</VehID>
            //         </ServiceSalesClosed>
            //         <ErrorCode>0</ErrorCode>
            //         <ErrorMessage/>
            //       </ServiceSalesClosed>

            // Get description
            string description = "";

            if (!string.IsNullOrWhiteSpace(resultData))
                description = ParseExtractServiceResponseDescr(resultData, dealNo);

            _logger.Debug(string.Format("Formatted description for deal ID ({0}): {1}", dealNo, description));

            lstDescrTagNames.Add(description);

            // Get tag names
            string tagNames = "";

            if (!string.IsNullOrWhiteSpace(resultData))
                tagNames = ParseExtractServiceResponseTagNames(resultData, dealNo);
            if (!string.IsNullOrWhiteSpace(tagNames))
                _logger.ProcessingDoc.TagNames = tagNames;

            _logger.Debug(string.Format("Formatted tag names for deal ID ({0}): {1}", dealNo, tagNames));

            lstDescrTagNames.Add(tagNames);

            // Return description and tag names
            return lstDescrTagNames;
        }

        private string ParseExtractServiceResponseDescr(string resultXml, string dealNo)
        {
            string description = string.Empty;
            //string errorCode = string.Empty;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(resultXml);

                description = AddDescrItem(description, xmlDoc, "OpenDate");
                description = AddDescrItem(description, xmlDoc, "CloseDate");
                description = AddDescrItem(description, xmlDoc, "ContractDate");
                description = AddDescrItem(description, xmlDoc, "CustNo");
                description = AddDescrItem(description, xmlDoc, "Name1");
                description = AddDescrItem(description, xmlDoc, "Name");
                description = AddDescrItem(description, xmlDoc, "StockNo");
                description = AddDescrItem(description, xmlDoc, "VIN");
                description = AddDescrItem(description, xmlDoc, "VehID");
                description = AddDescrItem(description, xmlDoc, "RONumber");
                //description += ((!string.IsNullOrWhiteSpace(description)) ? " " : "") + "REFNO_" + dealNo.Replace("\"", "").Replace("'", "").Replace("|", "").Replace("&", "");

                //if (string.IsNullOrWhiteSpace(dealNo.Replace("\"", "").Replace("'", "").Replace("|", "").Replace("&", "")))
                //    throw new Exception("Deal is required");
            }
            catch (Exception ex)
            {
                _logger.Debug(string.Format("Can't parse description response from pip-extract service, deal ID ({0}): '{1}'", dealNo, ex.Message));
                description = "";
            }

            if (string.IsNullOrWhiteSpace(description.Trim())/* && errorCode.Trim() == "0"*/)
            {
                throw new Exception(string.Format("PIP Sales Extract data not available or incomplete, deal ID ({0})", dealNo));
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
                    case "OpenDate":
                        try
                        {
                            DateTime dt = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            var newValue = dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                            _logger.ProcessingDoc.OpenDate = newValue;
                            value = newValue;
                            value = "DATE_" + value;
                        }
                        catch (Exception ex) { throw ex; }
                        break;

                    case "CloseDate":
                        try
                        {
                            DateTime dt = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            var newValue = dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                            _logger.ProcessingDoc.CloseDate = newValue;
                            value = newValue;
                            value = "CLSDATE_" + value;
                        }
                        catch (Exception ex) { throw ex; }
                        break;
                    case "ContractDate":
                        try
                        {
                            DateTime dt = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            var newValue = dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                            _logger.ProcessingDoc.ContractDate = newValue;
                            value = newValue;
                            value = "CONDATE_" + value;
                        }
                        catch (Exception ex) { throw ex; }
                        break;
                    case "CustNo":
                        _logger.ProcessingDoc.CustNo = value;
                        value = "CNUM_" + value;
                        break;
                    case "Name1":
                        _logger.ProcessingDoc.Name1 = value;
                        value = "CNAME_" + value.Replace(" ", "_");
                        break;
                    case "Name":
                        _logger.ProcessingDoc.Name1 = value;
                        value = "CNAME_" + value.Replace(" ", "_");
                        break;
                    case "StockNo":
                        _logger.ProcessingDoc.Stock = value;
                        value = "STKNO_" + value;
                        break;
                    case "VIN":
                        _logger.ProcessingDoc.Vin = value;
                        value = "VIN_" + value;
                        break;
                    case "VehID":
                        _logger.ProcessingDoc.VehID = value;
                        value = "VEHID_" + value;
                        break;
                    case "RONumber":
                        value = "REFNO_" + value;
                        break;
                    default:
                        return descr;
                }

                return descr += ((!string.IsNullOrWhiteSpace(descr)) ? " " : "") + value.Replace("\"", "").Replace("'", "").Replace("|", "").Replace("&", "");
            }

            return descr; // if any of values not exist - the original description is returned
        }

        private string ParseExtractServiceResponseTagNames(string resultXml, string dealNo)
        {
            string tagNames = string.Empty;
            //string errorCode = string.Empty;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(resultXml);

                tagNames = AddTagNameItem(tagNames, xmlDoc, "OpenDate");
                tagNames = AddTagNameItem(tagNames, xmlDoc, "CloseDate");
                tagNames = AddTagNameItem(tagNames, xmlDoc, "ContractDate");
                tagNames = AddTagNameItem(tagNames, xmlDoc, "CustNo");
                tagNames = AddTagNameItem(tagNames, xmlDoc, "Name1");
                tagNames = AddTagNameItem(tagNames, xmlDoc, "Name");
                tagNames = AddTagNameItem(tagNames, xmlDoc, "StockNo");
                tagNames = AddTagNameItem(tagNames, xmlDoc, "VIN");
                tagNames = AddTagNameItem(tagNames, xmlDoc, "VehID");
                tagNames = AddTagNameItem(tagNames, xmlDoc, "RONumber");
                //tagNames += ((!string.IsNullOrWhiteSpace(tagNames)) ? "," : "") + "REFNO";

                //if (string.IsNullOrWhiteSpace(dealNo.Replace("\"", "").Replace("'", "").Replace("|", "").Replace("&", "")))
                //    throw new Exception("Deal is required");
            }
            catch (Exception ex)
            {
                _logger.Debug(string.Format("Can't parse tag names response from pip-extract service, deal ID ({0}): '{1}'", dealNo, ex.Message));
                tagNames = "";
            }

            if (string.IsNullOrWhiteSpace(tagNames.Trim())/* && errorCode.Trim() == "0"*/)
            {
                throw new Exception(string.Format("PIP Sales Extract data not available or incomplete, deal ID ({0})", dealNo));
            }

            return tagNames;
        }

        private string AddTagNameItem(string tagNames, XmlDocument xmlDoc, string nodeName)
        {
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(nodeName);

            if (nodeList.Count > 0)
            {
                string value = nodeList[0].InnerText;
                if (string.IsNullOrWhiteSpace(value))
                    return tagNames; // if any of values not exist - the original tag names are returned

                switch (nodeName)
                {
                    case "OpenDate":
                        try
                        {
                            DateTime dt = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            var newValue = dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                            value = newValue;
                            value = "DATE";
                        }
                        catch (Exception ex) { throw ex; }
                        break;
                    case "CloseDate":
                        try
                        {
                            DateTime dt = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            var newValue = dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                            value = newValue;
                            value = "CLSDATE";
                        }
                        catch (Exception ex) { throw ex; }
                        break;
                    case "ContractDate":
                        try
                        {
                            DateTime dt = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            var newValue = dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                            value = newValue;
                            value = "CONDATE";
                        }
                        catch (Exception ex) { throw ex; }
                        break;
                    case "CustNo":
                        value = "CNUM";
                        break;
                    case "Name1":
                        value = "CNAME";
                        break;
                    case "Name":
                        value = "CNAME";
                        break;
                    case "StockNo":
                        value = "STKNO";
                        break;
                    case "VIN":
                        value = "VIN";
                        break;
                    case "VehID":
                        value = "VEHID";
                        break;
                    case "RONumber":
                        value = "REFNO";
                        break;
                    default:
                        return tagNames;
                }

                return tagNames += ((!string.IsNullOrWhiteSpace(tagNames)) ? "," : "") + value;
            }

            return tagNames; // if any of values not exist - the original tag names are returned
        }

    }
}
