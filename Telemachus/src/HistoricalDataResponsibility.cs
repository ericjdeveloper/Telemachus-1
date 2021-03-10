using System;
using System.Collections.Generic;
using System.Text;
using WebSocketSharp.Net;
using WebSocketSharp;
using KSP.IO;
using System.IO;

namespace Telemachus
{
    class HistoricalDataResponsibility  : IHTTPRequestResponder
    {

        #region Constants
        const String PAGE_PREFIX = "/telemachus/datalink/history/";
        #endregion

        public bool process(HttpListenerRequest request, HttpListenerResponse response)
        {
            if(request.RawUrl.StartsWith(PAGE_PREFIX))
            {
                var results = new Dictionary<string, string>();
                results["altitude"] = "0";
                var returnData = Encoding.UTF8.GetBytes(SimpleJson.SimpleJson.SerializeObject(results));
                response.ContentEncoding = Encoding.UTF8;
                response.ContentType = "application/json";
                response.WriteContent(returnData);
                return true;
            }
            return false;
        }
    }
}
