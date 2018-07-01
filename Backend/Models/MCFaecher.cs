using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class MCFaecher: FaecherListe
    {
        public MCFaecher()
        {
            faecherListe = new List<Fach>();
            this.addAll();

        }

        private void addAll()
        {
            faecherListe.Add(new Fach("KOKO", true));
            faecherListe.Add(new Fach("JURA", true));
            faecherListe.Add(new Fach("BWL1", true));
            faecherListe.Add(new Fach("MOBU", true));
            faecherListe.Add(new Fach("IGRU2", true));
            faecherListe.Add(new Fach("PROG1", true));
            faecherListe.Add(new Fach("PROG2", true));
            faecherListe.Add(new Fach("BESY", true));
            faecherListe.Add(new Fach("ALDA", true));
            faecherListe.Add(new Fach("DABA", true));
            faecherListe.Add(new Fach("SENG", true));
            faecherListe.Add(new Fach("ITSEC", true));
            faecherListe.Add(new Fach("KONE", true));
            faecherListe.Add(new Fach("MATHE1", true));
            faecherListe.Add(new Fach("MATHE2", true));
            faecherListe.Add(new Fach("IGRU1", true));
            faecherListe.Add(new Fach("MOKO", true));
            faecherListe.Add(new Fach("WETE", true));
            faecherListe.Add(new Fach("EMOC", true));
            faecherListe.Add(new Fach("HAPO", true));
            faecherListe.Add(new Fach("EMA", true));
            faecherListe.Add(new Fach("OBIS", true));
            faecherListe.Add(new Fach("MOVS", true));
            faecherListe.Add(new Fach("WEMU", true));
            faecherListe.Add(new Fach("MMI1", true));
            faecherListe.Add(new Fach("PROJ", true));
            faecherListe.Add(new Fach("REIN", false));
            faecherListe.Add(new Fach("ADMIN", false));
            faecherListe.Add(new Fach("MUME", false));
            faecherListe.Add(new Fach("PROFI", false));
            faecherListe.Add(new Fach("GPU", false));
            faecherListe.Add(new Fach("BPM", false));
            faecherListe.Add(new Fach("EPRO", false));
            faecherListe.Add(new Fach("GRAF1", false));
            faecherListe.Add(new Fach("JA3D", false));
            faecherListe.Add(new Fach("USER", false));
            faecherListe.Add(new Fach("MMI2", false));
            faecherListe.Add(new Fach("REQ", false));
            faecherListe.Add(new Fach("MESY", false));
            faecherListe.Add(new Fach("WINF", false));
            faecherListe.Add(new Fach("GRAF2", false));
            faecherListe.Add(new Fach("BI", false));
            faecherListe.Add(new Fach("SQUAL", false));
            faecherListe.Add(new Fach("SEMA", false));
            faecherListe.Add(new Fach("IMAN", false));
            faecherListe.Add(new Fach("BWLWP", false));
            faecherListe.Add(new Fach("ANDR", false));
            faecherListe.Add(new Fach("REAR", false));
            faecherListe.Add(new Fach("AMOS", false));
            faecherListe.Add(new Fach("WIAP", false));
            faecherListe.Add(new Fach("VIRT", false));


        }
    }
}
