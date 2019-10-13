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
        public ModalDTO<KeyValuePair<int, List<Enemy>>> ModalDTO { get; set; } 

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
            EnemyService.AddEnemyToGroup(ModalDTO.Data);
            await ModalDTO.EventCallback.InvokeAsync(arg);
        }
        public void AddEnemyToGroup(Enemy enemy)
        {            
            if (ModalDTO.Data.Value.IndexOf(enemy) == -1)
            {
                enemy.Group = ModalDTO.Data.Key;
                ModalDTO.Data.Value.Add(enemy);                
            }
            else
            {
                enemy.Group = 0;
                ModalDTO.Data.Value.Remove(enemy);                
            }
            Console.WriteLine(ModalDTO.Data.Value.Count);
        }

        public string IsInGroup(Enemy enemy)
        {
            var isInGroup = enemy.Group == ModalDTO.Data.Key;
            return isInGroup ? "selected" : "";
        }
    }
}
