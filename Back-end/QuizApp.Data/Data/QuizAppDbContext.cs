using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data.Models;

namespace QuizApp.Data.Data
{
    public class QuizAppDbContext :IdentityDbContext<User,Role,Guid>
    {
        public DbSet<Quiz> Quizzes { get; set; }

        public QuizAppDbContext(DbContextOptions<QuizAppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.;database=QuizzDb;user=sa;password=123456789;TrustServerCertificate=true");
            }
        }
    }
}
