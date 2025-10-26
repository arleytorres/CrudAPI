using System.ComponentModel.DataAnnotations;

namespace CrudJWT.DTOs
{
    public record LoginRequest
    {
        [Required(ErrorMessage = "O username precisa ser definido.")]
        [MinLength(4, ErrorMessage = "O username não pode ser tão curto.")]
        public string username { get; init; }

        [Required(ErrorMessage = "A senha precisa ser definida.")]
        [MinLength(4, ErrorMessage = "A senha não pode ser tão curta.")]
        public string password { get; init; }
    }
}
