using FunBooksAndVideos.Api.Models;

namespace FunBooksAndVideos.Api.Interfaces
{
    public interface IShippingSlipService
    {
        void Generate(PurchaseOrder purchaseOrder);
    }
}