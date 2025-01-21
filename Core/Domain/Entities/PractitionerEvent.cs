using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class PractitionerEvent : BaseEntityEvent
    {
        public Practitioner Practitioner { get; set; }
        public int PractitionerId { get; set; }
    }
}
