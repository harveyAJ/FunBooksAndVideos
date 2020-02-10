using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;

namespace FunBooksAndVideos.Api.Services
{
    public class ShippingSlipService : IShippingSlipService
    {
        public void Generate(PurchaseOrder purchaseOrder)
        {
            //Get Customer from purchaseOrder and send email with slip or something like that
            //Could also store that shipping slip to DB
        }
    }
}