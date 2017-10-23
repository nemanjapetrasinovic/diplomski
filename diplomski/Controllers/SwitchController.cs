using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using diplomski.Models;

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
            return View(s);
        }
    }
}