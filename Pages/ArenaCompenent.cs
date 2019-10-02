using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorApp.Services;
using BlazorApp.Models.Enemies;

namespace BlazorApp.Pages
{
    public class ArenaCompenent : ComponentBase
    {
        [Inject]
        public IEnemyService EnemyService { get; private set; }
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        public List<Enemy> ArenaEnemies { get; set; } = new List<Enemy>();
        public bool Loading { get; set; }
        public bool IsExpanded { get; private set; } 
        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            Enemies = await EnemyService.Enemies;
            ArenaEnemies = await EnemyService.ArenaEnemies;
            Loading = false;         
        }

        public void AddEnemy(Enemy enemy)
        {
            if (ArenaEnemies.IndexOf(enemy) == -1)
            {
                ArenaEnemies.Add(enemy);
            }
            else
            {
                ArenaEnemies.Remove(enemy);
            }            
        }

        public void ExpandPanel()
        {
            IsExpanded = (IsExpanded == true) ? false : true;            
        }
    }
}
