namespace DTOs.Professor
{
    public class UpdateProfessorDto
    {
        public bool IsMaster { get; set; }
        public string ImgUrl { get; set; }
        public int SchoolId { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}
