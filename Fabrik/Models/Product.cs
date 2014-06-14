using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrik.Models
{
   public class Product
    {
       [Key]
       public int Id { get; set; }
       public string Name { get; set; }
       public string Metric { get; set; }
       public int Price { get; set; }


    }
}
