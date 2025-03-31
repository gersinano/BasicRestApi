using Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalService.Interfaces
{
    public interface IRestApiDevService
    {
        Task<List<Device>> GetDevicesAsync();

    }
}
