using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace Backend.Models
{
    public class DataReader
    {
        private XElement _dataNode;

        public string FileName { get; private set; }
        
        public DataReader(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");
            if (!File.Exists(fileName))
                throw new FileNotFoundException("fileName");

            this.FileName = fileName;
            _dataNode = XDocument.Load(fileName).Root;
        }

        public IEnumerable<Fach> GetFaecher()
        {
            var xmlNodes = _dataNode.Elements();

            var faecherNode = _dataNode.Elements().FirstOrDefault(element => element.Name == "Faecher");
            var faecherNodes = faecherNode.Elements();
            
            if (faecherNodes.Count() <= 0)
                yield break;

            foreach (XElement fachNode in faecherNodes)
                yield return NodeToFach(fachNode);
        }
        //public Dictionary<string, Fach> GetFaecherWithName()
        //{
        //    var faecher = this.GetFaecher();
        //    var faecherWithName = faecher.ToDictionary(fach => fach.Name);

        //    return faecherWithName;
        //}
        public IEnumerable<Dictionary<string, Fach>> GetStundenplaene()
        {
            var xmlNodes = _dataNode.Elements();

            var plaeneNode = _dataNode.Elements().FirstOrDefault(element => element.Name == "Stundenplaene");
            var planNodes = plaeneNode.Elements();

            if (planNodes.Count() <= 0)
                yield break;

            foreach (var planNode in planNodes)
                yield return NodeToPlan(planNode);
        }
        public Dictionary<string, Fach> GetFirstStundenplan()
        {
            return this.GetStundenplaene().FirstOrDefault();
        }

        private Dictionary<string, Fach> NodeToPlan(XElement planNode)
        {
            var plan = new Dictionary<string, Fach>();

            if (planNode.Descendants().Count() <= 0)
                return plan;

            foreach (var fachNode in planNode.Elements())
            {
                Fach fach = new Fach();
                fach.Name = fachNode.Attribute("Name").Value;

                fach.Info = fachNode.Attribute("Info").Value;
                fach.Raum = fachNode.Attribute("Raum").Value;
                fach.Length = Convert.ToInt32(fachNode.Attribute("Laenge").Value);
                if (fachNode.Attribute("Startzeit").Value == "")
                    fach.Startzeit = Fach.StartZeit.None;
                else
                    fach.Startzeit = (Fach.StartZeit)Enum.Parse(typeof(Fach.StartZeit), fachNode.Attribute("Startzeit").Value);
                if (fachNode.Attribute("Wochentag").Value == "")
                    fach.Wochentag = Fach.WochenTag.None;
                else
                    fach.Wochentag = (Fach.WochenTag)Enum.Parse(typeof(Fach.WochenTag), fachNode.Attribute("Wochentag").Value);

                plan.Add(fachNode.Attribute("Key").Value, fach);
            }

            return plan;
        }

        private Fach NodeToFach(XElement fachNode)
        {
            if (fachNode.Name != "Fach")
                throw new ArgumentException("Der Knoten enthält kein Fach.");

            Fach fach = new Fach();
            fach.Name = fachNode.Attribute("Name").Value;


            return fach;
        }
    }
}