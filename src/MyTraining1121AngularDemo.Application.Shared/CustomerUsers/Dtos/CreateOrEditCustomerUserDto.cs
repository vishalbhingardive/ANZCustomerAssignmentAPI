using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyTraining1121AngularDemo.CustomerUsers.Dtos
{
    public class CreateOrEditCustomerUserDto : EntityDto<long?>
    {

        [Range(CustomerUserConsts.MinTotalAmountValue, CustomerUserConsts.MaxTotalAmountValue)]
        public decimal TotalAmount { get; set; }

        public long? CustomerId { get; set; }

        public long? UserId { get; set; }

    }
}