using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class School : BaseEntity<int>
    {
        public ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }
        public string Name { get; set; }
        public string Cuit { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<Professor> Professors { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOnUtc { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
    }
}
