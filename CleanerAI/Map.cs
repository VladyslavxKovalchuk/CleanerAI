using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CleanerAI
{
	class Map
	{
		public int[,] map { get; set; }
		public int size
		{
			get;private set;
		}
        public int Trashs { get; set; }
		public Map(int N)
		{
			map = new int[N, N];
			size = N;
		}
		public void TryMakeTrash()
		{
			Random random = new Random();
			if (random.Next(1,100) > 50)
			{
				MakeTrash();
			}

		}
		private void MakeTrash()
		{
			int counter = 0;
			int randvalue;
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (map[i, j] == 0)
						counter += 1;
				}
			}
            Trashs++;
            Random random = new Random();
			randvalue = random.Next(1, counter);
            counter = 0;

            for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (map[i, j] == 0)
						counter += 1;

					if (randvalue == counter)
					{
						map[i, j] = 1;
						return;
					}
				}
			}
		}
		public int TrashCount()
		{
			int count = 0;
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (map[i,j] == 1)
					{
						count += 1;
					}
				}
			}
			return count - 1;
		}
		public int this[int index1,int index2]
		{
			get
			{
				return map[index1, index2];
			}
			set
			{
				map[index1, index2] = value;
			}
		}
	}
}
