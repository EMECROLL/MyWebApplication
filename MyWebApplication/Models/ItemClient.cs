using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApplication.Models
{
    public class ItemClient
    {
        [ForeignKey("ItemId")]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
