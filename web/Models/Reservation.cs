using System;
using System.Collections.Generic;

namespace web
{
    public class Reservation
    {
        public Guid Id {get;set;}
        public Property Property {get;set;}
        public DateTime StartDate {get;set;}
        public DateTime EndDate {get;set;}
        // public Reservation(ReservationDto ReservationDTO)
        // {

        // }
    }

}