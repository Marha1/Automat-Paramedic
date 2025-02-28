using System;

namespace Automat_Paramedic.Models
{
    public class VaccinationRecord : BaseModel
    {
        public string PatientName { get; set; }
        public string VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
        public DateTime NextVaccinationDate { get; set; }
    }
}