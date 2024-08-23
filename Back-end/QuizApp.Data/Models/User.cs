using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Data.Models
{
    public class User :IdentityUser<Guid>
    {
        [StringLength(50,MinimumLength =3)]
        public string FirstName { get; set; }
        public bool IsActive { get; set; }
    }
}
