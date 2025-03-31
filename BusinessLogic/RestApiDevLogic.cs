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

        public List<Device> GetDevices()
        {
            try
            {

                List<Device> devices = RestApiDevService.GetDevicesAsync().Result;

                return devices;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
