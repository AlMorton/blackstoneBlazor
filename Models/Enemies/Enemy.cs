using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorApp.Models.Enemies
{
    public interface IHasName
    {
        string Name { get; set; }
    }
    public class Enemy : IHasName
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public List<BehaviourChartColumn> BehaviourChartColumns { get; set; }
        public Enemy()
        {

        }    
    }
}
