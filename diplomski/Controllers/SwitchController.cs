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
    public class SwitchController : Controller
    {
        // GET: Switch
        public ActionResult AllSwitches()
        {
            List<Switch> AllSwitches = DataProvider.GetAllSwitches();
            return View(AllSwitches);
        }

        public ActionResult AddSwitch()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSwitch(FormCollection form)
        {
            String name = form["name"].ToString();
            String Manufacturer = form["Manufacturer"].ToString();
            String SNumberOfPorts = form["NumberOfPorts"].ToString();
            int NumberOfPorts = Convert.ToInt32(SNumberOfPorts);
            String SNumberOfTakenPorts = form["NumberOfTakenPorts"].ToString();
            int NumberOfTakenPorts = Convert.ToInt32(SNumberOfTakenPorts);
            String SerialNumber = form["SerialNumber"].ToString();

            DataProvider.AddSwitch(name, SerialNumber, Manufacturer, NumberOfPorts, NumberOfTakenPorts);
            return View();
        }

        public ActionResult Edit(String name, String SerialNumber)
        {
            Switch s = DataProvider.SwitchByName(name, SerialNumber);
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form)
        {
            String name = form["name"].ToString();
            String Manufacturer = form["Manufacturer"].ToString();
            String SNumberOfPorts = form["NumberOfPorts"].ToString();
            int NumberOfPorts = Convert.ToInt32(SNumberOfPorts);
            String SNumberOfTakenPorts = form["NumberOfTakenPorts"].ToString();
            int NumberOfTakenPorts = Convert.ToInt32(SNumberOfTakenPorts);
            String SerialNumber = form["SerialNumber"].ToString();
            List<String> MacAddressList = new List<string>();

            String nameOld = form["SwitchNameOld"].ToString();
            String SerialNumberOld = form["SerialNumberOld"].ToString();

            String s = form["MacAddresses"].ToString();
            String[] tokens = s.Split(',');
            foreach (String t in tokens)
                MacAddressList.Add(t);

            DataProvider.UpdateSwitch(name, SerialNumber, Manufacturer, NumberOfPorts, NumberOfTakenPorts,
                MacAddressList, nameOld, SerialNumberOld);
            return View();
        }

        public ActionResult Details(String name, String SerialNumber)
        {
            Switch s = DataProvider.SwitchByName(name, SerialNumber);

            List<ODocument> resultset = DataProvider.FindSwitchConnections(name, SerialNumber);
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

            return View(s);
        }

        public ActionResult DeleteSwitch(String name, String SerialNumber)
        {
            DataProvider.DeleteSwitch(name, SerialNumber);
            return View();
        }
    }
}