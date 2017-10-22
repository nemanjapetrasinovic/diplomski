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
    }
}