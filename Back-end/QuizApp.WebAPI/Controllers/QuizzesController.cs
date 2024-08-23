using Microsoft.AspNetCore.Mvc;
using QuizApp.Business;
using QuizApp.Business.Services;
using QuizApp.Data.Models;
using System.Linq.Expressions;

namespace QuizApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizService _quizService;
        public QuizzesController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet("get-all-quizzes")]
        public async Task<IActionResult> GetQuizzes()
        {
            var quizzes = await _quizService.GetAllAsync();

            var quizzesViewModels = quizzes.Select(q => new QuizViewModel()
            {
                Id = q.Id,
                Title = q.Title,
                Description = q.Description,
                Notes = q.Notes,
                IsActive = q.IsActive
            }).ToList();

            return Ok(quizzesViewModels);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetQuizById(Guid id)
        {
            var quiz = await _quizService.GetByIdAsync(id);

            if (quiz == null)
                return NotFound();

            var quizViewModel = new QuizViewModel()
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Description = quiz.Description,
                Notes = quiz.Notes,
                IsActive = quiz.IsActive
            };

            return Ok(quizViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetQuizzesByPage([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string filter = "", [FromQuery] string sortBy = "")
        {

            return Ok(_quizService.GetByPagingAsync(filter,sortBy,page,pageSize));
        }
    }
}
