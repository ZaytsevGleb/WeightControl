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

        [Fact]
        public void Validator_ShouldThrowNameNullError_IfNameIsNull()
        {
            // Arrange
            var product = new ProductDto { Name = null };

            // Act/Assert
            validator.TestValidate(product).ShouldHaveValidationErrorFor(n => n.Name);
        }

        [Fact]
        public void Validator_ShouldThrowNameEmptyError_IfNameIsEmpty()
        {
            // Arrange
            var product = new ProductDto { Name = "" };

            // Act/Assert
            validator.TestValidate(product).ShouldHaveValidationErrorFor(n => n.Name);
        }

        [Fact]
        public void Validator_ShouldNotThrowNameNullError_IfNameIsValid()
        {
            // Arrange
            var product = new ProductDto { Name = "Pizza" };

            // Act/Assert
            validator.TestValidate(product).ShouldNotHaveValidationErrorFor(n => n.Name);
        }

        [Fact]
        public void Validator_ShouldThrowCaloriesEmptyError_IfCaloriesIsEmpty()
        {
            // Arrange
            var product = new ProductDto();

            // Act/Assert
            validator.TestValidate(product).ShouldHaveValidationErrorFor(c => c.Calories);
        }

        [Fact]
        public void Validator_ShouldNotThrowCaloriesEmptyError_IfCaloriesIsValid()
        {
            // Arrange
            var product = new ProductDto { Calories = 10 };

            // Act/Assert
            validator.TestValidate(product).ShouldNotHaveValidationErrorFor(c => c.Calories);
        }

        [Fact]
        public void Validator_ShouldThrowTypeEmptyError_IfTypeIsEmpty()
        {
            // Arrange
            var product = new ProductDto();

            // Act/Assert
            validator.TestValidate(product).ShouldHaveValidationErrorFor(t => t.Type);
        }

        [Fact]
        public void Validator_ShouldNotThrowTypeEmptyError_IfTypeIsValid()
        {
            // Arrange
            var product = new ProductDto { Type = 1 };

            // Act/Assert
            validator.TestValidate(product).ShouldNotHaveValidationErrorFor(t => t.Type);
        }

        [Fact]
        public void Validator_ShouldThrowUnitEmptyError_IfUnitIsEmpty()
        {
            // Arrange
            var product = new ProductDto();

            // Act/Assert
            validator.TestValidate(product).ShouldHaveValidationErrorFor(u => u.Unit);
        }

        [Fact]
        public void Validator_ShouldNotThrowUnitEmptyError_IfUnitIsValid()
        {
            // Arrange
            var product = new ProductDto { Unit = 1 };

            // Act/Assert
            validator.TestValidate(product).ShouldNotHaveValidationErrorFor(u => u.Unit);
        }
    }
}
