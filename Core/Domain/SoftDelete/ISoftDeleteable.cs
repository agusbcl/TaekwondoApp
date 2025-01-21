namespace Domain.SoftDelete
{
    public interface ISoftDeleteable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedOnUtc { get; set; }
    }
}
