// Sample code
using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // SelectMany example
        var students = new[]
        {
            new { Name = "Ana", Courses = new[] { "C#", "SQL" } },
            new { Name = "Luis", Courses = new[] { "Java", "SQL" } }
        };

        var selectManyResult = students.SelectMany(
            student => student.Courses,
            (student, course) => new { student.Name, Course = course }
        );

        Console.WriteLine("SelectMany Result:");
        foreach (var item in selectManyResult)
            Console.WriteLine($"Name: {item.Name}, Course: {item.Course}");

        Console.WriteLine();

        // GroupBy example
        var people = new[]
        {
            new { Name = "Ana", City = "Bogotá" },
            new { Name = "Luis", City = "Medellín" },
            new { Name = "Pedro", City = "Bogotá" }
        };

        var groupByResult = people
            .GroupBy(p => p.City)
            .Select(g => new
            {
                City = g.Key,
                Count = g.Count(),
                People = g.Select(p => p.Name).OrderBy(n => n).ToList()
            });

        Console.WriteLine("GroupBy Result:");
        foreach (var group in groupByResult)
        {
            Console.WriteLine($"City: {group.City}, Count: {group.Count}");
            foreach (var person in group.People)
                Console.WriteLine($" - {person}");
        }

        Console.WriteLine();

        // Join (Inner Join) example
        var employees = new[]
        {
            new { Id = 1, Name = "Ana", DepartmentId = 1 },
            new { Id = 2, Name = "Luis", DepartmentId = 2 }
        };

        var departments = new[]
        {
            new { Id = 1, Name = "IT" },
            new { Id = 2, Name = "HR" },
            new { Id = 3, Name = "Sales" }
        };

        var joinResult = employees.Join(
            departments,
            emp => emp.DepartmentId,
            dep => dep.Id,
            (emp, dep) => new { emp.Name, Department = dep.Name }
        );

        Console.WriteLine("Inner Join Result:");
        foreach (var item in joinResult)
            Console.WriteLine($"Name: {item.Name}, Department: {item.Department}");

        Console.WriteLine();

        // GroupJoin (Left Join) example
        var groupJoinResult = departments.GroupJoin(
            employees,
            dep => dep.Id,
            emp => emp.DepartmentId,
            (dep, emps) => new
            {
                Department = dep.Name,
                Employees = emps.Select(e => e.Name).ToList()
            });

        Console.WriteLine("GroupJoin (Left Join) Result:");
        foreach (var group in groupJoinResult)
        {
            Console.WriteLine($"Department: {group.Department}");
            foreach (var emp in group.Employees)
                Console.WriteLine($" - {emp}");
            if (!group.Employees.Any())
                Console.WriteLine(" - (no employees)");
        }

        Console.WriteLine();

        // Query syntax join
        var querySyntaxResult = from emp in employees
                                join dep in departments
                                on emp.DepartmentId equals dep.Id
                                select new { emp.Name, Department = dep.Name };

        Console.WriteLine("Query Syntax Join Result:");
        foreach (var item in querySyntaxResult)
            Console.WriteLine($"Name: {item.Name}, Department: {item.Department}");
    }
}
