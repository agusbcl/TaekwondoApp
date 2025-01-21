namespace Domain.Entities.BaseEntities
{
    public abstract class BaseEntityColor : BaseEntity<int>
    {
        public Color Color { get; set; }
        public int ColorId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

    }
}
