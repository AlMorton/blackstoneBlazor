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
        List<IAttributes> InitiativeTrack { get; set; }
        Dictionary<int, List<Enemy>> EnemyGroups { get; set; }     
        void AddEnemyToGroup(int group, Enemy enemy);
    }
    public class EnemyService : IEnemyService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        private List<Enemy> _enemies;
        public Task<List<Enemy>> Enemies { get; set; }
        public List<Enemy> ArenaEnemies { get; private set; }
        public Dictionary<int, List<Enemy>> EnemyGroups { get; set; }
        public List<IAttributes> InitiativeTrack { get; set; }

        public EnemyService(NavigationManager navigationManager, HttpClient httpClient)
        {
            _navigationManager = navigationManager;
            _http = httpClient;
            SetEnemies();
            ArenaEnemies = new List<Enemy>();
            InitiativeTrack = new List<IAttributes>();
            SetupGroups();
        }

        public void AddEnemyToGroup(int group, Enemy enemy)
        {
            // Fill out
            if (EnemyGroups[group].IndexOf(enemy) == -1)
            {
                EnemyGroups[group].Add(enemy);
            }
            else
            {               
                EnemyGroups[group].Remove(enemy);
            }
        }
        private void SetEnemies()
        {
            Enemies = Del();
        }        

        private async Task<List<Enemy>> Del()
        {
            var baseUri = _navigationManager.BaseUri;

            if (_enemies is null)
            {
                _enemies = await _http.GetJsonAsync<List<Enemy>>($"{baseUri}enemy-data/enemies.json");
            }

            return this._enemies;
        }
        
        private void SetupGroups()
        {
            EnemyGroups = new Dictionary<int, List<Enemy>>();
            for (int i = 1; i < 4; i++)
            {
                EnemyGroups.Add(i, new List<Enemy>());
            }
        }
    }
}
