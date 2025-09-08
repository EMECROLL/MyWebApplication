using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApplication.Models
{
    public class SerialNumber
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public Item? Item { get; set; }
    }
}
