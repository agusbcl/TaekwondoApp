using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class Practitioner : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateOnly BirthDate { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public bool IsReferee { get; set; }
        public bool IsCoach { get; set; }
        public bool IsProfessor { get; set; }
        public bool IsCompetitor { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public Professor Professor { get; set; }
        public int ProfessorId { get; set; }
        public ICollection<EmergencyContact> EmergencyContacts { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
