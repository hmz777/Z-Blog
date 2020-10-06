using HMZSoftwareBlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMZSoftwareBlazorWebAssembly.Helpers
{
    public class TopBarController : ITopBarControllerService
    {
        private readonly IJSRuntime jSRuntime;

        public TopBarController(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task NavigateOn()
        {
            await jSRuntime.InvokeVoidAsync("BlazorHelpers.TopBarShow");
        }

        public async Task NavigateOff()
        {
            await jSRuntime.InvokeVoidAsync("BlazorHelpers.TopBarHide");
        }
    }
}
