using FluentValidation.Results;
using System;
using System.Linq;

namespace WeightControl.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public string Description{ get; set; }

        public BadRequestException(string message) : base(message)
        {
            
        }

        public BadRequestException(ValidationResult validationResult): base()
        {
            Description = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
        }
    }
}
