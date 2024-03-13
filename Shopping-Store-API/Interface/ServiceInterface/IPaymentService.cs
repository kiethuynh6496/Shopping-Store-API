using Shopping_Store_API.DTOs.OrderDTOs;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Interface.ServiceInterface
{
    public interface IPaymentService
    {
        MomoResponseDTO CreateMomoPayment(Order order);
    }
}
