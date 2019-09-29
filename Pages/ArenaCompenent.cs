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

        public List<Enemy> Enemies { get; set; }

        public List<Enemy> ArenaEnemies { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ArenaEnemies = new List<Enemy>();
            this.Enemies = await EnemyService.Enemies;
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
    }
}
