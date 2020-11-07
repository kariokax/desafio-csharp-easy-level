using Newtonsoft.Json;
using ProvaConexa.Dominio.Models;
using ProvaConexa.Dominio.Servico;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProvaConexa.Servico
{
    public class OpenWeatherMapService : IOpenWeatherMapService
    {
        private readonly string _key;
        private readonly HttpClient _cliente = new HttpClient();

        public OpenWeatherMapService()
        {
            _key = "417a6fe864617aac00636c2ab50be962";
            _cliente.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
            _cliente.DefaultRequestHeaders.Accept.Clear();
            _cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public OpenWeaterApiResponse ObterTemperaturaPorCidade(string cidade)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/" + $"weather?q={cidade}&units=metric&appid={_key}");
                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<OpenWeaterApiResponse>(json);
                return result;
            }
        }
        public OpenWeaterApiResponse ObterTemperaturaPorLonELat(double longitude, double latitude)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/" + $"weather?lat={latitude}&lon={longitude}&units=metric&appid={_key}");
                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<OpenWeaterApiResponse>(json);

                return result;
            }
        }
    }
}
