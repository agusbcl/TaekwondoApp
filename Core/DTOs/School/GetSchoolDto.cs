using DTOs.Professor;

namespace DTOs.School
{
    public class GetSchoolDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cuit {  get; set; }
        public string ImgUrl { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}
