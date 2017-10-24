using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using diplomski.Models;
using Orient.Client;
using System.Web.Script.Serialization;

namespace diplomski
{
    public static class DataProvider
    {
        #region DatabaseInit
        private static ODatabase InitDB()
        {
            ODatabase database = new ODatabase("localhost", 2424, "NetworkGraph",
               ODatabaseType.Graph, "Nemanja", "nemanja1994");
            return database;
        }
        #endregion

        #region Desktop
        public static List<Desktop> GetAllDesktops()
        {
            ODatabase database = InitDB();
            string query = String.Format("SELECT * FROM Desktop");
            List<ODocument> resultset = database.Select().From("Desktop").ToList();
            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Desktop> AllDesktops = new List<Desktop>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Desktop d = converter.Deserialize<Desktop>(a);
                AllDesktops.Add(d);
            }

            database.Close();
            return AllDesktops;
        }

        public static void AddDesktop(String name,String OS,String LanMacAddress)
        {
            ODatabase database = InitDB();
            database.Insert().Into("Desktop").Set("name", name)
                .Set("OS", OS).Set("LanMacAddress", LanMacAddress).Run();
            database.Close();
        }

        public static Desktop DesktopByName(String name,String LanMacAddress)
        {
            ODatabase database = InitDB();
            string query = String.Format("SELECT * FROM Desktop WHERE name=\""+name+"\" AND LanMacAddress=\""
                +LanMacAddress+"\"");
            List<ODocument> resultset = database.Query(query).ToList();

            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Desktop> AllDesktops = new List<Desktop>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Desktop d = converter.Deserialize<Desktop>(a);
                AllDesktops.Add(d);
            }

            Desktop desktop=null;
            if (AllDesktops != null)
                desktop = AllDesktops[0];
            database.Close();

            return desktop;
        }

        public static Desktop DesktopByNameOnly(String name)
        {
            ODatabase database = InitDB();
            string query = String.Format("SELECT * FROM Desktop WHERE name=\"" + name+"\"");
            List<ODocument> resultset = database.Query(query).ToList();

            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Desktop> AllDesktops = new List<Desktop>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Desktop d = converter.Deserialize<Desktop>(a);
                AllDesktops.Add(d);
            }

            Desktop desktop = null;
            if (AllDesktops != null)
                desktop = AllDesktops[0];
            database.Close();

            return desktop;
        }

        public static void UpdateDesktop(String name, String OS, String LanMacAddress,String nameOld,String LanMacAddressOld)
        {
            ODatabase database = InitDB();

            string query = String.Format("SELECT * FROM Desktop WHERE name=\"" + nameOld + "\" AND LanMacAddress=\""
                 + LanMacAddressOld + "\"");
            List<ODocument> result = database.Query(query).ToList();

            ODocument o = result[0];
            ORID z=o.GetField<ORID>("@ORID");

            database.Update(z).Set("name", name).Set("OS", OS).Set("LanMacAddress", LanMacAddress).Run();
        }
        #endregion

        #region Laptop
        public static List<Laptop> GetAllLaptops()
        {
            ODatabase database = InitDB();
            string query = String.Format("SELECT * FROM Laptop");
            List<ODocument> resultset = database.Select().From("Laptop").ToList();
            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Laptop> AllLaptops = new List<Laptop>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Laptop d = converter.Deserialize<Laptop>(a);
                AllLaptops.Add(d);
            }

            database.Close();
            return AllLaptops;
        }

        public static void AddLaptop(String name, String OS, String LanMacAddress,String WiFiMacAddress,String WiFiNetworkName)
        {
            ODatabase database = InitDB();
            database.Insert().Into("Laptop").Set("name", name)
                .Set("OS", OS).Set("LanMacAddress", LanMacAddress)
                .Set("WiFiMacAddress",WiFiMacAddress).Set("WiFiNetworkName",WiFiNetworkName).Run();
            database.Close();
        }

        public static Laptop LaptopByName(String name, String LanMacAddress, String WiFiMacAddress)
        {
            ODatabase database = InitDB();
            string query = String.Format("SELECT * FROM Laptop WHERE name=\"" + name + "\" AND LanMacAddress=\""
                + LanMacAddress + "\" AND WiFiMacAddress=\""+WiFiMacAddress+"\"");
            List<ODocument> resultset = database.Query(query).ToList();

            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Laptop> AllLaptops = new List<Laptop>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Laptop d = converter.Deserialize<Laptop>(a);
                AllLaptops.Add(d);
            }

            Laptop laptop = null;
            if (AllLaptops != null)
                laptop = AllLaptops[0];
            database.Close();

            return laptop;
        }

        public static Laptop LaptopByNameOnly(String name)
        {
            ODatabase database = InitDB();
            string query = String.Format("SELECT * FROM Laptop WHERE name=\"" + name + "\"");
            List<ODocument> resultset = database.Query(query).ToList();

            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Laptop> AllLaptops = new List<Laptop>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Laptop d = converter.Deserialize<Laptop>(a);
                AllLaptops.Add(d);
            }

            Laptop laptop = null;
            if (AllLaptops != null)
                laptop = AllLaptops[0];
            database.Close();

            return laptop;
        }

        public static void UpdateLaptop(String name, String OS, String LanMacAddress, String WiFiMacAddress, String WiFiNetworkName, String nameOld, String LanMacAddressOld,String WiFiMacAddressOld)
        {
            ODatabase database = InitDB();

            string query = String.Format("SELECT * FROM Laptop WHERE name=\"" + nameOld + "\" AND LanMacAddress=\""
                 + LanMacAddressOld + "\" AND WiFiMacAddress=\""+WiFiMacAddressOld+"\"");
            List<ODocument> result = database.Query(query).ToList();

            ODocument o = result[0];
            ORID z = o.GetField<ORID>("@ORID");

            database.Update(z).Set("name", name).Set("OS", OS).Set("LanMacAddress", LanMacAddress)
                .Set("WiFiMacAddress",WiFiMacAddress).Set("WiFiNetworkName", WiFiNetworkName).Run();
        }
        #endregion

        #region Server
        public static List<Server> GetAllServers()
        {
            ODatabase database = InitDB();
            List<ODocument> resultset = database.Select().From("Server").ToList();
            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Server> AllServers = new List<Server>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Server d = converter.Deserialize<Server>(a);
                AllServers.Add(d);
            }

            database.Close();
            return AllServers;
        }

        public static void AddServer(String name, String OS, String LanMacAddress, String Type, String Description)
        {
            ODatabase database = InitDB();
            database.Insert().Into("Server").Set("name", name)
                .Set("OS", OS).Set("LanMacAddress", LanMacAddress)
                .Set("Type", Type).Set("Description", Description).Run();
            database.Close();
        }

        public static Server ServerByName(String name, String LanMacAddress)
        {
            ODatabase database = InitDB();
            string query = String.Format("SELECT * FROM Server WHERE name=\"" + name + "\" AND LanMacAddress=\""
                + LanMacAddress + "\"");
            List<ODocument> resultset = database.Query(query).ToList();

            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Server> AllServerss = new List<Server>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Server d = converter.Deserialize<Server>(a);
                AllServerss.Add(d);
            }

            Server server = null;
            if (AllServerss != null)
                server = AllServerss[0];
            database.Close();

            return server;
        }

        public static Server ServerByNameOnly(String name)
        {
            ODatabase database = InitDB();
            string query = String.Format("SELECT * FROM Server WHERE name=\"" + name + "\"");
            List<ODocument> resultset = database.Query(query).ToList();

            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Server> AllServerss = new List<Server>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Server d = converter.Deserialize<Server>(a);
                AllServerss.Add(d);
            }

            Server server = null;
            if (AllServerss != null)
                server = AllServerss[0];
            database.Close();

            return server;
        }

        public static void UpdateServer(String name, String OS, String LanMacAddress, String Type, String Description, String nameOld, String LanMacAddressOld)
        {
            ODatabase database = InitDB();

            string query = String.Format("SELECT * FROM Server WHERE name=\"" + nameOld + "\" AND LanMacAddress=\""
                 + LanMacAddressOld + "\"");
            List<ODocument> result = database.Query(query).ToList();

            ODocument o = result[0];
            ORID z = o.GetField<ORID>("@ORID");

            database.Update(z).Set("name", name).Set("OS", OS).Set("LanMacAddress", LanMacAddress)
                .Set("Type", Type).Set("Description", Description).Run();
        }
        #endregion

        #region Router
        public static List<Router> GetAllRouters()
        {
            ODatabase database = InitDB();
            List<ODocument> resultset = database.Select().From("Router").ToList();
            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Router> AllRouters = new List<Router>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Router d = converter.Deserialize<Router>(a);
                AllRouters.Add(d);
            }

            database.Close();
            return AllRouters;
        }

        public static void AddRouter(String name, String OS, String SerialNumber, String Manufacturer,
            String WiFiNetworkName, int NumberOfPorts, int NumberOfTakenPorts)
        {
            List<String> MacAddressList = new List<string>();
            ODatabase database = InitDB();
            database.Insert().Into("Router").Set("name", name)
                .Set("OS", OS).Set("SerialNumber", SerialNumber)
                .Set("Manufacturer", Manufacturer).Set("WiFiNetworkName", WiFiNetworkName)
                .Set("NumberOfPorts", NumberOfPorts).Set("NumberOfTakenPorts", NumberOfTakenPorts)
                .Set("MacAddressList", MacAddressList).Run();
            database.Close();
        }

        public static Router RouterByName(String name, String SerialNumber)
        {
            ODatabase database = InitDB();
            string query = String.Format("SELECT * FROM Router WHERE name=\"" + name + "\" AND SerialNumber=\""
                + SerialNumber + "\"");
            List<ODocument> resultset = database.Query(query).ToList();

            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Router> AllRouters = new List<Router>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Router d = converter.Deserialize<Router>(a);
                AllRouters.Add(d);
            }

            Router router = null;
            if (AllRouters != null)
                router = AllRouters[0];
            database.Close();

            return router;
        }

        public static Router RouterByNameOnly(String name)
        {
            ODatabase database = InitDB();
            string query = String.Format("SELECT * FROM Router WHERE name=\"" + name + "\"");
            List<ODocument> resultset = database.Query(query).ToList();

            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Router> AllRouters = new List<Router>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Router d = converter.Deserialize<Router>(a);
                AllRouters.Add(d);
            }

            Router router = null;
            if (AllRouters != null)
                router = AllRouters[0];
            database.Close();

            return router;
        }

        public static void UpdateRouter(String name, String OS, String SerialNumber, String Manufacturer,
            int NumberOfPorts, int NumberOfTakenPorts, String WiFiNetworkName,
            List<String> MacAddressList, String RouterNameOld, String SerialNumberOld)
        {
            ODatabase database = InitDB();

            string query = String.Format("SELECT * FROM Router WHERE name=\"" + RouterNameOld + "\" AND SerialNumber=\""
                 + SerialNumberOld + "\"");
            List<ODocument> result = database.Query(query).ToList();

            ODocument o = result[0];
            ORID z = o.GetField<ORID>("@ORID");

            database.Update(z).Set("name", name).Set("OS", OS).Set("SerialNumber", SerialNumber)
                .Set("Manufacturer", Manufacturer).Set("NumberOfPorts", NumberOfPorts)
                .Set("NumberOfTakenPorts", NumberOfTakenPorts).Set("WiFiNetworkName", WiFiNetworkName)
                .Set("MacAddressList", MacAddressList).Run();
        }
        #endregion

        #region Switch
        public static List<Switch> GetAllSwitches()
        {
            ODatabase database = InitDB();
            List<ODocument> resultset = database.Select().From("Switch").ToList();
            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Switch> AllSwitches = new List<Switch>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Switch d = converter.Deserialize<Switch>(a);
                AllSwitches.Add(d);
            }

            database.Close();
            return AllSwitches;
        }

        public static void AddSwitch(String name, String SerialNumber, String Manufacturer,
             int NumberOfPorts, int NumberOfTakenPorts)
        {
            List<String> MacAddressList = new List<string>();
            ODatabase database = InitDB();
            database.Insert().Into("Switch").Set("name", name)
                .Set("SerialNumber", SerialNumber)
                .Set("Manufacturer", Manufacturer)
                .Set("NumberOfPorts", NumberOfPorts).Set("NumberOfTakenPorts", NumberOfTakenPorts)
                .Set("MacAddressList", MacAddressList).Run();
            database.Close();
        }

        public static Switch SwitchByName(String name, String SerialNumber)
        {
            ODatabase database = InitDB();
            string query = String.Format("SELECT * FROM Switch WHERE name=\"" + name + "\" AND SerialNumber=\""
                + SerialNumber + "\"");
            List<ODocument> resultset = database.Query(query).ToList();

            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Switch> AllSwitches = new List<Switch>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Switch d = converter.Deserialize<Switch>(a);
                AllSwitches.Add(d);
            }

            Switch router = null;
            if (AllSwitches != null)
                router = AllSwitches[0];
            database.Close();

            return router;
        }

        public static Switch SwitchByNameOnly(String name)
        {
            ODatabase database = InitDB();
            string query = String.Format("SELECT * FROM Switch WHERE name=\"" + name + "\"");
            List<ODocument> resultset = database.Query(query).ToList();

            JavaScriptSerializer converter = new JavaScriptSerializer();

            List<Switch> AllSwitches = new List<Switch>();

            foreach (ODocument doc in resultset)
            {
                var json = converter.Serialize(doc);
                String a = json.ToString();
                Switch d = converter.Deserialize<Switch>(a);
                AllSwitches.Add(d);
            }

            Switch router = null;
            if (AllSwitches != null)
                router = AllSwitches[0];
            database.Close();

            return router;
        }

        public static void UpdateSwitch(String name, String SerialNumber, String Manufacturer,
            int NumberOfPorts, int NumberOfTakenPorts,
            List<String> MacAddressList, String SwitchNameOld, String SerialNumberOld)
        {
            ODatabase database = InitDB();

            string query = String.Format("SELECT * FROM Switch WHERE name=\"" + SwitchNameOld + "\" AND SerialNumber=\""
                 + SerialNumberOld + "\"");
            List<ODocument> result = database.Query(query).ToList();

            ODocument o = result[0];
            ORID z = o.GetField<ORID>("@ORID");

            database.Update(z).Set("name", name)
                .Set("SerialNumber", SerialNumber)
                .Set("Manufacturer", Manufacturer)
                .Set("NumberOfPorts", NumberOfPorts)
                .Set("NumberOfTakenPorts", NumberOfTakenPorts)
                .Set("MacAddressList", MacAddressList).Run();
        }
        #endregion

        #region Computer
        public static ODocument ComputerByName(String name)
        {
            ODatabase database = InitDB();
            string query = String.Format("SELECT * FROM Computer WHERE name=\"" + name + "\"");
            List<ODocument> resultset = database.Query(query).ToList();


            List<ODocument> AllComputers = new List<ODocument>();

            foreach (ODocument doc in resultset)
            {
                AllComputers.Add(doc);
            }

            ODocument computer = null;
            if (AllComputers != null)
                computer = AllComputers[0];
            database.Close();

            return computer;
        }

        #endregion

        #region Node
        public static ODocument NodeByName(String name)
        {
            ODatabase database = InitDB();
            string query = String.Format("SELECT * FROM Node WHERE name=\"" + name + "\"");
            List<ODocument> resultset = database.Query(query).ToList();


            List<ODocument> AllNodes = new List<ODocument>();

            foreach (ODocument doc in resultset)
            {
                AllNodes.Add(doc);
            }

            ODocument node = null;
            if (AllNodes != null)
                node = AllNodes[0];
            database.Close();

            return node;
        }
        #endregion

        #region Edge
        public static void CreateEdge(ORID o1,ORID o2, String connectionTypeValue, String CableTypeValue,
            LanCable lanCable,OpticCable opticCable)
        {

        }
        #endregion
    }
}