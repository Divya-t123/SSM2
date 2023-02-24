using System.ComponentModel.DataAnnotations;

namespace SSM2.Models
{
    public class Product
    {

                [Key]
            public int ProductId { get; set; }
            public string name { get; set; }
            public virtual Category cat { get; set; }
            public double price { get; set; }
            public double weight { get; set; }







    }
}
