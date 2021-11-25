//// Uzduotis 1

//var name = "Simas";
//var surname = "Pavardenis";
//var birthYear = 1992;
//var currentYear = 2021;

//var age = currentYear - birthYear;

//Console.WriteLine("As esu " + name + " " + surname + ". Man yra " + age + "metai.");

//// Uzduotis 2

//// Alternative
//// string[] students = new string[7]; students[0] = "name"; ir t.t.

//var arrayOfNames = new[] { "Simas", "Aukse", "Giedre", "Tautvydas", "Edgaras", "Kristina", "Vaidas" };

//foreach (var name in arrayOfNames)
//{
//    Console.WriteLine(name);
//}



//// Uzduotis 3


//int[] arr_sample = new int[10];
//Random rd = new Random();

//for (int index = 0; index < 5; index++)
//{
//    int rand_num = rd.Next(100, 200);
//    arr_sample[index] = rand_num;
//    System.Console.WriteLine(arr_sample[index]);
//}
//System.Console.WriteLine("");
//for (int index = 4; index < 10; index++)
//{
//    int rand_num = rd.Next(100, 200);
//    arr_sample[index] = rand_num;

//}

//for (int index = 0; index < 10; index++)
//{
//    System.Console.WriteLine(arr_sample[index]);
//}

//// Uzduotis 4


//int[,] arr2d = new int[10, 10];

//for (int i = 0; i < 10; i++)
//{
//        for (int j = 0; j < 10; j++)
//    {
//        arr2d[i,j] = i * j;

//        Console.Write(arr2d[i, j] + "\t");
//        }
//        Console.WriteLine("");

//}


//// Uzduotis 5


//int a, b, c;

//Random rd = new Random();


//a = rd.Next(100, 200);
//b = rd.Next(100, 200);
//c = rd.Next(100, 200);

//Console.WriteLine("Enter your three lenghts: ");
//a = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("Enter your second lenght: ");
//b = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("Enter your third lenght: ");
//c = Convert.ToInt32(Console.ReadLine());

//if (a+b>c && b+c>a && a+c>b)
//{
//    Console.WriteLine("Possible triangle");
//}
//else
//{
//    Console.WriteLine("Impossible triangle");
//}

//// Uzduotis 6

//int candlesAmount, candlesPrice;
//double totalPrice;
//candlesPrice = 1;
//Random rd = new Random();

////Console.WriteLine("Enter your three lenghts: ");
////candlesAmount = Convert.ToInt32(Console.ReadLine());

//candlesAmount = rd.Next(5, 3001);

//if (candlesAmount*candlesPrice  > 2000)
//{
//    totalPrice = (candlesAmount*candlesPrice*0.96);
//}
//else if(candlesAmount*candlesPrice > 1000)
//{
//    totalPrice = (candlesAmount * candlesPrice * 0.97);
//}
//else
//{
//    totalPrice = (candlesAmount * candlesPrice);
//}

//Console.WriteLine(candlesAmount + "Candles bought for " + totalPrice);

// Uzduotis 7

int hours, minutes, seconds, addTime, addMinutes, addSeconds;
Random rd = new Random();

var isFinished = false;

while (isFinished == false)
{

    hours = rd.Next(0, 24);
    minutes = rd.Next(0, 60);
    seconds = rd.Next(0, 60);


    Console.WriteLine(hours + ":" + minutes + ":" + seconds);

    addTime = rd.Next(0, 300);
    addMinutes = Convert.ToInt32(Math.Truncate(addTime / 60d));
    addSeconds = Convert.ToInt32(addTime - addMinutes * 60);

    Console.WriteLine(addTime + " total seconds to be added");
    Console.WriteLine(addMinutes + " minutes");
    Console.WriteLine(addSeconds + " seconds");


    if (addSeconds + seconds > 61)
    {
        seconds = addSeconds + seconds - 60;
        addMinutes += 1;
    }
    else
    {
        seconds = addSeconds + seconds;
    }

    if (addMinutes + minutes > 61)
    {
        minutes = addMinutes + minutes - 60;
        hours = hours + 1;
    }
    else
    {
        minutes = addMinutes + minutes;
    }

    if (hours < 24) { Console.WriteLine(hours + ":" + minutes + ":" + seconds); }
    else { Console.WriteLine("1 day, " + 00 + ":" + minutes + ":" + seconds); }

    Console.WriteLine("'exit' to exit");
    var consoleInput = Console.ReadLine();
    if (consoleInput == "exit")
    { isFinished = true; break; }
}