using System.ComponentModel.DataAnnotations;

namespace CustomerStorage.ViewModels.CustomerModels
{
    public class CreateCustomerViewModel
    {
        [Required(ErrorMessage = "Name - is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Company name - is required")]
        public string? CompanyName { get; set; }

        [Phone(ErrorMessage = "Invalid Phone")]
        [StringLength(13, ErrorMessage = "Invalid Phone")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Email - is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string? Email { get; set; }
    }
}
