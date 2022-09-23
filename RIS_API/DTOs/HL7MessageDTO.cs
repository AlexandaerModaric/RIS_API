using RIS_API.Data;
using Ris2022.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RIS_API.DTOs
{
    public class CreateHL7MessageDTO
    {
        public int Patientid { get; set; }

        public int Modalityid { get; set; }


        public int Proceduretypeid { get; set; }

        public string Studyid { get; set; }

        public DateTime Startdate { get; set; }

        public int Accessionnumber { get; set; }

        public DateTime Insertdate { get; set; }
    }
    public class HL7MessageDTO:CreateHL7MessageDTO
    {
        public int Id { get; set; }

        public PatientDTO patient { get; set; }


        public ModalityDTO modality { get; set; }

        public ProceduretypeDTO proceduretype { get; set; }
    }

}
