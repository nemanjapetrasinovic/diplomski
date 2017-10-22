using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using diplomski.Models;

namespace diplomski.Controllers
{
    public class ServerController : Controller
    {
        // GET: Server
        public ActionResult AllServers()
        {
            List<Server> AllServers = DataProvider.GetAllServers();
            return View(AllServers);
        }

        public ActionResult AddServer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddServer(FormCollection form)
        {
            String name = form["name"].ToString();
            String OS = form["OS"].ToString();
            String LanMacAddress = form["LanMacAddress"].ToString();
            String Type = form["Type"].ToString();
            String Description = form["Description"].ToString();

            DataProvider.AddServer(name, OS, LanMacAddress, Type, Description);
            return View();
        }

        public ActionResult Edit(String name, String LanMacAddress)
        {
            Server server = DataProvider.ServerByName(name, LanMacAddress);
            return View(server);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form)
        {
            String name = form["name"].ToString();
            String OS = form["OS"].ToString();
            String LanMacAddress = form["LanMacAddress"].ToString();
            String Type = form["Type"].ToString();
            String Description = form["Description"].ToString();
            String ServerNameOld = form["ServerNameOld"].ToString();
            String ServerLanMacAddressOld = form["ServerLanMacAddressOld"].ToString();

            DataProvider.UpdateServer(name, OS, LanMacAddress, Type, Description, ServerNameOld, ServerLanMacAddressOld);
            return View();
        }

        public ActionResult Details(String name, String LanMacAddress)
        {
            Server server = DataProvider.ServerByName(name, LanMacAddress);
            return View(server);
        }
    }
}