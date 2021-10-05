using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web
{
  public interface IPropertyRepository
  {
    Task<IEnumerable<Property>> GetAllAsync();
    Task<Property> GetByIdAsync(Guid id);
    void AddReservationAsync(Property property, Reservation reservation);
    Task AddPropertyAsync(Property property,Guid Owner_Id);
    Task SaveAsync();
  }
}