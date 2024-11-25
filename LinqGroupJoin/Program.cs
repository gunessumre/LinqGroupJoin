using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Öğrenciler tablosu
        List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, StudentName = "Ali", ClassId = 1 },
            new Student { StudentId = 2, StudentName = "Ayşe", ClassId = 2 },
            new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 1 },
            new Student { StudentId = 4, StudentName = "Fatma", ClassId = 3 },
            new Student { StudentId = 5, StudentName = "Ahmet", ClassId = 2 }
        };

        // Sınıflar tablosu
        List<Class> classes = new List<Class>
        {
            new Class { ClassId = 1, ClassName = "Matematik" },
            new Class { ClassId = 2, ClassName = "Türkçe" },
            new Class { ClassId = 3, ClassName = "Kimya" }
        };

        // Group Join LINQ sorgusu
        var result = from c in classes
            join s in students on c.ClassId equals s.ClassId into studentGroup
            select new
            {
                ClassName = c.ClassName,
                Students = studentGroup
            };

        // Sonuçları ekrana yazdır
        foreach (var item in result)
        {
            Console.WriteLine($"Sınıf: {item.ClassName}");
            foreach (var student in item.Students)
            {
                Console.WriteLine($"  Öğrenci: {student.StudentName}");
            }
        }
    }
}

public class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int ClassId { get; set; }
}

public class Class
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
}







