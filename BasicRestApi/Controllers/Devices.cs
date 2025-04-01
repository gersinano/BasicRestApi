using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Objects;
using System.Xml.Linq;

namespace BasicRestApi.Controllers
{
    [ApiController]
    [Route("api/devices")]
    public class Devices : ControllerBase
    {
        private IRestApiDevLogic RestLogic;


        public Devices(IRestApiDevLogic restLogic)
        {
            RestLogic = restLogic;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Device>> GetDevices([FromQuery] string? name, [FromQuery] int? page, [FromQuery] int? pageSize)
        {
            try
            {
                List<Device> devices = RestLogic.GetDevices(name, page, pageSize);

                return Ok(devices);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Controller level - Error getting all devices: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public ActionResult<IEnumerable<Device>> CreateNewDevice([FromBody] CreateDevice createDeviceRequest)
        {
            try
            {
                Device devices = RestLogic.CreateNewDevice(createDeviceRequest);

                return Ok(devices);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Controller level - BadRequest: {ex.Message}");
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Controller level - Error getting all devices: {ex.Message}");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<string>> DeleteDevice(string id)
        {
            try
            {
                string devices = RestLogic.DeleteDevice(id);

                return Ok(devices);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Controller level - BadRequest: {ex.Message}");
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Controller level - Error getting all devices: {ex.Message}");
                return StatusCode(500, new { error = ex.Message });
            }
        }

    }
}
