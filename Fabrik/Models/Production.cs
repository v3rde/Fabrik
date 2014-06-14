using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
