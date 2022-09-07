using System.Collections.Generic;
using WeightControl.Domain.Entities;

namespace WeightControl.Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string name, string email, ICollection<Role> reles);
    }
}
