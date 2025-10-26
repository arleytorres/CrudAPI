using System.ComponentModel.DataAnnotations;

namespace CrudJWT.DTOs
{
    public record RegisterRequest
    {
        [Required(ErrorMessage = "O username precisa ser definido.")]
        [MinLength(4, ErrorMessage = "O username não pode ser tão curto.")]
        public string username { get; init; }

        [Required(ErrorMessage = "A senha precisa ser definida.")]
        [MinLength(4, ErrorMessage = "A senha não pode ser tão curta.")]
        public string password { get; init; }

        [Required(ErrorMessage = "A confirmação de senha é obrigatória.")]
        [Compare(nameof(password), ErrorMessage = "As senhas não são equivalentes.")]
        public string confirm_password { get; init; }

        [Required(ErrorMessage = "A role precisa ser definida.")]
        [MinLength(4, ErrorMessage = "A role não pode ser tão curta.")]
        public string role { get; init; }
    }
}
