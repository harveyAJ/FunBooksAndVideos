using FunBooksAndVideos.Api.Models;
using FunBooksAndVideos.Domain.enums;

namespace FunBooksAndVideos.Api.Interfaces
{
    public interface ICustomerAccountService
    {
        void ActivateMembership(int customerId, int itemId);
    }
}