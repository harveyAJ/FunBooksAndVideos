using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;

namespace FunBooksAndVideos.Api.Services
{
    public class ShippingSlipService : IShippingSlipService
    {
        public void Generate(PurchaseOrder purchaseOrder)
        {
            //TODO: Get Customer from purchaseOrder object and e.g. send email with slip (assuming Customer object has an email field)
            //TODO: update the database
        }
    }
}