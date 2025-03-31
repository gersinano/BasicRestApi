using ExternalService.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExternalService
{
    public class RestApiDevService : IRestApiDevService
    {
        private IConfiguration Configuration;
        private readonly IHttpClientFactory Factory;

        public RestApiDevService(IConfiguration configuration, IHttpClientFactory factory) 
        {
            Configuration = configuration;
            Factory = factory;
        }

        public async Task<List<Device>> GetDevicesAsync()
        {
            try
            {
                var client = Factory.CreateClient("httpclient-restful-api-dev");
                HttpResponseMessage response = await client.GetAsync("/objects");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<Device> devices = JsonConvert.DeserializeObject<List<Device>>(content);

                    return devices;
                }
                else
                {
                    throw new HttpRequestException($"Request failed with status: {response.StatusCode}");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting devices: {ex.Message}");
                throw;
            }
        }
    }
}
