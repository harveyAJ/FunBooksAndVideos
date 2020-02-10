using FunBooksAndVideos.Domain.enums;

namespace FunBooksAndVideos.Api.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public MembershipType MembershipType { get; set; }

        public int Points { get; set; }
    }
}