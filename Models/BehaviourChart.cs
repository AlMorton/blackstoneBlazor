using BlazorApp.Models.Enemies;
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

    public static class AdventurersConstants
    {
        public static List<Adventurer> Adventurers = new List<Adventurer>
        {
            new Adventurer("Janus Drake"),
            new Adventurer("Espern Locarno"),
            new Adventurer("Taddeus The Purifier"),
            new Adventurer("Pious Vorne"),
            new Adventurer("Amallyn Shadowdguide"),
            new Adventurer("Dahyak Grekh"),
            new Adventurer("UR-025"),
            new Adventurer("Rein & Raus"),
        };
    }

    public class Adventurer : IHasName
    {
        public string Name { get; set; }
        public Adventurer(string name)
        {
            Name = name;
        }
    }

    

}
