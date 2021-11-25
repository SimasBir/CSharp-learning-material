using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_2_OOP
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        // prop - shorthand prop (double tab)
        public string address { get; set; }

        public int grade { get; set; }
        public Student() //dafault egzistuojantis konstruktorius, iki kol sukuriam custom'ini
        {}
        public Student(string name, string surname, int age, string address)
        {
            Name = name;
            Surname = surname;
            Age = age;
            this.address = address;
        }
        //galima kurti ir apkeitus ar pridejus parametrus ir prideti default / optional reiksmes (turi buti paskutines)
        public Student(string name, string surname,string address, int age=28,int grade=5)
        {
            Name = name;
            Surname = surname;
            Age = age;
            this.address = address;
            this.grade = grade;
            sayBye();
        }

        public override string ToString()
        {
            return "Studento vardas yra "+Name+" pavarde "+Surname+" amzius "+Age;
        }

        public static void sayBye()
        {
            Console.WriteLine("bye");
        }
    }
}
