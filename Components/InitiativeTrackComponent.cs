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
        public List<IAttributes> InitiativeTrack { get; set; }
        public IAttributes DraggedOver { get; set; }
        public IAttributes BeingDragged { get; set; }
        public string DraggedStyle { get; set; }
        protected override void OnInitialized()
        {   
            Adventurers = AdventurersConstants.Adventurers;
            InitiativeTrack = EnemyService.InitiativeTrack;
        }

        public void AddAdventurer(IAttributes adventurer)
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
            var movedToHistory = new Dictionary<int, IAttributes>();

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

        public void HandleDragLeave()        {

        }

        public string SetToCSSStyle(IAttributes item)
        {
            return item.CSSClass;
        }

        public string SetDragStyle(IAttributes item)
        {
            if (item == BeingDragged)
            {            
                return "dragged";
            }            
            return "";
        }
        public void OnBeingDragged(DragEventArgs e, IAttributes item)
        {
            e.DataTransfer.DropEffect = "move";
            BeingDragged = item;
        }

        public void OnDraggedOver(DragEventArgs e, IAttributes item)
        {
            DraggedOver = item;
        }

        public void HandleOnTouch(TouchEventArgs e, IAttributes item)
        {
            if (BeingDragged is null)
            {
                BeingDragged = item;                
            }
            else if(BeingDragged != item)
            {
                DraggedOver = item;                
                HandleDrop();
            }
            else
            {
                BeingDragged = item;
            }                     
        }

        public void HandleTouchEnter(TouchEventArgs e, IAttributes item)
        {
            
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
