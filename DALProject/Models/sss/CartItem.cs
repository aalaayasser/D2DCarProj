using System.ComponentModel.DataAnnotations;

namespace DALProject.Models.sss
{
    public class CartItem : ModelClass
    {

       

        public int Quantity { get; set; }
        public System.DateTime DateCreated { get; set; }

        public int PartId { get; set; }
        [Required]
        public virtual Part Part { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }

    
}
