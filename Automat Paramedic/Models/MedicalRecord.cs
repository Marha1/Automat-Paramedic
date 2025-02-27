using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat_Paramedic.Models
{
    public class MedicalRecord: BaseModel
    {
        public string FullName { get; set; } // ФИО учащегося
        public DateTime DateOfBirth { get; set; } // Дата рождения
        public string ChronicDiseases { get; set; } // Хронические заболевания
        public string Allergies { get; set; } // Аллергии
        public string Vaccinations { get; set; } // Прививки
    }
}
