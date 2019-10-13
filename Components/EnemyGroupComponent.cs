using Microsoft.AspNetCore.Components;
using BlazorApp.Models.Enemies;
using BlazorApp.UIControllers;

namespace BlazorApp.Components
{
    public class EnemyGroupComponent : ComponentBase
    {
        [Parameter]
        public EnemyGroup EnemyGroup { get; set; }

        [Inject]
        public IExpandPanelController ExpandPanelController { get; set; }
    }
}
