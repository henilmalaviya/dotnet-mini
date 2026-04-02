# Exam-Ready - Desktop Question Bank & Generator

A Windows Desktop Application using C# .NET for managing question banks and generating exam papers.

## Technology Stack

- **Language**: C# (.NET 8)
- **UI Framework**: Windows Forms (MDI)
- **Database**: SQLite (via Microsoft.Data.Sqlite)
- **Data Access**: ADO.NET (Connected + Disconnected architectures)
- **PDF Generation**: PdfSharp
- **OOP**: Base Class `Question` → Derived `MCQQuestion`, `DescriptiveQuestion`

## Project Structure

```
ExamReady/
├── Models/
│   ├── Question.cs          # Base abstract class
│   ├── MCQQuestion.cs      # Derived MCQ class (method overriding)
│   ├── DescriptiveQuestion.cs
│   └── QuestionFactory.cs  # Factory pattern for question creation
├── Data/
│   ├── DbConnection.cs     # Connected architecture (SQLiteDataReader)
│   └── QuestionRepository.cs  # Disconnected (DataAdapter + DataSet)
├── Forms/
│   ├── MdiParent.cs        # MDI Dashboard (parent form)
│   ├── QuestionForm.cs    # Question CRUD module
│   └── ExamGeneratorForm.cs
├── Reports/
│   └── ExamReportForm.cs   # Print/PDF export
├── Utils/
│   ├── ExamAlgorithm.cs    # Random question selection algorithm
│   └── ValidationHelper.cs
└── Database/
    └── Schema.sql          # SQLite database schema
```

## Features

### A. MDI Dashboard
- MenuStrip with File, Manage, Generate, Help menus
- Professional background
- All child windows open inside the MDI frame

### B. Question Management (CRUD)
- Input fields: Question Text, Type, Difficulty, Marks, Subject
- Validation controls to ensure no empty questions
- DataGridView with search, edit, delete functionality
- Filter by subject

### C. Exam Generator Algorithm
- Select: Total Marks, Subject, Difficulty Distribution
- Algorithm randomly picks questions that sum to requested marks
- Preview generated exam before printing

### D. Reporting
- Print directly to printer
- Export to PDF
- Professional header with subject, date, marks

## Database Schema

```sql
CREATE TABLE tblQuestions (
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
);
```

## OOP Implementation

The project demonstrates OOP principles:
- **Inheritance**: `Question` (Base) → `MCQQuestion`, `DescriptiveQuestion` (Derived)
- **Method Overriding**: `GetDisplayText()`, `GetQuestionType()`, `GetFormattedQuestion()`
- **Factory Pattern**: `QuestionFactory.CreateQuestion()`

## ADO.NET Implementation

- **Connected Architecture**: `DbConnection.cs` uses `SQLiteDataReader` for fast fetching
- **Disconnected Architecture**: `QuestionRepository.cs` uses `SQLiteDataAdapter` + `DataSet` for grid view

## Setup Instructions

### Prerequisites
- Windows 10/11
- Visual Studio 2022 or later
- .NET 8 Desktop Runtime

### Steps

1. **Open the project** in Visual Studio:
   ```bash
   cd ExamReady
   dotnet restore
   ```

2. **Build and Run**:
   - Open `ExamReady.sln` in Visual Studio
   - Press F5 to run

3. **Database**:
   - The database `ExamReady.db` is created automatically on first run
   - Or run `Database/Schema.sql` to create manually

### NuGet Packages
- `Microsoft.Data.Sqlite` - SQLite database
- `PdfSharp` - PDF generation
- `System.Configuration.ConfigurationManager` - Configuration

## Project Configuration

Edit `App.config` to change database path:
```xml
<connectionStrings>
  <add name="ExamReadyDB" 
       connectionString="Data Source=ExamReady.db;Version=3;" 
       providerName="System.Data.SQLite" />
</connectionStrings>
```

## Usage Flow

1. **Launch** → MDI Dashboard opens
2. **Manage → Questions** → Add/Edit/Delete questions
3. **Generate → Generate Exam** → Select subject, marks, difficulty distribution
4. **Preview** → Review generated questions
5. **Print/Export** → Print or save as PDF

## Syllabus Requirements Met

| Requirement | Implementation |
|-------------|----------------|
| C# OOP | Base class `Question` with derived `MCQQuestion`, `DescriptiveQuestion` |
| Method Overriding | `GetDisplayText()`, `GetQuestionType()` overridden in derived classes |
| ADO.NET Connected | `DbConnection.GetAllQuestions()` uses `SQLiteDataReader` |
| ADO.NET Disconnected | `QuestionRepository.GetQuestionsDataSet()` uses `DataSet` + `DataAdapter` |
| Validation Controls | `ValidationHelper` validates inputs |
| Exception Handling | Global try-catch blocks in all data operations |
| MDI | `MdiParent` is the parent container form |
| Windows Forms | All UI components use WinForms |

---

**Note**: This project uses SQLite for easier setup. For SQL Server as per original requirements, replace `Microsoft.Data.Sqlite` with `System.Data.SqlClient` and update connection strings.
