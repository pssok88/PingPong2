using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public GripStyle GripStyle { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public DateTime Date { get; set; }
    
    }
}
