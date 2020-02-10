using FunBooksAndVideos.Api.Interfaces;

namespace FunBooksAndVideos.Api.Services
{
    public class CustomerAccountService : ICustomerAccountService
    {
        public void ActivateMembership(int customerId, int itemId)
        {
            //TODO: Retrieve Customer from DB and apply given membership from repository of membership items
            //TODO: update database
        }
    }
}