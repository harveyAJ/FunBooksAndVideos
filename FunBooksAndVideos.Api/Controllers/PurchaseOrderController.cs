using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpPost]
        public StatusCodeResult PlaceOrder(PurchaseOrder purchaseOrder)
        {
            _purchaseOrderService.Process(purchaseOrder);

            return Ok();
        }
    }
}