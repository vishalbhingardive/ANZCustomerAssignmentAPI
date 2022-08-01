using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.ToDoList
{
    public class ToDoItem:FullAuditedEntity<long>
    {
        public string Text { get; set; }
    }
}
