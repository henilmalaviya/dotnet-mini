using System.Data;
using Microsoft.Data.Sqlite;
using ExamReady.Models;

namespace ExamReady.Data
{
    public class QuestionRepository
    {
        private readonly string _connectionString;

        public QuestionRepository()
        {
            _connectionString = "Data Source=ExamReady.db;Version=3;";
        }

        private SqliteDataAdapter CreateDataAdapter(string? filterSubject = null)
        {
            string query = "SELECT * FROM tblQuestions";
            
            if (!string.IsNullOrEmpty(filterSubject))
            {
                query += " WHERE Subject = @Subject";
            }
            
            query += " ORDER BY CreatedAt DESC";

            SqliteDataAdapter adapter = new SqliteDataAdapter(query, _connectionString);
            
            if (!string.IsNullOrEmpty(filterSubject))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@Subject", filterSubject);
            }

            adapter.InsertCommand = new SqliteCommand(@"
                INSERT INTO tblQuestions (Subject, QuestionText, QType, Difficulty, Marks, OptionA, OptionB, OptionC, OptionD, CorrectAnswer, CreatedAt)
                VALUES (@Subject, @QuestionText, @QType, @Difficulty, @Marks, @OptionA, @OptionB, @OptionC, @OptionD, @CorrectAnswer, @CreatedAt)", 
                new SqliteConnection(_connectionString));

            adapter.UpdateCommand = new SqliteCommand(@"
                UPDATE tblQuestions 
                SET Subject = @Subject, QuestionText = @QuestionText, QType = @QType, 
                    Difficulty = @Difficulty, Marks = @Marks,
                    OptionA = @OptionA, OptionB = @OptionB, OptionC = @OptionC, OptionD = @OptionD,
                    CorrectAnswer = @CorrectAnswer
                WHERE ID = @ID",
                new SqliteConnection(_connectionString));

            adapter.DeleteCommand = new SqliteCommand("DELETE FROM tblQuestions WHERE ID = @ID",
                new SqliteConnection(_connectionString));

            return adapter;
        }

        public DataSet GetQuestionsDataSet(string? filterSubject = null)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using var adapter = CreateDataAdapter(filterSubject);
                adapter.Fill(dataSet, "tblQuestions");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading questions dataset: {ex.Message}", ex);
            }

            return dataSet;
        }

        public void UpdateQuestionsFromDataSet(DataSet dataSet)
        {
            try
            {
                using var adapter = CreateDataAdapter();
                adapter.Update(dataSet, "tblQuestions");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating questions from dataset: {ex.Message}", ex);
            }
        }

        public DataTable GetFilteredQuestions(string subject, string difficulty, string qType)
        {
            DataTable table = new DataTable();

            try
            {
                using var connection = new SqliteConnection(_connectionString);
                connection.Open();

                List<string> conditions = new List<string>();
                
                if (!string.IsNullOrEmpty(subject))
                    conditions.Add("Subject = @Subject");
                if (!string.IsNullOrEmpty(difficulty))
                    conditions.Add("Difficulty = @Difficulty");
                if (!string.IsNullOrEmpty(qType))
                    conditions.Add("QType = @QType");

                string query = "SELECT * FROM tblQuestions";
                if (conditions.Count > 0)
                    query += " WHERE " + string.Join(" AND ", conditions);

                using var command = new SqliteCommand(query, connection);
                
                if (!string.IsNullOrEmpty(subject))
                    command.Parameters.AddWithValue("@Subject", subject);
                if (!string.IsNullOrEmpty(difficulty))
                    command.Parameters.AddWithValue("@Difficulty", difficulty);
                if (!string.IsNullOrEmpty(qType))
                    command.Parameters.AddWithValue("@QType", qType);

                using var adapter = new SqliteDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error filtering questions: {ex.Message}", ex);
            }

            return table;
        }

        public DataTable GetQuestionsForExam(string subject, string? difficulty, int maxMarks)
        {
            DataTable table = new DataTable();

            try
            {
                using var connection = new SqliteConnection(_connectionString);
                connection.Open();

                string query = "SELECT * FROM tblQuestions WHERE Subject = @Subject AND Marks <= @MaxMarks";
                
                if (!string.IsNullOrEmpty(difficulty))
                {
                    query += " AND Difficulty = @Difficulty";
                }

                using var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@Subject", subject);
                command.Parameters.AddWithValue("@MaxMarks", maxMarks);

                if (!string.IsNullOrEmpty(difficulty))
                {
                    command.Parameters.AddWithValue("@Difficulty", difficulty);
                }

                using var adapter = new SqliteDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching questions for exam: {ex.Message}", ex);
            }

            return table;
        }
    }
}
