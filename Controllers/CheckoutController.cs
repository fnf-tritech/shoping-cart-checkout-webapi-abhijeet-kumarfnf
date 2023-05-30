using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCheckout.Services;
using System;

namespace ShoppingCheckout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly CheckoutServices _checkout;

        public CheckoutController(CheckoutServices checkout)
        {
            _checkout = checkout;
        }

        [HttpGet("{skus}")]
        public IActionResult Checkout(string skus)
        {
            try
            {
                int totalPrice = _checkout.Checkout(skus);
                return Ok(totalPrice);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}