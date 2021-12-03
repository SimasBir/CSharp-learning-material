using _1201StudentGradesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1201StudentGradesApp
{

    public class StudentsConsole
    {
        private Student _student { get; set; }
        public StudentsConsole()
        {
            _student = new Student();
        }


        public void ExecuteAdd()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter class number");
            try
            {
                int classGrade = Convert.ToInt32(Console.ReadLine());
                _student.Add(name, surname, classGrade); //, grades

            }
            catch (Exception ex)
            {
                Console.WriteLine("Class number must be an integer");
            }
        }

        public void ExecuteList()
        {
            var students = _student.GetAll();
            var info = "";
            foreach (var student in students)
            {
                Console.WriteLine(
                    $"Id:{student.Id}, " +
                    $"name: {student.Name}, " +
                    $"surname: {student.Surname}, " +
                    $"class: {student.ClassGrade}");

                //info = info + studentInfo;
            }
            //Console.WriteLine(info);
        }

        public void ExecuteChoose()
        {
            Console.WriteLine("Which student Id would you like to select?");
            try
            {
                int Id = Convert.ToInt32(Console.ReadLine());
                var selectedStudent = _student.Choose(Id)[0];
                string mathGrades = ""; //sena varianta palieku kaip reference
                string mathGrades2 = String.Join(", ", selectedStudent.Grades.Math); //kitas,geresnis variantas
                string biologyGrades = "";
                var math = selectedStudent.Grades.Math;
                var biology = selectedStudent.Grades.Biology;

                foreach (var grade in math)
                {
                    mathGrades = mathGrades + grade.ToString() + ", ";
                }
                foreach (var grade in biology)
                {
                    biologyGrades = biologyGrades + grade.ToString() + ", ";
                }

                Console.WriteLine(
                        $"Id:{selectedStudent.Id}, " +
                        $"name: {selectedStudent.Name}, " +
                        $"surname: {selectedStudent.Surname}, " +
                        $"class: {selectedStudent.ClassGrade}, " +
                        $"math grades: {mathGrades}" +
                        $"biology grades: {biologyGrades}");
                Console.WriteLine($"Math average: {selectedStudent.Grades.Math.Average()}");
                Console.WriteLine($"Biology average: {selectedStudent.Grades.Biology.Average()}");
                Console.WriteLine(mathGrades2);
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void ExecuteDelete()
        {
            try
            {
                Console.WriteLine("Which student Id would you like to delete?");
                int Id = Convert.ToInt32(Console.ReadLine());
                _student.Delete(Id);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExecuteUpdate()
        {
            try
            {
                Console.WriteLine("Which student Id would you like to update?");
                int Id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter new name");
                string name = Console.ReadLine();

                Console.WriteLine("Enter new surname");
                string surname = Console.ReadLine();

                Console.WriteLine("Enter new class number");
                int classGrade = Convert.ToInt32(Console.ReadLine());

                _student.Update(Id, name, surname, classGrade);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        //public void ExecuteTest()
        //{

        //}
    }
}
