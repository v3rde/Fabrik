using System.ComponentModel.DataAnnotations;

namespace Fabrik.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
