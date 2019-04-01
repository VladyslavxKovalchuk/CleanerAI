using System;
using System.Collections.Generic;
using System.Text;

namespace CleanerAI
{
	class Game
	{
		private readonly Map map;
		private readonly Cleaner cleaner;
		private readonly int TotalTime;
		public Game(Map pmap, Cleaner pCleaner, int time)
		{
			map = pmap;
			cleaner = pCleaner;
			TotalTime = time;
		}
		private Direction strategyDicrection = Direction.Up;
		private void DailyMephod()
		{
			map.TryMakeTrash();
			if (!cleaner.CheckAndMove())
			{
				MoveByStrategy();
			}
		}
		private void MoveByStrategy()
		{
			if (cleaner.Y == 0)
				strategyDicrection = Direction.Right;
			if (cleaner.Y == 4)
				strategyDicrection = Direction.Left;
			if (cleaner.X == 0)
				strategyDicrection = Direction.Up;
			if (cleaner.X == 4)
				strategyDicrection = Direction.Down;



			if ((cleaner.X == 4) && (cleaner.Y == 0))
			{
				strategyDicrection = Direction.Up;
			}

			if ((cleaner.X == 4) && (cleaner.Y == 4))
			{
				strategyDicrection = Direction.Left;
			}
			if ((cleaner.Y == 0) && (cleaner.X == 0))
			{
				strategyDicrection = Direction.Right;

			}
			if ((cleaner.Y == 0) && (cleaner.X == 4))
			{
				strategyDicrection = Direction.Down;
			}
			if ((cleaner.Y == 1) && (cleaner.X == 4))
			{
				strategyDicrection = Direction.Left;
			}
			if ((cleaner.Y == 4) && (cleaner.X == 3))
			{
				strategyDicrection = Direction.Up;
			}
			if ((cleaner.Y == 3) && (cleaner.X == 0))
			{
				strategyDicrection = Direction.Right;
			}
			if ((cleaner.Y == 0) && (cleaner.X == 1))
			{
				strategyDicrection = Direction.Down;
			}


			cleaner.Move(strategyDicrection);
		}
		public void Start()
		{
			for (int i = 0; i < TotalTime; i++)
			{
				DailyMephod();
			}
		}

	}

}

