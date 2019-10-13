using System.Collections.Generic;
using System.ComponentModel;

namespace BlazorApp.Models.Enemies
{
    public class EnemyGroup : IInitiativeTrackItem
    {
        public string Name { get; set; }
        public string CSSClass { get; set; } = "enemy";
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();

        public EnemyGroup(int groupNumber)
        {
            Name = $"Group {groupNumber}";
        }
    }
}
