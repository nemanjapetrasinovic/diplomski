using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using diplomski.Models;
using Orient.Client;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace diplomski.Controllers
{
    public class ConnectController : Controller
    {
        // GET: Connect
        public ActionResult AddConnection()
        {
            List<Desktop> AllDesktops = DataProvider.GetAllDesktops();
            List<Laptop> AllLaptops = DataProvider.GetAllLaptops();
            List<Server> AllServers = DataProvider.GetAllServers();
            List<Router> AllRouters = DataProvider.GetAllRouters();
            List<Switch> AllSwitches = DataProvider.GetAllSwitches();


            ViewBag.Desktops = AllDesktops;
            ViewBag.Laptops = AllLaptops;
            ViewBag.Servers = AllServers;
            ViewBag.Routers = AllRouters;
            ViewBag.Switches = AllSwitches;
            return View();
        }

        public ActionResult CreateConnection(String firstNodeType, String firstNode, String secondNodeType,
            String secondNode, String connectionTypeValue, String lanCategoryValue, String lanManufacturerValue,
            String OpticManufacturer, String OpticMaterial, String OpticMode, String CableTypeValue)
        {
            ODocument computer=null;
            if (firstNodeType == "Desktop" || firstNodeType == "Laptop" || firstNodeType == "Server")
                computer = DataProvider.ComputerByName(firstNode);

            ODocument node=null;
            if (firstNodeType == "Router" || firstNodeType == "Switch")
                node = DataProvider.NodeByName(firstNode);

            ODocument computer1=null;
            if (secondNodeType == "Desktop" || secondNodeType == "Laptop" || secondNodeType == "Server")
                computer1 = DataProvider.ComputerByName(secondNode);

            ODocument node1=null;
            if (secondNodeType == "Router" || secondNodeType == "Switch")
                node1 = DataProvider.NodeByName(secondNode);

            ORID o1 = null;
            if (computer!=null)
                o1= computer.GetField<ORID>("@ORID");
            else if(node!=null)
                o1 = node.GetField<ORID>("@ORID");

            ORID o2 = null;
            if (computer1 != null)
                o2 = computer1.GetField<ORID>("@ORID");
            else if (node != null)
                o2 = node1.GetField<ORID>("@ORID");

            LanCable lanCable = new LanCable();
            lanCable.Category = lanCategoryValue;
            lanCable.Manufacturer = lanManufacturerValue;

            OpticCable opticCable = new OpticCable();
            opticCable.Manufacturer = OpticManufacturer;
            opticCable.Material = OpticMaterial;
            opticCable.Mode = OpticMode;

            DataProvider.CreateEdgeCable(o1, o2, connectionTypeValue, CableTypeValue, lanCable, opticCable);

            return View();
        }
    }
}