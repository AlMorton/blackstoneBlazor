using BlazorApp.Models.Enemies;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Components
{
    public class InitiativeTrackComponent : ComponentBase
    {
        [Inject]
        public IEnemyService EnemyService { get; private set; }
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();

        protected override async Task OnInitializedAsync()
        {
            Enemies = await EnemyService.ArenaEnemies;            
        }      
        
        public void Shuffle()
        {
            var length = Enemies.Count;
            var totalToShuffle = length;

            Random random = new Random();           

            for (int i = 0; i < length; i++)
            {
                var moveTo = random.Next(i, length);

                var temp = Enemies[moveTo];
                var tempTwo = Enemies[i];
                Enemies[i] = temp;
                Enemies[moveTo] = tempTwo;
            }
        }
        public void HandleDragEnter()
        {
            
        }

        public void HandleDragLeave()
        {
            
        }

        public async Task HandleDrop()
        {
           
        }

        public void Reorder(DragEventArgs e, Enemy enemy)
        {   

        }
    }
}
