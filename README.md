# 📚 SchoolSystem

**SchoolSystem** is a desktop student information system developed using Windows Forms (WinForms) and SQL Server. This application manages student records, course data, clubs, teacher branches, and grading. It offers a simple, user-friendly, and extensible automation solution for educational institutions.

## 🚀 Features

- Student management (add, delete, update)
- Club tracking and memberships
- Teacher-course mapping
- Exam and project grade tracking
- Automatic grade average and pass/fail calculation
- SQL Server for data integrity and relational structure
- Secure data access via ADO.NET
- Intuitive Windows Forms interface

---

## 🏗️ Project Architecture

| Layer               | Technology                        |
|---------------------|------------------------------------|
| User Interface (UI) | C# WinForms (.NET Framework 4.8)   |
| Data Layer          | SQL Server                         |
| Data Access         | ADO.NET                            |
| IDE                 | Visual Studio                      |

---

## 🧩 Module Structure

### 🎛️ Main Form
- `Form1.cs`: Main interface where all user interactions occur.
- `Form1.Designer.cs`: Design file containing form elements.

### 🗂️ Database Integration
- `DataSet1.xsd`: Defines typed dataset and TableAdapters.
- `App.config`: Contains SQL Server connection string.

---

## 🗃️ Database Design

The system consists of the following main tables:

### 🔹 TBL_Students
| Column Name     | Data Type   | Description                   |
|------------------|--------------|-------------------------------|
| StudentID        | int          | Primary key (PK)              |
| StudentName      | varchar(30)  | First name of the student     |
| StudentSurName   | varchar(30)  | Last name of the student      |
| StudentClub      | tinyint      | Club foreign key              |
| StudentGender    | varchar(6)   | Gender                        |

### 🔹 TBL_Clubs
| Column Name | Data Type   | Description             |
|--------------|--------------|-------------------------|
| ClubID       | tinyint      | Primary key (PK)        |
| ClubName     | varchar(30)  | Name of the club        |

### 🔹 TBL_Lectures
| Column Name  | Data Type   | Description             |
|---------------|--------------|-------------------------|
| LectureID     | tinyint      | Primary key (PK)        |
| LectureName   | varchar(30)  | Name of the course      |

### 🔹 TBL_Teachers
| Column Name     | Data Type   | Description                                |
|------------------|--------------|--------------------------------------------|
| TeacherID        | tinyint      | Primary key (PK)                           |
| TeacherBranch    | tinyint      | Foreign key (linked to LectureID)          |
| TeacherName      | varchar(50)  | Full name of the teacher                   |

### 🔹 TBL_Notes
| Column Name     | Data Type     | Description                                 |
|------------------|----------------|---------------------------------------------|
| NoteID           | int            | Primary key (PK)                             |
| LectureID        | tinyint        | Foreign key to course                        |
| StudentID        | int            | Foreign key to student                       |
| Exam1            | tinyint        | First exam score                             |
| Exam2            | tinyint        | Second exam score                            |
| Exam3            | tinyint        | Third exam score                             |
| ProjectNote      | tinyint        | Project score                                |
| Average          | decimal(5,2)   | Calculated average                           |
| Status           | bit            | Pass (1) / Fail (0)                          |

---

## 🔗 Table Relationships

- `TBL_Students.StudentClub` → `TBL_Clubs.ClubID`
- `TBL_Notes.StudentID` → `TBL_Students.StudentID`
- `TBL_Notes.LectureID` → `TBL_Lectures.LectureID`
- `TBL_Teachers.TeacherBranch` → `TBL_Lectures.LectureID`

Entity relationship diagram of the database:

![Database Schema](f922864a-fe07-4144-9e3f-dc5f4acd9e51.png)

---

## ⚙️ Usage

1. **Clone the project:**
   ```bash
   git clone https://github.com/yourusername/SchoolSystem.git
   ```

2. **Open with Visual Studio**
   - Open the solution file `SchoolSystem.sln`.
   - Update the `connectionString` in `App.config` to match your SQL Server configuration.

3. **Set up the database**
   - Execute the `SQL_Schema.sql` script using SQL Server Management Studio to create the schema.

4. **Run the project**
   - Press `F5` in Visual Studio to build and launch the application.

---

## 👤 Developer

- 🌐 [alican-kaya.com](https://alican-kaya.com/)
- 💼 [LinkedIn: Alican Kaya](https://www.linkedin.com/in/alican-kaya-881650234/)

---

## 📝 License

This project is licensed under the [MIT License](LICENSE).
