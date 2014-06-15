using System.ComponentModel.DataAnnotations;

namespace Fabrik.Models
{
    public class Area
    {   [Key]
        public int Id { get; set; }
        public Workshop Workshop { get; set; }
        public string Name { get; set; }
    }
}
