using System.Collections.Generic;

namespace FunBooksAndVideos.Api.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public IEnumerable<Item> Items { get; set; }

        public decimal TotalPrice { get; set; }
    }
}