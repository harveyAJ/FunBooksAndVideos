using FunBooksAndVideos.Domain.enums;

namespace FunBooksAndVideos.Api.Models
{
    public class Item
    {
        public int Id { get; set; }

        public ItemType Type { get; set; }

        public decimal Price { get; set; }
    }
}