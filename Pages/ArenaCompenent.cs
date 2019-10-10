using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorApp.Services;
using BlazorApp.Models.Enemies;
using BlazorApp.UIControllers;

namespace BlazorApp.Pages
{
    public class ArenaCompenent : ComponentBase
    {
        [Inject]
        public IEnemyService EnemyService { get; private set; }
        [Inject]
        public IExpandPanelController ExpandPanelController { get; set; }
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        public List<Enemy> ArenaEnemies { get; set; } = new List<Enemy>();
        public bool Loading { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            Enemies = await EnemyService.Enemies;
            ArenaEnemies = EnemyService.ArenaEnemies;
            Loading = false;         
        }
        public void AddEnemy(Enemy enemy)
        {
            if (EnemyService.ArenaEnemies.IndexOf(enemy) == -1)
            {
                EnemyService.ArenaEnemies.Add(enemy);
                EnemyService.InitiativeTrack.Add(enemy);
            }
            else
            {
                EnemyService.ArenaEnemies.Remove(enemy);
                EnemyService.InitiativeTrack.Remove(enemy);
            }        
        }
        
    }
}
