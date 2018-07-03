using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace Backend.Models
{
    public class DataWriter
    {
        private XElement _dataNode;

        public string FileName { get; private set; }

        public static void Create(string fileName)
        {
            var newData = new XDocument();
            var dataNode = new XElement("Data");
            var faecherNode = new XElement("Faecher");
            var stundenplaeneNode = new XElement("Stundenplaene");

            dataNode.Add(faecherNode);
            dataNode.Add(stundenplaeneNode);
            newData.Add(dataNode);

            newData.Save(fileName);
        }
        
        public DataWriter(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");
            if (!File.Exists(fileName))
                throw new FileNotFoundException("fileName");

            this.FileName = fileName;
            _dataNode = XDocument.Load(fileName).Root;
        }

        public void AddFach(Fach fach)
        {
            var xmlNodes = _dataNode.Elements();

            var faecherNode = _dataNode.Elements().FirstOrDefault(element => element.Name == "Faecher");

            XElement fachNode = new XElement("Fach", new XAttribute("Name", fach.Name));

            faecherNode.Add(fachNode);

            this.Save();
        }

        public void RemoveFach(Fach fach)
        {
            var xmlNodes = _dataNode.Elements();

            var faecherNode = _dataNode.Elements().FirstOrDefault(element => element.Name == "Faecher");

            var fachNode = faecherNode.Elements().FirstOrDefault(node => node.Attribute("Name").Value == fach.Name);
            if (fachNode != null)
                fachNode.Remove();

            this.Save();
        }

        public void AddStundenplan(string planName, Dictionary<string, Fach> stundenPlan)
        {
            if (stundenPlan == null)
                return;
            if (stundenPlan.Count <= 0)
                return;

            var xmlNodes = _dataNode.Elements();

            var stundenPlaeneNode = _dataNode.Elements().FirstOrDefault(element => element.Name == "Stundenplaene");

            var newPlan = new XElement("Plan", new XAttribute("Name", planName));
            foreach (var pair in stundenPlan)
            {
                Fach fach = pair.Value;
                string key = pair.Key;

                XElement fachNode = new XElement("Fach",
                    new XAttribute("Key", key),
                    new XAttribute("Name", fach.Name ?? ""),
                    new XAttribute("Raum", fach.Raum ?? ""),
                    new XAttribute("Info", fach.Info ?? ""),
                    new XAttribute("Startzeit", fach.Startzeit == Fach.StartZeit.None ? "" : fach.Startzeit.ToString()),
                    new XAttribute("Wochentag", fach.Wochentag == Fach.WochenTag.None ? "" : fach.Wochentag.ToString()),
                    new XAttribute("Laenge", fach.Length.ToString()));
                newPlan.Add(fachNode);
            }
            stundenPlaeneNode.Add(newPlan);

            this.Save();

            
        }

        public void RemoveStundenplan(int id)
        {
            var xmlNodes = _dataNode.Elements();

            var stundenPlaeneNode = xmlNodes.FirstOrDefault(element => element.Name == "Stundenplaene");
            var planNode = stundenPlaeneNode.Elements().FirstOrDefault(node => node.Attribute("Id").Value == id.ToString());

            if (planNode != null)
                planNode.Remove();

            this.Save();
        }

        private void Save()
        {
            _dataNode.Save(this.FileName);
        }

        //private int LastElementId(XElement node)
        //{
        //    if(node == null)
        //        return -1;

        //    if(node.Elements().Count() <= 0)
        //        return 0;

        //    var subNodes = node.Elements();
        //    var lastNode = subNodes.Last();

        //    return Convert.ToInt32(lastNode.Attribute("Id").Value);
        //}
    }
}
