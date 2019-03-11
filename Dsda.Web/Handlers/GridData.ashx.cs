using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Web;
using System.Runtime.Serialization.Json;
using Dsda.DataAccess;


namespace Dsda.Web.Handlers
{
    /// <summary>
    /// Summary description for GridData
    /// </summary>
    public class GridData : IHttpHandler
    {
        private DA da = new DA();

        public void ProcessRequest(HttpContext context)
        {
            if (string.Equals("edit", context.Request["oper"]) && context.Request["id"] != null && context.Request["Notes"] != null)
            {
                int id = 0;
                int.TryParse(context.Request["id"], out id);
                if (id != 0)
                {
                    da.UpdateUploadSessionNotes(id, context.Request["Notes"]);
                }
                return;
            }

            string gridName = context.Request.QueryString["grid"];

            DataAccess.DataContracts.GridData gridData = null;

            switch (gridName)
            {
                case "DealerIds":
                    gridData = da.GetDealerIds();
                    break;
                case "Dealers":
                    DateTime dateFrom = DateTime.MinValue;
                    DateTime.TryParse(context.Request.QueryString["from"], out dateFrom);
                    DateTime dateTo = DateTime.MinValue;
                    DateTime.TryParse(context.Request.QueryString["to"], out dateTo);
                    string dealer = context.Request.QueryString["dealer"];

                    gridData = da.GetDealersPaged(GetQueryStringInt(context.Request.QueryString, "page"),
                                                            GetQueryStringInt(context.Request.QueryString, "rows"),
                                                            dateFrom,
                                                            dateTo,
                                                            dealer);
                    break;
                case "UploadSessions":
                    dateFrom = DateTime.MinValue;
                    DateTime.TryParse(context.Request.QueryString["from"], out dateFrom);
                    dateTo = DateTime.MinValue;
                    DateTime.TryParse(context.Request.QueryString["to"], out dateTo);
                    dealer = context.Request.QueryString["dealer"];
                    
                    gridData = da.GetUploadSessionsPaged(GetQueryStringInt(context.Request.QueryString, "page"),
                                                            GetQueryStringInt(context.Request.QueryString, "rows"),
                                                            dateFrom,
                                                            dateTo,
                                                            dealer);
                    break;
                case "UploadSessionDetails":
                    gridData = da.GetUploadSessionDetailsPaged(GetQueryStringInt(context.Request.QueryString, "page"), 
                                                                GetQueryStringInt(context.Request.QueryString, "rows"),
                                                                GetQueryStringInt(context.Request.QueryString, "uploadSessionId"));
                    break;
            }

            if (gridData != null)
            {
                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DataAccess.DataContracts.GridData));
                serializer.WriteObject(stream, gridData);

                stream.Position = 0;
                var sJson = new StreamReader(stream).ReadToEnd();

                context.Response.ContentType = "application/json";
                context.Response.Write(sJson);
            }
        }

        private int GetQueryStringInt(NameValueCollection queryString, string paramName)
        {
            int id;
            string str_id = queryString[paramName];
            int.TryParse(str_id, out id);
            return id;
        }
        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}