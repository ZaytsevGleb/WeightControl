using System.Collections.Generic;
using WeightControl.Domain.Entities;

namespace WeightControl.Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
