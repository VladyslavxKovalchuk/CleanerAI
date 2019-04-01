using System;
using System.Collections.Generic;
using System.Text;

namespace CleanerAI
{
	class Cleaner
	{
		public int X { get; set;}
		public int Y { get; set;}
		private readonly Map map;

		public bool CheckAndMove()
		{
			Direction ToMove;
			if (Check(out ToMove))
			{
				Move(ToMove);
				return true;
			}
			return false;
		}
		private bool Check(out Direction dicrection)
		{
			for (int i = 0; i < 4; i++)
			{
                if ((X == 0) && (i == 0))
                    continue;
                if ((X == 4) && (i == 1))
                    continue;
                if ((Y == 0) && (i == 2))
                    continue;
                if ((Y == 4) && (i == 3))
                    continue;

                try
				{
					switch (i)
					{
						case 0:
							if (map[X - 1, Y] == 1)
							{
								dicrection = Direction.Left;
								return true;
							}
							break;
						case 1:
							if (map[X + 1, Y] == 1)
							{
								dicrection = Direction.Right;
								return true;
							}
							break;
						case 2:
							if (map[X, Y - 1] == 1)
							{
								dicrection = Direction.Up;
								return true;
							}
							break;
						case 3:
							if (map[X, Y + 1] == 1)
							{
								dicrection = Direction.Down;
								return true;
							}
							break;
					}
				}
				catch (IndexOutOfRangeException)
				{

				}
			}
			dicrection = Direction.Down;
			return false;
		}

		public Cleaner(int StartX,int StartY, Map pMap)
		{
			X = StartX;
			Y = StartY;
			map = pMap;
			map[X, Y] = 1;
		}

		public void Move(Direction dicrection)
		{
			switch(dicrection)
			{
				case Direction.Up:
					if (Y == 0)
					{
						throw new InvalidOperationException("out of map");
					}
					map[X, Y] = 0;
					Y -= 1;
					map[X, Y] = 1;
					break;
				case Direction.Down:
					if (Y == map.size - 1)
					{
						throw new InvalidOperationException("out of map");
					}
					map[X, Y] = 0;
					Y += 1;
					map[X, Y] = 1;
					break;
				case Direction.Left:
					if (X == 0)
					{
						throw new InvalidOperationException("out of map");
					}
					map[X, Y] = 0;
					X -= 1;
					map[X, Y] = 1;
					break;
				case Direction.Right:
					if (X == map.size - 1)
					{
						throw new InvalidOperationException("out of map");
					}
					map[X, Y] = 0;
					X += 1;
					map[X, Y] = 1;
					break;

			}
		}
	}
	public enum Direction
	{
		Up,Down,Left,Right
	}
}