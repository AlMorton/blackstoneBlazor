using System.Collections.Generic;

namespace BlazorApp.Models
{
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
            {"Onslaught" ,"Attack the closest explorer that is in range of and visible to this hostile. Then attack the closest explorer that is in range of and visible to this hostile (this may be a different target if the first explorer is taken out of action or another explorer is equally close)."
            },
            {"Sneak", "Make a move that ends as close as possible to an explorer without entering a hex that is visible to any explorers."
            }
        };

        public static Dictionary<string, string> RoguePsyker = new Dictionary<string, string>
        {
            {"Annihilate", "Place the empowered marker beside the Rogue Psyker. Then attack an explorer that is adjacent and visible to this hostile. Re-roll failed attack rolls for that attack. The Rogue Psyker remains empowered until they suffer a wound or grievous wound."
            },
            {"Disrupt", "One unspent activation or destiny dice chosen by the hostile player is discarded and cannot be spent this turn. If no unspent activation or destiny dice are available, one explorer chosen by the hostile player suffers a wound. "
            },
            {"Empower", "Place the empowered marker beside the Rogue Psyker. If the Rogue Psyker is already empowered, treat this result as a Disrupt result instead. \"The Rogue Psyker remains empowered until they suffer a wound or grievous wound.\""
            },
            {"Regenerate", "Remove a wound counter from the Rogue Psyker. If the Rogue Psyker does not have a wound counter, treat this result as a Disrupt result instead."
            }
        };

        public static Dictionary<string, string> SpindleDrone = new Dictionary<string, string>
        {
            {"Alert", "Increase the threat level by 1 (see the Threat Level special rule on the other side of this reference card) and then take an Onslaught action. If the threat level is 3, take an Onslaught action and re-roll failed attack rolls for that action instead."
            },           
        };
        public static Dictionary<string, string> TraitorGuard = new Dictionary<string, string>
        {
            {"Fury", "Take an Onslaught action. Re-roll failed attack rolls for that action."
            },
            {"Rush", "Move towards the closest explorer. Then take a Charge action."
            },
        };
        public static Dictionary<string, string> ChaosBeastman = new Dictionary<string, string>
        {
            {"Fury", "Take an Onslaught action. Re-roll failed attack rolls for that action."
            },
            {"Rush", "Move towards the closest explorer. Then take a Charge action."
            },
        };
        public static Dictionary<string, string> NegavoltCultist = new Dictionary<string, string>
        {
            {"Fury", "Take an Onslaught action. Re-roll failed attack rolls for that action."
            },
            {"Recharge", "Remove a wound counter from the Negavolt Cultist. If the Negavolt Cultist does not have a wound counter, treat this result as an Advance result instead. "
            },
            {"Rush", "Move towards the closest explorer. Then take a Charge action."
            }
        };
        public static Dictionary<string, string> UrGhul= new Dictionary<string, string>
        {
            {"Pounce", " If there is an explorer adjacent and visible to this Ur-Ghul, take an Onslaught action. Otherwise, take a Charge action. Re-roll failed attack rolls for whichever action."
            },            
            {"Rush", "Move towards the closest explorer. Then take a Charge action."
            }
        };
        public static Dictionary<string, string> ChaosSpaceMarine = new Dictionary<string, string>
        {
            {"Rapid Fire", "Take an Onslaught action. Re-roll failed attack rolls for that action."
            },
            {"Rush", "Move towards the closest explorer. Then take a Charge action."
            }
        };
        public static Dictionary<string, string> ObsidiusMallex = new Dictionary<string, string>
        {
            {"Fury", "Take an Onslaught action. Re-roll failed attack rolls for that action."
            },
            {"Overcharge", "Make an overcharged Plasma Pistol attack against the closest explorer that is in range of and visible to Obsidius Mallex."
            },
            {"Rush", "Move towards the closest explorer. Then take a Charge action."
            }
        };
    }

}
