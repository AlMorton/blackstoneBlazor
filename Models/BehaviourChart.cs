using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class BehaviourChart 
    {
        public Status Status { get; set; }
        public SortedList<RollRange, string> Actions { get; set; }

        public BehaviourChart()
        {
            Actions = new SortedList<RollRange, string>();
        }

        public void GetStatus(int diceRoll)
        {
           
        }
    }

    public class RollRange : IComparer<RollRange>, IComparable<RollRange>
    {
        public int From { get; set; }
        public int To { get; set; }
        public string Result { get; set; }

        public int Compare(RollRange x, RollRange y)
        {
            if (x.From > y.From) return 1;
            if (x.From < y.From) return -1;
            else return 0;            
        }

        public int CompareTo(RollRange other)
        {
            // Falls between
            if (other.From >= From && To <= other.To) return 1;

            if (From > other.From) return 1;

            if (From < other.From) return 0;

            else return -1;
        }
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
