using System;
using System.Collections.Generic;

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
            var index = Actions.BinarySearch(roll);
            if(index != -1) return Actions[index].ActionTaken;

            return "Confusion!";
        }
    }

    public interface IRollRange : IComparable<IRollRange>
    {
        int From { get; set; }
        int To { get; set; }
    }

    public class RollRange : IRollRange, IComparer<IRollRange>
    {
        public int From { get; set; }
        public int To { get; set; }
        public string ActionTaken { get; set; }
        public RollRange()
        {

        }      

        public int Compare(IRollRange x, IRollRange y)
        {
            if (x.From > y.From) return 1;
            if (x.From < y.From) return -1;
            else return 0;            
        }

        public int CompareTo(IRollRange other)
        {
            // Falls between
            if (other.From >= From && To <= other.To) return 1;

            if (From > other.From) return 1;

            if (From < other.From) return 0;

            else return -1;
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
