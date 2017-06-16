using System.ComponentModel.DataAnnotations;


namespace LoginRegistration.Models 
{
    public class User
    {
        [MinLength(2)]
        [DataType(DataType.Text)]
        public string Name {get; set;}
        
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password {get; set;}
        [Required]
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        public string PasswordConfirmation { get; set; }
    }


}