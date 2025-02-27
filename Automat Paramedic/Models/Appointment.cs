using System;
using System.Collections.Generic;

namespace Automat_Paramedic.Models
{
    public class Appointment : BaseModel
    {
        public string FullName { get; set; }
        public string Group { get; set; }
        public DateTime Date { get; set; }
        public string Symptoms { get; set; }
        public string Treatment { get; set; }
        public string Recommendations { get; set; }

        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
    }
}
