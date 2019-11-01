using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueueingDemo.DAL;

namespace QueueingDemo.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return Json(ServiceDAL.GetServices());
        }
        public void Add(string serviceName)
        {
            ServiceDAL.AddService(serviceName);
        }
    }
}