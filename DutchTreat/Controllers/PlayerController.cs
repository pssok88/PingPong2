using AutoMapper;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    [Route("api/[Controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ILogger<PlayerController> _logger;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerRepository playerRepository, ILogger<PlayerController> logger, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _logger = logger;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get()
        {
            try
            {
                return Ok(_playerRepository.GetAllPlayers());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get players {ex}");
                return BadRequest($"Failed to get players");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPlayerById(int id)
        {
            try
            {
                var player = _playerRepository.GetPlayerById(id);

                if (player != null)
                {
                    return Ok(_mapper.Map<Player, PlayerViewModel>(player));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get players {ex}");
                return BadRequest($"Failed to get players");
            }
        }

        [Route("level/{levelId:int}")]
        public IActionResult GetPlayersBySkillLevel(int levelId)
        {
            try
            {
                return Ok(_playerRepository.GetPlayersBySkillLevel(levelId));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get players {ex}");
                return BadRequest($"Failed to get players");
            }
        }

        [Route("style/{styleId:int}")]
        public IActionResult GetPlayersByGripStyle(int styleId)
        {
            try
            {
                return Ok(_playerRepository.GetPlayersByGripStyle(styleId));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get players {ex}");
                return BadRequest($"Failed to get players");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]PlayerViewModel player)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var gripStyle = _playerRepository.GetGripStyle(player.GripStyleId);

                    var skillLevel = _playerRepository.GetSkillLevel(player.SkillLevelId);

                    var newPlayer = new Player()
                    {
                        Id = player.PlayerId,
                        Name = player.PlayerName,
                        NickName = player.PlayerNickname,
                        GripStyle = gripStyle,
                        SkillLevel = skillLevel,
                        Date = DateTime.Now
                    };

                    _playerRepository.AddEntity(newPlayer);
                    if (_playerRepository.SaveAll())
                    {
                        var vm = new PlayerViewModel()
                        {
                            PlayerId = newPlayer.Id,
                            PlayerName = newPlayer.Name,
                            PlayerNickname = newPlayer.NickName,
                            GripStyleId = newPlayer.GripStyle.Id,
                            SkillLevelId = newPlayer.SkillLevel.Id,
                            CreatedDate = newPlayer.Date
                        };

                        return Created($"/api/player/{vm.PlayerId}", vm);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save new player {ex}");
            }

            return BadRequest("Failed to save new player");

        }
        
    }
}
