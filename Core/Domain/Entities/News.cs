using Domain.Entities.BaseEntities;
using Domain.SoftDelete;

namespace Domain.Entities
{
    public class News : BaseEntity<int>, ISoftDeleteable
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public DateOnly CreationDate { get; set; }
        public Authority Authority { get; set; }
        public int AuthorityId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOnUtc { get; set; }
    }
}
