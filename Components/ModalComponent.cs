﻿using Microsoft.AspNetCore.Components;
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
               
        public int Group { get; set; }

        [Inject]
        public IEnemyService EnemyService { get; set; }        
        
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();


        protected override void OnParametersSet()
        {
            Group = ModalDTO.Data;
            base.OnParametersSet();
        }

        protected override async Task OnInitializedAsync()
        {
            Enemies = await EnemyService.Enemies;              
        }
        
        public async Task SaveAsync(MouseEventArgs arg)
        {            
            await ModalDTO.EventCallback.InvokeAsync(arg);
        }

        public void AddEnemyToGroup(Enemy enemy)
        {
            EnemyService.AddEnemyToGroup(ModalDTO.Data, enemy);                   
        }

        public string IsInGroup(Enemy enemy)
        {               
            return EnemyService.EnemyGroups[ModalDTO.Data].Enemies.Contains(enemy) ? "selected" : "";
        }
    }
}
