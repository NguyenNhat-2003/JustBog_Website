using QuizApp.Data.Data;
using QuizApp.Data.Models;
using QuizApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data
{
    public interface IUnitOfWork : IDisposable
    {
        QuizAppDbContext Context { get; }

        IGenericRepository<Quiz> QuizRepository { get; }
        IGenericRepository<Question> QuestionRepository { get; }
        IGenericRepository<User> UserRepository { get; }    
        IGenericRepository<Role> RoleRepository { get; }

        IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();
    }
}
