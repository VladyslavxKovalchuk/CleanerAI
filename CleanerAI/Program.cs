using System;

namespace CleanerAI
{
	class Program
	{
		static void Main(string[] args)
        {
           
                method();
            
            

        }

        private static void method()
        {
            int SumTrash = 0;
            for (int i = 0; i < 1000; i++)
            {
                SumTrash += StartOneGame();
            }
            Console.WriteLine("Average trash count of 1000 times = {0}", (double)SumTrash / 1000);
            Console.ReadKey();
        }

        private static int StartOneGame()
		{
			Map map = new Map(5);
			Cleaner cleaner = new Cleaner(2, 2, map);
			Game game = new Game(map, cleaner, 100);
			game.Start();
			return map.TrashCount();
		}
	}
}
