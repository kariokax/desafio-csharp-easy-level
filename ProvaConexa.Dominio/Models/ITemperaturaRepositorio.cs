using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaConexa.Dominio.Models
{
    public interface ITemperaturaRepositorio
    {
        Temperatura Temperatura (string cidade);
        Temperatura Temperatura (double latitude, double longitude);
        List<Temperatura> Temperaturas(string cidade);
        List<Temperatura> Temperaturas(double latitude, double longitude);
    }
}
