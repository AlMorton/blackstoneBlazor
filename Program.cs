using BlazorApp.Services;
using BlazorApp.UIControllers;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;
using System;

namespace BlazorApp
{

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<IActionsService, ActionsService>();

            builder.Services.AddScoped<IEnemyService, EnemyService>();

            builder.Services.AddScoped<IDiceRollService, DiceRollService>();
            builder.Services.AddTransient<IExpandPanelController, ExpandPanelController>();

            builder.Services.AddScoped<IDice, Dice>(x => {
                return new Dice(20);
            });

            builder.RootComponents.Add<App>("app");
            
            await builder.Build().RunAsync();
            
        }
    }
}
