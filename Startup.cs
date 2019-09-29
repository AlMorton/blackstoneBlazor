using BlazorApp.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IEnemyService, EnemyService>();

            services.AddSingleton<IDiceRollService, DiceRollService>();

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
