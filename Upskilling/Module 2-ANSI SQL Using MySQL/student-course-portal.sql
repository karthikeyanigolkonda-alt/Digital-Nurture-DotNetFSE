CREATE DATABASE IF NOT EXISTS StudentCoursePortal;
USE StudentCoursePortal;

-- 1. STUDENT TABLE
CREATE TABLE Student (
    StudentId INT PRIMARY KEY AUTO_INCREMENT,
    StudentName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    Department VARCHAR(50),
    GPA DECIMAL(3,2)
);

-- 2. COURSE TABLE
CREATE TABLE Course (
    CourseId INT PRIMARY KEY AUTO_INCREMENT,
    CourseName VARCHAR(100) NOT NULL,
    CourseCode VARCHAR(20) UNIQUE,
    Credits INT NOT NULL,
    Fee DECIMAL(10,2)
);

-- 3. ENROLLMENT TABLE
CREATE TABLE Enrollment (
    EnrollmentId INT PRIMARY KEY AUTO_INCREMENT,
    StudentId INT,
    CourseId INT,
    EnrollmentDate DATE,
    Grade VARCHAR(5),

    FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
    FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
);

-- 4. INSERT STUDENTS
INSERT INTO Student
(StudentName, Email, Department, GPA)
VALUES
('Rahul', 'rahul@gmail.com', 'CSE', 8.20),
('Priya', 'priya@gmail.com', 'AIML', 9.10),
('Kiran', 'kiran@gmail.com', 'ECE', 7.80),
('Anjali', 'anjali@gmail.com', 'CSE', 8.70),
('Arun', 'arun@gmail.com', 'IT', 7.50);

-- 5. INSERT COURSES
INSERT INTO Course
(CourseName, CourseCode, Credits, Fee)
VALUES
('C# Programming', 'CS101', 4, 5000),
('Angular', 'CS102', 4, 6000),
('Database Systems', 'CS103', 3, 4500),
('Computer Networks', 'CS104', 3, 4000),
('Artificial Intelligence', 'CS105', 4, 7000);

-- 6. INSERT ENROLLMENTS
INSERT INTO Enrollment
(StudentId, CourseId, EnrollmentDate, Grade)
VALUES
(1, 1, '2026-01-10', 'A'),
(1, 2, '2026-01-12', 'B'),
(2, 1, '2026-01-10', 'A+'),
(2, 5, '2026-01-15', 'A'),
(3, 3, '2026-01-20', 'B'),
(4, 2, '2026-01-12', 'A'),
(4, 3, '2026-01-20', 'A+'),
(5, 4, '2026-01-25', 'C');

-- 7. BASIC SELECT
SELECT * FROM Student;
SELECT * FROM Course;

-- 8. WHERE
SELECT * FROM Student
WHERE GPA >= 8.0;

-- 9. ORDER BY
SELECT * FROM Student
ORDER BY GPA DESC;

-- 10. UPDATE
UPDATE Student
SET GPA = 8.50
WHERE StudentId = 1;

-- 11. COUNT
SELECT COUNT(*) AS TotalStudents
FROM Student;

-- 12. AVG
SELECT AVG(GPA) AS AverageGPA
FROM Student;

-- 13. MAX / MIN
SELECT MAX(GPA) AS HighestGPA,
       MIN(GPA) AS LowestGPA
FROM Student;

-- 14. GROUP BY
SELECT Department, COUNT(*) AS StudentCount
FROM Student
GROUP BY Department;

-- 15. INNER JOIN
SELECT
    s.StudentName,
    c.CourseName,
    e.Grade
FROM Student s
INNER JOIN Enrollment e
    ON s.StudentId = e.StudentId
INNER JOIN Course c
    ON e.CourseId = c.CourseId;

-- 16. LEFT JOIN
SELECT
    s.StudentName,
    c.CourseName
FROM Student s
LEFT JOIN Enrollment e
    ON s.StudentId = e.StudentId
LEFT JOIN Course c
    ON e.CourseId = c.CourseId;

-- 17. DISTINCT
SELECT DISTINCT Department
FROM Student;

-- 18. LIKE
SELECT *
FROM Student
WHERE StudentName LIKE 'A%';

-- 19. BETWEEN
SELECT *
FROM Student
WHERE GPA BETWEEN 8.0 AND 9.0;

-- 20. IN
SELECT *
FROM Course
WHERE CourseCode IN ('CS101', 'CS102', 'CS105');

-- 21. SUBQUERY
SELECT *
FROM Student
WHERE GPA > (
    SELECT AVG(GPA)
    FROM Student
);

-- 22. HAVING
SELECT Department, AVG(GPA) AS AverageGPA
FROM Student
GROUP BY Department
HAVING AVG(GPA) >= 8.0;

-- 23. VIEW
CREATE OR REPLACE VIEW StudentCourseDetails AS
SELECT
    s.StudentName,
    s.Department,
    c.CourseName,
    c.CourseCode,
    e.Grade
FROM Student s
JOIN Enrollment e
    ON s.StudentId = e.StudentId
JOIN Course c
    ON e.CourseId = c.CourseId;

SELECT * FROM StudentCourseDetails;