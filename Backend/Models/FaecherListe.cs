using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class FaecherListe
    {
        protected List<Fach> faecherListe;

        public FaecherListe()
        {
            faecherListe = new List<Fach>();
        }

        public List<Fach> GetFaecherListe()
        {
            faecherListe.Sort();
            return faecherListe;
        }

        public void AddFach(Fach fach)
        {
            faecherListe.Add(fach);
        }
    }
}
