namespace WeightControl.Domain.Entities
{
    public class User: BaseEntity
    {
        public new int Id { get; set; } 
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}