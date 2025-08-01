namespace ShopProject.Application.Dtos.OrderDetail
{
    public class OrderDetailDto
    {
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
