using PaymentService.Domain.Models;
using PaymentService.Services.PaymentServices;
using Microsoft.AspNetCore.Mvc;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices _paymentService;
        public PaymentController(IPaymentServices paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPayments();
            return Ok(payments);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPaymentById(Guid id)
        {
            var payment = await _paymentService.GetPaymentById(id);
            return Ok(payment);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePayment(Payment payment)
        {
            var newPayment = await _paymentService.CreatePayment(payment);
            return Ok(newPayment);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePayment(Payment payment)
        {
            var updatedPayment = await _paymentService.UpdatePayment(payment);
            return Ok(updatedPayment);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePayment(Guid id)
        {
            await _paymentService.DeletePayment(id);
            return Ok();
        }
    }
}
