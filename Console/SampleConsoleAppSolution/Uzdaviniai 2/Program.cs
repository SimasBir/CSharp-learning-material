using System;
using System.Collections.Generic;
using System.Linq;

namespace Uzdaviniai_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rd = new Random();
            List<int> numb = new List<int>();

            for (int i = 0; i < 30; i++)
            {
                numb.Add(rd.Next(5, 26));
            }
            numb.ForEach(el => Console.WriteLine(el));

            // 2.1
            Console.WriteLine("");
            int lowerCount = numb.Count(x => x > 10);
            Console.WriteLine(lowerCount);

            //2.2
            int highestNumb = 0;
            string highestPos = "";
            for (int i = 0; i < numb.Count; i++)
            {
                if (numb[i] > highestNumb)
                {
                    highestNumb = numb[i];
                }
            }
            for (int i = 0; i < numb.Count; i++)
            {
                if (numb[i] == highestNumb)
                {
                    highestPos = highestPos + i + ", ";
                }
            }

            //alternative
            List<int> indexes = new List<int>();
            for (int i = 0; i < numb.Count; i++)
            {
                if (numb[i] > highestNumb)
                {
                    highestNumb = numb[i];
                    indexes.Clear();

                }
                if (numb[i] == highestNumb)
                {
                    indexes.Add(i);
                }
            }

            Console.WriteLine("Highest number is " + highestNumb + " at position " + highestPos);

            //2.3
            Console.WriteLine("");
            int secondSum = 0;
            for (int i = 0; i < numb.Count; i += 2)
            {
                secondSum = secondSum + numb[i];
            }
            Console.WriteLine(secondSum);

            //2.4
            Console.WriteLine("");
            List<int> numb2 = new List<int>();
            for (int i = 0; i < numb.Count; i++)
            {
                numb2.Add(numb[i] - i);
            }
            numb2.ForEach(el => Console.WriteLine(el));

            //2.5

            List<int> porinis = new List<int>();
            List<int> nePorinis = new List<int>();

            for (int i = 0; i < numb.Count; i++)
            {
                if (i % 2 == 0)
                {
                    porinis.Add(numb[i]);
                    //Console.WriteLine("porinis");
                    //Console.WriteLine(i);
                }
                if (i % 2 - 1 == 0)
                {
                    nePorinis.Add(numb[i]);
                    //Console.WriteLine("ne");
                }

            }
            //Console.WriteLine("");
            //Console.WriteLine("Porines index reiksmes:");
            //porinis.ForEach(el => Console.WriteLine(el));
            //Console.WriteLine("Ne porines indexo reiksmes:");
            //nePorinis.ForEach(el => Console.WriteLine(el));


            //2.6
            Console.WriteLine("");

            for (int i = 0; i < porinis.Count; i++)
            {
                if (porinis[i] > 15)
                {
                    porinis[i] = 0;
                }
            }
            porinis.ForEach(el => Console.WriteLine(el));

            //2.7
            Console.WriteLine("");
            for (int i = 0; i < porinis.Count; i++)
            {
                if (porinis[i] > 10)
                {
                    Console.WriteLine(i);
                    break;
                }
            }


            // 3
            Console.WriteLine("");
            Random random = new Random();
            const string chars = "ABCD";
            string myBorrowedCode = new string(Enumerable.Repeat(chars, 200)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            Console.WriteLine(myBorrowedCode);

            int a = 0, b = 0, c = 0, d = 0;

            foreach (char i in myBorrowedCode)
            {
                if (i == 'A')
                {
                    a += 1;
                }
                if (i == 'B')
                {
                    b += 1;
                }
                if (i == 'C')
                {
                    c += 1;
                }
                if (i == 'D')
                {
                    d += 1;
                }

            }
            Console.WriteLine("A buvo " + a + ", B buvo " + b + ", C buvo " + c + ", D buvo " + d);
            Console.WriteLine("Is viso buvo: " + ((int)a + b + c + d));

            //4


        }
    }
}
