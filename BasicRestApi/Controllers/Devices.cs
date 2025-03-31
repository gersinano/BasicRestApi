using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Objects;

namespace BasicRestApi.Controllers
{
    [ApiController]
    [Route("api/device")]
    public class Devices : ControllerBase
    {
        private IRestApiDevLogic RestLogic;


        public Devices(IRestApiDevLogic restLogic)
        {
            RestLogic = restLogic;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Device>> GetDevices()
        {
            try
            {
                List<Device> devices = RestLogic.GetDevices();

                return Ok(devices);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Controller level - Error getting all devices: {ex.Message}");
                throw;
            }
        }
    }
}
