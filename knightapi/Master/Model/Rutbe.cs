using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public class Rutbe
    {
        public int Id { get; set; }
        public string RutbeAdi { get; set; }
        public string Aciklama { get; set; }
        public string Logo { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }
    }
}
