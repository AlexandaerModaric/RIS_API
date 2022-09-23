using System.ComponentModel.DataAnnotations;

namespace RIS_API.Data
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string PatientId { get; set; }
        [Required]
        [MaxLength(25)]
        public string Firstname { get; set; } = null!;

        [MaxLength(25)]
        public string? Middlename { get; set; }

        [Required]
        [MaxLength(25)]
        public string Lastname { get; set; } = null!;

        [Range(0, 1)]
        public String Sex { get; set; }

        public string Mothername { get; set; }

        public DateTime Birthdate { get; set; }

        public virtual ICollection<HL7Message> patientHL7Msgs
        {
            get; set;
        }
    }
}
