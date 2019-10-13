using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorApp.Services;
using BlazorApp.Models.Enemies;
using BlazorApp.UIControllers;
using System;
using Microsoft.AspNetCore.Components.Web;
using BlazorApp.Models;

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
        public ModalDTO<int> ModalDTO { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ModalDTO = new ModalDTO<int>(this.StateHasChanged);
            Loading = true;
            Enemies = await EnemyService.Enemies;
            ArenaEnemies = EnemyService.ArenaEnemies;
            Loading = false;            
        }       

        public void AddEnemy(Enemy enemy)
        {
            Console.WriteLine("Add enemy called");
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
