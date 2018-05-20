using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeScheduler.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public EventsController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            List<Event> events = new List<Event>();
            string eventsJsonFile = Path.Combine(_hostingEnvironment.ContentRootPath, "events.json");
            
            using (StreamReader r = new StreamReader(eventsJsonFile))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach(var item in array)
                {
                    Event newEvent = new Event{
                        Title = item.title,
                        StartTime = Convert.ToDateTime(item.start.ToString()),
                        OrderId = item.orderId,
                        EventType = EventType.Event
                    };
                    events.Add(newEvent);
                }
            }

            return Json(events);
        }
    }
}
