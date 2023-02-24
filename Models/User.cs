using System.ComponentModel.DataAnnotations;

namespace SSM2.Models
{
    public class User
    {

        [Key]
            public int UserID { get; set; }
            public string FName { get; set; }

            public string LName { get; set; }


        
    }
}
