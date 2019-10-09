using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class EnemyActions
    {
        public string Enemy { get; set; }
        public List<Action> Actions { get; set; }
    }
    public class Action
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
