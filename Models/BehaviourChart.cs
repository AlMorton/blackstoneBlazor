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
        public string GetStatus(RollRange roll)
        {
            var result = "Confusion!";

            foreach (var rr in Actions)
            {
                if (roll.From >= rr.From && roll.To <= rr.To)
                {
                    return result = rr.ActionTaken;
                }
            }
            return result;
        }
    }

    public interface IRollRange
    {
        int From { get; set; }
        int To { get; set; }
    }

    public class RollRange : IRollRange
    {
        public int From { get; set; }
        public int To { get; set; }
        public string ActionTaken { get; set; }
        public RollRange()
        {

        }    
    }

    public enum StatusEnum
    {
        Hidden,
        Engaged,
        InCover,
        Close,
        Other
    }

    public static class EnemyActions
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
