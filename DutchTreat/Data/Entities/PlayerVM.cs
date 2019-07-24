using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data.Entities
{
    public class PlayerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public int GripStyleId { get; set; }
        public int SkillLevelId { get; set; }

    }
}
