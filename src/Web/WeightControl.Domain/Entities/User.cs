using System.Collections.Generic;

namespace WeightControl.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Role> Roles{ get; set; }
    }
}