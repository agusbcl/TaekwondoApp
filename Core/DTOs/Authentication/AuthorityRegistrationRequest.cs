namespace DTOs.Authentication
{
    public class AuthorityRegistrationRequest : RegistrationRequest
    {
        public string JobTitle { get; set; }
        public DateOnly StartDate { get; set; }
        public string AddressStreet { get; set; }
        public string AddresZipCode { get; set; }
        public string AddressCity { get; set; }
        public string AddressProvince { get; set; }
    }
}
