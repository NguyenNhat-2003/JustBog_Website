using QuizApp.Data.Data;
using QuizApp.Data.Models;
using QuizApp.Data.Repositories;

namespace QuizApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuizAppDbContext _context;
        private IGenericRepository<Quiz>? _quizRepository;
        private IGenericRepository<Question>? _questionRepository;
        private IGenericRepository<User>? _userRepository;
        private IGenericRepository<Role>? _roleRepository;

        public UnitOfWork(QuizAppDbContext context)
        {
            _context=context;
        }
        public QuizAppDbContext Context => _context;

        public IGenericRepository<Quiz> QuizRepository => _quizRepository ?? new GenericRepository<Quiz>(_context);

        public IGenericRepository<Question> QuestionRepository => _questionRepository ?? new GenericRepository<Question>(_context);

        public IGenericRepository<User> UserRepository => _userRepository ?? new GenericRepository<User>(_context);

        public IGenericRepository<Role> RoleRepository => _roleRepository ?? new GenericRepository<Role>(_context);

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();    
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);    
        }

        public async Task RollBackTransactionAsync()
        {
           await _context.Database.RollbackTransactionAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
