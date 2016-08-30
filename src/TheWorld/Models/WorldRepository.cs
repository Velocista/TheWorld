using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public class WorldRepository : IWorldRepository
    {
        private WorldContext _context;
        private ILogger<WorldRepository> _logger;

        public WorldRepository(WorldContext context,
            ILogger<WorldRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddStop(string tripName, string userName, Stop newStop)
        {
            var trip = GetTripByName(tripName, userName);

            if(trip != null)
            {
                //Add the forgien key
                trip.Stops.Add(newStop);
                //Add the new object
                _context.Stops.Add(newStop);
            }
        }

        public void AddTrip(Trip trip)
        {
            _context.Add(trip);
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            _logger.LogInformation("Getting all trips from the DB");

            return _context.Trips.ToList();
        }

        public Trip GetTripByName(string tripName, string userName)
        {
            return _context.Trips
                .Include(t => t.Stops)
                .Where(t => t.Name == tripName && t.UserName == userName)
                .FirstOrDefault();
        }

        public IEnumerable<Trip> GetUserTripsWithStops(string name)
        {
            return _context.Trips
                .Include(t => t.Stops)
                .OrderBy(t => t.Name)
                .Where(t => t.UserName == name)
                .ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            //Will return true if one or more rows were affected
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
