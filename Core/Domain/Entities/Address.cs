using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class Address : BaseEntity<int>
    {
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        ICollection<School> Schools { get; set; }
        ICollection<Practitioner> Practitioners { get; set; }
        ICollection<EmergencyContact> EmergencyContacts { get; set; }
    }
}
