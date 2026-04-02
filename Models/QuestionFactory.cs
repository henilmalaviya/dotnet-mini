namespace ExamReady.Models
{
    public static class QuestionFactory
    {
        public static Question CreateQuestion(string qType)
        {
            return qType.ToUpper() switch
            {
                "MCQ" => new MCQQuestion(),
                "DESCRIPTIVE" => new DescriptiveQuestion(),
                _ => throw new ArgumentException($"Unknown question type: {qType}")
            };
        }

        public static Question CreateQuestionFromDataReader(System.Data.IDataReader reader)
        {
            string qType = reader["QType"].ToString() ?? "";
            Question question = CreateQuestion(qType);

            question.ID = Convert.ToInt32(reader["ID"]);
            question.Subject = reader["Subject"].ToString() ?? "";
            question.QuestionText = reader["QuestionText"].ToString() ?? "";
            question.QType = qType;
            question.Difficulty = reader["Difficulty"].ToString() ?? "";
            question.Marks = Convert.ToInt32(reader["Marks"]);
            question.CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString() ?? DateTime.Now.ToString());

            if (question is MCQQuestion mcq)
            {
                mcq.OptionA = reader["OptionA"].ToString() ?? "";
                mcq.OptionB = reader["OptionB"].ToString() ?? "";
                mcq.OptionC = reader["OptionC"].ToString() ?? "";
                mcq.OptionD = reader["OptionD"].ToString() ?? "";
                mcq.CorrectAnswer = reader["CorrectAnswer"].ToString() ?? "";
            }

            return question;
        }
    }
}
