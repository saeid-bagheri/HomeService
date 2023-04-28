using System.ComponentModel.DataAnnotations.Schema;

namespace HomeService.Models.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
