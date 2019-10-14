using BlazorApp.Pages;
using BlazorApp.Services;
using BlazorApp.UIControllers;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IActionsService, ActionsService>();

            services.AddSingleton<IEnemyService, EnemyService>();

            services.AddSingleton<IDiceRollService, DiceRollService>();
            services.AddTransient<IExpandPanelController, ExpandPanelController>();

            services.AddScoped<IDice, Dice>(x => {
                return new Dice(20);
            });            
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
             
        }
    }
}
