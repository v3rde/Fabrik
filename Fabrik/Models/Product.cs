using System.ComponentModel.DataAnnotations;

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
