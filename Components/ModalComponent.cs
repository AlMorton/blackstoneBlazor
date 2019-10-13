using Microsoft.AspNetCore.Components;
using System;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;
using BlazorApp.Models.Enemies;
using BlazorApp.Services;
using BlazorApp.Models;
using System.Collections.Generic;

namespace BlazorApp.Components
{
    public class ModalComponent : ComponentBase
    {
        [Parameter]
        public ModalDTO<int> ModalDTO { get; set; } 

        [Inject]
        public IEnemyService EnemyService { get; set; }        
        
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();

        protected override async Task OnInitializedAsync()
        {
            Enemies = await EnemyService.Enemies;            
        }
        public void Close()
        {
            ModalDTO.SetShowModal();            
        }
        
        public async Task SaveAsync(MouseEventArgs arg)
        {              
            await ModalDTO.EventCallback.InvokeAsync(arg);
        }

        
    }
}
