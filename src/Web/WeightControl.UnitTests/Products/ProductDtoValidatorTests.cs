using FluentValidation.TestHelper;
using WeightControl.Application.Products.Models;
using Xunit;

namespace WeightControl.UnitTests.Products
{
    public class ProductDtoValidatorTests
    {
        private readonly ProductDtoValidator validator;
        public ProductDtoValidatorTests()
        {
            validator = new ProductDtoValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Validator_ShouldThrowNameNullAndEmptyError(string name)
        {
            // Arrange
            var product = new ProductDto { Name = name };

            // Act/Assert
            validator.TestValidate(product).ShouldHaveValidationErrorFor(n => n.Name);
        }

        [Fact]
        public void Validator_ShouldNotThrowNameNullAndEmptyError()
        {
            // Arrange
            var product = new ProductDto { Name = "Pizza" };

            // Act/Assert
            validator.TestValidate(product).ShouldNotHaveValidationErrorFor(n => n.Name);
        }

        [Fact]
        public void Validator_ShouldThrowCaloriesEmptyError()
        {
            // Arrange
            var product = new ProductDto();

            // Act/Assert
            validator.TestValidate(product).ShouldHaveValidationErrorFor(c => c.Calories);
        }

        [Fact]
        public void Validator_ShouldNotThrowCaloriesEmptyError()
        {
            // Arrange
            var product = new ProductDto { Calories = 10 };

            // Act/Assert
            validator.TestValidate(product).ShouldNotHaveValidationErrorFor(c => c.Calories);
        }

        [Fact]
        public void Validator_ShouldThrowTypeEmptyError()
        {
            // Arrange
            var product = new ProductDto();

            // Act/Assert
            validator.TestValidate(product).ShouldHaveValidationErrorFor(t => t.Type);
        }

        [Fact]
        public void Validator_ShouldNotThrowTypeEmptyError()
        {
            // Arrange
            var product = new ProductDto { Type = 1 };

            // Act/Assert
            validator.TestValidate(product).ShouldNotHaveValidationErrorFor(t => t.Type);
        }

        [Fact]
        public void Validator_ShouldThrowUnitEmptyError()
        {
            // Arrange
            var product = new ProductDto();

            // Act/Assert
            validator.TestValidate(product).ShouldHaveValidationErrorFor(u => u.Unit);
        }

        [Fact]
        public void Validator_ShouldNotThrowUnitEmptyError()
        {
            // Arrange
            var product = new ProductDto { Unit = 1 };

            // Act/Assert
            validator.TestValidate(product).ShouldNotHaveValidationErrorFor(u => u.Unit);
        }
    }
}
