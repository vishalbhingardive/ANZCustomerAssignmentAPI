using Abp.Application.Services.Dto;

namespace MyTraining1121AngularDemo.CustomerUsers.Dtos
{
    public class UsersSecondDto : EntityDto<long>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
    }
}