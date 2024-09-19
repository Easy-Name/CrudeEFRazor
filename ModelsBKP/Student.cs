/*using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Student
{
    [Key]
    [DisplayName("Id")] //name that is going to be shown on the screen
    public int Id { get; set; }  //Key indicates that this ID is going to be a primary Key

    //validations for name
    [Required(ErrorMessage ="Informe o nome")]
    [StringLength(80, ErrorMessage = "O nome deve conter até 80 caracteres")]
    [MinLength(5, ErrorMessage = "O nome deve conter pelo menos 5 caracteres")]
    //end of validations for name

    [DisplayName("Nome Completo")]
    public string Name { get; set; } = string.Empty;

    //validations for email
    [Required(ErrorMessage = "Informe o email")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]


    [DisplayName("E-Mail")]
    public string Email { get; set; } = string.Empty;

    public List<Student> Students { get; set; } = new();

}
*/