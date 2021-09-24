using Lab11_2_StackOvr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11_2_StackOvr.Controllers
{
    public class AdminControls : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditQ (string UID)
        {
            return Content("test");
        }

    }
}
