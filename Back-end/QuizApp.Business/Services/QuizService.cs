using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuizApp.Business.Services.Base;
using QuizApp.Data;
using QuizApp.Data.Models;
using System.Globalization;
using System.Linq.Expressions;

namespace QuizApp.Business.Services
{
    public class QuizService :BaseService<Quiz>,IQuizService
    {
        public QuizService(IUnitOfWork unitOfWork,ILogger<QuizService> logger) :base(unitOfWork, logger) 
        {
            
        }

        public async Task<PaginatedResult<Quiz>> GetByPagingAsync(string filter = "", string sortBy = "", int pageIndex = 1, int pageSize = 10)
        {
            Func<IQueryable<Quiz>, IOrderedQueryable<Quiz>> orderBy = null;

            switch (sortBy.ToLower())
            {
                case "title":
                    orderBy = q => q.OrderBy(p => p.Title);
                    break;
                case "id":
                    orderBy = q => q.OrderBy(p => p.Id);
                    break;

            }

            Expression<Func<Quiz, bool>> filterQuery = null;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                filterQuery = p => p.Title.Contains(filter);
            }

            return await GetAsync(filterQuery, orderBy, "", pageIndex, pageSize);

        }
    }
}
