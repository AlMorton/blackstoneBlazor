using BlazorApp.Models.Enemies;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.IO;
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

        public string StreamReaderContent { get; set; }

        public List<Enemy> Enemies { get; set; }        

        protected override async Task OnInitializedAsync()
        {
            Enemies = await Http.GetJsonAsync<List<Enemy>>("enemy-data/enemies.json");
        }
    }
}
