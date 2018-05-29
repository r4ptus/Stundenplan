using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Fach
    {
        string Name { get; set; }
        string Raum { get; set; }
        int Length { get; set; }
        int Startzeit { get; set; }
        string Info { get; set; }
        bool FindetStatt { get; set; }
    }
}
