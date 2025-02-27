using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat_Paramedic.Models
{
    public class Medicine : BaseModel
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public List<MedicineTransaction> Transactions { get; set; } = new();

    }

}
