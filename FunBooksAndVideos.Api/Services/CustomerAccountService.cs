using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;
using FunBooksAndVideos.Domain.enums;

namespace FunBooksAndVideos.Api.Services
{
    public class CustomerAccountService : ICustomerAccountService
    {
        public void ActivateMembership(int customerId, int itemId)
        {
            //Retrieve Customer from DB and apply given membership
        }
    }
}