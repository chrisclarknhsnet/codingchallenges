using System;

namespace YouFeelingLuckyPunk
{
    class Program
    {
        static void Main(string[] args)
        {
            // Below would actually passed in using dependency injection
            var luckyDipGenerator = new LuckyDipEstoniaNewRules();
            issueLuckyDip(luckyDipGenerator);
        }

        private static void issueLuckyDip(ILuckyDip luckyDip)
        {
            Console.WriteLine("Your numbers are:\n");
            
            foreach (int number in luckyDip)
            {
                Console.Write($"{number}, ");
            }

            Console.WriteLine("\n");
        }
    }
}
