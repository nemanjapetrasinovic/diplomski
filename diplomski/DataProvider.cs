using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using diplomski.Models;
using Orient.Client;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
        public static void CreateEdgeCable(ORID o1,ORID o2, String firstNodeType, String secondNodeType,
            String connectionTypeValue, String CableTypeValue,
            LanCable lanCable,OpticCable opticCable)
        {
            ODatabase database = InitDB();

            if ((firstNodeType == "Desktop" || firstNodeType == "Laptop" || firstNodeType == "Server")
                && (secondNodeType == "Router" || secondNodeType == "Switch"))
            {
                String query = "SELECT * FROM Computer WHERE @rid=" + o1.RID.ToString();
                List<ODocument> resultset = database.Query(query).ToList();
                JavaScriptSerializer converter = new JavaScriptSerializer();

                List<Computer> AllComputers = new List<Computer>();
                String macAddress1 = null;
                foreach (ODocument doc in resultset)
                {
                    var json = converter.Serialize(doc);
                    String a = json.ToString();
                    Computer d = converter.Deserialize<Computer>(a);
                    AllComputers.Add(d);
                }

                Computer computer = null;
                if (AllComputers != null)
                    computer = AllComputers[0];

                macAddress1 = computer.LanMacAddress;

                String query1 = "SELECT * FROM Node WHERE @rid=" + o2.RID.ToString();
                List<ODocument> resultset1 = database.Query(query1).ToList();

                List<Node> AllNodes = new List<Node>();

                foreach (ODocument doc in resultset1)
                {
                    var json = converter.Serialize(doc);
                    String a = json.ToString();
                    Node d = converter.Deserialize<Node>(a);
                    AllNodes.Add(d);
                }

                Node node = null;
                if (AllNodes != null)
                    node = AllNodes[0];

                String macAddress2 = null;
                if (node != null)
                {
                    if (node.NumberOfPorts != node.NumberOfTakenPorts)
                    {
                        node.NumberOfTakenPorts++;
                        macAddress2 = node.MacAddressList.ElementAt(node.NumberOfTakenPorts - 1);
                    }
                }

                if (connectionTypeValue == "Cable")
                {
                    if (CableTypeValue == "Lan")
                    {
                        lanCable.End1 = macAddress1;
                        lanCable.End2 = macAddress2;
                        lanCable.Type = "Lan";

                        String addCableQuerry = "CREATE EDGE LanCable FROM " + o1.RID.ToString() + " TO " + o2.RID.ToString() +
                            " SET End1 = \"" + lanCable.End1 + "\", End2 = \"" + lanCable.End2 + "\", Type=\"" + lanCable.Type
                            + "\", Manufacturer=\"" + lanCable.Manufacturer + "\", Category=\"" + lanCable.Category + "\"";

                        database.Command(addCableQuerry);

                        if (node != null)
                        {
                            database.Update(o2)
                            .Set("NumberOfPorts", node.NumberOfPorts)
                            .Set("NumberOfTakenPorts", node.NumberOfTakenPorts)
                            .Set("MacAddressList", node.MacAddressList).Run();
                        }
                        return;
                    }
                }
                else
                if (connectionTypeValue=="WiFi")
                {
                    if(firstNodeType=="Laptop")
                    {
                        String queryL = "SELECT * FROM Laptop WHERE @rid=" + o1.RID.ToString();
                        List<ODocument> resultsetL = database.Query(queryL).ToList();

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

                        macAddress1 = laptop.WifiMacAddress;
                    }

                    String query2 = "SELECT * FROM Router WHERE @rid=" + o2.RID.ToString();
                    List<ODocument> resultset2 = database.Query(query1).ToList();

                    List<Router> AllRouters = new List<Router>();

                    foreach (ODocument doc in resultset2)
                    {
                        var json = converter.Serialize(doc);
                        String a = json.ToString();
                        Router d = converter.Deserialize<Router>(a);
                        AllRouters.Add(d);
                    }

                    Router router = null;
                    if (AllRouters != null)
                        router = AllRouters[0];

                    if (router != null)
                        macAddress2 = router.WiFiMacAddress;

                    WiFiConnection wificonnection = new WiFiConnection();
                    wificonnection.ClientMacAddress = macAddress1;
                    wificonnection.HostMacAddress = macAddress2;
                    wificonnection.WiFiNetworkName = router.WiFiNetworkName;

                    String addWifiQuerry = "CREATE EDGE WiFiConnection FROM " + o1.RID.ToString() + " TO " + o2.RID.ToString() +
                            " SET WiFiNetworkName = \"" + wificonnection.WiFiNetworkName 
                            + "\", HostMacAddress = \"" + wificonnection.HostMacAddress 
                            + "\", ClientMacAddress=\"" + wificonnection.ClientMacAddress + "\"";
                    database.Command(addWifiQuerry);

                }
            }
            else 
            if ((secondNodeType == "Desktop" || secondNodeType == "Laptop" || secondNodeType == "Server")
                && (firstNodeType == "Router" || firstNodeType == "Switch"))
            {
                String query = "SELECT * FROM Computer WHERE @rid=" + o2.RID.ToString();
                List<ODocument> resultset = database.Query(query).ToList();
                JavaScriptSerializer converter = new JavaScriptSerializer();

                List<Computer> AllComputers = new List<Computer>();
                String macAddress1 = null;
                foreach (ODocument doc in resultset)
                {
                    var json = converter.Serialize(doc);
                    String a = json.ToString();
                    Computer d = converter.Deserialize<Computer>(a);
                    AllComputers.Add(d);
                }

                Computer computer = null;
                if (AllComputers != null)
                    computer = AllComputers[0];

                macAddress1 = computer.LanMacAddress;

                String query1 = "SELECT * FROM Node WHERE @rid=" + o1.RID.ToString();
                List<ODocument> resultset1 = database.Query(query1).ToList();

                List<Node> AllNodes = new List<Node>();

                foreach (ODocument doc in resultset1)
                {
                    var json = converter.Serialize(doc);
                    String a = json.ToString();
                    Node d = converter.Deserialize<Node>(a);
                    AllNodes.Add(d);
                }

                Node node = null;
                if (AllNodes != null)
                    node = AllNodes[0];

                String macAddress2 = null;
                if (node != null)
                {
                    if (node.NumberOfPorts != node.NumberOfTakenPorts)
                    {
                        node.NumberOfTakenPorts++;
                        macAddress2 = node.MacAddressList.ElementAt(node.NumberOfTakenPorts - 1);
                    }
                }

                if (connectionTypeValue == "Cable")
                {
                    if (CableTypeValue == "Lan")
                    {
                        lanCable.End1 = macAddress1;
                        lanCable.End2 = macAddress2;
                        lanCable.Type = "Lan";

                        String addCableQuerry = "CREATE EDGE LanCable FROM " + o2.RID.ToString() + " TO " + o1.RID.ToString() +
                            " SET End1 = \"" + lanCable.End1 + "\", End2 = \"" + lanCable.End2 + "\", Type=\"" + lanCable.Type
                            + "\", Manufacturer=\"" + lanCable.Manufacturer + "\", Category=\"" + lanCable.Category + "\"";

                        database.Command(addCableQuerry);

                        if (node != null)
                        {
                            database.Update(o1)
                            .Set("NumberOfPorts", node.NumberOfPorts)
                            .Set("NumberOfTakenPorts", node.NumberOfTakenPorts)
                            .Set("MacAddressList", node.MacAddressList).Run();
                        }
                        return;
                    }
                }
                if (connectionTypeValue == "WiFi")
                {
                    if (secondNodeType == "Laptop")
                    {
                        String queryL = "SELECT * FROM Laptop WHERE @rid=" + o2.RID.ToString();
                        List<ODocument> resultsetL = database.Query(queryL).ToList();

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

                        macAddress1 = laptop.WifiMacAddress;
                    }

                    String query2 = "SELECT * FROM Router WHERE @rid=" + o1.RID.ToString();
                    List<ODocument> resultset2 = database.Query(query1).ToList();

                    List<Router> AllRouters = new List<Router>();

                    foreach (ODocument doc in resultset2)
                    {
                        var json = converter.Serialize(doc);
                        String a = json.ToString();
                        Router d = converter.Deserialize<Router>(a);
                        AllRouters.Add(d);
                    }

                    Router router = null;
                    if (AllRouters != null)
                        router = AllRouters[0];

                    if (router != null)
                        macAddress2 = router.WiFiMacAddress;

                    WiFiConnection wificonnection = new WiFiConnection();
                    wificonnection.ClientMacAddress = macAddress1;
                    wificonnection.HostMacAddress = macAddress2;
                    wificonnection.WiFiNetworkName = router.WiFiNetworkName;

                    String addWifiQuerry = "CREATE EDGE WiFiConnection FROM " + o2.RID.ToString() + " TO " + o1.RID.ToString() +
                            " SET WiFiNetworkName = \"" + wificonnection.WiFiNetworkName
                            + "\", HostMacAddress = \"" + wificonnection.HostMacAddress
                            + "\", ClientMacAddress=\"" + wificonnection.ClientMacAddress + "\"";
                    database.Command(addWifiQuerry);

                }
            }
            else
            if ((firstNodeType == "Desktop" || firstNodeType == "Laptop" || firstNodeType == "Server")
                && (secondNodeType == "Desktop" || secondNodeType == "Laptop" || secondNodeType == "Server"))
            {
                String query = "SELECT * FROM Computer WHERE @rid=" + o1.RID.ToString();
                List<ODocument> resultset = database.Query(query).ToList();
                JavaScriptSerializer converter = new JavaScriptSerializer();

                List<Computer> AllComputers = new List<Computer>();
                String macAddress1 = null;
                foreach (ODocument doc in resultset)
                {
                    var json = converter.Serialize(doc);
                    String a = json.ToString();
                    Computer d = converter.Deserialize<Computer>(a);
                    AllComputers.Add(d);
                }

                Computer computer = null;
                if (AllComputers != null)
                    computer = AllComputers[0];

                macAddress1 = computer.LanMacAddress;

                String query1 = "SELECT * FROM Computer WHERE @rid=" + o2.RID.ToString();
                List<ODocument> resultset1 = database.Query(query1).ToList();

                List<Computer> AllComputers1 = new List<Computer>();
                String macAddress2 = null;
                foreach (ODocument doc in resultset1)
                {
                    var json = converter.Serialize(doc);
                    String a = json.ToString();
                    Computer d = converter.Deserialize<Computer>(a);
                    AllComputers1.Add(d);
                }

                Computer computer1 = null;
                if (AllComputers1 != null)
                    computer1 = AllComputers1[0];

                macAddress2 = computer1.LanMacAddress;

                if (connectionTypeValue == "Cable")
                {
                    if (CableTypeValue == "Lan")
                    {
                        lanCable.End1 = macAddress1;
                        lanCable.End2 = macAddress2;
                        lanCable.Type = "Lan";

                        String addCableQuerry = "CREATE EDGE LanCable FROM " + o1.RID.ToString() + " TO " + o2.RID.ToString() +
                            " SET End1 = \"" + lanCable.End1 + "\", End2 = \"" + lanCable.End2 + "\", Type=\"" + lanCable.Type
                            + "\", Manufacturer=\"" + lanCable.Manufacturer + "\", Category=\"" + lanCable.Category + "\"";

                        database.Command(addCableQuerry);

                        return;
                    }
                }
            }
            else
            if ((firstNodeType == "Router" || firstNodeType == "Switch")
                && (secondNodeType == "Router" || secondNodeType == "Switch"))
            {
                String query = "SELECT * FROM Node WHERE @rid=" + o1.RID.ToString();
                JavaScriptSerializer converter = new JavaScriptSerializer();
                List<ODocument> resultset = database.Query(query).ToList();

                List<Node> AllNodes = new List<Node>();

                foreach (ODocument doc in resultset)
                {
                    var json = converter.Serialize(doc);
                    String a = json.ToString();
                    Node d = converter.Deserialize<Node>(a);
                    AllNodes.Add(d);
                }

                Node node = null;
                if (AllNodes != null)
                    node = AllNodes[0];

                String macAddress1 = null;
                if (node != null)
                {
                    if (node.NumberOfPorts != node.NumberOfTakenPorts)
                    {
                        node.NumberOfTakenPorts++;
                        macAddress1 = node.MacAddressList.ElementAt(node.NumberOfTakenPorts - 1);
                    }
                }

                String query1 = "SELECT * FROM Node WHERE @rid=" + o2.RID.ToString();
                List<ODocument> resultset1 = database.Query(query1).ToList();

                List<Node> AllNodes1 = new List<Node>();

                foreach (ODocument doc in resultset1)
                {
                    var json = converter.Serialize(doc);
                    String a = json.ToString();
                    Node d = converter.Deserialize<Node>(a);
                    AllNodes1.Add(d);
                }

                Node node1 = null;
                if (AllNodes1 != null)
                    node1 = AllNodes1[0];

                String macAddress2 = null;
                if (node1 != null)
                {
                    if (node1.NumberOfPorts != node1.NumberOfTakenPorts)
                    {
                        node1.NumberOfTakenPorts++;
                        macAddress2 = node1.MacAddressList.ElementAt(node1.NumberOfTakenPorts - 1);
                    }
                }

                if (connectionTypeValue == "Cable")
                {
                    if (CableTypeValue == "Lan")
                    {
                        lanCable.End1 = macAddress1;
                        lanCable.End2 = macAddress2;
                        lanCable.Type = "Lan";

                        String addCableQuerry = "CREATE EDGE LanCable FROM " + o1.RID.ToString() + " TO " + o2.RID.ToString() +
                            " SET End1 = \"" + lanCable.End1 + "\", End2 = \"" + lanCable.End2 + "\", Type=\"" + lanCable.Type
                            + "\", Manufacturer=\"" + lanCable.Manufacturer + "\", Category=\"" + lanCable.Category + "\"";

                        database.Command(addCableQuerry);

                        if (node != null)
                        {
                            database.Update(o1)
                            .Set("NumberOfPorts", node.NumberOfPorts)
                            .Set("NumberOfTakenPorts", node.NumberOfTakenPorts)
                            .Set("MacAddressList", node.MacAddressList).Run();
                        }

                        if (node1 != null)
                        {
                            database.Update(o2)
                            .Set("NumberOfPorts", node1.NumberOfPorts)
                            .Set("NumberOfTakenPorts", node1.NumberOfTakenPorts)
                            .Set("MacAddressList", node1.MacAddressList).Run();
                        }
                        return;
                    }
                }
            }
        }
        #endregion
    }
}