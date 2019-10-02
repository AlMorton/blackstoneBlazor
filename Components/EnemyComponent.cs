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

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter]
        public bool Removable { get; set; }

        public int DiceRoll { get; set; }     

        public string Action { get; set; }

        public bool IsCollapsed { get; private set; }        

        [Inject]
        public IDiceRollService DiceRollService { get; private set; }

        public EventCallback<MouseEventArgs> SetStatus(BehaviourChartColumn behaviourChartColumn)
        {
            DiceRoll = DiceRollService.GetRoll();

            Enemy.Status = behaviourChartColumn.GetStatus(DiceRoll);

            string action = "";
            Constants.Actions.TryGetValue(Enemy.Status, out action);
            Action = action;

            return new EventCallback<MouseEventArgs>();
        }           
        
        public void Shrink()
        {
            IsCollapsed = (IsCollapsed) ? false : true;
        }

        public DragEventArgs HandleDragStart(DragEventArgs dragEvent)
        {
            Console.WriteLine(dragEvent);
            return dragEvent;
        }
    }
}
