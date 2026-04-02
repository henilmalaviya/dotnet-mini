-- Exam-Ready SQLite Database Schema

CREATE TABLE IF NOT EXISTS tblQuestions (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Subject TEXT NOT NULL,
    QuestionText TEXT NOT NULL,
    QType TEXT NOT NULL,
    Difficulty TEXT NOT NULL,
    Marks INTEGER NOT NULL,
    CreatedAt TEXT DEFAULT CURRENT_TIMESTAMP
);

-- Sample data for testing
INSERT INTO tblQuestions (Subject, QuestionText, QType, Difficulty, Marks) VALUES
('Mathematics', 'What is 2 + 2?', 'MCQ', 'Easy', 1),
('Mathematics', 'Solve: x + 5 = 10', 'Descriptive', 'Medium', 5),
('Mathematics', 'Calculate the derivative of x²', 'Descriptive', 'Hard', 10),
('Science', 'What is H2O?', 'MCQ', 'Easy', 1),
('Science', 'Explain photosynthesis', 'Descriptive', 'Hard', 10),
('English', 'What is a noun?', 'MCQ', 'Easy', 1),
('English', 'Write a paragraph about your favorite book', 'Descriptive', 'Medium', 5);
