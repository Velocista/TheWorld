﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private IWorldRepository _repository;
        private ILogger<AppController> _logger;

        public AppController(IMailService mailService, 
            IConfigurationRoot config, 
            IWorldRepository repository,
            ILogger<AppController> logger)
        {
            _mailService = mailService;
            _config = config;
            _repository = repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Trips()
        {
            //try
            //{
            //    var data = _repository.GetAllTrips();

            //    return View(data);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"Failed to get trips in Index page: {ex.Message}");
            //    return Redirect("/error");
            //}
            ViewBag.googleKey = _config["Keys:GoogleMapKey"];

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if(model.Email.Contains("aol.com"))
            {
                ModelState.AddModelError("Email", "We don't support AOL Addresses");  // This will assign the model error to the Email Field
                ModelState.AddModelError("", "We don't support AOL Addresses");  //This will assign the error to the Model
            }

            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From the World", model.Message);

                ViewBag.UserMessage = "Message Sent";

                ModelState.Clear();
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
