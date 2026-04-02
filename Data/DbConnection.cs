using System.Data;
using Microsoft.Data.Sqlite;
using ExamReady.Models;

namespace ExamReady.Data
{
    public class DbConnection
    {
        private readonly string _connectionString;

        public DbConnection()
        {
            _connectionString = "Data Source=ExamReady.db";
        }

        public DbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqliteConnection GetConnection()
        {
            return new SqliteConnection(_connectionString);
        }

        public void InitializeDatabase()
        {
            using var connection = GetConnection();
            connection.Open();

            string createTableSql = @"
                CREATE TABLE IF NOT EXISTS tblQuestions (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Subject TEXT NOT NULL,
                    QuestionText TEXT NOT NULL,
                    QType TEXT NOT NULL,
                    Difficulty TEXT NOT NULL,
                    Marks INTEGER NOT NULL,
                    OptionA TEXT,
                    OptionB TEXT,
                    OptionC TEXT,
                    OptionD TEXT,
                    CorrectAnswer TEXT,
                    CreatedAt TEXT DEFAULT CURRENT_TIMESTAMP
                )";

            using var command = new SqliteCommand(createTableSql, connection);
            command.ExecuteNonQuery();
        }

        public List<Question> GetAllQuestions()
        {
            List<Question> questions = new List<Question>();

            try
            {
                using var connection = GetConnection();
                connection.Open();

                string query = "SELECT * FROM tblQuestions ORDER BY CreatedAt DESC";
                using var command = new SqliteCommand(query, connection);
                
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    questions.Add(QuestionFactory.CreateQuestionFromDataReader(reader));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching questions: {ex.Message}", ex);
            }

            return questions;
        }

        public List<Question> GetQuestionsBySubject(string subject)
        {
            List<Question> questions = new List<Question>();

            try
            {
                using var connection = GetConnection();
                connection.Open();

                string query = "SELECT * FROM tblQuestions WHERE Subject = @Subject";
                using var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@Subject", subject);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    questions.Add(QuestionFactory.CreateQuestionFromDataReader(reader));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching questions by subject: {ex.Message}", ex);
            }

            return questions;
        }

        public Question? GetQuestionById(int id)
        {
            try
            {
                using var connection = GetConnection();
                connection.Open();

                string query = "SELECT * FROM tblQuestions WHERE ID = @ID";
                using var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return QuestionFactory.CreateQuestionFromDataReader(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching question by ID: {ex.Message}", ex);
            }

            return null;
        }

        public int InsertQuestion(Question question)
        {
            try
            {
                using var connection = GetConnection();
                connection.Open();

                string query = @"
                    INSERT INTO tblQuestions (Subject, QuestionText, QType, Difficulty, Marks, OptionA, OptionB, OptionC, OptionD, CorrectAnswer, CreatedAt)
                    VALUES (@Subject, @QuestionText, @QType, @Difficulty, @Marks, @OptionA, @OptionB, @OptionC, @OptionD, @CorrectAnswer, @CreatedAt);
                    SELECT last_insert_rowid();";

                using var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@Subject", question.Subject);
                command.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                command.Parameters.AddWithValue("@QType", question.QType);
                command.Parameters.AddWithValue("@Difficulty", question.Difficulty);
                command.Parameters.AddWithValue("@Marks", question.Marks);
                command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                if (question is MCQQuestion mcq)
                {
                    command.Parameters.AddWithValue("@OptionA", mcq.OptionA);
                    command.Parameters.AddWithValue("@OptionB", mcq.OptionB);
                    command.Parameters.AddWithValue("@OptionC", mcq.OptionC);
                    command.Parameters.AddWithValue("@OptionD", mcq.OptionD);
                    command.Parameters.AddWithValue("@CorrectAnswer", mcq.CorrectAnswer);
                }
                else
                {
                    command.Parameters.AddWithValue("@OptionA", "");
                    command.Parameters.AddWithValue("@OptionB", "");
                    command.Parameters.AddWithValue("@OptionC", "");
                    command.Parameters.AddWithValue("@OptionD", "");
                    command.Parameters.AddWithValue("@CorrectAnswer", "");
                }

                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting question: {ex.Message}", ex);
            }
        }

        public void UpdateQuestion(Question question)
        {
            try
            {
                using var connection = GetConnection();
                connection.Open();

                string query = @"
                    UPDATE tblQuestions 
                    SET Subject = @Subject, QuestionText = @QuestionText, QType = @QType, 
                        Difficulty = @Difficulty, Marks = @Marks,
                        OptionA = @OptionA, OptionB = @OptionB, OptionC = @OptionC, OptionD = @OptionD,
                        CorrectAnswer = @CorrectAnswer
                    WHERE ID = @ID";

                using var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@ID", question.ID);
                command.Parameters.AddWithValue("@Subject", question.Subject);
                command.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                command.Parameters.AddWithValue("@QType", question.QType);
                command.Parameters.AddWithValue("@Difficulty", question.Difficulty);
                command.Parameters.AddWithValue("@Marks", question.Marks);

                if (question is MCQQuestion mcq)
                {
                    command.Parameters.AddWithValue("@OptionA", mcq.OptionA);
                    command.Parameters.AddWithValue("@OptionB", mcq.OptionB);
                    command.Parameters.AddWithValue("@OptionC", mcq.OptionC);
                    command.Parameters.AddWithValue("@OptionD", mcq.OptionD);
                    command.Parameters.AddWithValue("@CorrectAnswer", mcq.CorrectAnswer);
                }
                else
                {
                    command.Parameters.AddWithValue("@OptionA", "");
                    command.Parameters.AddWithValue("@OptionB", "");
                    command.Parameters.AddWithValue("@OptionC", "");
                    command.Parameters.AddWithValue("@OptionD", "");
                    command.Parameters.AddWithValue("@CorrectAnswer", "");
                }

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating question: {ex.Message}", ex);
            }
        }

        public void DeleteQuestion(int id)
        {
            try
            {
                using var connection = GetConnection();
                connection.Open();

                string query = "DELETE FROM tblQuestions WHERE ID = @ID";
                using var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting question: {ex.Message}", ex);
            }
        }

        public List<string> GetDistinctSubjects()
        {
            List<string> subjects = new List<string>();

            try
            {
                using var connection = GetConnection();
                connection.Open();

                string query = "SELECT DISTINCT Subject FROM tblQuestions ORDER BY Subject";
                using var command = new SqliteCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    subjects.Add(reader["Subject"].ToString() ?? "");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching subjects: {ex.Message}", ex);
            }

            return subjects;
        }
    }
}
