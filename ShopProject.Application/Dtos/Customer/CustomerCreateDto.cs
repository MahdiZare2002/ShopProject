namespace ShopProject.Application.Dtos.Customer
{
    public class CustomerCreateDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
