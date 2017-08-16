using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerState.Models
{
    public class WebService
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public bool LastTestResult { get; set; }
        public string LastTestResultText { get; set; }
    } 
}