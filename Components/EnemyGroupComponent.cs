using BlazorApp.Models.Enemies;
using BlazorApp.UIControllers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Components
{
    public class EnemyGroupComponent : Component
    {
        [Parameter]
        public EnemyGroup EnemyGroup { get; set; }

        [Inject]
        public IExpandPanelController ExpandPanelController { get; set; }
    }
}
