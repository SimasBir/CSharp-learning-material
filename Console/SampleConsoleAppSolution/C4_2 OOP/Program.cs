using System;
using System.Collections.Generic;

namespace C4_2_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Student studentas0 = new Student("Naglis", "Mackis", 30, "Kaunas");

            Student studentas = new Student();
            studentas.Name = "Petras";
            studentas.Surname = "Adomaitis";
            studentas.Age = 19;

            //Console.WriteLine(studentas);
            //Console.WriteLine(studentas.ToString());

            Student studentas2 = new Student();
            studentas2.Name = "Petras2";
            studentas2.Surname = "Adomaitis2";
            studentas2.Age = 192;
            //Console.WriteLine(studentas2);
            //sayHi();
            //Student.sayBye();

            //Console.WriteLine(MyMaths.sumInt(7, 4));


            List<Student> students = new List<Student>() { studentas, studentas2, studentas0 };
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
        public static void sayHi()
        {
            Console.WriteLine("hi");
        }
        public static string returnHi()
        {
            return "hi";
        }
        public static void sayHiP(string name)
        {
            Console.WriteLine("hi" + name);
        }
        public static string returnHiP(string name)
        {
            return "hi" + name;
        }


    }
}
