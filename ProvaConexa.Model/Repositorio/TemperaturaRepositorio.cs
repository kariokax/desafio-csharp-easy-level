using ProvaConexa.Dominio.Models;
using ProvaConexa.Dominio.Servico;
using ProvaConexa.Repositorio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvaConexa.Repositorio.Repositorio
{
    public class TemperaturaRepositorio : ITemperaturaRepositorio
    {
        private IOpenWeatherMapService _servico;
        private DataContext _contexto;

        public TemperaturaRepositorio(DataContext contexto, IOpenWeatherMapService servico)
        {
            _contexto = contexto;
            _contexto.Database.EnsureCreated();
            _servico = servico;
        }
        public Temperatura Temperatura(string cidade)
        {
            var tempCidade = _servico.ObterTemperaturaPorCidade(cidade);
            var temperaturaAtual = _contexto.Cidade.Where(t => t.Id == tempCidade.id).FirstOrDefault();

            var temperatura = new Temperatura();
            var city = new Cidade();

            temperatura.Data = DateTime.Now.Date;
            temperatura.Cidade_Id = tempCidade.id;
            temperatura.TemperaturaCidade = tempCidade.main.temp;

            AtualizarRelacao(temperatura);

            city.Nome = tempCidade.name;
            city.Longitude = tempCidade.coord.lon;
            city.Latitutde = tempCidade.coord.lat;
            city.Temperatura = temperaturaAtual.Temperatura;




            if (temperaturaAtual != null)
            {
                city.Temperatura.Add(temperatura);

                _contexto.Cidade.Update(temperaturaAtual);
            }
            else
            {
                city.Temperatura = new List<Temperatura>();
                city.Temperatura.Add(temperatura);
                city.Id = tempCidade.id;

                _contexto.Cidade.Add(city);
            }


            _contexto.SaveChangesAsync();

            return temperatura;

        }

        public Temperatura Temperatura(double latitude, double longitude)
        {
            var tempCidade = _servico.ObterTemperaturaPorLonELat(latitude, longitude);
            var temperaturaAtual = _contexto.Cidade.Where(t => t.Id == tempCidade.id).FirstOrDefault();

            var temperatura = new Temperatura();
            var city = new Cidade();

            temperatura.Data = DateTime.Now.Date;
            temperatura.Cidade_Id = tempCidade.id;
            temperatura.TemperaturaCidade = tempCidade.main.temp;

            AtualizarRelacao(temperatura);

            city.Nome = tempCidade.name;
            city.Longitude = tempCidade.coord.lon;
            city.Latitutde = tempCidade.coord.lat;
            city.Temperatura = temperaturaAtual.Temperatura;




            if (temperaturaAtual != null)
            {
                city.Temperatura.Add(temperatura);

                _contexto.Cidade.Update(temperaturaAtual);
            }
            else
            {
                city.Temperatura = new List<Temperatura>();
                city.Temperatura.Add(temperatura);
                city.Id = tempCidade.id;

                _contexto.Cidade.Add(city);
            }


            _contexto.SaveChangesAsync();

            return temperatura;
        }

        public List<Temperatura> Temperaturas(string cidade)
        {
            var temperaturaAtual = Temperatura(cidade);

            var city = _contexto.Cidade.Where(t => t.Id == temperaturaAtual.Id).FirstOrDefault();
            city.Temperatura = _contexto.Temperatura.Where(t => t.Cidade_Id == city.Id &&
                                t.Data.Month == DateTime.Now.Month).ToList();

            return city.Temperatura;

        }

        public List<Temperatura> Temperaturas(double latitude, double longitude)
        {
            var temperaturaAtual = Temperatura(latitude, longitude);

            var city = _contexto.Cidade.Where(t => t.Id == temperaturaAtual.Id).FirstOrDefault();
            city.Temperatura = _contexto.Temperatura.Where(t => t.Cidade_Id == city.Id &&
                                t.Data.Month == DateTime.Now.Month).ToList();

            return city.Temperatura;
        }

        public void AtualizarRelacao(Temperatura temperatura)
        {
            _contexto.Temperatura.Add(temperatura);
            _contexto.SaveChangesAsync();
        }
    }
}
