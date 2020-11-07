using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaConexa.Dominio.Models
{
    public class OpenWeaterApiResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public Main main { get; set; }
        public class Main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
        }
        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

    }
}
