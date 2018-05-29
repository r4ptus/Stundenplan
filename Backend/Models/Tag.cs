using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Tag
    {
        public List<Fach> Fächer = new List<Fach>();

        enum Wochentag {Mo,Di,Mi,Do,Fr };
    }
}
