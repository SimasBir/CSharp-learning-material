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

        private List<Student> _studentBody = new List<Student>();

        public Student()
        {
            Id = IdCounter++;
            Grades.math = GenerateGrades();
            Grades.biology = GenerateGrades();
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

        public List<Student> GetAll()
        {
            return _studentBody;
        }

        private bool Check(int Id)
        {
            bool IdExists = _studentBody.Exists(x => x.Id == Id);
            return IdExists;

        }

        public List<Student> Choose(int Id)
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

        public void Delete(int Id)
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

        public void Update(int Id, string name, string surname)
        {
            if (Check(Id))
            {
                _studentBody.Where(t => t.Id == Id).ToList().ForEach(x => x.Name = name);
                _studentBody.Where(t => t.Id == Id).ToList().ForEach(x => x.Surname = surname);
            }
            else
            {
                throw new ArgumentException("Such Id doesn't exist");
            }
        }
        public void Average(int Id,string subject)
        {
            if (Check(Id))
            {

            }
            else
            {
                throw new ArgumentException("Such Id doesn't exist");
            }
        }

    }
}
