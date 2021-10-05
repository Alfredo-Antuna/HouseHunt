using System;
using System.Collections.Generic;

namespace web
{
    public class Owner
    {
        public Guid Id {get;set;}
        public List<Property> Propertys {get;set;}
        public string Name {get;set;}
        public Owner()
        {
            Propertys = new();
        
        }
        // public Owner(OwnerDto OwnerDTO)
        // {

        // }
    }

}