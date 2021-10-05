using System;
using System.Collections.Generic;

namespace web
{
    public class Property
    {
        public Guid Id {get;set;}
        public List<Reservation> Reservations {get;set;}
        public Owner Owner {get;set;}
        public string Name {get;set;}
        public string City {get;set;}
        public string State {get;set;}
        public int Zipcode {get;set;}

        public Property()
        {
            Reservations = new();
        
        }
        public Property(PropertyDto propertyDto)
        {
           Id = Guid.NewGuid();
           Reservations = new();
           Name = propertyDto.Name;
           City = propertyDto.City;
           State = propertyDto.State;
           Zipcode = propertyDto.Zipcode;
        }
    }

}