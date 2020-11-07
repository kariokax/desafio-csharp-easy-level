using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaConexa.Dominio.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Longitude { get; set; }
        public double Latitutde { get; set; }
        public List<Temperatura> Temperatura { get; set; }
    }
}
