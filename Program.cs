using BlazorApp;
using BlazorApp.Services;
using BlazorApp.UIControllers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IActionsService, ActionsService>();

builder.Services.AddScoped<IEnemyService, EnemyService>();

builder.Services.AddScoped<IDiceRollService, DiceRollService>();
builder.Services.AddTransient<IExpandPanelController, ExpandPanelController>();

builder.Services.AddScoped<IDice, Dice>(x =>
{
    return new Dice(20);
});

builder.RootComponents.Add<App>("app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();




