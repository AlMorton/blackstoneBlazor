using System.Collections.Generic;

namespace BlazorApp.Models.Enemies
{
    public class Enemy
    {
        public string Name { get; set; }
        public List<BehaviourChartColumn> BehaviourChartColumns { get; set; }

    }
}
