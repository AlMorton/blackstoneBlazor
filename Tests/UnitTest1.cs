using BlazorApp.Models;
using BlazorApp.Models.Enemies;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
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
            var files = Directory.GetFiles(@"C:\VisualStudio\BlazorApp\wwwroot\enemy-data", "*.json");

            var newFileContent = "[";

            foreach(var filePath in files)
            {
                if(!filePath.Contains("enemies"))
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

            var fs = File.Create(@"C:\VisualStudio\BlazorApp\wwwroot\enemy-data\enemies.json");
            fs.Dispose();
            File.WriteAllText(@"C:\VisualStudio\BlazorApp\wwwroot\enemy-data\enemies.json", newFileContent);
        }

        [Test]
        public void JsonTest()
        {
            
            string path = @"C:\VisualStudio\BlazorApp\wwwroot\enemy-data\traitor-guard.json";
            var content = File.ReadAllText(path);
            var converted = JsonConvert.DeserializeObject<List<Enemy>>(content);
            var testSubject = converted[0].BehaviourChartColumns[0];

            var diceRoll = new RollRange
            {
                From = 15,
                To = 15
            };

            var x = testSubject.GetStatus(diceRoll);

            Assert.AreEqual(EnemyActions.Charge, x);

        }

        [Test]
        public void TimeZone()
        {
            // This doesn't work in blazor, sadly. Probably because none of the system timezones work from the browser.
            var d = DateTimeOffset.Now;
            var date = TimeZoneInfo.ConvertTime(d, TimeZoneInfo.FindSystemTimeZoneById("US Eastern Standard Time"));
        }
       
    }
}