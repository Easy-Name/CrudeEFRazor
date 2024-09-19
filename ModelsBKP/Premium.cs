/*using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Premium
{
    [Key]
    [DisplayName("Id")] 
    public int Id { get; set; }  //Key indicates that this ID is going to be a primary Key

    //validations for Premium
    [Required(ErrorMessage = "Informe o titulo do Premium")]
    [StringLength(80, ErrorMessage = "O nome deve conter até 80 caracteres")]
    [MinLength(5, ErrorMessage = "O nome deve conter pelo menos 5 caracteres")]
    //end of validations for name

    [DisplayName("Título")]
    public string Name { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    [DisplayName("Inicio")]
    public DateTime StartDate { get; set; }


    [DataType(DataType.DateTime)]
    [DisplayName("Termino")]
    public DateTime EndtDate { get; set; }

    [DisplayName("Aluno")]
    [Required(ErrorMessage = "Aluno inválido")]
    public int StudentId { get; set; }

    public Student? Student { get; set; }

}*/
