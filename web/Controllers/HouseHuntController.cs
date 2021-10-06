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
            await _repository.AddPropertyAsync(property);
            // await _repository.SaveAsync();
            return CreatedAtAction("GetOne", new { property.Id }, property);
        }
        [HttpGet("{id}/house")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            // 1. id fails validation, returns (400 Bad Request)
            // 2. id is valid but not found, returns (204 No Content)
            // 3. id is valid and is found, returns (200 OK)
            var todo = await _repository.GetByIdAsync(id);
            return Ok(todo);
        }

        [HttpGet("{ownerguid}/all")]
        public async Task<IActionResult> GetAll(Guid ownerguid)
        {
            var allProperty = await _repository.GetAllPropertyByOwner(ownerguid);

            return Ok(allProperty);
        }
        [HttpGet("{city}/house/city")]
        public async Task<IActionResult> GetPropertyByCity(string city)
        {
            var propertyCity = await _repository.GetPropertyByCity(city);

            return Ok(propertyCity);
        }
        [HttpGet("{state}/house/state")]
        public async Task<IActionResult> GetPropertyByState(string state)
        {
            var propertyState = await _repository.GetPropertyByState(state);

            return Ok(propertyState);
        }
        [HttpGet("{zip}/house/zip")]
        public async Task<IActionResult> GetPropertyByZip(int zip)
        {
            var propertyZip = await _repository.GetPropertyByZip(zip);

            return Ok(propertyZip);
        }


    }
}
