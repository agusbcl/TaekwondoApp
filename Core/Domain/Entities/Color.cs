using Domain.Entities.BaseEntities;

namespace Domain.Entities
{
    public class Color : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Order { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
