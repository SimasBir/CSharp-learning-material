using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1201StudentGradesApp.Models
{
    public class Student
    {
        private static int IdCounter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ClassGrade { get; set; }
        public Grade Grades = new Grade();

        //private List<Student> _studentBody = new List<Student>();

        public Student()
        {
            Id = IdCounter++;
            Grades.Math = GenerateGrades();
            Grades.Biology = GenerateGrades();
        }
        private List<int> GenerateGrades()
        {
            List<int> grades = new List<int>();
            Random random = new Random();
            var amount = random.Next(5, 8);

            for (int i = 0; i < amount; i++)
            {
                grades.Add(random.Next(1, 11));
            }

            return grades;
        }
        //public List<Student> BestInClass(string className)
        //{
        //    if (className == "math")
        //    {
        //        var bestStudent = _studentBody.OrderByDescending(s => s.Grades.Math.Average()).First();
        //        return bestStudent;
        //    }
        //    else
        //    {
        //        var bestStudent = _studentBody.OrderByDescending(s => s.Grades.Biology.Average()).First();
        //        return bestStudent;
        //    }
        //}
    }

}

