using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Components;
using System.Timers;
using BlazorApp.Models;

namespace BlazorApp.Pages
{
    public class CounterPageComponent : ComponentBase
    {
        public Dice Dice = new Dice(20);

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
            
        }

        public void UpdateView()
        {
            this.StateHasChanged();
        }
        public void IncrementCount()
        {
            Dice.RollDice();
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
