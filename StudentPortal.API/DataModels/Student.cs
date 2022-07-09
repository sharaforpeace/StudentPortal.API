using System;
 
namespace StudentPortal.API.DataModels
{
    public class Student
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Email { get; set; }
        public long Mobile { get; set; }
        public String ProfileImageUrl { get; set; }
        public Guid GenderId { get; set; }

        // Navigation Property
        public Gender Gender { get; set; }
        public Address Address { get; set;  }

    }
}
