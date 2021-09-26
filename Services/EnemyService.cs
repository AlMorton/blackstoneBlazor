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
        Dictionary<int, EnemyGroup> EnemyGroups { get;  }     
        void AddEnemyToGroup(int group, Enemy enemy);
    }
    public class EnemyService : IEnemyService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        private List<Enemy> _enemies = new List<Enemy>();
        public Task<List<Enemy>> Enemies => SetEnemiesFromJsonAsync();
        public List<Enemy> ArenaEnemies { get; private set; }
        public Dictionary<int, EnemyGroup> EnemyGroups { get; private set; }
        public List<IInitiativeTrackItem> InitiativeTrack { get; set; }

        public EnemyService(NavigationManager navigationManager, HttpClient httpClient)
        {
            _navigationManager = navigationManager;
            _http = httpClient;           
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

        private async Task<List<Enemy>> SetEnemiesFromJsonAsync()
        {
            if (_enemies.Count > 0) return _enemies;

            var baseUri = _navigationManager.BaseUri;
            
            foreach (var enemyFileName in EnemyFileNameConstants.EnemyFileNames)
            {
                var data = await _http.GetStringAsync($"{baseUri}enemy-data/{enemyFileName}.json");

                if (data is null) throw new Exception("enemies.json contains no entries");

                var enemy = JsonSerializer.Deserialize<Enemy>(data) ?? throw new Exception("Enable to deserialize enemies.json");

                _enemies.Add(enemy);
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

    public static class EnemyFileNameConstants
    {
        public static string[] EnemyFileNames = new string[14] { 
            Ambull,AmbullEnraged,BorewyrmInfestation,
            ChaosBeastman,ChaosSpaceMarine, CultistFireBrand, 
            Cultist, NegavoltCultist, ObsidiusMallex,ObsidiusMallexEmpowered,
            RoguePsyker, SpindleDrone, TraitorGuard, UrGhul};

        public const string Ambull = "ambull";
        public const string AmbullEnraged = "ambull-enraged";
        public const string BorewyrmInfestation = "borewyrm-infestation";
        public const string ChaosBeastman = "chaos-beastman";
        public const string ChaosSpaceMarine = "chaos-spacemarine";
        public const string CultistFireBrand = "cultist-firebrand";
        public const string Cultist = "cultist";
        public const string NegavoltCultist = "negavolt-cultist";
        public const string ObsidiusMallex = "obsidius-mallex";
        public const string ObsidiusMallexEmpowered = "obsidius-mallex-empowered";
        public const string RoguePsyker = "rogue-psyker";
        public const string SpindleDrone = "spindle-drone";
        public const string TraitorGuard = "traitor-guard";
        public const string UrGhul = "ur-ghul";


    }
}
