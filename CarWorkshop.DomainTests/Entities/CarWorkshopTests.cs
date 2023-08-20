using Xunit;
using FluentAssertions;

namespace CarWorkshop.Domain.Entities.Tests
{
    public class CarWorkshopTests
    {
        [Fact()]
        public void EncodeName_ShouldSetEncodedName()
        {
            // arrenge 
            var carWorkshop = new CarWorkshop(); 
            carWorkshop.Name = "Test Workshop";
        
            // act
            carWorkshop.EncodeName();

            // assert
            carWorkshop.EncodedName.Should().Be("test-workshop");
        }

        [Fact()]
        public void EncodeName_ShouldTrowException_WhenNameIsNull()
        {
            // arrenge 
            var carWorkshop = new CarWorkshop();

            // act
            Action action = () => carWorkshop.EncodeName();

            // arrenge 
            action.Invoking(a => a.Invoke())
                .Should().Throw<NullReferenceException>();
        }
    }
}