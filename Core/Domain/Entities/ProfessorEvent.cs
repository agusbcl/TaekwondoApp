using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class ProfessorEvent : BaseEntityEvent
    {
        public Professor Professor { get; set; }
        public int ProfessorId { get; set; }
    }
}