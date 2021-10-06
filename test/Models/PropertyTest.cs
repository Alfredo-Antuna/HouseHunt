using System;
using Xunit;
using FluentAssertions;
using web;

namespace test
{
    public class PropertyTest
    {

        [Fact]
        public void ShouldCreateProperty()
        {
            Property property = new Property();
            property.Reservations.Should().HaveCount(0);
        }

        [Fact]
        public void PropertyCreatedFromDto()
        {
            PropertyDto propertyDto = new PropertyDto() { OwnerId = Guid.Parse("73408898-c7ca-47d1-b96a-cc37d96850df"), Name = "Test House", City = "Houston", State = "TX", Zipcode = "77777" };
            Property property = new Property(propertyDto);
            property.Reservations.Should().HaveCount(0);
            property.OwnerId.Should().Be(Guid.Parse("73408898-c7ca-47d1-b96a-cc37d96850df"));
            property.Name.Should().Be("Test House");
            property.City.Should().Be("Houston");
            property.State.Should().Be("TX");
            property.Zipcode.Should().Be("77777");
        }

    }
}