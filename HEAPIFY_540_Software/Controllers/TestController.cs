using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HEAPIFY_Manager_540.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return PartialView("SideMenu");
        }
        public ActionResult SideMenu()
        {
            return PartialView("SideMenu");
        }
    }
}


