using FunBooksAndVideos.Api.Models;

namespace FunBooksAndVideos.Api.Interfaces
{
    public interface IPurchaseOrderService
    {
        void Process(PurchaseOrder purchaseOrder);
    }
}