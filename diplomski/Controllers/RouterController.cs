using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using diplomski.Models;
using Orient.Client;
using System.Web.Script.Serialization;

namespace diplomski.Controllers
{
    public class RouterController : Controller
    {
        // GET: Router
        public ActionResult AllRouters()
        {
            List<Router> AllRouters = DataProvider.GetAllRouters();
            return View(AllRouters);
        }

        public ActionResult AddRouter()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRouter(FormCollection form)
        {
            String name = form["name"].ToString();
            String OS = form["OS"].ToString();
            String Manufacturer = form["Manufacturer"].ToString();
            String SNumberOfPorts = form["NumberOfPorts"].ToString();
            int NumberOfPorts = Convert.ToInt32(SNumberOfPorts);
            String SNumberOfTakenPorts = form["NumberOfTakenPorts"].ToString();
            int NumberOfTakenPorts= Convert.ToInt32(SNumberOfTakenPorts);
            String WiFiNetworkName = form["WiFiNetworkName"].ToString();
            String SerialNumber = form["SerialNumber"].ToString();

            DataProvider.AddRouter(name, OS, SerialNumber, Manufacturer, WiFiNetworkName, NumberOfPorts, NumberOfTakenPorts);
            return View();
        }

        public ActionResult Edit(String name, String SerialNumber)
        {
            Router router = DataProvider.RouterByName(name, SerialNumber);
            return View(router);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form)
        {
            String name = form["name"].ToString();
            String OS = form["OS"].ToString();
            String Manufacturer = form["Manufacturer"].ToString();
            String SNumberOfPorts = form["NumberOfPorts"].ToString();
            int NumberOfPorts = Convert.ToInt32(SNumberOfPorts);
            String SNumberOfTakenPorts = form["NumberOfTakenPorts"].ToString();
            int NumberOfTakenPorts = Convert.ToInt32(SNumberOfTakenPorts);
            String WiFiNetworkName = form["WiFiNetworkName"].ToString();
            String SerialNumber = form["SerialNumber"].ToString();
            List<String> MacAddressList = new List<string>();

            String nameOld = form["RouterNameOld"].ToString();
            String SerialNumberOld = form["SerialNumberOld"].ToString();

            String s = form["MacAddresses"].ToString();
            String[] tokens = s.Split(',');
            foreach (String t in tokens)
                MacAddressList.Add(t);

            DataProvider.UpdateRouter(name, OS, SerialNumber, Manufacturer, NumberOfPorts, NumberOfTakenPorts,
                WiFiNetworkName, MacAddressList, nameOld, SerialNumberOld);
            return View();
        }

        
        public ActionResult Details(String name, String SerialNumber,int depth)
        {
            Router router = DataProvider.RouterByName(name,SerialNumber);
            return View(router);
        }

        public ActionResult DeleteRouter(String name, String SerialNumber)
        {
            DataProvider.DeleteRouter(name, SerialNumber);
            return View();
        }

        [HttpPost]
        public ActionResult RouterConnections(FormCollection form)
        {
            String name = form["name"].ToString();
            String SerialNumber = form["SerialNumber"].ToString();
            String depthString = form["NodeDepth"].ToString();
            int depth = Convert.ToInt32(depthString);

            Router router = DataProvider.RouterByName(name, SerialNumber);
            List<ODocument> resultset = DataProvider.FindRouterConnections(name, SerialNumber, depth*2);
            List<Desktop> desktops = new List<Desktop>();
            List<Laptop> laptops = new List<Laptop>();
            List<Server> servers = new List<Server>();
            List<Router> routers = new List<Router>();
            List<Switch> switches = new List<Switch>();
            List<LanCable> lancables = new List<LanCable>();

            JavaScriptSerializer converter = new JavaScriptSerializer();

            if (resultset != null)
            {
                foreach (ODocument doc in resultset)
                {
                    String className = doc.GetField<String>("@OClassName");
                    switch (className)
                    {
                        case "Desktop":
                            var json = converter.Serialize(doc);
                            String a = json.ToString();
                            Desktop d = converter.Deserialize<Desktop>(a);
                            desktops.Add(d);
                            break;
                        case "Laptop":
                            var json1 = converter.Serialize(doc);
                            String a1 = json1.ToString();
                            Laptop d1 = converter.Deserialize<Laptop>(a1);
                            laptops.Add(d1);
                            break;
                        case "Server":
                            var json2 = converter.Serialize(doc);
                            String a2 = json2.ToString();
                            Server d2 = converter.Deserialize<Server>(a2);
                            servers.Add(d2);
                            break;
                        case "Router":
                            var json3 = converter.Serialize(doc);
                            String a3 = json3.ToString();
                            Router d3 = converter.Deserialize<Router>(a3);
                            routers.Add(d3);
                            break;
                        case "Switch":
                            var json4 = converter.Serialize(doc);
                            String a4 = json4.ToString();
                            Switch d4 = converter.Deserialize<Switch>(a4);
                            switches.Add(d4);
                            break;
                        case "LanCable":
                            var json5 = converter.Serialize(doc);
                            String a5 = json5.ToString();
                            LanCable d5 = converter.Deserialize<LanCable>(a5);
                            lancables.Add(d5);
                            break;
                    }

                }
            }

            @ViewBag.desktops = desktops;
            @ViewBag.laptops = laptops;
            @ViewBag.servers = servers;
            @ViewBag.routers = routers;
            @ViewBag.switches = switches;
            @ViewBag.lancables = lancables;
            return View();
        }
    }
}