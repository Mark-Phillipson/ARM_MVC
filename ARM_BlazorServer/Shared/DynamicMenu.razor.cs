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
using ARM_BlazorServer.Services;

namespace ARM_BlazorServer.Shared
{
    public partial class DynamicMenu
    {
        [Parameter] public string MenuType { get; set; }="Default";
        [Inject] BuildDynamicMenuService? BuildDynamicMenuService { get; set; }
        List<MenuItem>? menuItems=new List<MenuItem>();
        protected override async Task OnInitializedAsync()
        {
            if (BuildDynamicMenuService!= null )
            {
                menuItems =await BuildDynamicMenuService.GetDynamicMenus(MenuType);
            }
        }
    }
}