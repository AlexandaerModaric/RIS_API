using RIS_API.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ris2022.Data.Models
{
    public partial class Modality
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(25)]
        public string? Name { get; set; }
        
        [Required]
        [StringLength(25)]
        public string? AeTitle { get; set; }
        
        [Required]
        [StringLength(25)]
        public string? IpAddress { get; set; }

        [Required]
        [Range(1, 65536)]
        public int? Port { get; set; }


        [StringLength(200)]
        public string? Description { get; set; }

        [ForeignKey(nameof(Modalitytype))]
        public int Modalitytypeid { get; set; }

        public virtual Modalitytype Modalitytype { get; set; }

        public virtual ICollection<HL7Message>? HL7Messages { get; set; }

    }
}
