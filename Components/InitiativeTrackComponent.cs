using BlazorApp.Models;
using BlazorApp.Models.Enemies;
using BlazorApp.Pages;
using BlazorApp.Services;
using BlazorApp.UIControllers;
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

        [Inject]
        public IExpandPanelController ExpandPanelController { get; set; }

        [Parameter]
        public List<Enemy> Enemies { get; set; }
        public List<Adventurer> Adventurers { get; set; }
        public List<IInitiativeTrackItem> InitiativeTrack { get; set; }
        public IInitiativeTrackItem DraggedOver { get; set; }
        public IInitiativeTrackItem BeingDragged { get; set; }
        public string DraggedStyle { get; set; }
        protected override void OnInitialized()
        {
            Adventurers = AdventurersConstants.Adventurers;
            InitiativeTrack = EnemyService.InitiativeTrack;
        }

        public void AddAdventurer(IInitiativeTrackItem adventurer)
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
            Random random = new Random();

            for (int num = 0; num < 15; num++)
            {
                var maxNumber = length;

                for (int i = length - 1; i > 0; i--)
                {
                    var moveOne = random.Next(0, maxNumber);

                    var currentItem = InitiativeTrack[i];
                    var moveTo = InitiativeTrack[moveOne];
                    InitiativeTrack[moveOne] = currentItem;
                    InitiativeTrack[i] = moveTo;                   
                    maxNumber--;
                }
            }

            
        }

        public void HandleDragEnter()
        {}

        public void HandleDragLeave()
        {}

        public string SetToCSSStyle(IInitiativeTrackItem item)
        {
            return item.CSSClass;
        }

        public string SetDragStyle(IInitiativeTrackItem item)
        {
            if (item == BeingDragged)
            {
                return "dragged";
            }
            return "";
        }
        public void OnBeingDragged(DragEventArgs e, IInitiativeTrackItem item)
        {
            e.DataTransfer.DropEffect = "move";
            BeingDragged = item;
        }

        public void OnDraggedOver(DragEventArgs e, IInitiativeTrackItem item)
        {
            DraggedOver = item;
        }

        public void HandleOnTouch(TouchEventArgs e, IInitiativeTrackItem item)
        {
            if (BeingDragged is null)
            {
                BeingDragged = item;
            }
            else
            {
                DraggedOver = item;
                HandleDrop();
            }
        }

        public void HandleTouchEnter(TouchEventArgs e, IInitiativeTrackItem item)
        {}

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
