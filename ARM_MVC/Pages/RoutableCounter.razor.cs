using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace ARM_MVC.Pages
{
    public partial class RoutableCounter
    {
        private int currentCount = 0;
        private void IncrementCount()
        {
             currentCount++;
        }
    }
}