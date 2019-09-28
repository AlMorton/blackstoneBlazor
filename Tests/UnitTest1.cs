using BlazorApp.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;

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

            var annoyingFuckingBackSlashRemoved = json.Replace(@"\\" , string.Empty);

            Assert.Pass();
        }
    }
}