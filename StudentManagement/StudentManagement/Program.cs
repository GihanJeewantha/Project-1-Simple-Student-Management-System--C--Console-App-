using System;
using System.Collections.Generic;

public class Person
{
    // Encapsulated fields
    private string name;
    private int age;

    // Public properties
    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }

    // Constructor that accepts both fields
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Virtual so derived classes can override
    public virtual void ShowInfo()
    {
        Console.WriteLine($"Name: {Name} | Age: {Age}");
    }
}

public class Student : Person
{
    private string grade;
    public string Grade { get => grade; set => grade = value; }

    public Student(string name, int age, string grade) : base(name, age)
    {
        this.grade = grade;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Name: {Name} | Age: {Age} | Grade: {Grade}");
    }
}


public class Teacher : Person
{
    private string subject;
    public string Subject { get => subject; set => subject = value; }

    public Teacher(string name, int age, string subject) : base(name, age)
    {
        this.subject = subject;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Name: {Name} | Age: {Age} | Subject: {Subject}");
    }
}


public class School
{
    private List<Person> people = new List<Person>();

    public void AddPerson(Person p) => people.Add(p);

    public void ShowAllPeople()
    {
        if (people.Count == 0)
        {
            Console.WriteLine("No people in school.");
            return;
        }

        foreach (var person in people)
        {
            person.ShowInfo(); // polymorphism in action
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        var school = new School();
        while (true)
        {
            Console.WriteLine("1. Add Student\n2. Add Teacher\n3. Show All\n4. Exit");
            Console.Write("Enter choice: ");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid choice\n");
                continue;
            }

            switch (choice)
            {
                case 1: AddStudent(school); break;
                case 2: AddTeacher(school); break;
                case 3: school.ShowAllPeople(); break;
                case 4: Console.WriteLine("Goodbye!"); return;
                default: Console.WriteLine("Invalid choice\n"); break;
            }
        }
    }

    static void AddStudent(School school)
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Enter age: ");
        int age = ReadIntFromConsole();
        Console.Write("Enter grade: ");
        string grade = Console.ReadLine() ?? "";
        var student = new Student(name, age, grade);
        school.AddPerson(student);
        Console.WriteLine("Student added!\n");
    }

    static void AddTeacher(School school)
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Enter age: ");
        int age = ReadIntFromConsole();
        Console.Write("Enter subject: ");
        string subject = Console.ReadLine() ?? "";
        var teacher = new Teacher(name, age, subject);
        school.AddPerson(teacher);
        Console.WriteLine("Teacher added!\n");
    }

    static int ReadIntFromConsole()
    {
        while (true)
        {
            var s = Console.ReadLine();
            if (int.TryParse(s, out int val)) return val;
            Console.Write("That's not a valid number. Try again: ");
        }
    }
}



