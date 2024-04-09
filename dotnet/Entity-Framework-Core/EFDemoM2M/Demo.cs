using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Data;
using EFConfigs.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDemoM2M;

public class Demo : IDisposable
{
  private readonly MyDbContext _ctx;

  public Demo()
  {
    _ctx = new MyDbContext();
  }

  public void Dispose()
  {
    _ctx.Dispose();
  }
  private Student GenerateStudent(string name)
  {
    return new Student
    {
      Name = name
    };
  }

  private Teacher GenerateTeacher(string name)
  {
    return new Teacher
    {
      Name = name
    };
  }

  public async Task Create()
  {
    var student1 = GenerateStudent("Student 1");
    var student2 = GenerateStudent("Student 2");
    var student3 = GenerateStudent("Student 3");

    var teacher1 = GenerateTeacher("Teacher 1");
    var teacher2 = GenerateTeacher("Teacher 2");
    var teacher3 = GenerateTeacher("Teacher 3");

    student1.Teachers.Add(teacher2);
    student1.Teachers.Add(teacher1);

    student2.Teachers.Add(teacher2);
    student2.Teachers.Add(teacher3);

    student3.Teachers.Add(teacher1);
    student3.Teachers.Add(teacher2);
    student3.Teachers.Add(teacher3);

    _ctx.Students.AddRange(student1, student2, student3);

    await _ctx.SaveChangesAsync();
  }

  public void Print()
  {
    var students = _ctx.Students.Include(s => s.Teachers).ToList();
    foreach (var s in students)
    {
      Console.WriteLine(s);
      foreach (var t in s.Teachers.ToList())
      {
        Console.WriteLine(new string("\t") + t);
      }
    }
    Console.WriteLine(new string('-', 20));
    var teachers = _ctx.Teachers.Include(t => t.Students).ToList();
    foreach (var t in teachers)
    {
      Console.WriteLine(t);
      foreach (var s in t.Students.ToList())
      {
        Console.WriteLine(new string("\t") + s);
      }
    }
  }
}