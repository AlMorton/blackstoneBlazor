using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models.Enemies;

namespace BlazorApp.Components
{
    public class EnemyComponent : ComponentBase
    {
        [Parameter]
        public Enemy Enemy { get; set; }
        [Parameter]
        public EventCallback<Enemy> EnemyChanged { get; set; }
        public string Name { get; set; }
        
    }
}
