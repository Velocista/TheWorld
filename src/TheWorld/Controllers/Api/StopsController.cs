﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorld.Models;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Api
{
    [Route("/api/trips/{tripName}/stops")]
    public class StopsController : Controller
    {
        private ILogger<StopsController> _logger;
        private IWorldRepository _repository;

        public StopsController(IWorldRepository repository,
            ILogger<StopsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IActionResult Get(string tripName)
        {
            try
            {
                var trip = _repository.GetTripByName(tripName);

                return Ok(Mapper.Map<IEnumerable<StopsViewModel>>(trip.Stops.OrderBy(s => s.Order).ToList()));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get stops: {ex}");
            }
            return BadRequest("Error occured");
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(string tripName, [FromBody]StopsViewModel vm)
        {
            try
            {
                //If the VM is valid
                if (ModelState.IsValid)
                {
                    var newStop = Mapper.Map<Stop>(vm);

                    //Lookup geo points

                    //Save to the DB
                    _repository.AddStop(tripName, newStop);

                    if (await _repository.SaveChangesAsync())
                    {
                        return Created($"api/trips/{tripName}/stops/{newStop.Name}",
                            Mapper.Map<StopsViewModel>(newStop));
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Failed to add trip: {0}", ex);
            }

            return BadRequest("Failed to add trip");
        }
    }
}
