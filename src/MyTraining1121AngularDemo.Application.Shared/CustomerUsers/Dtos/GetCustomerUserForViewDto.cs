namespace MyTraining1121AngularDemo.CustomerUsers.Dtos
{
    public class GetCustomerUserForViewDto
    {
        public CustomerUserDto CustomerUser { get; set; }

        public long? CustomerId { get; set; }
        public string CustomerName { get; set; }

        public long? UserId { get; set; }   
        public string UserName { get; set; }
        public string Email { get; set; }
       

    }
}