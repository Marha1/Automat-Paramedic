using Automat_Paramedic.Primitives;
using System;

namespace Automat_Paramedic.Models
{
    public class MedicineTransaction : BaseModel
    {
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } 

        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType Type { get; set; }
        public string Notes { get; set; }
    }
}
