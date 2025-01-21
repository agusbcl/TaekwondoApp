using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class PractitionerColor : BaseEntityColor
    {
        public Practitioner Practitioner { get; set; }
        public int PractitionerId { get; set; }

    }
}
