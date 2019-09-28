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
        public void JsonTest()
        {
            string path = @"C:\VisualStudio\BlazorApp\wwwroot\sample-data\test.json";
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
            var d = DateTimeOffset.Now;
            var date = TimeZoneInfo.ConvertTime(d, TimeZoneInfo.FindSystemTimeZoneById("US Eastern Standard Time"));
        }

        [Test]
        public void Test1()
        {
            BehaviourChartColumn = new BehaviourChartColumn();
            string json = JsonConvert.SerializeObject(BehaviourChartColumn, Formatting.None);

            var annoyingFuckingBackSlashRemoved = json.Replace(@"\\", string.Empty);

            Assert.Pass();
        }
    }
}