using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Models
{

    public class BehaviourChartColumn 
    {
        public string Status { get; set; }
        public List<RollRange> Actions { get; set; }

        public BehaviourChartColumn()
        {

        }
        public string GetStatus(int roll)
        {
            var result = "Confusion!";

            foreach (var rr in Actions)
            {
                if (roll >= rr.From && roll <= rr.To)
                {
                    return result = rr.ActionTaken;
                }
            }
            return result;
        }
    }
}
