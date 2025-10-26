using System.ComponentModel.DataAnnotations;

namespace CrudJWT.DTOs
{
    public record ClientRequest
    {
        [Required(ErrorMessage = "O nome do cliente precisa ser definido.")]
        [MinLength(3, ErrorMessage = "O nome não pode ser tão curto")]
        public string firstName { get; init; }

        [Required(ErrorMessage = "O sobrenome do cliente precisa ser definido.")]
        [MinLength(3, ErrorMessage = "O sobrenome não pode ser tão curto")]
        public string lastName { get; init; }

        [Range(18, 120, ErrorMessage = "A idade informada é inválida (deve ser entre 18 e 120).")]
        public int age { get; init; }

        [Required(ErrorMessage = "O número de celular é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O número de celular informado é inválido. (válido: DD+número)")]
        public string phoneNumber { get; init; }
    }
}
