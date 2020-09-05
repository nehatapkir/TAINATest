using System;

namespace TAINATest.Model
{
    public class PersonDTO
    {
        public long PersonId { get; set; }
        public int Gender { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
