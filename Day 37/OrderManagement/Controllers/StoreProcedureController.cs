using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.DTO.Requests;
using OrderManagement.DTO.Responses;
using OrderManagement.Models;

namespace OrderManagement.Controllers
{
    public class StoreProcedureController : Controller
    {
        private readonly CybersoftMarketplaceContext _context;
        public StoreProcedureController(CybersoftMarketplaceContext context)
        {
            _context = context;
        }

        [HttpPost("/api/orders")]
        public async Task<ActionResult> CreateOrder([FromBody] OrderRequest orderRequest)
        {
            try
            {
                if (orderRequest.CustomerId > 0)
                {
                    await _context.Database.BeginTransactionAsync();

                    // Kiem tra khach hang co ton tai khong
                    int isExistedCustomer = _context.Database.SqlQueryRaw<int>($@"EXEC CheckExistedCustomer @CustomerId = ${orderRequest.CustomerId}").AsEnumerable().FirstOrDefault();

                    if (isExistedCustomer == 1)
                    {
                        var result = _context.Database.SqlQueryRaw<CustomerOrderDTO>($@"EXEC CreateCustomerOrder @CustomerId = ${orderRequest.CustomerId}").ToList();
                        await _context.Database.CommitTransactionAsync();

                        return StatusCode(200, new { message = "Thành công", customerOrder = result });
                    }
                    else
                    {
                        return StatusCode(404, new { message = "Không tìm thấy khách hàng" });
                    }
                }
                else
                {
                    return StatusCode(400, new { message = "Bad Request" });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error", error = ex.Message });
            }
        }

        [HttpPost("/api/orders/{orderId}/items")]
        public async Task<ActionResult> AddProductIntoOrder([FromRoute] int orderId, [FromBody] ProductRequest productRequest)
        {
            try
            {
                if (orderId > 0 && productRequest.ProductId > 0 && productRequest.Quantity > 0)
                {
                    await _context.Database.BeginTransactionAsync();

                    // Kiem tra don hang da ton tai chua
                    int isExistedOrder = _context.Database.SqlQueryRaw<int>($@"EXEC CheckExistedOrder @OrderId = ${orderId}").AsEnumerable().FirstOrDefault();

                    if (isExistedOrder == 1)
                    {
                        // Kiem tra san pham co ton tai khong
                        int isExistedProduct = _context.Database.SqlQueryRaw<int>($@"EXEC CheckExistedProduct @ProductId = ${productRequest.ProductId}").AsEnumerable().FirstOrDefault();

                        if (isExistedProduct == 1)
                        {
                            // Bao gom them moi va cap nhat san pham vao don hang
                            int result = _context.Database.SqlQueryRaw<int>($@"EXEC AddProductIntoOrder @OrderId = ${orderId}, @ProductId = ${productRequest.ProductId}, @Quantity = ${productRequest.Quantity}").AsEnumerable().FirstOrDefault();

                            // Truong hop hang ton dap ung
                            if (result == 1)
                            {
                                await _context.Database.CommitTransactionAsync();

                                return StatusCode(200, new { message = "Thành công" });
                            }
                            else
                            {
                                return StatusCode(404, new { message = "Thất bại, hàng tồn kho không đủ" });
                            }
                        }
                        else
                        {
                            return StatusCode(404, new { message = "Không tìm thấy sản phẩm" });
                        }
                    }
                    else
                    {
                        return StatusCode(404, new { message = "Không tìm thấy đơn hàng" });
                    }
                }
                else
                {
                    return StatusCode(400, new { message = "Bad Request" });
                }                
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error", error = ex.Message });
            }

        }


        [HttpGet("/api/orders/{orderId}/total")]
        public async Task<ActionResult> CalculateOrder([FromRoute] int orderId)
        {
            try
            {
                if (orderId > 0)
                {
                    await _context.Database.BeginTransactionAsync();

                    decimal result = _context.Database.SqlQueryRaw<decimal>($@"EXEC CalculateOrder @OrdersId = ${orderId}").AsEnumerable().FirstOrDefault();

                    // Don hang ton tai
                    if (result == 1)
                    {

                        await _context.Database.CommitTransactionAsync();

                        return StatusCode(200, new { message = "Thành công", totalAmount = result });
                    }
                    else
                    {
                        return StatusCode(404, new { message = "Không tìm thấy đơn hàng" });
                    }
                }
                else
                {
                    return StatusCode(400, new { message = "Bad Request" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error", error = ex.Message });
            }

        }

        [HttpGet("api/customers/{customerId}/orders")]
        public async Task<ActionResult> GetCustomerHistories([FromRoute] int customerId)
        {
            try
            {
                if (customerId > 0)
                {
                    await _context.Database.BeginTransactionAsync();

                    int isExistedCustomer = _context.Database.SqlQueryRaw<int>($@"EXEC CheckExistedCustomer @CustomerId = ${customerId}").AsEnumerable().FirstOrDefault();

                    // Kiem tra xem khach hang ton tai khong
                    if (isExistedCustomer == 1)
                    {
                        var result = new List<CustomerOrdersListDTO>();

                        var data = _context.Database.SqlQueryRaw<CustomerOrdersDTO>($@"EXEC GetCustomerOrders @CustomerId = ${customerId}").ToList();

                        result = data
                                        .GroupBy(o => new { o.OrdersId, o.OrderDate, o.TotalAmount })
                                        .Select(g => new CustomerOrdersListDTO
                                        {
                                            OrdersId = g.Key.OrdersId,
                                            OrderDate = g.Key.OrderDate,
                                            TotalAmount = g.Key.TotalAmount,
                                            Details = g.Select(d => new CustomerOrderDetailDTO
                                            {
                                                ProductName = d.ProductName,
                                                Quantity = d.Quantity,
                                                UnitPrice = d.UnitPrice
                                            }).ToList()
                                        }).ToList();

                        await _context.Database.CommitTransactionAsync();

                        return StatusCode(200, new { message = "Thành công", history = result });
                    }
                    else
                    {
                        return StatusCode(404, new { message = "Không tìm thấy khách hàng" });
                    }
                }
                else
                {
                    return StatusCode(400, new { message = "Bad Request" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error", error = ex.Message });
            }

        }
    }
}
