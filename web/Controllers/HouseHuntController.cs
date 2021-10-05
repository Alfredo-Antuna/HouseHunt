using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;

namespace web.Controllers
{
    [ApiController]
    [Route("api/househunt")]
    public class HouseHuntController : ControllerBase
    {
        private IPropertyRepository _repository;

        public HouseHuntController(IPropertyRepository repository)
        {
        _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PropertyDto propertyDto)
        {
            var property = new Property(propertyDto);
            await _repository.AddPropertyAsync(property, propertyDto.OwnerGuid);
            // await _repository.SaveAsync();



            return CreatedAtAction("GetOne",new {property.Id}, property);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
        // 1. id fails validation, returns (400 Bad Request)
        // 2. id is valid but not found, returns (204 No Content)
        // 3. id is valid and is found, returns (200 OK)

        var todo = await _repository.GetByIdAsync(id);
        return Ok(todo);
        }



    }
}
