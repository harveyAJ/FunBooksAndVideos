using System.Linq;
using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;
using FunBooksAndVideos.Api.Models.enums;

namespace FunBooksAndVideos.Api.BusinessRules
{
    /// <summary>
    /// This is business rule 2: If the purchase order contains a physical product a shipping slip has to be generated
    /// </summary>
    public class GenerateShippingSlipBusinessRule : IBusinessRule
    {
        private readonly IShippingSlipService _shippingSlipService;

        public GenerateShippingSlipBusinessRule(IShippingSlipService shippingSlipService)
        {
            _shippingSlipService = shippingSlipService;
        }

        public void Apply(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder.Items.Any(x => x.Type == ItemType.Product))
            {
                _shippingSlipService.Generate(purchaseOrder);
            }
        }
    }
}