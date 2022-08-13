namespace WeightControl.Domain.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Type { get; set; }
        public int Unit { get; set; }
    }
}
