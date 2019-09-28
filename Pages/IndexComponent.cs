using BlazorApp.Models.Enemies;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public class IndexComponent : ComponentBase
    {
        [Inject]
        public  HttpClient Http { get; private set; }

        [Parameter]
        public RenderFragment Enemy { get; set; }

        public List<Enemy> Enemies { get; set; }

        private void OpenFiles()
        {
            var content = File.ReadAllText("enemy-data/traitor-guard.json");
            Enemies = JsonConvert.DeserializeObject<List<Enemy>>(content);
        }

        protected override async Task OnInitializedAsync()
        {
            OpenFiles();
            //Enemies = await Http.GetJsonAsync<List<Enemy>>("enemy-data/traitor-guard.json");
        }
    }
}
