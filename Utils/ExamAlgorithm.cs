using System;
using System.Collections.Generic;
using System.Linq;
using ExamReady.Data;
using ExamReady.Models;

namespace ExamReady.Utils
{
    public class ExamAlgorithm
    {
        private readonly Random _random = new Random();

        public List<Question> GenerateExam(int totalMarks, string subject, double easyPercent, double mediumPercent, double hardPercent)
        {
            var db = new DbConnection();
            var allQuestions = db.GetQuestionsBySubject(subject);

            if (allQuestions.Count == 0)
                return new List<Question>();

            var easyQuestions = allQuestions.Where(q => q.Difficulty == "Easy").ToList();
            var mediumQuestions = allQuestions.Where(q => q.Difficulty == "Medium").ToList();
            var hardQuestions = allQuestions.Where(q => q.Difficulty == "Hard").ToList();

            int easyMarks = (int)(totalMarks * easyPercent / 100.0);
            int mediumMarks = (int)(totalMarks * mediumPercent / 100.0);
            int hardMarks = (int)(totalMarks * hardPercent / 100.0);

            List<Question> selected = new List<Question>();
            selected.AddRange(SelectByDifficulty(easyQuestions, easyMarks));
            selected.AddRange(SelectByDifficulty(mediumQuestions, mediumMarks));
            selected.AddRange(SelectByDifficulty(hardQuestions, hardMarks));

            int current = selected.Sum(q => q.Marks);
            if (current < totalMarks)
            {
                var remaining = allQuestions.Where(q => !selected.Any(s => s.ID == q.ID))
                    .OrderByDescending(q => q.Marks).ToList();
                foreach (var q in remaining)
                {
                    if (current + q.Marks <= totalMarks)
                    {
                        selected.Add(q);
                        current += q.Marks;
                    }
                    if (current >= totalMarks) break;
                }
            }

            return selected.OrderBy(q => q.Difficulty == "Easy" ? 1 : q.Difficulty == "Medium" ? 2 : 3).ToList();
        }

        private List<Question> SelectByDifficulty(List<Question> questions, int targetMarks)
        {
            var selected = new List<Question>();
            var shuffled = questions.OrderBy(x => _random.Next()).ToList();
            int current = 0;
            foreach (var q in shuffled)
            {
                if (current + q.Marks <= targetMarks)
                {
                    selected.Add(q);
                    current += q.Marks;
                }
                if (current >= targetMarks) break;
            }
            return selected;
        }
    }
}
