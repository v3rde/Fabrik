using System;
using System.ComponentModel.DataAnnotations;

namespace Fabrik.Models
{
    public class Production
    {
        [Key]
        public int Id { get; set; }
        public Area Area { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Worker Worker { get; set; }
        public DateTime DateTime { get; set; }
    }
}
