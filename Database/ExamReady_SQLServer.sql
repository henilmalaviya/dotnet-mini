-- =====================================================
-- Exam-Ready SQL Script for SQL Server
-- Run this script in SQL Server Management Studio
-- =====================================================

-- Create database (if needed)
-- CREATE DATABASE ExamReadyDB;
-- USE ExamReadyDB;

-- Create Questions table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tblQuestions')
BEGIN
    CREATE TABLE tblQuestions (
        ID INT PRIMARY KEY IDENTITY(1,1),
        Subject NVARCHAR(100) NOT NULL,
        QuestionText NVARCHAR(MAX) NOT NULL,
        QType NVARCHAR(20) NOT NULL,
        Difficulty NVARCHAR(20) NOT NULL,
        Marks INT NOT NULL,
        OptionA NVARCHAR(500),
        OptionB NVARCHAR(500),
        OptionC NVARCHAR(500),
        OptionD NVARCHAR(500),
        CorrectAnswer NVARCHAR(10),
        CreatedAt DATETIME DEFAULT GETDATE()
    );
END

-- Insert sample questions
INSERT INTO tblQuestions (Subject, QuestionText, QType, Difficulty, Marks, OptionA, OptionB, OptionC, OptionD, CorrectAnswer) VALUES
('Mathematics', 'What is 2 + 2?', 'MCQ', 'Easy', 1, '3', '4', '5', '6', 'B'),
('Mathematics', 'Solve: x + 5 = 10', 'Descriptive', 'Medium', 5, NULL, NULL, NULL, NULL, NULL),
('Mathematics', 'Calculate the derivative of x²', 'Descriptive', 'Hard', 10, NULL, NULL, NULL, NULL, NULL),
('Science', 'What is H2O?', 'MCQ', 'Easy', 1, 'Salt', 'Water', 'Sugar', 'Acid', 'B'),
('Science', 'Explain the process of photosynthesis', 'Descriptive', 'Hard', 10, NULL, NULL, NULL, NULL, NULL),
('English', 'What is a noun?', 'MCQ', 'Easy', 1, 'Action word', 'Person/Place/Thing', 'Description', 'None', 'B'),
('English', 'Write a paragraph about your favorite book', 'Descriptive', 'Medium', 5, NULL, NULL, NULL, NULL, NULL);

-- Query to view all questions
SELECT * FROM tblQuestions ORDER BY CreatedAt DESC;

-- Query to filter by subject
SELECT * FROM tblQuestions WHERE Subject = 'Mathematics';

-- Query to get subjects for dropdown
SELECT DISTINCT Subject FROM tblQuestions ORDER BY Subject;
