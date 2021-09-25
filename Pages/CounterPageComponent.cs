using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using System.Timers;
using BlazorApp.Models;
using BlazorApp.Services;

namespace BlazorApp.Pages
{
    public class CounterPageComponent : ComponentBase
    {
        [Inject]
        public IDiceRollService Dice { get; set; }
        public DateTimeOffset Date { get; set; }

        public EventCallback DiceRollResult { get; set; }

        public List<NameForm> Names = new List<NameForm>
        {
            new NameForm("Alice"),
            new NameForm("Bob"),
            new NameForm("John"),
            new NameForm("Gilbert"),
            new NameForm("Sullivan")
        };

        public string Message { get; set; }

        public CounterPageComponent()
        {
            
            // This errors in the browser
            var tz = TimeZoneInfo.Utc;
            var d = DateTimeOffset.Now;
            Date = TimeZoneInfo.ConvertTime(d, tz);
        }

        public EventCallback RollDice()
        {
            var result = this.Dice.GetRoll();
            DiceRollResult = new EventCallback();
            return DiceRollResult;
        }

        public void UpdateView()
        {
            this.StateHasChanged();
        }      
       
    }

    public class NameForm
    {
        public string Name { get; set; }

        public bool Attending { get; set; }

        public NameForm(string name)
        {
            Name = name;
        }
    }
}
