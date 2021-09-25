using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Action = BlazorApp.Models.EnemyAction;

namespace BlazorApp.Services
{
    public interface IActionsService
    {
        List<EnemyActions> EnemyActions { get; set; }
        Dictionary<string, string> Actions { get; set;}
    }

    public class ActionsService : IActionsService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ActionsService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;

            var t = new Task(async () =>
            {
                await SetEnemyActionsAsync();
            });
            t.RunSynchronously();
        }

        public List<EnemyActions> EnemyActions { get; set; }
        public Dictionary<string, string> Actions { get; set; }

        private async Task SetEnemyActionsAsync()
        {
            var baseUri = _navigationManager.BaseUri;

            var data = await _http.GetStringAsync($"{baseUri}enemy-actions/enemy-actions.json");

            EnemyActions = JsonSerializer.Deserialize<List<EnemyActions>>(data);

            Actions = EnemyActions.SelectMany(ea => ea.Actions)
                .GroupBy(ac => ac.Name, ac => ac.Description)
                .ToDictionary(ac => ac.Key, ac => ac.First());
        }

    }
}
