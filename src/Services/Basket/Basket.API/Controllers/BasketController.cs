using Basket.API.ClientGprcServices;
using Basket.Domain.Entities;
using Basket.Domain.Reposities;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly DiscountServiceClient _discountServiceClient;
        private readonly IPublishEndpoint _publishEndpoint;

        public BasketController(IBasketRepository basketRepository, DiscountServiceClient discountServiceClient, IPublishEndpoint publishEndpoint)
        {
            _basketRepository = basketRepository ?? throw new ArgumentException(nameof(basketRepository));
            _discountServiceClient = discountServiceClient;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet("{username}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult< ShoppingCart>> GetBasketAsync(string username)
        {
            var basket = await _basketRepository.GetBasket(username);
            return Ok(basket ?? new ShoppingCart(username));
        }

        [HttpPost]
        
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasetAsync(ShoppingCart shoppingCart)
        {
           // var result = await _discountServiceClient.CheckDisountAsync(new Discount.Gprc.CouponRequet() { ProductId = "1", Value = "XVB" });
            
           //return Ok( await _basketRepository.UpdateBasket(shoppingCart));

            // Communicate with Discount.Grpc and calculate lastest prices of products into sc
            foreach (var item in shoppingCart.Items)
            {
                var coupon = await _discountServiceClient.CheckDisountAsync(new Discount.Gprc.CouponRequet() {ProductId = item.ProductName, Value = item.Price.ToString() });
                item.Price -= coupon.Amount;
            }

            return Ok(await _basketRepository.UpdateBasket(shoppingCart));
        }
        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasketAsync(string username)
        {
            await _basketRepository.DeleteBasket(username);
            return Ok();
        }

        [HttpPost]
        [Route("Checkout")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> CheckoutBasketAsync(string username)
        {
            var basket = await _basketRepository.GetBasket(username);
            if(basket != null && basket.Items.Count > 0)
            {
                BasketCheckoutEvent checkoutEvent = new BasketCheckoutEvent() { TotalPrice = basket.TotalPrice, UserName = username };
                foreach(var item in basket.Items)
                {
                    checkoutEvent.Items.Add(new ProductItem() 
                    { 
                        Color = item.Color ,
                        ProductId = item.ProductId ,
                        Price = item.Price ,
                        ProductName = item.ProductName ,
                        Quantity= item.Quantity 
                    });
                }
                await _publishEndpoint.Publish(checkoutEvent);
                await _basketRepository.DeleteBasket(username);
                return Accepted();
            }
            else
            {
                return BadRequest();
            }

            
        }
    }
}
