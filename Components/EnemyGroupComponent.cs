using Microsoft.AspNetCore.Components;
using BlazorApp.Models.Enemies;
using BlazorApp.UIControllers;
using System.Linq;

namespace BlazorApp.Components
{
    public class EnemyGroupComponent : ComponentBase
    {
        [Parameter]
        public EnemyGroup EnemyGroup { get; set; }

        [Inject]
        public IExpandPanelController ExpandPanelController { get; set; }

        public void CollapseExpand()
        {
            if(EnemyGroup.Enemies.Any())
            {
                ExpandPanelController.ExpandPanel();
            }            
        }
    }
}
