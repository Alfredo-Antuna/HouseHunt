using System;
using System.ComponentModel.DataAnnotations;
namespace web
{
    public class PropertyDto
    { 
                [Required]
                public Guid OwnerGuid {get;set;}
                [Required]
                public string Name {get;set;}
                [Required]
                public string City {get;set;}
                [Required]
                [MinLength(2)]
                [MaxLength(2)]
                public string State {get;set;}
                [Required]
                public int Zipcode {get;set;}
    }
}