using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using MyTraining1121AngularDemo.Customers.Exporting;
using MyTraining1121AngularDemo.Customers.Dtos;
using MyTraining1121AngularDemo.Dto;
using Abp.Application.Services.Dto;
using MyTraining1121AngularDemo.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using MyTraining1121AngularDemo.Storage;
using MyTraining1121AngularDemo.CustomerUsers.Dtos;
using MyTraining1121AngularDemo.CustomerUsers;
using MyTraining1121AngularDemo.Authorization.Users;

namespace MyTraining1121AngularDemo.Customers
{
    [AbpAuthorize(AppPermissions.Pages_Customers)]
    public class CustomersAppService : MyTraining1121AngularDemoAppServiceBase, ICustomersAppService
    {
        private readonly IRepository<Customer, long> _customerRepository;
        private readonly ICustomersExcelExporter _customersExcelExporter;
        private readonly IRepository<CustomerUser, long> _customerUserRepository;
        private readonly IRepository<User, long> _lookup_userRepository;

        public CustomersAppService(IRepository<Customer, long> customerRepository, ICustomersExcelExporter customersExcelExporter, IRepository<CustomerUser, long> customerUserRepository, IRepository<User, long> lookup_userRepository)
        {
            _customerRepository = customerRepository;
            _customersExcelExporter = customersExcelExporter;
            _customerUserRepository = customerUserRepository;
            _lookup_userRepository = lookup_userRepository;
        }


        public ListResultDto<UsersSecondDto> GetUsersForCustomerDropdown(GetFilterInput input)
        {
            var users = _lookup_userRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   c => c.Name.Contains(input.Filter) ||
                        c.Surname.Contains(input.Filter) ||
                        c.EmailAddress.Contains(input.Filter)
               )
               .OrderBy(c => c.Name)
               .ToList();

            return new ListResultDto<UsersSecondDto>(ObjectMapper.Map<List<UsersSecondDto>>(users));
        }

        public async Task<PagedResultDto<GetCustomerForViewDto>> GetAll(GetAllCustomersInput input)
        {
            var filteredCustomers = _customerRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Email.Contains(input.Filter) || e.Address.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailFilter), e => e.Email == input.EmailFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AddressFilter), e => e.Address == input.AddressFilter)
                        .WhereIf(input.MinRegistrationDateFilter != null, e => e.RegistrationDate >= input.MinRegistrationDateFilter)
                        .WhereIf(input.MaxRegistrationDateFilter != null, e => e.RegistrationDate <= input.MaxRegistrationDateFilter);

            var pagedAndFilteredCustomers = filteredCustomers
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var customers = from o in pagedAndFilteredCustomers
                            select new
                            {

                                o.Name,
                                o.Email,
                                o.Address,
                                o.RegistrationDate,
                                Id = o.Id
                            };

            var totalCount = await filteredCustomers.CountAsync();

            var dbList = await customers.ToListAsync();
            var results = new List<GetCustomerForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetCustomerForViewDto()
                {
                    Customer = new CustomerDto
                    {

                        Name = o.Name,
                        Email = o.Email,
                        Address = o.Address,
                        RegistrationDate = o.RegistrationDate,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetCustomerForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetCustomerForViewDto> GetCustomerForView(long id)
        {
            var customer = await _customerRepository.GetAsync(id);

            var output = new GetCustomerForViewDto { Customer = ObjectMapper.Map<CustomerDto>(customer) };

            return output;
        }


        public async Task<GetCustomerForViewDto> GetCustomer(long id)
        {
            var customer = await _customerRepository.GetAsync(id);

            var output = new GetCustomerForViewDto { Customer = ObjectMapper.Map<CustomerDto>(customer) };


            return output;
        }



        [AbpAuthorize(AppPermissions.Pages_Customers_Edit)]
        public async Task<GetCustomerForEditOutput> GetCustomerForEdit(EntityDto<long> input)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetCustomerForEditOutput { Customer = ObjectMapper.Map<CreateOrEditCustomerDto>(customer) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditCustomerDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Customers_Create)]
        protected virtual async Task Create(CreateOrEditCustomerDto input)
        {
            try
            {
                    
                var customerUser = _customerUserRepository.GetAll();
               

                            var customer = ObjectMapper.Map<Customer>(input);

                            long Customerid = await _customerRepository.InsertAndGetIdAsync(customer);

                            var length = input.UserRefIds.Count;
                            foreach (long i in input.UserRefIds)
                            {
                        
                                var cust = new CustomerUser
                                {
                                    CustomerId = Customerid,
                                    UserId = i,
                                    TotalAmount = 9878

                                };
                                await _customerUserRepository.InsertAsync(cust);
                            }

            }
            catch (Exception e)
            {
                throw e;
            }


        }

        [AbpAuthorize(AppPermissions.Pages_Customers_Edit)]
        protected virtual async Task Update(CreateOrEditCustomerDto input)
        {
            try
            {
              
                var customer = await _customerRepository.FirstOrDefaultAsync((long)input.Id);
                ObjectMapper.Map(input, customer);

              
                long Customerid = await _customerRepository.InsertOrUpdateAndGetIdAsync(customer);

                var length = input.UserRefIds.Count;
                foreach (long i in input.UserRefIds)
                {

                    var cust = new CustomerUser
                    {

                        CustomerId = Customerid,
                        UserId = i,
                        TotalAmount = 9878

                    };
                    await _customerUserRepository.InsertAsync(cust);
                }
            }
            catch(Exception e)
            {
                throw e;
            }

        }

        [AbpAuthorize(AppPermissions.Pages_Customers_Delete)]
        public async Task Delete(EntityDto<long> input)
        {
           var customerUser = await _customerUserRepository.GetAll()
                .Where(a=>a.CustomerId == input.Id)
                .Select(a=>a.Id).FirstOrDefaultAsync();

            await _customerUserRepository.DeleteAsync((long)customerUser);

            await _customerRepository.DeleteAsync(input.Id);
        }


        public async Task<FileDto> GetCustomersToExcel(GetAllCustomersForExcelInput input)
        {

            var filteredCustomers = _customerRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Email.Contains(input.Filter) || e.Address.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailFilter), e => e.Email == input.EmailFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AddressFilter), e => e.Address == input.AddressFilter)
                        .WhereIf(input.MinRegistrationDateFilter != null, e => e.RegistrationDate >= input.MinRegistrationDateFilter)
                        .WhereIf(input.MaxRegistrationDateFilter != null, e => e.RegistrationDate <= input.MaxRegistrationDateFilter);

            var query = (from o in filteredCustomers
                         select new GetCustomerForViewDto()
                         {
                             Customer = new CustomerDto
                             {
                                 Name = o.Name,
                                 Email = o.Email,
                                 Address = o.Address,
                                 RegistrationDate = o.RegistrationDate,
                                 Id = o.Id
                             }
                         });

            var customerListDtos = await query.ToListAsync();

            return _customersExcelExporter.ExportToFile(customerListDtos);
        }

    }
}