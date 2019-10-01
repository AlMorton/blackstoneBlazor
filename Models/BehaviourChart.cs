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
    }
    
    public static class Constants
    {
        public static Dictionary<string, string> Actions = new Dictionary<string, string>
        {
            { "Advance", "Move towards the closest explorer. Then attack the closest explorer that is in range of and visible to this hostile."
            },
            { "Aim", "Attack the furthest explorer that is in range of and visible to this hostile. That attack ignores cover."
            },
            {"Charge", "Move towards the closest explorer. Then attack an explorer that is adjacent and visible to this hostile. If there are no explorers adjacent and visible to this hostile, move towards the closest  explorer a second time."
            },
            {"Fall Back", "Double this hostile's move value when they take this action. If this hostile can make a move that ends in a hex that is not visible to any explorers, they do so. If they cannot, they attack the closest explorer that is in range of and visible to this hostile." },
            {
                "Hold", "Do nothing"
            },
            {
                "Onslaught" ,"Attack the closest explorer that is in range of and visible to this hostile. Then attack the closest explorer that is in range of and visible to this hostile (this may be a different target if the first explorer is taken out of action or another explorer is equally close)."
            },
            {  "Sneak", "Make a move that ends as close as possible to an explorer without entering a hex that is visible to any explorers."
            }
        };
    }
    
}
