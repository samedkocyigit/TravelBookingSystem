﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Dtos.PaymentDtos;
using UserService.Domain.Models;
using UserService.Services.PaymentServices;

namespace UserService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        protected readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPayments();
            return Ok(payments);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(PaymentCreateDto payment)
        {
            var newPayment = await _paymentService.CreatePayment(payment);
            return Ok(newPayment);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPaymentById(Guid id)
        {
            var payment = await _paymentService.GetPaymentById(id);
            return Ok(payment);
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
