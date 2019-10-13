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
        public ModalDTO<KeyValuePair<int, List<Enemy>>> ModalDTO { get; set; }
        protected override async Task OnInitializedAsync()
        {
           
            Loading = true;
            Enemies = await EnemyService.Enemies;
            ArenaEnemies = EnemyService.ArenaEnemies;
            Loading = false;            
        }
        public void ToggleModal(int group)
        {
            var groupData = new KeyValuePair<int, List<Enemy>>(group, new List<Enemy>());    
            ModalDTO = new ModalDTO<KeyValuePair<int, List<Enemy>>>(this.StateHasChanged);
            ModalDTO.Data = groupData;
            ModalDTO.SetShowModal();
        }
    }
}
