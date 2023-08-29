using Xunit;
using Moq;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using AutoMapper;
using FluentAssertions;
using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Application.Mappings.Tests
{
    public class CarWorkshopMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ShouldMapCarWorkshopDtoToCarWorkshop()
        {
            // arrange
            var userContextMock = new Mock<IUserContext>();
            userContextMock
                .Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@example.com", new[] { "Moderator" }));

            var configuration = new MapperConfiguration(cfg 
                => cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object)));

            var mapper = configuration.CreateMapper();

            var dto = new CarWorkshopDto
            {
                City = "City",
                PhoneNumber = "1234567890",
                PostalCode = "12345",
                Street = "Street"
            };

            // act
            var result = mapper.Map<Domain.Entities.CarWorkshop>(dto);

            // assert
            result.Should().NotBeNull();
            result.ContactDetails.Should().NotBeNull();
            result.ContactDetails.City.Should().Be(dto.City);
            result.ContactDetails.PhoneNumber.Should().Be(dto.PhoneNumber);
            result.ContactDetails.PostalCode.Should().Be(dto.PostalCode);
            result.ContactDetails.PostalCode.Should().Be(dto.Street);

        }

        [Fact()]
        public void MappingProfile_ShouldMapCarWorkshopToCarWorkshopDto()
        {
            // arrange
            var userContextMock = new Mock<IUserContext>();
            userContextMock
                .Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@example.com", new[] { "Moderator" }));

            var configuration = new MapperConfiguration(cfg
                => cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object)));

            var mapper = configuration.CreateMapper();

            var carWorkshop = new Domain.Entities.CarWorkshop
            {
                Id = 1,
                CreatedById = "1",
                ContactDetails = new CarWorkshopContactDetails
                {
                    City = "City",
                    PhoneNumber = "1234567890",
                    PostalCode = "12345",
                    Street = "Street"
                }
            };

            // act
            var result = mapper.Map<CarWorkshopDto>(carWorkshop);

            // assert
            result.Should().NotBeNull();
            result.IsEditable.Should().BeTrue();
            result.ContactDetails.Should().NotBeNull();
            result.ContactDetails.City.Should().Be(dto.City);
            result.ContactDetails.PhoneNumber.Should().Be(dto.PhoneNumber);
            result.ContactDetails.PostalCode.Should().Be(dto.PostalCode);
            result.ContactDetails.PostalCode.Should().Be(dto.Street);
        }
    }   
}