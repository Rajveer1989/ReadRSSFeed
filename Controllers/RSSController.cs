using Read_RSS_Feed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace Read_RSS_Feed.Controllers
{
    public class RSSController : Controller
    {
        // GET: RSS
        public ActionResult Read()
        { 
            return View();
        }
        [HttpPost]
        [HandleError]
        public ActionResult Read(string RSSURL)
        {
            string Data = "";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(RSSURL);
            req.Method = "GET";
            req.Timeout = 40000;
            using (HttpWebResponse res=(HttpWebResponse)req.GetResponse())
            {
                using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                {
                     Data = sr.ReadToEnd();

                }   

            }
            //WebClient webClient = new WebClient();
            //string data = webClient.DownloadString(RSSURL);
            XDocument xml = XDocument.Parse(Data);
            var extractdata = (from item in xml.Descendants("item")
                               select new RSSFEED
                               {
                                   link = ((string)item.Element("link")),
                                   title = ((string)item.Element("title")),
                                   description = ((string)item.Element("description"))
                               });
            ViewBag.alldata = extractdata;


            return View();
            
        }
    }
}