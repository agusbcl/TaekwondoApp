using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class School : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Cuit { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOnUtc { get; set; }
        public ICollection<Professor> Professors { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
    }
}
