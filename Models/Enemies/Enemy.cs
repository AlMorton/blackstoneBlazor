using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorApp.Models.Enemies
{
    public class Enemy
    {
        public string Name { get; set; }        
        public string Status { get; set; }
        public string Action { get; set; }
        public int InitiativeGroup { get; set; }
        public List<BehaviourChartColumn> BehaviourChartColumns { get; set; }        
    }    
}
