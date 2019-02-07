using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proficiencia.Application.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public string Descricao { get; set; }
        public string Conclusao { get; set; }        
    }
}
