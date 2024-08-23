using QuizApp.Data.Models;

namespace QuizApp.Business.Services
{
    public interface IQuizService : IBaseService<Quiz>
    {
        Task<PaginatedResult<Quiz>> GetByPagingAsync(
            string filter = "",
            string sortBy = "",
            int pageIndex = 1,
            int pageSize = 10);
    }
}
