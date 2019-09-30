using BlazorApp.Models.Enemies;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System;

namespace BlazorApp.Services
{
    public interface IEnemyService
    {
        Task<List<Enemy>> Enemies { get; }

        List<Enemy> ArenaEnemies { get; }
    }
    public class EnemyService : IEnemyService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _NavigationManager;

        private List<Enemy> _enemies;
        public Task<List<Enemy>> Enemies { get; set; }
        public List<Enemy> ArenaEnemies { get; private set; } = new List<Enemy>();

        public EnemyService(NavigationManager navigationManager, HttpClient httpClient)
        {
            _NavigationManager = navigationManager;
            _http = httpClient;
            SetEnemies();
        }
        private void SetEnemies()
        {
            Enemies = Del();
        }

        private async Task<List<Enemy>> Del()
        {
            var baseUri = _NavigationManager.BaseUri;
            if (_enemies is null)
            {
                _enemies = await _http.GetJsonAsync<List<Enemy>>($"{baseUri}enemy-data/enemies.json");
            }

            return this._enemies;
        }
    }
}
