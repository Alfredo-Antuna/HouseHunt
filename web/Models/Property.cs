using System;
using System.Collections.Generic;

namespace web
{
    public class Property
    {
        public Guid Id { get; set; }
        public List<Reservation> Reservations { get; set; } = new();
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; } 

    public Property(){}

        public Property(PropertyDto propertyDto): this()
        {
            Id = Guid.NewGuid();
            OwnerId = propertyDto.OwnerId;
            Name = propertyDto.Name;
            City = propertyDto.City;
            State = propertyDto.State;
            Zipcode = propertyDto.Zipcode;
        }
    }

}