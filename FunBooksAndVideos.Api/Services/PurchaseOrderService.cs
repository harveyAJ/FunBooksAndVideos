using System.Collections.Generic;
using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;

namespace FunBooksAndVideos.Api.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IList<IBusinessRule> _businessRules;

        public PurchaseOrderService(IList<IBusinessRule> businessRules)
        {
            _businessRules = businessRules;
        }

        public void Process(PurchaseOrder purchaseOrder)
        {
            foreach (var businessRule in _businessRules)
            {
                businessRule.Apply(purchaseOrder);
            }

            //TODO: save purchase order to database
        }
    }
}