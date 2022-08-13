using System;

namespace WeightControl.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message): base(message)
        {

        }
    }
}
