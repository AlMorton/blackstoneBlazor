using BlazorApp.Models;
using BlazorApp.Models.Enemies;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    public class JsonFilesTests
    {
        public BehaviourChartColumn BehaviourChartColumn { get; set; }
        public RollRange RollRange { get; set; }
        public string JSON { get; set; }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OpenDirectoryAndAggregateJsonToOneFile()
        {
            var dir = Directory.GetCurrentDirectory();
            var root = dir.Substring(dir.IndexOf("Test"));
            root = dir.Split(root)[0];
            var files = Directory.GetFiles($"{root}wwwroot\\enemy-data", "*.json");

            var newFileContent = "[";

            foreach (var filePath in files)
            {
                if (!filePath.Contains("enemies"))
                {
                    var fileContent = File.ReadAllText(filePath);
                    newFileContent += fileContent;
                    newFileContent += ",";
                }
            }

            newFileContent += "]";
            // Remove the last comma after the last json object
            newFileContent.LastIndexOf(',');
            newFileContent = newFileContent.Remove(newFileContent.LastIndexOf(','), 1);

            var fs = File.Create($"{root}wwwroot\\enemy-data\\enemies.json");
            fs.Dispose();
            File.WriteAllText($"{root}wwwroot\\enemy-data\\enemies.json", newFileContent);
        }

      
        [Test]
        public void JsonTest()
        {

            string path = @"C:\VisualStudio\BlazorApp\wwwroot\enemy-data\traitor-guard.json";
            var content = File.ReadAllText(path);
            var converted = JsonConvert.DeserializeObject<List<Enemy>>(content);
            var testSubject = converted[0].BehaviourChartColumns[0];

            var diceRoll = 15;

            var x = testSubject.GetStatus(diceRoll);

            Assert.AreEqual(EnemyActionsTest.Charge, x);

        }
    }

    public static class EnemyActionsTest
    {
        public static string Hold { get; } = "Hold";
        public static string Sneak { get; set; } = "Sneak";
        public static string Advance { get; set; } = "Advance";
        public static string Charge { get; set; } = "Charge";
        public static string FallBack { get; set; } = "FallBack";
        public static string Aim { get; set; } = "Aim";
        public static string Onslaught { get; set; } = "Onslaught";
    }
}