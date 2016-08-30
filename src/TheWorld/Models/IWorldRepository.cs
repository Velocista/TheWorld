using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        Trip GetTripByName(string tripName, string userName);

        void AddTrip(Trip trip);

        Task<bool> SaveChangesAsync();

        void AddStop(string tripName, string userName, Stop newStop);
        IEnumerable<Trip> GetUserTripsWithStops(string name);
    }
}