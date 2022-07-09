using System;
 

namespace StudentPortal.API.DataModels
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }

        //Navigtion Property
        public Guid StudentId { get; set; }
    }
}
