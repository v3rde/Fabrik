using System.ComponentModel.DataAnnotations;

namespace Fabrik.Models
{
    public class Workshop
    {   [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
