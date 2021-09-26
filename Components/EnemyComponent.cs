using Microsoft.AspNetCore.Components;
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

        public bool IsCollapsed { get; private set; }        

        [Inject]
        public IDiceRollService DiceRollService { get; private set; }
        [Inject]
        public IActionsService ActionsService { get; set; }

        public EventCallback<MouseEventArgs> SetStatus(BehaviourChartColumn behaviourChartColumn)
        {
            DiceRoll = DiceRollService.GetRoll();

            Enemy.Status = behaviourChartColumn.GetStatus(DiceRoll);

            string action = "";
            ActionsService.Actions.TryGetValue(Enemy.Status, out action);
            Enemy.Action = action;

            return new EventCallback<MouseEventArgs>();
        }           
        
        public void Shrink()
        {
            IsCollapsed = !IsCollapsed;
        }
    }
}
