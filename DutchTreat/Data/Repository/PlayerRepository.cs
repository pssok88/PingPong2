using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DutchContext _ctx;

        public PlayerRepository(DutchContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            var players = _ctx.Player
                .Include(gs => gs.GripStyle)
                .Include(sl => sl.SkillLevel)
                .OrderBy(p => p.Id)
                .ToList();
            return players;
        }

        public SkillLevel GetSkillLevel(int level)
        {
            return _ctx.SkillLevel.Where(s => s.Id == level).FirstOrDefault();
        }
        public IEnumerable<SkillLevel> GetSkillLevels()
        {
            return _ctx.SkillLevel.ToList();
        }
        public GripStyle GetGripStyle(int style)
        {
            return _ctx.GripStyle.Where(s => s.Id == style).FirstOrDefault();
        }
        public IEnumerable<GripStyle> GetGripStyles()
        {
            return _ctx.GripStyle.ToList();
        }
        
        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void AddEntity(object player)
        {
            _ctx.Add(player);
        }

        public Player GetPlayerById(int id)
        {
            return _ctx.Player
                .Include(gs => gs.GripStyle)
                .Include(sl => sl.SkillLevel)
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Player> GetPlayersBySkillLevel(int skillLevelId)
        {
            return _ctx.Player
                .Where(p => p.SkillLevel.Id == skillLevelId)
                .Include(p => p.SkillLevel)
                .Include(p => p.GripStyle)
                .OrderBy(p => p.Id)
                .ToList();
        }
        public IEnumerable<Player> GetPlayersByGripStyle(int gripStyleId)
        {
            return _ctx.Player
                .Where(p => p.GripStyle.Id == gripStyleId)
                .Include(p => p.SkillLevel)
                .Include(p => p.GripStyle)
                .OrderBy(p => p.Id)
                .ToList();
        }
    }
}
