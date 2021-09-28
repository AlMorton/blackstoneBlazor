using BlazorApp.Models.Enemies;

namespace BlazorApp.Models
{
    public class Adventurer : IInitiativeTrackItem
    {
        public string Name { get; set; }
        public string CSSClass { get; set; } 
        public Adventurer(string name)
        {
            Name = name;
            CSSClass = "adventurer";
        }

        public void Addventurer(IList<IInitiativeTrackItem> list)
        {
            CSSClass += " selected";
            list.Add(this);
        }

        public void RemoveAdventurer(IList<IInitiativeTrackItem> list)
        {
            CSSClass = "adventurer";
            list.Remove(this);

        }
    }
}
