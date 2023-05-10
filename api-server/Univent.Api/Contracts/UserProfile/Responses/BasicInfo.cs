namespace Univent.Api.Contracts.UserProfile.Responses
{
    public record BasicInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Hometown { get; set; }
        public string ProfilePicture { get; set; }
    }
}
