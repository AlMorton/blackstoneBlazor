using BlazorApp.Models.Enemies;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public class EnemiesComponent : ComponentBase
    {
        [Inject]
        public IEnemyService EnemyService { get; private set; }

        public List<Enemy> Enemies { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.Enemies = await EnemyService.Enemies;
        }
    }
}
