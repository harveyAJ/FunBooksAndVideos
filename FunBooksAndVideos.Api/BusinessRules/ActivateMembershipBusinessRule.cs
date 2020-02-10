using System.Linq;
using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;
using FunBooksAndVideos.Api.Models.enums;
using FunBooksAndVideos.Domain.enums;

namespace FunBooksAndVideos.Api.BusinessRules
{
    /// <summary>
    /// This is business rule 1: If the purchase order contains a membership, it has to be activated in the customer account immediately
    /// </summary>
    public class ActivateMembershipBusinessRule : IBusinessRule
    {
        private readonly ICustomerAccountService _customerAccountService;

        public ActivateMembershipBusinessRule(ICustomerAccountService customerAccountService)
        {
            _customerAccountService = customerAccountService;
        }

        public void Apply(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder.Items.Any(x => x.Type == ItemType.Membership))
            {
                foreach (var item in purchaseOrder.Items)
                {
                    _customerAccountService.ActivateMembership(purchaseOrder.CustomerId, item.Id);
                }
            }
        }
    }
}