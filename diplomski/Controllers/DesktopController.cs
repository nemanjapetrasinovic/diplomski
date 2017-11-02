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
    public class DesktopController : Controller
    {
        // GET: Desktop
        public ActionResult AllDesktops()
        {
            List<Desktop> desktops = DataProvider.GetAllDesktops();
            return View(desktops);
        }

        public ActionResult AddDesktop()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDesktop(FormCollection form)
        {
            String name = form["name"].ToString();
            String OS = form["OS"].ToString();
            String LanMacAddress = form["LanMacAddress"].ToString();
            String Model = form["Model"].ToString();
            String Owner = form["Owner"].ToString();
            String PhoneNumber = form["PhoneNumber"].ToString();
            String Email = form["Email"].ToString();
            String Comment = form["Comment"].ToString();
            String Configuration = form["Configuration"].ToString();

            DataProvider.AddDesktop(name, OS, LanMacAddress,Model,Owner,PhoneNumber,Email,Comment,Configuration);
            return View();
        }

        public ActionResult Edit(String name,String LanMacAddress)
        {
            Desktop desktop=DataProvider.DesktopByName(name,LanMacAddress);
            return View(desktop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form)
        {
            String name = form["name"].ToString();
            String OS = form["OS"].ToString();
            String LanMacAddress = form["LanMacAddress"].ToString();
            String DesktopNameOld = form["DesktopNameOld"].ToString();
            String DesktopMacAddressOld = form["DesktopMacAddressOld"].ToString();

            String Model = form["Model"].ToString();
            String Owner = form["Owner"].ToString();
            String PhoneNumber = form["PhoneNumber"].ToString();
            String Email = form["Email"].ToString();
            String Comment = form["Comment"].ToString();
            String Configuration = form["Configuration"].ToString();

            DataProvider.UpdateDesktop(name, OS, LanMacAddress, DesktopNameOld, DesktopMacAddressOld,Model,Owner,PhoneNumber,
                Email,Comment,Configuration);
            return View();
        }

        public ActionResult Details(String name, String LanMacAddress)
        {
            Desktop desktop = DataProvider.DesktopByName(name, LanMacAddress);
            return View(desktop);
        }

        public ActionResult DeleteDesktop(String name, String LanMacAddress)
        {
            DataProvider.DeleteDesktop(name, LanMacAddress);
            return View();
        }

        [HttpPost]
        public ActionResult DesktopConnections(FormCollection form)
        {
            String name = form["name"].ToString();
            String LanMacAddress = form["LanMacAddress"].ToString();
            String depthString = form["NodeDepth"].ToString();
            int depth = Convert.ToInt32(depthString);

            List<ODocument> resultset = DataProvider.FindDesktopConnections(name, LanMacAddress,depth*2);
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