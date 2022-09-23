using RIS_API.Data;
using System.ComponentModel.DataAnnotations;

namespace RIS_API.DTOs
{
    public class CreatePatientDTO
    {
        public string PatientId { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "this valid string length is 25")]
        public string Firstname { get; set; } = null!;

        [MaxLength(25, ErrorMessage = "this valid string length is 25")]
        public string? Middlename { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "this valid string length is 25")]
        public string Lastname { get; set; } = null!;

        [Range(0, 1, ErrorMessage = "0 or 1")]
        public String Sex { get; set; }

        [MaxLength(25, ErrorMessage = "this valid string length is 25")]
        public string Mothername { get; set; }

        public DateTime Birthdate { get; set; }

    }

    public class PatientDTO : CreatePatientDTO
    {
        public int Id { get; set; }
        public ICollection<HL7MessageDTO> HL7Messages { get; set; }

    }
}
