using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using diplomski.Models;

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
    }
}