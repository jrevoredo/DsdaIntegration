using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using Dsda.DataAccess;
using Dsda.DataAccess.Objects;
using log4net;

namespace Dsda.Uploader
{
    public enum enLogLevel
    {
        Info = 1,
        Debug = 2,
        Error = 3
    }

    public class Logger
    {
        private DA _da;
        private int _sessionId;
        private ILog _log = LogManager.GetLogger("mainLogger");
        private List<LogItem> sessionLog = new List<LogItem>();
        private string _dealerId;

        public DocInfo ProcessingDoc { get; set; }

        public Logger(DA da)
        {
            _da = da;
        }

        public void InitProcessingDoc(string sourceDir, string name)
        {
            ProcessingDoc = new DocInfo(sourceDir, name, _dealerId);
            _da.UpdateDocumentProcessingInfo(_sessionId, ProcessingDoc);
        }

        public void InitDealerSessionLog(string dialerId)
        {
            _dealerId = dialerId;
            _sessionId = _da.UpdateUploadSessionRecord(0, 0, 0, 0, 0, _dealerId);
            Debug(string.Format("Start processing files for Dealer ID '{0}'", _dealerId));
        }

        public void Info(string message)
        {
            _log.Info(message);
            sessionLog.Add(new LogItem(DateTime.Now, enLogLevel.Info, message));
            _da.CreateUploadSessionDetailRecord(_sessionId, enMessageType.INFO, message);
            if (ProcessingDoc != null && ProcessingDoc.DocInfoId > 0)
                _da.UpdateDocumentProcessingInfo(_sessionId, ProcessingDoc);
        }

        public void Info(string message, Exception ex)
        {
            _log.Info(message, ex);
            sessionLog.Add(new LogItem(DateTime.Now, enLogLevel.Info
                            ,string.Format("{0}{1}Exception: {2}{3}{4}", message, Environment.NewLine, ex.Message, Environment.NewLine, ex.StackTrace )));
            _da.CreateUploadSessionDetailRecord(_sessionId, enMessageType.ERROR, message);

            if (ProcessingDoc != null && ProcessingDoc.DocInfoId > 0)
                _da.UpdateDocumentProcessingInfo(_sessionId, ProcessingDoc);
        }

        public void Debug(string message)
        {
            _log.Debug(message);
            sessionLog.Add(new LogItem(DateTime.Now, enLogLevel.Debug, message));
            //_da.CreateUploadSessionDetailRecord(_sessionId, enMessageType.DEBUG, message);

            if (ProcessingDoc != null && ProcessingDoc.DocInfoId > 0)
                _da.UpdateDocumentProcessingInfo(_sessionId, ProcessingDoc);
        }

        public void Debug(string message, Exception ex)
        {
            _log.Debug(message, ex);
            sessionLog.Add(new LogItem(DateTime.Now, enLogLevel.Debug
                , string.Format("{0}{1}Exception: {2}{3}{4}", message, Environment.NewLine, ex.Message, Environment.NewLine, ex.StackTrace)));
            //_da.CreateUploadSessionDetailRecord(_sessionId, enMessageType.DEBUG, message);

            if (ProcessingDoc != null && ProcessingDoc.DocInfoId > 0)
                _da.UpdateDocumentProcessingInfo(_sessionId, ProcessingDoc);
        }

        public void Error(string message)
        {
            _log.Error(message);
            sessionLog.Add(new LogItem(DateTime.Now, enLogLevel.Error, message));
            _da.CreateUploadSessionDetailRecord(_sessionId, enMessageType.ERROR, message);

            if (ProcessingDoc != null && ProcessingDoc.DocInfoId > 0)
            {
                if (!string.IsNullOrWhiteSpace(ProcessingDoc.ProcessedErrors))
                    ProcessingDoc.ProcessedErrors += Environment.NewLine;

                ProcessingDoc.ProcessedErrors += message;
                _da.UpdateDocumentProcessingInfo(_sessionId, ProcessingDoc);
            }

        }

        public void Error(string message, Exception ex)
        {
            _log.Error(message, ex);
            sessionLog.Add(new LogItem(DateTime.Now, enLogLevel.Error
                , string.Format("{0}{1}Exception: {2}{3}{4}", message, Environment.NewLine, ex.Message, Environment.NewLine, ex.StackTrace)));
            _da.CreateUploadSessionDetailRecord(_sessionId, enMessageType.ERROR, message);

            if (ProcessingDoc != null && ProcessingDoc.DocInfoId > 0)
            {
                if (!string.IsNullOrWhiteSpace(ProcessingDoc.ProcessedErrors))
                    ProcessingDoc.ProcessedErrors += Environment.NewLine;

                ProcessingDoc.ProcessedErrors += ex.Message;
                _da.UpdateDocumentProcessingInfo(_sessionId, ProcessingDoc);
            }

        }

        public void SaveStatistics(int totalFiles, int uploadedFiles, int movedFiles, int failuresFiles)
        {
            string msg = string.Format("Statistic for Dealer ID '{0}': total files ({1}), uploaded ({2}), moved ({3}), failures ({4})",
                                       _dealerId , totalFiles, uploadedFiles, movedFiles, failuresFiles);
            _log.Info(msg);
            sessionLog.Add(new LogItem(DateTime.Now, enLogLevel.Info, msg));

            _da.UpdateUploadSessionRecord(_sessionId, totalFiles, uploadedFiles, movedFiles, failuresFiles, _dealerId);
        }

        public string GetFullSessionLog(enLogLevel[] level, bool isShowLevel, bool isShowDate, bool isHtml)
        {
            StringBuilder sd = new StringBuilder();
            if (isHtml)
                sd.AppendLine("<html><body><table style='width:100%;'>");

            foreach (var logItem in sessionLog)
            {
                if (level.Contains(logItem.Level))
                {
                    string msg = string.Format("{0}{1}{2}",
                                               isShowDate
                                                   ? logItem.Date.ToString("yyyy-MM-dd HH.mm.ss ",
                                                                           CultureInfo.InvariantCulture)
                                                   : ""
                                               , isShowLevel
                                                     ? (logItem.Level == enLogLevel.Error
                                                            ? "ERROR: "
                                                            : logItem.Level == enLogLevel.Debug
                                                                  ? "DEBUG: "
                                                                  : "INFO: ")
                                                     : ""
                                               , logItem.Message);

                    if (isHtml)
                        msg = "<tr><td>" + msg + "</td></tr>";
                    sd.AppendLine(msg);
                }
            }

            if (isHtml)
                sd.AppendLine("</table></body></html>");
            return sd.ToString();
        }
    }

    public class LogItem
    {
        public LogItem (DateTime date, enLogLevel level, string message)
        {
            Date = date;
            Level = level;
            Message = message;
        }
        public DateTime Date;
        public enLogLevel Level;
        public string Message;
    }
}
