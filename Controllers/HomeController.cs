using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO.Ports;

namespace Auto_garden.Controllers
{
    public class HomeController : Controller
    {
        private int baudrate = 57600, databits = 8;
        private Parity parity = Parity.None;
        private StopBits stopbits = StopBits.One;

        private SerialPort port;

        public ActionResult Index()
        {
            ViewBag.Title = "Auto Garden - Home";

            

            return View();
        }

        [HttpPost]
        public ActionResult SetServo(int position)
        {
                

            using (port = new SerialPort("COM4", baudrate, parity, databits, stopbits))
                try
                {
                    if (!port.IsOpen)
                    {
                        port.Open();
                    }
                    port.Write(position.ToString());
                    return Json(new { success = true });

                }
                catch (Exception e)
                {
                    return Json(new { success = false });
                }          
                        
        }

    }
}
