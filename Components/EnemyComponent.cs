using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models.Enemies;
using BlazorApp.Services;
using BlazorApp.Models;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp.Components
{
    public class EnemyComponent : ComponentBase
    {
        [Parameter]
        public Enemy Enemy { get; set; }

        public int DiceRoll { get; set; }

        [Inject]
        public IDiceRollService DiceRollService { get; private set; }

        public EventCallback<MouseEventArgs> SetStatus(BehaviourChartColumn behaviourChartColumn)
        {
            var result = DiceRollService.GetRoll();

            DiceRoll = result.From;

            Enemy.Status = behaviourChartColumn.GetStatus(result);

            return new EventCallback<MouseEventArgs>();
        }
        
    }
}
