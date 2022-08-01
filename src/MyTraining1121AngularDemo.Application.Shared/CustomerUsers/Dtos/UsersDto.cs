using Abp.Application.Services.Dto;

namespace MyTraining1121AngularDemo.CustomerUsers.Dtos
{
    public class UsersDto : EntityDto<long>
    {

        public string FullName { get; set; }

        public string EmailAddress { get; set; }
    }
}