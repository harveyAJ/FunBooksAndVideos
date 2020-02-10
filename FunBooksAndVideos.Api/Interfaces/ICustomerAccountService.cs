namespace FunBooksAndVideos.Api.Interfaces
{
    public interface ICustomerAccountService
    {
        void ActivateMembership(int customerId, int itemId);
    }
}