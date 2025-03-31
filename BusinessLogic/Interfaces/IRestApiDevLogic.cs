using Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRestApiDevLogic
    {
        List<Device> GetDevices(string? name, int? page, int? pageSize);
        Device CreateNewDevice(CreateDevice createNewDevice);

    }
}
