using System;


namespace DBexam.Models
{
    public class Menu
    {
        public static int SystemMenuOptions()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("What actions would you like to perform?\n");
            Console.WriteLine("Select an option:\n");
            Console.WriteLine("[1]\tCreate a department\n" +
                "[2]\tCreate student\n" +
                "[3]\tCreate lecture\n" +
                "[4]\tCreate relationship between student and department\n" +
                "[5]\tCreate relationship between lecture and department\n" +
                "[6]\tCreate relationship between lecture and student\n" +
                "[7]\tShow all students in the department\n" +
                "[8]\tShow all lectures in the department\n" +
                "[9]\tShow all lectures that belongs to a student\n" +
                "[10]\tMove student to another department\n\n" +
                "[11]\tExit menu");

            var optionSelected = readInt();
            return optionSelected;
        }
        public static int readInt()
        {
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("You entered ivalid value, press enter to continue");
                Console.WriteLine("Please enter a valid choise");
                Console.ReadKey();
                return 0;
            }
        }
        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
