using DutchTreat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.ViewModels
{
    public class PlayerViewModel
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerNickname { get; set; }
        public int GripStyleId { get; set; }
        public string GripStyleName { get; set; }
        public int SkillLevelId { get; set; }
        public string SkillLevelName { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
    