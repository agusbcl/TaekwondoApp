using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class EmergencyContact : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Relationship { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public Practitioner Practitioner { get; set; }
        public int PractitionerId { get; set; }
    }
}
