using System;

class Student
{
    public string Name { get; set; }
    public string Branch { get; set; }
}

class StudentView
{
    public void Display(Student student)
    {
        Console.WriteLine($"Student: {student.Name}, {student.Branch}");
    }
}

class StudentController
{
    private Student model;
    private StudentView view;

    public StudentController(Student model, StudentView view)
    {
        this.model = model;
        this.view = view;
    }

    public void UpdateView()
    {
        view.Display(model);
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student
        {
            Name = "Lakshmi",
            Branch = "AIML"
        };

        StudentView view = new StudentView();
        StudentController controller = new StudentController(student, view);

        controller.UpdateView();
    }
}
