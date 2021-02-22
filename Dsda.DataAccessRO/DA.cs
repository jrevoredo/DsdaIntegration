using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Dsda.DataAccessRO.DataContracts;
using Dsda.DataAccessRO.Objects;

namespace Dsda.DataAccessRO
{
    public enum enMessageType
    {
        INFO = 0,
        ERROR = 1,
        DEBUG = 2
    }

    public class DA
    {
        private DataClassesDataContext context =
            new DataClassesDataContext(
                ConfigurationManager.ConnectionStrings["DsdaIntegrationROConnectionString"].ConnectionString);

        public GridData GetDealerIds()
        {
            GridData data = new GridData();

            data.rows = context.tblUploadSessions
                .Select(s => s.DealerId)
                .Distinct()
                .Select(d => new GridDataRow()
                {
                    id = d,
                    cell = new object[]
                    {
                        d
                    }
                }).ToArray();

            return data;
        }

        public GridData GetDealersPaged(int page, int rowsPerPage, DateTime dateFrom, DateTime dateTo, string dealer)
        {
            GridData data = new GridData();
            var query = context.tblUploadSessions.AsQueryable();

            if (dateFrom != DateTime.MinValue && dateTo != DateTime.MinValue)
            {
                dateFrom = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day);
                dateTo = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day).AddDays(1).AddMilliseconds(-1);
                query = query.Where(w => w.DateCreated >= dateFrom && w.DateCreated <= dateTo);
            }

            if (!string.IsNullOrWhiteSpace(dealer))
            {
                query = query.Where(w => string.Equals(dealer, w.DealerId));
            }

            var totalCount = query.Select(s => s.DealerId).Distinct().Count();
            data.total = totalCount / rowsPerPage + (totalCount % rowsPerPage > 0 ? 1 : 0);

            data.rows = query
                .GroupBy(item => new { item.DealerId })
                .Select(g => new GridDataRow()
                {
                    id = g.Key.DealerId,
                    cell = new object[]
                    {
                        g.Key.DealerId,
                        g.Sum(item => item.TotalFilesCount),
                        g.Sum(item => item.FailedFilesCount)
                    }
                })
                .OrderBy(r => r.id)
                .Skip((page - 1) * rowsPerPage).Take(rowsPerPage).ToArray();

            data.records = data.rows.Count();

            return data;
        }

        public GridData GetUploadSessionsPaged(int page, int rowsPerPage, DateTime dateFrom, DateTime dateTo, string dealer)
        {
            GridData data = new GridData();
            var query = context.tblUploadSessions.AsQueryable();

            if (dateFrom != DateTime.MinValue && dateTo != DateTime.MinValue)
            {
                dateFrom = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day);
                dateTo = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day).AddDays(1).AddMilliseconds(-1);
                query = query.Where(w => w.DateCreated >= dateFrom && w.DateCreated <= dateTo);
            }

            if (!string.IsNullOrWhiteSpace(dealer))
            {
                query = query.Where(w => string.Equals(dealer, w.DealerId));
            }

            var totalCount = query.Count();
            data.records = totalCount;
            data.total = totalCount / rowsPerPage + (totalCount % rowsPerPage > 0 ? 1 : 0);

            data.rows = query
                .OrderByDescending(order => order.DateCreated)
                .Skip((page - 1) * rowsPerPage)
                .Take(rowsPerPage)
                .Select(s => new GridDataRow
                {
                    id = s.UploadSessionId.ToString(),
                    cell = new object[]
                            {
                                s.UploadSessionId,
                                s.DateCreated,
                                s.TotalFilesCount,
                                s.UploadedFilesCount,
                                s.MovedFilesCount,
                                s.FailedFilesCount,
                                s.Notes,
                                0, 0, 0, 0
                            }
                })
                .ToArray();

            if (data.rows.Length > 0)
            {
                var totals = query
                    .GroupBy(item => "TotalRow")
                    .Select(g => new object[]
                        {
                            g.Sum(item => item.TotalFilesCount),
                            g.Sum(item => item.UploadedFilesCount),
                            g.Sum(item => item.MovedFilesCount),
                            g.Sum(item => item.FailedFilesCount)
                        }).FirstOrDefault();

                if (totals != null)
                {
                    data.rows[0].cell[7] = totals[0];
                    data.rows[0].cell[8] = totals[1];
                    data.rows[0].cell[9] = totals[2];
                    data.rows[0].cell[10] = totals[3];
                }
            }

            return data;
        }

        public GridData GetUploadSessionDetailsPaged(int page, int rowsPerPage, int uploadSessionId)
        {
            GridData data = new GridData();
            var totalCount = context.tblUploadSessionDetails.Count(w => w.UploadSessionId == uploadSessionId);
            data.total = totalCount / rowsPerPage + (totalCount % rowsPerPage > 0 ? 1 : 0);
            data.rows = context.tblUploadSessionDetails.OrderByDescending(order => order.UploadSessionDetailId)
                .OrderByDescending(order => order.MessageType)
                .ThenByDescending(order => order.UploadSessionDetailId)
                .Where(w => w.UploadSessionId == uploadSessionId)
                .Skip((page - 1) * rowsPerPage).Take(rowsPerPage)
                .Select(s => new GridDataRow
                {
                    id = s.UploadSessionDetailId.ToString(),
                    cell = new object[]
                                                {
                                                    s.UploadSessionDetailId,
                                                    s.MessageType,
                                                    s.Message
                                                }
                })
                .ToArray();
            data.records = data.rows.Count();

            return data;
        }

        public GridData GetUploadSessionDetails(int uploadSessionId)
        {
            GridData data = new GridData();
            var totalCount = context.tblUploadSessionDetails.Count(w => w.UploadSessionId == uploadSessionId);
            data.rows = context.tblUploadSessionDetails.OrderByDescending(order => order.UploadSessionDetailId)
                .OrderByDescending(order => order.MessageType)
                .ThenByDescending(order => order.UploadSessionDetailId)
                .Where(w => w.UploadSessionId == uploadSessionId)
                .Select(s => new GridDataRow
                {
                    id = s.UploadSessionDetailId.ToString(),
                    cell = new object[]
                                                {
                                                    s.UploadSessionDetailId,
                                                    s.MessageType,
                                                    s.Message
                                                }
                })
                .ToArray();
            data.records = data.rows.Count();

            return data;
        }

        public int UpdateUploadSessionRecord(int id, int totalFiles, int uploadedFiles, int movedFiles, int filedFiles, string dealerId)
        {
            tblUploadSession record;

            if (id == 0)
            {
                record = new tblUploadSession();
                record.DateCreated = DateTime.Now;
                record.TotalFilesCount = 0;
                record.UploadedFilesCount = 0;
                record.MovedFilesCount = 0;
                record.FailedFilesCount = 0;
                record.DealerId = dealerId;

                context.tblUploadSessions.InsertOnSubmit(record);
            }
            else
            {
                record = context.tblUploadSessions.FirstOrDefault(w => w.UploadSessionId == id);

                if (record != null)
                {
                    record.TotalFilesCount = totalFiles;
                    record.UploadedFilesCount = uploadedFiles;
                    record.MovedFilesCount = movedFiles;
                    record.FailedFilesCount = filedFiles;
                    record.DealerId = dealerId;
                }
            }

            context.SubmitChanges();

            return record.UploadSessionId;
        }

        public void UpdateUploadSessionNotes(int id, string notes)
        {
            tblUploadSession record;

            record = context.tblUploadSessions.FirstOrDefault(w => w.UploadSessionId == id);

            if (record != null)
            {
                record.Notes = notes;
            }

            context.SubmitChanges();
        }

        public void CreateUploadSessionDetailRecord(int sessionId, enMessageType type, string message)
        {
            tblUploadSessionDetail record = new tblUploadSessionDetail();
            record.UploadSessionId = sessionId;
            record.MessageType = (int)type;
            record.Message = message;

            context.tblUploadSessionDetails.InsertOnSubmit(record);
            context.SubmitChanges();
        }

        public void UpdateDocumentProcessingInfo(int sessionId, DocInfo doc)
        {
            tblDocumentProcessing record = new tblDocumentProcessing();

            if (doc.DocInfoId == 0)
            {
                record.UploadSessionId = sessionId;
                record.ProcessingDate = doc.ProcessingDate;
                record.SourceDir = doc.SourceDir;
                record.Name = doc.Name;
                record.DealerId = doc.DealerId;
                context.tblDocumentProcessings.InsertOnSubmit(record);
            }
            else
            {
                record = context.tblDocumentProcessings.FirstOrDefault(w => w.DocumentProcessingId == doc.DocInfoId);

                if (record != null)
                {
                    record.TagNames = doc.TagNames;
                    record.OpenDate = doc.OpenDate;
                    record.CloseDate = doc.CloseDate;
                    record.ContractDate = doc.ContractDate;
                    record.CustNo = doc.CustNo;
                    record.Name1 = doc.Name1;
                    record.Stock = doc.Stock;
                    record.Vin = doc.Vin;
                    record.VehID = doc.VehID;
                    record.DealId = doc.DealId;
                    record.CabId = doc.CabId;
                    record.DocDate = doc.DocDate;
                    record.DocType = doc.DocType;
                    record.DocFolder = doc.DocFolder;
                    record.IsProcessed = doc.IsProcessed;
                    record.ProcessedErrors = doc.ProcessedErrors;
                }
            }

            context.SubmitChanges();
            doc.DocInfoId = record.DocumentProcessingId;
        }

        public List<DocInfo> GetDocumentProcessingLog(int sessionId)
        {
            return context.tblDocumentProcessings
                .Where(w => w.UploadSessionId == sessionId)
                .Select(s => new DocInfo(s.SourceDir, s.Name, s.DealerId)
                {
                    ProcessingDate = s.ProcessingDate,
                    TagNames = s.TagNames,
                    OpenDate = s.OpenDate,
                    CloseDate = s.CloseDate,
                    ContractDate = s.ContractDate,
                    CustNo = s.CustNo,
                    Name1 = s.Name1,
                    Stock = s.Stock,
                    Vin = s.Vin,
                    VehID = s.VehID,
                    DealId = s.DealId,
                    CabId = s.CabId,
                    DocDate = s.DocDate,
                    DocType = s.DocType,
                    DocFolder = s.DocFolder,
                    IsProcessed = s.IsProcessed.HasValue ? s.IsProcessed.Value : false,
                    ProcessedErrors = s.ProcessedErrors
                }).ToList();
        }
    }
}
