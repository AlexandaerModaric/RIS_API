using RIS_API.Data;
using System.ComponentModel.DataAnnotations;

namespace RIS_API.DTOs
{
    public class CreateModalitytypeDTO
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
    }
    public class ModalitytypeDTO:CreateModalitytypeDTO
    {
        public int Id { get; set; }

        public ICollection<HL7MessageDTO> HL7Messages { get; set; }
    }
}
