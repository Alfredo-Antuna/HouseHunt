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

    public async Task<IEnumerable<Property>> GetAllAsync()
    {
      return await _db.Propertys.ToListAsync();
    }

    public async Task<Property> GetByIdAsync(Guid id)
    {
      return await _db.Propertys
      .Where(property => property.Id == id)
      .Include(property => property.Reservations)
      .Include(property =>property.Owner)
      .SingleOrDefaultAsync();
    }

    
    public async Task AddPropertyAsync(Property property,Guid ownerId)
    {
        Console.WriteLine($"property{property.Name} Owner: {ownerId}");
        Console.WriteLine($"DATABASE:{_db}");
        Console.WriteLine($"OwnersFromDatabase:{_db.Owners.Count()}");
        foreach (var o in _db.Owners.ToList() )
        {
            if (o.Id == ownerId){Console.WriteLine($"OWNER {o.Id}");}
        }

        var owner = _db.Owners.Where(own => own.Id == ownerId).SingleOrDefault();
        
        Console.WriteLine($"OWNER:::::: {owner.Id}");
        
        
        if(owner == null) return;
        owner.Propertys.Add(property);
        await _db.SaveChangesAsync();
    }

    public async Task SaveAsync()
    {
      await _db.SaveChangesAsync();
    }
    public void AddReservationAsync(Property property, Reservation reservation)
    {
        //bool overlap = a.start < b.end && b.start < a.end;
        if(property.Reservations.Count()>0)
        {
            var overlap = property.Reservations.Where(fromReservation => fromReservation.StartDate < reservation.EndDate && reservation.StartDate < fromReservation.EndDate);
            if(overlap.Count() > 0)
            {
                return;
            }else
            {
                property.Reservations.Add(reservation);
            }
        }
    }
    public PropertyRepository(Database db)
    {
      _db = db;
    }
  }
}