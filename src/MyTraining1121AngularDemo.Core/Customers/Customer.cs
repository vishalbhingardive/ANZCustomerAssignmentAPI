using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.Collections.Generic;
using MyTraining1121AngularDemo.CustomerUsers;

namespace MyTraining1121AngularDemo.Customers
{
    [Table("Customers")]
    public class Customer : FullAuditedEntity<long>
    {

        [Required]
        [StringLength(CustomerConsts.MaxNameLength, MinimumLength = CustomerConsts.MinNameLength)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(CustomerConsts.MaxEmailLength, MinimumLength = CustomerConsts.MinEmailLength)]
        public virtual string Email { get; set; }

        [StringLength(CustomerConsts.MaxAddressLength, MinimumLength = CustomerConsts.MinAddressLength)]
        public virtual string Address { get; set; }

        public virtual DateTime RegistrationDate { get; set; }

        public virtual ICollection<CustomerUser> Users { get; set; }

    }
}