
using System.ComponentModel.DataAnnotations;

namespace PruebaPromart.DTO.Request
{
    public class DtoClient
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string BirthDate { get; set; }
    }
}
