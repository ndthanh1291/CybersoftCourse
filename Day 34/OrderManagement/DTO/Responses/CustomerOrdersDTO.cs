namespace OrderManagement.DTO.Responses
{
    public class CustomerOrdersDTO
    {
        public int OrdersId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string ProductName { get; set; } 
        public int Quantity { get; set; }       
        public decimal UnitPrice { get; set; }  
    }
}
