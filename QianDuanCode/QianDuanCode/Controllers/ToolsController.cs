using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QianDuanCode.Controllers
{


    public class ToolsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string Monitor(string url, string json, string random)
        {
            //改成用SortSetScan可以查询的模式

            //var url = "http://localhost:8082/api/AddOrder?MonitorKey=" + random;

            if (url.Contains("?"))
            {
                url = url + "&MonitorKey=" + random + "&token=" + GetToken();
            }
            else
            {
                url = url + "?MonitorKey=" + random + "&token=" + GetToken();
            }
            //var res = Common.PostHttpResponse(url, json);
            var list = new List<string>() { "请求1", "请求1", "请求1", "请求1", "请求1", "请求1", "请求1", "请求1", "请求1", "请求1", "请求1" };
            var res = JsonConvert.SerializeObject(list);
            return res;
        }
        public string GetMonitorLog(string random)
        {
            //var url = "http://localhost:8082/api/GetMonitorLog?MonitorKey=" + random;
            //var res = Common.PostHttpResponse(url, "");
            var list = new List<string>() { "结果1", "结果1", "结果1", "结果1", "结果1", "结果1", "结果1", "结果1", "结果1", "结果1", "结果1" };
            var res = JsonConvert.SerializeObject(list);
            return res;
        }

        private string GetToken()
        {
            return "dfeg3%3f";
        }

    }
}