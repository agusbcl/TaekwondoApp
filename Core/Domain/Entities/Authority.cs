using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class Authority : BaseEntity<int>
    {
        public ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }
        public string JobTitle { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public ICollection<News> News { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
    }
}
