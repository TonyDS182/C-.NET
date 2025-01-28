using System.ComponentModel.DataAnnotations;

namespace CRUD_Practica.Models
{
    public class Contacto
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Por favor, ingresa un email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
