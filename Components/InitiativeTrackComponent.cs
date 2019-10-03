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
       
        [Parameter]
        public List<Enemy> Enemies { get; set; } 

        public Enemy DraggedOver { get; set; }

        public Enemy BeingDragged { get; set; }

        public string DraggedStyle { get; set; }
       

        public void Shuffle()
        {
            var length = Enemies.Count;
            var totalToShuffle = length;

            Random random = new Random();
            var movedToHistory = new Dictionary<int, Enemy>();

            for (int i = 0; i < length; i++)
            {
                var moveTo = random.Next(0, length);
                var moveFrom = random.Next(0, length);
                if(!movedToHistory.ContainsKey(moveTo))
                {
                    var temp = Enemies[moveTo];
                    var tempTwo = Enemies[i];
                    Enemies[i] = temp;
                    Enemies[moveTo] = tempTwo;

                    movedToHistory.Add(moveTo, Enemies[i]);
                }                
            }
        }
        public void HandleDragEnter()
        {
            
        }

        public void HandleDragLeave()
        {
            
        }

        public string SetDragStyle(Enemy enemy)
        {
            if(enemy == BeingDragged)
            {
                return "dragged";
            }
            return "";
        }
        public void OnBeingDragged(DragEventArgs e, Enemy enemy)
        {
            BeingDragged = enemy;    
        }

        public void OnDraggedOver(DragEventArgs e, Enemy enemy)
        {
            DraggedOver = enemy;
        }


        public async Task HandleDrop()
        {
            var iOne = Enemies.IndexOf(BeingDragged);            
            var iTwo = Enemies.IndexOf(DraggedOver);
            // Swap them over
            Enemies[iOne] = DraggedOver;
            Enemies[iTwo] = BeingDragged;
            DraggedOver = null;
            BeingDragged = null;
            
        }

        public void Reorder(DragEventArgs e, Enemy enemy)
        {   

        }
    }
}
