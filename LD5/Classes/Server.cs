using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5.Classes
{
    /// <summary>
    /// Servers class
    /// </summary>
    public class Server
    {
        public string IP {  get; set; }
        public string URL { get; set; }
        public Server (string IP, string URL)
        {
            this.IP = IP;
            this.URL = URL;
        }

        public override string ToString()
        {
            return string.Format($"|{IP}|{URL}|{IP}|");
        }
    }
}
