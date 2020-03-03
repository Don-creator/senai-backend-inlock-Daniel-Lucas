using System.ComponentModel.DataAnnotations;


namespace Senai.InLock.WebApi.Domains
{
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "Informe o nome do estudio")]
        public string NomeEstudio { get; set; }
    }
}
