using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class BehaviourChart
    {

    }

    public enum Status
    {
        Hidden,
        Engaged,
        InCover,
        Close,
        Other
    }

    public static class Actions
    {
        public static string Hold { get; } = "Hold";
        public static string Sneak { get; set; } = "Sneak";
        public static string Advance { get; set; } = "Advance";
        public static string Charge { get; set; } = "Charge";
        public static string FallBack { get; set; } = "FallBack";
        public static string Aim { get; set; } = "Aim";
        public static string Onslaught { get; set; } = "Onslaught";
    }    
    
}
