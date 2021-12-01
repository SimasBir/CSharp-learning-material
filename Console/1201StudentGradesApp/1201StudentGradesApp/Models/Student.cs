using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1201StudentGradesApp.Models
{
    public class Student
    {
        private static int IdCounter = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Grade Grades { get; set; }

        private List<Student> _studentBody = new List<Student>();

        public void Add(string name, string surname) //, Grade grades
        {
            var student = new Student()
            {
                Id = IdCounter++,
                Name = name,
                Surname = surname,
                //Grades = grades,
            };

            _studentBody.Add(student);
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

    }
}
