namespace ShopProject.Application.Dtos.Address
{
    public class AddressDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string CompleteAddress { get; set; }
        public int NoNumber { get; set; }
    }
}
