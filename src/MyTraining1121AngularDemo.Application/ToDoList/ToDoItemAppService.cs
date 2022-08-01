using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.ToDoList
{
    public class ToDoItemAppService : MyTraining1121AngularDemoAppServiceBase, IToDoItemAppService
    {
        private readonly IRepository<ToDoItem, long> _repository;
        


        public ToDoItemAppService(IRepository<ToDoItem, long> repository)
        {
            _repository = repository;
        }

        public async Task<ToDoItemDto> CreateAsync(string text)
        {
            var item = await _repository.InsertAsync(new ToDoItem() { Text = text });
            return new ToDoItemDto() { Id = item.Id , Text = item.Text };
            //var customer = await _customerRepository.FirstOrDefaultAsync((long)input.Id);
            //ObjectMapper.Map(input, customer);
        }


        public async Task UpdateAllAsync(long input)
        {
            
            var customer = await _repository.FirstOrDefaultAsync((long)input);
            ObjectMapper.Map(input, customer);

            await _repository.UpdateAsync(customer); 
        }
        public async Task DeleteAsync(long id)
        {
           await _repository.DeleteAsync(id);
        }

        public async Task<List<ToDoItemDto>> GetListAsync()
        {
           var items = await _repository.GetAll().ToListAsync();
            return items.Select(item=>new ToDoItemDto() { Id = item.Id , Text = item.Text }).ToList();
        }
    }
}
