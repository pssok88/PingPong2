using AutoMapper;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, PlayerViewModel>()
                .ForMember(o => o.PlayerId, ex => ex.MapFrom(p=>p.Id))
                //.ForMember(o => o.PlayerName, ex => ex.MapFrom(p => p.Name))
                //.ForMember(o => o.PlayerNickname, ex => ex.MapFrom(p => p.NickName))
                .ReverseMap();
        }
    }
}
