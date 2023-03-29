using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung
{
    public class Auftrag
    {
        public int Id { get; set; }
        public int PosVon { get; set; }
        public int PosNach { get; set; }
        public int AnzahlContainer { get; set; }
    }
}
