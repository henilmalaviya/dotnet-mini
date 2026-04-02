namespace ExamReady.Models
{
    public abstract class Question
    {
        public int ID { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string QuestionText { get; set; } = string.Empty;
        public string QType { get; set; } = string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public int Marks { get; set; }
        public DateTime CreatedAt { get; set; }

        public abstract string GetDisplayText();
        
        public abstract string GetQuestionType();

        public virtual string GetFormattedQuestion()
        {
            return $"{QuestionText} ({Marks} marks)";
        }
    }
}
