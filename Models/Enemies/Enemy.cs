using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorApp.Models.Enemies
{
    public interface IAttributes
    {
        string Name { get; set; }
        string CSSClass { get; set; }
    }
    public class Enemy : IAttributes
    {
        public string Name { get; set; }
        public string CSSClass { get; set; } 
        public string Status { get; set; }
        public List<BehaviourChartColumn> BehaviourChartColumns { get; set; }        

        public Enemy()
        {
            CSSClass = "enemy"; 
        }    
    }
}
