using System;
using System.Collections.Generic;

namespace web
{
    public class Owner
    {
        public Guid Id {get;set;}
        public List<Property> Properties {get;set;}
        public string Name {get;set;}
        public Owner()
        {
            Properties = new();
        }
    }

}