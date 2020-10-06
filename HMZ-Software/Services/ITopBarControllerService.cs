using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMZSoftwareBlazorWebAssembly.Services
{
    public interface ITopBarControllerService
    {
        Task NavigateOn();
        Task NavigateOff();
    }
}
