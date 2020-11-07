using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaConexa.Dominio.Models
{
    public class Temperatura
    {
        public int Id { get; set; }
        public  int Cidade_Id { get; set; }
        public double TemperaturaCidade { get; set; }

        public DateTime Data { get; set; }
    }
}
