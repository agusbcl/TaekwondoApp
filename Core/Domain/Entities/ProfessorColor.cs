using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class ProfessorColor : BaseEntityColor
    {
        public Professor Professor { get; set; }
        public int ProfessorId { get; set; }
    }
}
