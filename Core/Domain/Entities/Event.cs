using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class Event : BaseEntity<int>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public ICollection<PractitionerEvent> CompetitorEvents { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOnUtc { get; set; }
    }
}
