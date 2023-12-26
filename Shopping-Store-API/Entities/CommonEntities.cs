using System.ComponentModel.DataAnnotations;

namespace Shopping_Store_API.Entities
{
    public class TrackEntity
    {
        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }
    }
}
