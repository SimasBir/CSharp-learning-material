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

            //var grades = Console.ReadLine();

            _student.Add(name, surname); //, grades
        }

        public void ExecuteList()
        {
            var students = _student.GetAll();
            var info = "";
            foreach (var student in students)
            {
                var studentInfo = $"Id:{student.Id}, name: {student.Name}, surname: {student.Surname}\n"; //, grades: {student.Grades}
                info = info + studentInfo;
            }
            Console.WriteLine(info);
        }
  
        public void ExecuteChoose()
        {
            Console.WriteLine("Which student Id would you like to select?");
            try
            {
                int Id = Convert.ToInt32(Console.ReadLine());
                var student = _student.Choose(Id);
                foreach (var stud in student)
                {
                    Console.WriteLine($"Id:{stud.Id}, name: {stud.Name}, surname: {stud.Surname}");
                }
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

                _student.Update(Id, name, surname);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
