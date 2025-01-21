using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class Practitioner : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateOnly BirthDate { get; set; }
        public string IdentificationNumber { get; set; }
        public bool IsReferee { get; set; }
        public string? RefereeIdNumber { get; set; }
        public DateOnly? RefereeIdExpirationDate { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public Professor Professor { get; set; }
        public int ProfessorId { get; set; }
        public ICollection<PractitionerColor> PractitionerColors { get; set; }
        public ICollection<PractitionerEvent> practitionerEvents { get; set; }
        public ICollection<EmergencyContact> EmergencyContacts { get; set; }
    }
}
