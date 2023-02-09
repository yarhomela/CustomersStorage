using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerStorage.DataAccessLayer.Entities
{
    public class Customer : Base.Base
    {
        [Column(TypeName = "nvarchar(150)")]
        public string? Name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? CompanyName { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
