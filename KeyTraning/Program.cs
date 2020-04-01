using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyTraning
{
	class Program
	{
		static void Main(string[] args)
		{
			double result = 0;
			char key;
			Console.SetWindowSize(50, 1);
			Console.CursorVisible = false;
			for (int i = 0; i < 3; i++)
			{
				result = 0;
				StringBilder TraningString = new StringBilder(i);
				TraningBase myTraning = new TraningBase(TraningString);
				while (result == 0)
				{
					if(myTraning.Counter == 0)
					{
						Console.Clear();
						Console.Write(TraningString.FinalText);
					}
					key = Console.ReadKey(true).KeyChar;
					result = myTraning.GoGame(key);
				}
				Console.Clear();
				Console.Write($"Ваш результат: {result} з\\м\tОшибок: {myTraning.Wrongs}");
				Console.ReadKey();
			}
		}
	}
}
