using FunBooksAndVideos.Api.Models;

namespace FunBooksAndVideos.Api.Interfaces
{
    public interface IBusinessRule
    {
        void Apply(PurchaseOrder purchaseOrder);
    }
}