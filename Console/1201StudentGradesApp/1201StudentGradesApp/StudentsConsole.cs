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
        private List<Student> _studentBody = new List<Student>(); //i sicia perdaryti students lista
        private Student _student { get; set; }
        public StudentsConsole()
        {
            _student = new Student();
        }
        public void Add(string name, string surname, int classGrade)
        {
            var student = new Student()
            {
                Name = name,
                Surname = surname,
                ClassGrade = classGrade,
            };

            _studentBody.Add(student);
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
                Add(name, surname, classGrade);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Class number must be an integer");
            }
        }
        private List<Student> GetAll()
        {
            return _studentBody;
        }
        public void ExecuteList()
        {
            var students = GetAll();
            foreach (var student in students)
            {
                Console.WriteLine(
                    $"Id:{student.Id}, " +
                    $"name: {student.Name}, " +
                    $"surname: {student.Surname}, " +
                    $"class: {student.ClassGrade}");
            }

        }
        private bool Check(int Id)
        {
            bool IdExists = _studentBody.Exists(x => x.Id == Id);
            return IdExists;

        }
        private List<Student> Choose(int Id)
        {
            if (Check(Id))
            {
                var chosen = _studentBody.Where(s => s.Id == Id).ToList();
                return chosen;
            }
            else
            {
                throw new ArgumentException("Such Id doesn't exist");
            }
        }

        public void ExecuteChoose()
        {
            Console.WriteLine("Which student Id would you like to select?");
            try
            {
                int Id = Convert.ToInt32(Console.ReadLine());
                var selectedStudent = Choose(Id)[0];

                string mathGrades = String.Join(", ", selectedStudent.Grades.Math); //kitas,geresnis variantas
                string biologyGrades = String.Join(", ", selectedStudent.Grades.Biology);

                Console.WriteLine(
                        $"Id:{selectedStudent.Id}, " +
                        $"name: {selectedStudent.Name}, " +
                        $"surname: {selectedStudent.Surname}, " +
                        $"class: {selectedStudent.ClassGrade}");
                Console.WriteLine($"Math grades: {mathGrades}");
                Console.WriteLine($"Biology grades: {biologyGrades}");
                Console.WriteLine($"Math average: {selectedStudent.Grades.GetMathAverage()}");
                Console.WriteLine($"Biology average: {selectedStudent.Grades.GetBiologyAverage()}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Delete(int Id)
        {
            if (Check(Id))
            {
                _studentBody = _studentBody.Where(s => s.Id != Id).ToList();
            }
            else
            {
                throw new ArgumentException("Such Id doesn't exist");
            }
        }
        public void ExecuteDelete()
        {
            try
            {
                Console.WriteLine("Which student Id would you like to delete?");
                int Id = Convert.ToInt32(Console.ReadLine());
                Delete(Id);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void Update(int Id, string name, string surname, int classGrade)
        {
            if (Check(Id))
            {
                _studentBody.Where(t => t.Id == Id).ToList().ForEach(x => x.Name = name);
                _studentBody.Where(t => t.Id == Id).ToList().ForEach(x => x.Surname = surname);
                _studentBody.Where(t => t.Id == Id).ToList().ForEach(x => x.ClassGrade = classGrade);
            }
            else
            {
                throw new ArgumentException("Such Id doesn't exist");
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

                Update(Id, name, surname, classGrade);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ExecuteBestInClass()
        {
            Console.WriteLine("Which class would you like to check (math or biology)?");
            string className = Console.ReadLine();

            if (className == "math")
            {
                var bestStudent = _studentBody.OrderByDescending(s => s.Grades.GetMathAverage()).FirstOrDefault();
                Console.WriteLine($"Best student in {className} is {bestStudent.Id} {bestStudent.Name}");
            }
            if (className == "biology")
            {
                var bestStudent = _studentBody.OrderByDescending(s => s.Grades.GetBiologyAverage()).FirstOrDefault();
                Console.WriteLine($"Best student in {className} is {bestStudent.Id} {bestStudent.Name}");
            }
        }
    }
}
