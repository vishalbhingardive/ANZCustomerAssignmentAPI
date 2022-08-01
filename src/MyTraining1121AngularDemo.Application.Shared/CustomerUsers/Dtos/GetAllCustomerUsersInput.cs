using Abp.Application.Services.Dto;
using System;

namespace MyTraining1121AngularDemo.CustomerUsers.Dtos
{
    public class GetAllCustomerUsersInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public decimal? MaxTotalAmountFilter { get; set; }
        public decimal? MinTotalAmountFilter { get; set; }

        public string CustomerNameFilter { get; set; }

        public string UserNameFilter { get; set; }

    }
}