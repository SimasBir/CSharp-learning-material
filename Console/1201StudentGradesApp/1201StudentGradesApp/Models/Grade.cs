﻿namespace _1201StudentGradesApp.Models
{
    public class Grade
    {
        public List<int> math { get; set; }
        public List<int> biology { get; set; }

        private List<Grade> _grades = new List<Grade>();
        private List<int> _subGrades = new List<int>();

        public List<int> Grades(string subject)
        {

            return _subGrades;
        }

        //public double averageGrades(string subject)
        //{
        //    var average = _subgrades.List<int>
        //    return average.Average();
        //}

        //funkcija kuri suskaiciuoja vidurkius X studento. 
        //yra objektas, kuris savyje turi pamokų pažymių listus.
        //toje klasėje turėti metodą kuris prasuka ciklą per this.Math Listą,
        //suskaičiuoja vidurkį ir gražina btų 

    }
}