using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lab2Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //1:
            WriteLine("1:");
            Person person1 = new Person();
            Person person2 = new Person();

            WriteLine($"Is person1 == person2 {person1.Equals(person2)}");
            WriteLine($"Hash code for person1 {person1.GetHashCode()}");
            WriteLine($"Hash code for person2 {person2.GetHashCode()}");

            //2:
            WriteLine("2:");
            Student student = new Student();
            Exam[] newExams = new Exam[] { new Exam("A", 2, new DateTime(2022, 6, 12)), new Exam("B", 3, new DateTime(2022, 6, 6)) };
            Test[] newTests = new Test[] { new Test("A", true), new Test("C", false) };
            student.AddExams(newExams);
            student.AddTests(newTests);

            WriteLine(student.ToString());


            //3:
            WriteLine("3:");
            WriteLine($"Person for student\n{student.Person}");
        
            //4:
            WriteLine("4:");
            Student studentCopy = (Student)student.DeepCopy();
            Test[] tests = new Test[] { new Test("C", true) };
            student.AddTests(tests);
            WriteLine($"Original object\n{student.ToString()}");
            WriteLine($"Copy object\n{studentCopy.ToString()}");

            //5:
            WriteLine("5:");
            try
            {
                Student student2 = new Student() { Group = 700 };
            }
            catch (Exception p)
            {
                WriteLine(p.Message);
            }

            //6:
            WriteLine("6:");
            foreach (object obj in student.AllGoodExams(3))
            {
                WriteLine(obj);
            }


            //7:
            WriteLine("Name subjects which are peresent in tests and exams");
            WriteLine("7:");
            foreach (var subject in student)
            {
                WriteLine(subject.ToString());
            }


            //8:
            WriteLine("Passed exams and tests");
            WriteLine("8:");
            foreach (object obj in student.PassedTestsAndExams())
            {
                WriteLine(obj);
            }

        }
    
    }
}
