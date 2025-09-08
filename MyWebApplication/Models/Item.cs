using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApplication.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }

        [ForeignKey("SerialNumberId")]
        public int? SerialNumberId { get; set; }
        public SerialNumber? SerialNumber { get; set; } = null!;
    }
}
