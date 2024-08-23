namespace QuizApp.Business
{
    public class QuizViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; } 
    }
}
