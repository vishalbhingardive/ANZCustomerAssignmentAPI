using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MyTraining1121AngularDemo.CustomerUsers.Dtos;

namespace MyTraining1121AngularDemo.Customers.Dtos
{
    public class CreateOrEditCustomerDto : EntityDto<long?>
    {

        [Required]
        [StringLength(CustomerConsts.MaxNameLength, MinimumLength = CustomerConsts.MinNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(CustomerConsts.MaxEmailLength, MinimumLength = CustomerConsts.MinEmailLength)]
        public string Email { get; set; }

        [StringLength(CustomerConsts.MaxAddressLength, MinimumLength = CustomerConsts.MinAddressLength)]
        public string Address { get; set; }

        public DateTime RegistrationDate { get; set; }
        public ICollection<CustomerUserDto> customerUserDtos { get; set; }
        public IList<long> UserRefIds { get; set; }
    }
}