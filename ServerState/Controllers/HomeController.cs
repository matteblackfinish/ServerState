using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServerState.Models;
using System.Net.Sockets;

namespace ServerState.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var allWebServices = new List<WebService>();

            // do for/each here where we bring in each webservice to test
            var tempWebService = new WebService { Name = "Google", Address = "google.ca", Port = 80 };
            var result = TestWebService(tempWebService);
            tempWebService.LastTestResult = result.Result;
            tempWebService.LastTestResultText = result.ResultText;

            allWebServices.Add(tempWebService);

            ViewBag.Results = allWebServices;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        private TestResult TestWebService(WebService webService)
        {
            var result = false;
            var resultText = "";
            var tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(webService.Address, webService.Port);
                result = true;
            }
            catch (Exception ex)
            {
                resultText = ex.ToString();
                result = false;
            }

            return new TestResult { Result = result, ResultText = resultText };
        }
    }
}