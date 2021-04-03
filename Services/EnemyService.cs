using BlazorApp.Models.Enemies;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Text.Json;

namespace BlazorApp.Services
{
    public interface IEnemyService
    {
        Task<List<Enemy>> Enemies { get; }
        List<Enemy> ArenaEnemies { get; }
        List<IInitiativeTrackItem> InitiativeTrack { get; set; }
        Dictionary<int, EnemyGroup> EnemyGroups { get; set; }     
        void AddEnemyToGroup(int group, Enemy enemy);
    }
    public class EnemyService : IEnemyService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        private List<Enemy> _enemies;
        public Task<List<Enemy>> Enemies { get; set; }
        public List<Enemy> ArenaEnemies { get; private set; }
        public Dictionary<int, EnemyGroup> EnemyGroups { get; set; }
        public List<IInitiativeTrackItem> InitiativeTrack { get; set; }

        public EnemyService(NavigationManager navigationManager, HttpClient httpClient)
        {
            _navigationManager = navigationManager;
            _http = httpClient;
            SetEnemies();
            ArenaEnemies = new List<Enemy>();
            InitiativeTrack = new List<IInitiativeTrackItem>();
            SetupGroups();
        }

        public void AddEnemyToGroup(int group, Enemy enemy)
        {
            // Fill out
            if (EnemyGroups[group].Enemies.IndexOf(enemy) == -1)
            {
                EnemyGroups[group].Enemies.Add(enemy);                
            }
            else
            {               
                EnemyGroups[group].Enemies.Remove(enemy);
            }

            AddGroupToInitiativeTrack(group);
        }

        public void AddGroupToInitiativeTrack(int group)
        {
            if (EnemyGroups[group].Enemies.Any() && InitiativeTrack.IndexOf(EnemyGroups[group]) == -1)
            {
                InitiativeTrack.Add(EnemyGroups[group]);
            }
            else if (!EnemyGroups[group].Enemies.Any())
            {
                InitiativeTrack.Remove(EnemyGroups[group]);
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
                var data = await _http.GetStringAsync($"{baseUri}enemy-data/enemies.json");
                _enemies = JsonSerializer.Deserialize<List<Enemy>>(data);
            }

            return this._enemies;
        }
        
        private void SetupGroups()
        {
            EnemyGroups = new Dictionary<int, EnemyGroup>();
            for (int i = 1; i < 9; i++)
            {
                EnemyGroups.Add(i, new EnemyGroup(i));
            }
        }
    }
}
