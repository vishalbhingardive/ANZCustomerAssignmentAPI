using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.ToDoList
{
    public interface IToDoItemAppService: IApplicationService
    {
        Task<List<ToDoItemDto>> GetListAsync();
        Task<ToDoItemDto> CreateAsync(string text);
        Task UpdateAllAsync(long input);
        Task DeleteAsync (long id);
    }
}
