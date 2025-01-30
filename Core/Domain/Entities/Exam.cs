using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class Exam : BaseEntity<int>
    {
        public DateOnly ExamDate {  get; set; }
        public string Jugde { get; set; }
        public bool Approved { get; set; }
        public Color Color { get; set; }
        public int ColorId { get; set; }
        public Practitioner Practitioner { get; set; }
        public int PractitionerId { get; set; }
    }
}
