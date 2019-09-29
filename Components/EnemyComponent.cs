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

        public bool Style { get; set; }

        [Inject]
        public IDiceRollService DiceRollService { get; private set; }

        public EventCallback<MouseEventArgs> SetStatus(BehaviourChartColumn behaviourChartColumn)
        {
            DiceRoll = DiceRollService.GetRoll();

            Enemy.Status = behaviourChartColumn.GetStatus(DiceRoll);

            return new EventCallback<MouseEventArgs>();
        }
        public void Minimize()
        {
            Style = Style == true ? false : true;
        }        
    }
}
