using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using diplomski.Models;

namespace diplomski.Controllers
{
    public class NetworkController : Controller
    {
        // GET: Network
        public ActionResult NetworkMap()
        {
            List<Desktop> AllDesktops = DataProvider.GetAllDesktops();
            List<Laptop> AllLaptops = DataProvider.GetAllLaptops();
            List<Server> AllServers = DataProvider.GetAllServers();
            List<Router> AllRouters = DataProvider.GetAllRouters();
            List<Switch> AllSwitchs = DataProvider.GetAllSwitches();
            List<LanCable> AllLanCables = DataProvider.GetAllLanCables();

            ViewBag.desktops = AllDesktops;
            ViewBag.laptops = AllLaptops;
            ViewBag.servers = AllServers;
            ViewBag.routers = AllRouters;
            ViewBag.switches = AllSwitchs;
            ViewBag.lancables = AllLanCables;
            return View();
        }
    }
}