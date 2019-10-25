using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QueueingDemo.Models;
namespace QueueingDemo.DAL
{
    public static class ServiceDAL
    {
        public static void AddService(string serviceName)
        {
            masterContext db = new masterContext();
            db.Service.Add(new Service { Name = serviceName });
            db.SaveChanges();
        }
    }
}
