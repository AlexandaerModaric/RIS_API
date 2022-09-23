using System.ComponentModel.DataAnnotations.Schema;
using Ris2022.Data.Models;

namespace RIS_API.Data
{
    public class HL7Message
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Patient))]
        public int Patientid { get; set; }
        public virtual Patient patient { get; set; }

        [ForeignKey(nameof(Modality))]
        public int Modalityid { get; set; }

        public virtual Modality modality { get; set; }

        [ForeignKey(nameof(Proceduretype))]
        public int Proceduretypeid { get; set; }

        public virtual Proceduretype proceduretype { get; set; }

        public string Studyid { get; set; }

        public DateTime Startdate { get; set; }

        public int Accessionnumber { get; set; }

        public DateTime Insertdate { get; set; }
    }
}
