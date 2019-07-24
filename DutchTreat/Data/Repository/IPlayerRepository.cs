using System.Collections.Generic;
using DutchTreat.Data.Entities;

namespace DutchTreat.Data
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAllPlayers();
        IEnumerable<Player> GetPlayersBySkillLevel(int skillLevel);
        IEnumerable<Player> GetPlayersByGripStyle(int gripStyleId);
        IEnumerable<GripStyle> GetGripStyles();
        IEnumerable<SkillLevel> GetSkillLevels();
        bool SaveAll();
        void AddEntity(object player);
        Player GetPlayerById(int id);
        GripStyle GetGripStyle(int style);
        SkillLevel GetSkillLevel(int level);
    }
}