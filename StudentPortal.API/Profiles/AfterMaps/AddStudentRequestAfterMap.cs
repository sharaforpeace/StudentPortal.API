using AutoMapper;
using StudentPortal.API.DomainModels;
using DataModels = StudentPortal.API.DataModels;


namespace StudentPortal.API.Profiles.AfterMaps
{
    public class AddStudentRequestAfterMap : IMappingAction<AddStudentRequest, DataModels.Student>
    {
        public void Process(AddStudentRequest source, DataModels.Student destination, ResolutionContext context)
        {
            destination.Id = System.Guid.NewGuid();
            destination.Address = new DataModels.Address()
            {
                Id = System.Guid.NewGuid(),
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            }; 
        }
    }
}
