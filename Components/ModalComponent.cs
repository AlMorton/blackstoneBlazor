using Microsoft.AspNetCore.Components;
using System;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;
using BlazorApp.Models.Enemies;
using BlazorApp.Services;
using BlazorApp.Models;

namespace BlazorApp.Components
{
    public class ModalComponent : ComponentBase
    {
        [Parameter]
        public ModalDTO<Enemy> ModalDTO { get; set; } 
        
        public Enemy Enemy { get; set; }

        [Inject]
        public IEnemyService EnemyService { get; set; }

        public void Close()
        {
            ModalDTO.ShowModal = "";
        }
    }
}
