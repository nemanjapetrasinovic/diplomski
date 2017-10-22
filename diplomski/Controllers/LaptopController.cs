using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using diplomski.Models;

namespace diplomski.Controllers
{
    public class LaptopController : Controller
    {
        // GET: Laptop
        public ActionResult AllLaptops()
        {
            List<Laptop> laptops = DataProvider.GetAllLaptops();
            return View(laptops);
        }
        public ActionResult AddLaptop()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLaptop(FormCollection form)
        {
            String name = form["name"].ToString();
            String OS = form["OS"].ToString();
            String LanMacAddress = form["LanMacAddress"].ToString();
            String WiFiMacAddress = form["WiFiMacAddress"].ToString();
            String WiFiNetworkName = form["WiFiNetworkName"].ToString();

            DataProvider.AddLaptop(name, OS, LanMacAddress,WiFiMacAddress,WiFiNetworkName);
            return View();
        }

        public ActionResult Edit(String name, String LanMacAddress, String WiFiMacAddress)
        {
            Laptop laptop = DataProvider.LaptopByName(name, LanMacAddress,WiFiMacAddress);
            return View(laptop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form)
        {
            String name = form["name"].ToString();
            String OS = form["OS"].ToString();
            String LanMacAddress = form["LanMacAddress"].ToString();
            String WiFiMacAddress = form["WiFiMacAddress"].ToString();
            String WiFiNetworkName= form["WiFiNetworkName"].ToString();
            String LaptopNameOld = form["LaptopNameOld"].ToString();
            String LaptopLanMacAddressOld = form["LaptopLanMacAddressOld"].ToString();
            String LaptopWiFiMacAddressOld = form["LaptopWiFiMacAddressOld"].ToString();

            DataProvider.UpdateLaptop(name,OS,LanMacAddress,WiFiMacAddress,WiFiNetworkName, LaptopNameOld, LaptopLanMacAddressOld, LaptopWiFiMacAddressOld);
            return View();
        }

        public ActionResult Details(String name, String LanMacAddress, String WiFiMacAddress)
        {
            Laptop laptop = DataProvider.LaptopByName(name, LanMacAddress, WiFiMacAddress);
            return View(laptop);
        }
    }
}