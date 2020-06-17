using BlazorApp.Services;
using BlazorApp.UIControllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp
{

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddSingleton<IActionsService, ActionsService>();

            builder.Services.AddSingleton<IEnemyService, EnemyService>();

            builder.Services.AddSingleton<IDiceRollService, DiceRollService>();
            builder.Services.AddTransient<IExpandPanelController, ExpandPanelController>();

            builder.Services.AddScoped<IDice, Dice>(x => {
                return new Dice(20);
            });

            builder.RootComponents.Add<App>("app");
            
            await builder.Build().RunAsync();
            
        }
    }
}
