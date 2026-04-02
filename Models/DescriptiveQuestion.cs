namespace ExamReady.Models
{
    public class DescriptiveQuestion : Question
    {
        public override string GetDisplayText()
        {
            return $"[Descriptive] {QuestionText}";
        }

        public override string GetQuestionType()
        {
            return "Descriptive";
        }

        public override string GetFormattedQuestion()
        {
            return $"{QuestionText}\n({Marks} marks)";
        }
    }
}
