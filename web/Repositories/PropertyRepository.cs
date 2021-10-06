using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace web
{
    public class PropertyRepository : IPropertyRepository
    {
        private Database _db;

        public async Task<IEnumerable<Property>> GetAllPropertyAsync()
        {
            return await _db.Properties.ToListAsync();
        }
        public async Task<IEnumerable<Property>> GetAllPropertyByOwner(Guid ownerid)
        {
            return await _db.Properties.Where(property => property.OwnerId == ownerid).ToListAsync();
        }
        public async Task<Property> GetByIdAsync(Guid id)
        {
            return await _db.Properties
            .Where(property => property.Id == id)
            .Include(property => property.Reservations)
            .SingleOrDefaultAsync();
        }
        public async Task AddPropertyAsync(Property property)
        {
            _db.Add(property);
            await _db.SaveChangesAsync();
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        public void AddReservationAsync(Property property, Reservation reservation)
        {
            //bool overlap = a.start < b.end && b.start < a.end;
            if (property.Reservations.Count() > 0)
            {
                var overlap = property.Reservations.Where(fromReservation => fromReservation.StartDate < reservation.EndDate && reservation.StartDate < fromReservation.EndDate);
                if (overlap.Count() > 0)
                {
                    return;
                }
                else
                {
                    property.Reservations.Add(reservation);
                }
            }
        }
        public PropertyRepository(Database db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Property>> GetPropertyByCity(string city)
        {
            return await _db.Properties.Where(property => property.City.Contains(city)).ToListAsync();
        }

        public async Task<IEnumerable<Property>> GetPropertyByState(string state)
        {
            return await _db.Properties.Where(property => property.State.Contains(state)).ToListAsync();
        }

        public async Task<IEnumerable<Property>> GetPropertyByZip(string zip)
        {
            return await _db.Properties.Where(property => property.Zipcode == zip).ToListAsync();
        }

    }
}