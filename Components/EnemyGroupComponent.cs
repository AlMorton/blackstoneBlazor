using Microsoft.AspNetCore.Components;
using BlazorApp.Models.Enemies;
using BlazorApp.UIControllers;
using System.Linq;
using BlazorApp.Services;

namespace BlazorApp.Components
{
    public class EnemyGroupComponent : ComponentBase
    {
        [Inject]
        public IEnemyService EnemyService { get; set; }
        public EnemyGroup EnemyGroup { get; set; }

        [Parameter]
        public int GroupNumber { get; set; }

        [Inject]
        public IExpandPanelController ExpandPanelController { get; set; }

        protected override Task OnInitializedAsync()
        {
            return Task.Run(() =>
            {
                EnemyGroup = EnemyService.EnemyGroups[GroupNumber];
            });
        }

        public void CollapseExpand()
        {
            if(EnemyGroup.Enemies.Any())
            {
                ExpandPanelController.ExpandPanel();
            }            
        }
    }
}
