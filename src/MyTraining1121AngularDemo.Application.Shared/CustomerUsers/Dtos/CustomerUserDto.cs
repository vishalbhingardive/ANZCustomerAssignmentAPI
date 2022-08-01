using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace MyTraining1121AngularDemo.CustomerUsers.Dtos
{
    public class CustomerUserDto : EntityDto<long>
    {
        public decimal TotalAmount { get; set; }

        public long? CustomerId { get; set; }

        public long? UserId { get; set; }
        public string UserName { get; set; }
        public string CustomerName { get; set; }
       
    }
}