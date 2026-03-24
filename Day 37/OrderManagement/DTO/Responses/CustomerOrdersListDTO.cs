using OrderManagement.Models;

namespace OrderManagement.DTO.Responses
{
    public class CustomerOrdersListDTO
    {
        public int OrdersId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<CustomerOrderDetailDTO> Details { get; set; } = new List<CustomerOrderDetailDTO>();
    }
}
