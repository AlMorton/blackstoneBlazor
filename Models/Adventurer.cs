using BlazorApp.Models.Enemies;

namespace BlazorApp.Models
{
    public class Adventurer : IAttributes
    {
        public string Name { get; set; }
        public string CSSClass { get; set; }
        public Adventurer(string name)
        {
            Name = name;
        }
    }
}
