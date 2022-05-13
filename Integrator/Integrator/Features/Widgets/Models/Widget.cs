using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using Integrator.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Win32.SafeHandles;

namespace Integrator.Features.Widgets.Models
{
    public class Widget : BaseEntity
    {
        public string Title { get; set; }
        public Integration Type { get; set; }
        public string Url { get; set; }
        public IEnumerable<Option> Options { get; set; }
    }
    
   public enum Integration
    {
        Sap,
        TimeSmart,
        TimeSmartRegistrations
    }
}