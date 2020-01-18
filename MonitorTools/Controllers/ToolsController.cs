using MonitorTools.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonitorTools.Controllers
{
    public class ToolsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string Monitor(AddOrderRequest request)
        {
            if (request != null)
            {
                Response.ContentType = "application/json";
                return JsonConvert.SerializeObject(request);
            }
            return "abc";
        }

    }
}