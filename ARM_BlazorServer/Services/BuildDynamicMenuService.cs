using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM_BlazorServer.Services
{
    public class BuildDynamicMenuService
    {

        public async Task<List<MenuItem>>? GetDynamicMenus(string menuType)
        {
            if (menuType == "Default")//In reality will be getting from database
            {
                List<MenuItem> menuItems = new List<MenuItem>();
                MenuItem menuItem =
                    new() { PageReference = "pagedemo", Icon = "book", MenuText = "Dynamic 1" };
                menuItems.Add(menuItem);
                menuItem =
                    new() { PageReference = "superuser", Icon = "pencil", MenuText = "Super User" };
                menuItems.Add(menuItem);
                return menuItems;
            }
            return null;
        }
    }
}
