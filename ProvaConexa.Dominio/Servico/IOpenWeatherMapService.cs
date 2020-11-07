using ProvaConexa.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaConexa.Dominio.Servico
{
    public interface IOpenWeatherMapService
    {

        OpenWeaterApiResponse ObterTemperaturaPorCidade(string cidade);
        OpenWeaterApiResponse ObterTemperaturaPorLonELat(double longitude, double latitude);
    }
}
