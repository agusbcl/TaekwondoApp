namespace DTOs.Authentication
{
    public class ProfessorRegistrationRequest : RegistrationRequest
    {
        public bool IsMaster { get; set; }
        public int SchoolId { get; set; }
        public string AddressStreet { get; set; }
        public string AddresZipCode { get; set; }
        public string AddressCity { get; set; }
        public string AddressProvince { get; set; }
    }
}
