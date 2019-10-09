using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Action = BlazorApp.Models.Action;

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

            EnemyActions = await _http.GetJsonAsync<List<EnemyActions>>($"{baseUri}enemy-actions/enemy-actions.json");
            Actions = EnemyActions.SelectMany(ea => ea.Actions)
                .GroupBy(ac => ac.Name, ac => ac.Description)
                .ToDictionary(ac => ac.Key, ac => ac.First());
        }

    }
}
