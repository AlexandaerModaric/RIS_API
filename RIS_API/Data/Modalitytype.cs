using RIS_API.Data;
using System.ComponentModel.DataAnnotations;

namespace Ris2022.Data.Models
{
    public partial class Modalitytype
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }


        public virtual ICollection<HL7Message> HL7Messages { get; set; }

    }
}
