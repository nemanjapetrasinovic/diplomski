using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using diplomski.Models;

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

            DataProvider.AddDesktop(name, OS, LanMacAddress);
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

            DataProvider.UpdateDesktop(name, OS, LanMacAddress, DesktopNameOld, DesktopMacAddressOld);
            return View();
        }

        public ActionResult Details(String name, String LanMacAddress)
        {
            Desktop desktop = DataProvider.DesktopByName(name, LanMacAddress);
            return View(desktop);
        }
    }
}