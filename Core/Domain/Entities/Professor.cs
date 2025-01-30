using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class Professor : BaseEntity<int>
    {
        public ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }
        public bool IsMaster { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOnUtc { get; set; }
        public ICollection<Practitioner> Practitioners { get; set; }
        public School School { get; set; }
        public int SchoolId { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }

    }
}
