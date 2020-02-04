using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public string GetMonitorLog(string random, int pageIndex, int pageSize = 10)
        {
            //var url = "http://localhost:8082/api/GetMonitorLog?MonitorKey=" + random;
            //var list = Common.PostHttpResponse(url, "");

            var data = new MonitorResponseModel { TotalCount = 0, Data = new List<string>() };
            var list = new List<string>() { "结果1", "结果1", "结果1", "结果1", "结果1", "结果1", "结果1", "结果1", "结果1", "结果1", "结果1" };


            if (list == null)
            {

                return JsonConvert.SerializeObject(data);
            }
            data.TotalCount = list.Count;
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            data.Data = list;

            var res = JsonConvert.SerializeObject(data);
            return res;
        }

        private string GetToken()
        {
            var model = new
            {
                appid = ConfigurationManager.AppSettings["appId"],
                appkey = ConfigurationManager.AppSettings["appkey"]
            };
            var url = "http://localhost:8082/api/token";
            //Common.PostHttpResponse(url, model);

            return "dfeg3%3f";
        }

    }


    public class RequestTokenModel
    {
        public string appid { get; set; }
        public string appkey { get; set; }
    }

    public class MonitorRequestModel
    {
        public string Url { get; set; }
        public string Json { get; set; }
        public string Random { get; set; }
    }

    public class MonitorResponseModel
    {
        public int TotalCount { get; set; }
        public List<string> Data { get; set; }
    }
}