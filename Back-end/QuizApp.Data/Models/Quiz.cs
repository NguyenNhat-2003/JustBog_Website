using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Models
{
    public class Quiz
    {
        public  Guid Id { get; set; }
        
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Range(1, 3600)]
        public int Duration { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;

    }
}
