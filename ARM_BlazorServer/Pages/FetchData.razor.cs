using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using ARM_BlazorServer;
using ARM_BlazorServer.Shared;
using ARM_BlazorServer.Data;

namespace ARM_BlazorServer.Pages
{
    [Authorize(Roles ="Admin")]
    public partial class FetchData
    {
        private WeatherForecast[]? forecasts;
        protected override async Task OnInitializedAsync()
        {
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
        }
    }
}