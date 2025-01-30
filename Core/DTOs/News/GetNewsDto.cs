namespace DTOs.News
{
    public class GetNewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public DateOnly CreationDate { get; set; }

    }
}
