using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ProvaConexa.Teste
{
    public class TemperaturaCidadeTeste
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public TemperaturaCidadeTeste()
        {
            _server = new TestServer(new WebHostBuilder()
           .UseStartup<Startup>());
            _client = _server.CreateClient();

        }

        [Fact]
        public async Task ObterPorCidadeTeste()
        {

            var response = await _client.GetAsync("/api/temperatura/cidade?cidade=Goiânia");
            var json = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
            Assert.NotEmpty(json);
            Assert.NotNull(json);

        }
        
        [Fact]
        public async Task ObterPorCoordenadaTeste()
        {

            var response = await _client.GetAsync("/api/temperatura/coordenada?longitude=-49.25&latitude=-16.68");
            var json = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
            Assert.NotEmpty(json);
            Assert.NotNull(json);

        }

        [Fact]
        public async Task ObterPorCidadeInexistenteTeste()
        {

            var response = await _client.GetAsync("/api/temperatura/cidade?cidade=inexistente");

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest,response.StatusCode);

        }

        [Fact]
        public async Task ObterHistoricoPorCidadeTeste()
        {

            var response = await _client.GetAsync("/api/temperatura/historico?cidade=goiânia");
            var json = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(json);
            Assert.NotNull(json);

        }

        [Fact]
        public async Task ObterHistoricoPorCoordenadaTeste()
        {

            var response = await _client.GetAsync("/api/temperatura/historico?longitude=-49.25&latitude=-16.68");
            var json = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(json);
            Assert.NotNull(json);

        }

    }
}
