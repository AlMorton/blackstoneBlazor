using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Dice : IRollRange
    {
        public int Sides { get; private set; }
        public int From { get; private set; }
        public int To => From;

        private RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        public Dice(int sides)
        {
            Sides = sides;
        }

        public void RollDice()
        {
            byte[] randomNumber = new byte[1];
            do
            {
                rngCsp.GetBytes(randomNumber);
            }
            while (!IsFairRoll(randomNumber[0]));

            From = (byte)((randomNumber[0] % Sides) + 1);
        }

        private bool IsFairRoll(byte roll)
        {
            int fullSetsOfValues = Byte.MaxValue / Sides;
            
            return roll < Sides * fullSetsOfValues;
        }
    }

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

    public interface IRollRange
    {
        int From { get; }
        int To { get; }
    }

    public class RollRange : IRollRange, IComparer<IRollRange>, IComparable<IRollRange>
    {
        public int From { get; set; }
        public int To { get; set; }
        public string Result { get; set; }

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
