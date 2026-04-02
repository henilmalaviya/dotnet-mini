namespace ExamReady.Models
{
    public class MCQQuestion : Question
    {
        public string OptionA { get; set; } = string.Empty;
        public string OptionB { get; set; } = string.Empty;
        public string OptionC { get; set; } = string.Empty;
        public string OptionD { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;

        public override string GetDisplayText()
        {
            return $"[MCQ] {QuestionText}";
        }

        public override string GetQuestionType()
        {
            return "MCQ";
        }

        public override string GetFormattedQuestion()
        {
            return $"{QuestionText}\nA) {OptionA}\nB) {OptionB}\nC) {OptionC}\nD) {OptionD}\n({Marks} marks)";
        }
    }
}
