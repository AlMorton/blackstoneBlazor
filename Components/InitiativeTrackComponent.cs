﻿using BlazorApp.Models;
using BlazorApp.Models.Enemies;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Components
{
    public class InitiativeTrackComponent : ComponentBase
    {
        [Inject]
        public IEnemyService EnemyService { get; private set; }
        [Parameter]
        public List<Enemy> Enemies { get; set; }
        public List<Adventurer> Adventurers { get; set; }
        public List<IHasName> InitiativeTrack { get; set; }
        public IHasName DraggedOver { get; set; }
        public IHasName BeingDragged { get; set; }
        public string DraggedStyle { get; set; }

        protected override void OnInitialized()
        {   
            Adventurers = AdventurersConstants.Adventurers;
            InitiativeTrack = EnemyService.InitiativeTrack;
        }

        public void AddAdventurer(IHasName adventurer)
        {
            if (InitiativeTrack.IndexOf(adventurer) == -1)
            {
                InitiativeTrack.Add(adventurer);
            }
            else
            {
                InitiativeTrack.Remove(adventurer);
            }
        }

        public void Shuffle()
        {
            var length = InitiativeTrack.Count;
            var maxNumber = length;
            Random random = new Random();
            var movedToHistory = new Dictionary<int, IHasName>();

            for (int i = length - 1; i > 0; i--)
            {
                var moveOne = random.Next(0, maxNumber);
                // We don't want the move to be the same as current index
                // moveTwo = random.Next(0, length);  
                if (!movedToHistory.ContainsKey(moveOne))
                {
                    var currentItem = InitiativeTrack[i];
                    var moveTo = InitiativeTrack[moveOne];
                    InitiativeTrack[moveOne] = currentItem;
                    InitiativeTrack[i] = moveTo;
                    movedToHistory.Add(moveOne, currentItem);
                }
                maxNumber--;
            }
        }
        public void HandleDragEnter()
        {

        }

        public void HandleDragLeave()
        {

        }

        public string SetDragStyle(IHasName hasName)
        {
            if (hasName == BeingDragged)
            {
                return "dragged";
            }
            return "";
        }
        public void OnBeingDragged(DragEventArgs e, IHasName hasName)
        {
            e.DataTransfer.DropEffect = "move";
            BeingDragged = hasName;
        }

        public void OnDraggedOver(DragEventArgs e, IHasName hasName)
        {
            DraggedOver = hasName;
        }

        public void HandleDrop()
        {
            var iOne = InitiativeTrack.IndexOf(BeingDragged);
            var iTwo = InitiativeTrack.IndexOf(DraggedOver);
            // Swap them over
            InitiativeTrack[iOne] = DraggedOver;
            InitiativeTrack[iTwo] = BeingDragged;
            DraggedOver = null;
            BeingDragged = null;
        }
    }
}
