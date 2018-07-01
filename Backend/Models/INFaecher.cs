using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    class INFaecher: FaecherListe
    {
        public INFaecher()
        {
            faecherListe = new List<Fach>();
            this.addALL();
        }

        private void addALL()
        {
            faecherListe.Add(new Fach("KOKO", true));
            faecherListe.Add(new Fach("JURA", true));
            faecherListe.Add(new Fach("BWL1", true));
            faecherListe.Add(new Fach("BWL2", true));
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
            faecherListe.Add(new Fach("PARA", true));
            faecherListe.Add(new Fach("REAR", true));
            faecherListe.Add(new Fach("MATHE3", true));
            faecherListe.Add(new Fach("PROJ", true));
            faecherListe.Add(new Fach("WETE", true));
            faecherListe.Add(new Fach("PROG3", true));
            faecherListe.Add(new Fach("TINF", true));
            faecherListe.Add(new Fach("REIN", false));
            faecherListe.Add(new Fach("ADMIN", false));
            faecherListe.Add(new Fach("MUME", false));
            faecherListe.Add(new Fach("WEBU", false));
            faecherListe.Add(new Fach("PROFI", false));
            faecherListe.Add(new Fach("GPU", false));
            faecherListe.Add(new Fach("EPRO", false));
            faecherListe.Add(new Fach("GRAF1", false));
            faecherListe.Add(new Fach("JA3D", false));
            faecherListe.Add(new Fach("MMI1", false));
            faecherListe.Add(new Fach("USER", false));
            faecherListe.Add(new Fach("MMI2", false));
            faecherListe.Add(new Fach("MESY", false));
            faecherListe.Add(new Fach("REQ", false));
            faecherListe.Add(new Fach("WINF", false));
            faecherListe.Add(new Fach("BPM", false));
            faecherListe.Add(new Fach("GRAF2", false));
            faecherListe.Add(new Fach("BI", false));
            faecherListe.Add(new Fach("SQUAL", false));
            faecherListe.Add(new Fach("ADMIN", false));
            faecherListe.Add(new Fach("SEMA", false));
            faecherListe.Add(new Fach("IMAN", false));
            faecherListe.Add(new Fach("BWLWP", false));
            faecherListe.Add(new Fach("RTOS", false));
            faecherListe.Add(new Fach("DPRO", false));
            faecherListe.Add(new Fach("OBIS", false));
            faecherListe.Add(new Fach("AMOS", false));
            faecherListe.Add(new Fach("ANDR", false));
            faecherListe.Add(new Fach("MOKO", false));
            faecherListe.Add(new Fach("WIAP", false));
            faecherListe.Add(new Fach("EMA", false));
            faecherListe.Add(new Fach("NEUR", false));
            faecherListe.Add(new Fach("VIRT", false));
           
        }
    }
}
