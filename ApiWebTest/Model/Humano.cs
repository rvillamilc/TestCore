using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebTest.Model
{
    public class Humano
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public long Edad { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
    }
}
