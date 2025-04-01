using BusinessLogic.Interfaces;
using ExternalService.Interfaces;
using Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class RestApiDevLogic : IRestApiDevLogic
    {
        private IRestApiDevService RestApiDevService;
        public RestApiDevLogic(IRestApiDevService restApiDevService) 
        {
            RestApiDevService = restApiDevService;
        }

        public List<Device> GetDevices(string? name, int? page, int? pageSize)
        {
            try
            {

                List<Device> devices = RestApiDevService.GetDevicesAsync().Result;

                if (!string.IsNullOrEmpty(name))
                {
                    devices = devices.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (pageSize is not null) // check only pagesize, because if page is null and pagesize has a value, show the first page by deafult with x records.
                {
                    devices = devices.Skip(((page ?? 1) - 1) * (int)pageSize).Take((int)pageSize).ToList();

                }


                return devices;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public Device CreateNewDevice(CreateDevice createNewDevice)
        {
            try
            {
                foreach (KeyValuePair<string, object> item in createNewDevice.Data)
                {
                    if(string.IsNullOrWhiteSpace(item.Key))
                    {
                        throw new ArgumentException("Key Value is required.");
                    }
                    if(item.Value is not null)
                    {
                        if(item.Value is string)
                        {
                            if (string.IsNullOrWhiteSpace((string)item.Value))
                            {
                                throw new ArgumentException($"{item.Key} Value is required.");
                            }
                        }
                    }
                }

                Device device = RestApiDevService.CreateNewDeviceAsync(createNewDevice).Result;

                return device;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string DeleteDevice(string id)
        {
            try
            {

                string device = RestApiDevService.DeleteDeviceAsync(id).Result;

                return device;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
