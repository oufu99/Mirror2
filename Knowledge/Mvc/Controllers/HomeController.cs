﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
        public void Index()
        {

        }

        public string Do(Person p)
        {


        }
    }
    public class Person  
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}