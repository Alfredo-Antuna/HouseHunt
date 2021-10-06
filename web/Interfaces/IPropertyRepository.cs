using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllPropertyAsync();
        Task<IEnumerable<Property>> GetAllPropertyByOwner(Guid ownerid);
        Task<IEnumerable<Property>> GetPropertyByCity(string city);
        Task<IEnumerable<Property>> GetPropertyByState(string state);
        Task<IEnumerable<Property>> GetPropertyByZip(string zip);

        Task<Property> GetByIdAsync(Guid id);
        void AddReservationAsync(Property property, Reservation reservation);
        Task AddPropertyAsync(Property property);
        Task SaveAsync();
    }
}