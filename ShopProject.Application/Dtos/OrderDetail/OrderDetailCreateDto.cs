namespace ShopProject.Application.Dtos.OrderDetail
{
    public class OrderDetailCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
