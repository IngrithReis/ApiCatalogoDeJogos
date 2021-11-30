using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoDeJogos.InputModels
{
    public class JogoInputModel
    {
        [Required(ErrorMessage ="Campo obrigatório!")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="O {0} deve conter de {2} a {1} caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Campo obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "A{0} deve conter de {2} a {1} caracteres!")]
        public string Produtora { get; set; }

        [Required(ErrorMessage ="Campo obrigatório!")]
        [Range(1,1000, ErrorMessage ="O valor do jogo deve estar entre 1 a 1000 Reais!")]
        public double Preco { get; set; }
    }
}
