namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data types
            //int number = 5;
            //string text = "text";
            //char singleChar = 'A';
            //bool boolValue = false;
            //double doubleValue = 5.432;
            //DateTime dateTimeValue = DateTime.Now;

            var arrayOfInts1 = new[] { 1, 2, 3, 4, 5 }; /*Reciau naudojamas, nes negalima prideti values*/
            arrayOfInts1[0] = 5;
            // arrayOfInts1[9] = 1; /*Lus programa, jei runint*/

            var arrayOfInts2 = new List<int> { 1, 2 };
            arrayOfInts2.AddRange(new List<int> { 2, 3, 4, 6 });

            var isFinished = false;
            while (isFinished == true)
            {
                // Console Commands

                Console.WriteLine("Enter your input or write 'Exit' to exit");
                var consoleInput = Console.ReadLine();

                //Console.WriteLine(consoleInput);


                if (consoleInput == "Exit")
                { isFinished = true; break; }
                else
                {

                    // Uzkomentuoti - ctrl+k, ctrl+c; Atkomentuoti ctrl+k, ctrl+u;
                    // String manipulation example: 5 + 4, 4 - 5;

                    // Split string into smaller string by spaces

                    // Get first two number
                    consoleInput.Substring(0, 2);

                    // Get first number
                    consoleInput.FirstOrDefault();

                    // Split string into smaller string by spaces
                    var consoleElements = consoleInput.Split(" ");

                    //// for Loop
                    //for(int i = 0; i < consoleElements.Length; i++)
                    //{
                    //    Console.WriteLine(consoleElements[i]);
                    //}

                    //// forEach loop
                    //foreach(var consoleElement in consoleElements)
                    //{
                    //    Console.WriteLine(consoleElement);
                    //}


                    try
                    {
                        var firstInput = consoleElements[0];

                        var mathOperator = consoleElements[1];

                        var secondInput = consoleElements[2];

                        var firstNumber = Convert.ToInt32(firstInput);
                        var secondNumber = Convert.ToInt32(consoleElements[2]);
                        // if statements
                        if (mathOperator == "+")
                        {
                            Console.WriteLine(firstNumber + secondNumber);
                        }
                        if (mathOperator == "-")
                        {
                            Console.WriteLine(firstNumber - secondNumber);
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("The input format is not correct");
                    }
                }
            }

        }

    }
}