using System;
using System.Linq;

namespace СheckLuckyTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please, enter number for cheking.");
                int inputNumber = int.Parse(Console.ReadLine());

                СheckLuckyTicket(inputNumber);
            }
        }
        private static void СheckLuckyTicket(int inputNumber)
        {
            string strNumber = inputNumber.ToString();

            int[] arrayNumber = new int[strNumber.Length];

            for (int i = 0; i < strNumber.Length; i++)
                arrayNumber[i] = int.Parse(strNumber[i].ToString());

            if (arrayNumber.Length < 4 || arrayNumber.Length > 8)
                Console.WriteLine("Error, the ticket number is a number that can be 4 to 8 digits long.\n");
           
            else
            {
                if (arrayNumber.Count() % 2 != 0)
                    InsertToArray(ref arrayNumber);

                int[] firstPartArray = arrayNumber.Take(arrayNumber.Length / 2).ToArray();
                int[] secondPartArray = arrayNumber.Skip(arrayNumber.Length / 2).ToArray();

                int resultAddFirstPartArray = AddSumArray(ref firstPartArray);
                int resulAddSecondPartArray = AddSumArray(ref secondPartArray);

                if (resultAddFirstPartArray == resulAddSecondPartArray)
                    Console.WriteLine("You have a lucky ticket!\n");
                else
                    Console.WriteLine("You don't have a lucky ticket!\n");
            }
        }

        private static int AddSumArray(ref int[] firstPartArray)
        {
            int sum = 0;
            for (int i = 0; i < firstPartArray.Length; i++)
                sum += firstPartArray[i];

            return sum;
        }

        private static void InsertToArray(ref int[] arrayNumber)
        {
            int[] newArray = new int[arrayNumber.Length + 1];
            int index = 0;
            int value = 0;
            newArray[index] = value;
            for (int i = 0; i < index; i++)
                newArray[i] = arrayNumber[i];

            for (int i = index; i < arrayNumber.Length; i++)
                newArray[i + 1] = arrayNumber[i];

            arrayNumber = newArray;
        }

    }
}
