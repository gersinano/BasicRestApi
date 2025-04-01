using ExternalService.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
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
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    List<Device> devices = JsonConvert.DeserializeObject<List<Device>>(content);

                    return devices;
                }
                else
                {
                    throw new Exception($"Request failed with status: {response.StatusCode}, Message: {content}");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting devices: {ex.Message}");
                throw;
            }
        }
        public async Task<Device> CreateNewDeviceAsync(CreateDevice createDeviceRequest)
        {
            try
            {

                var client = Factory.CreateClient("httpclient-restful-api-dev");

                var jsonContent = new StringContent(JsonConvert.SerializeObject(createDeviceRequest), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("/objects", jsonContent);
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Device device = JsonConvert.DeserializeObject<Device>(content);

                    return device;
                }
                else
                {
                    throw new Exception($"Request failed with status: {response.StatusCode}, Message: {content}");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting devices: {ex.Message}");
                throw;
            }
        }
        
        public async Task<string> DeleteDeviceAsync(string id)
        {
            try
            {

                var client = Factory.CreateClient("httpclient-restful-api-dev");

                HttpResponseMessage response = await client.DeleteAsync($"/objects/{id}");
                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return content;
                }
                else
                {
                    throw new Exception($"Request failed with status: {response.StatusCode}, Message: {content}");

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
