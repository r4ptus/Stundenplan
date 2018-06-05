using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Fach
    {
        public enum StartZeit { S0800, S0845, S0955, S1040, S1145, S1230, S1400, S1445, S1545, S1630, S1730, S1825, S1915, S2000 }
        public enum WochenTag { Mo, Di, Mi, Do, Fr}

        public string Name { get; set; }
        public string Raum { get; set; }
        public string Info { get; set; }
        public string Studiengang { get; set; }
        public int Length { get; set; }
        public StartZeit Startzeit { get; set; }
        public WochenTag Wochentag { get; set; }
        public bool FindetStatt { get; set; }
    }
}
