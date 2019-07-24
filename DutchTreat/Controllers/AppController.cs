using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IProductRepository _productRepository;
        private readonly IPlayerRepository _playerRepository;

        public AppController(IMailService mailService, IProductRepository productRepository, IPlayerRepository playerRepository)
        {
            _mailService = mailService;
            _productRepository = productRepository;
            _playerRepository = playerRepository;
        }

        public IActionResult Index()
        {
            ViewBag.ListOfStyles = _playerRepository.GetGripStyles();
            ViewBag.ListOfLevels = _playerRepository.GetSkillLevels();
            var players = _playerRepository.GetAllPlayers();
            return View(players);
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //send the email
                _mailService.SendMail("pssok88@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Email Sent";
                ModelState.Clear();
            }
            else
            {
                //Show the errors
            }
                return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Shop()
        {
            var results = _productRepository.GetAllProducts();

            return View(results);//with core you can pass data through to the View
        }
    }
}