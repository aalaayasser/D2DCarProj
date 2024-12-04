using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject.Models
{
    public enum PaymentMethod
    {
        Cash = 1,
        CreditCard = 2,

    }
    public class Payment : ModelClass
    {



        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }

        public PaymentMethod Method { get; set; }

    }
}

