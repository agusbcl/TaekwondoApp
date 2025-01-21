namespace Domain.Entities.BaseEntities
{
    public abstract class BaseEntityEvent : BaseEntity<int>
    {
        public Event Event { get; set; }
        public int EventId { get; set; }
        public decimal Payment { get; set; }
        public bool PaymentCompleted { get; set; }
        public string WeightCategory { get; set; }
        public int EarnedPoints { get; set; }
    }
}
