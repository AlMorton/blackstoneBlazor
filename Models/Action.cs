using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class EnemyActions
    {
        public string Enemy { get; set; }
        public List<EnemyAction> Actions { get; set; }
    }
    public class EnemyAction
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
