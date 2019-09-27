using System;
using System.Collections.Generic;

namespace BlazorApp.Models
{

    public class BehaviourChartColumn 
    {
        public string Status { get; set; }
        public List<IRollRange> Actions { get; set; }    
        public BehaviourChartColumn()
        {
            this.Status = StatusEnum.Hidden.ToString();
            Actions = new List<IRollRange>();
            Actions.Add(new RollRange(1, 3, EnemyActions.Hold));
            Actions.Add(new RollRange(4, 6, EnemyActions.Sneak));
            Actions.Add(new RollRange(7, 12, EnemyActions.Advance));
            Actions.Add(new RollRange(13, 19, EnemyActions.Charge));
            Actions.Add(new RollRange(20, 20, "Rush"));            
        }

        public string GetStatus(IRollRange roll)
        {
            Actions.BinarySearch(roll);
            return "";
            //return Actions[roll];
        }
    }

    public interface IRollRange : IComparable<IRollRange>
    {
        int From { get; }
        int To { get; }
    }

    public class RollRange : IRollRange, IComparer<IRollRange>
    {
        public int From { get; set; }
        public int To { get; set; }
        public string ActionTaken { get; set; } 
        public RollRange(int from, int to, string action)
        {
            From = from;
            To = to;
            ActionTaken = action;
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
