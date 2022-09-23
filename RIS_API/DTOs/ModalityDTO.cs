using RIS_API.Data;
using Ris2022.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RIS_API.DTOs
{
    public class CreateModalityDTO
    {

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

        public int Modalitytypeid { get; set; }

    }
    public class ModalityDTO:CreateModalityDTO
    {
        public int Id { get; set; }

        public ModalitytypeDTO Modalitytype { get; set; }

        public ICollection<HL7MessageDTO> HL7Messages { get; set; }
    }
}
