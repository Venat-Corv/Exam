using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace KeyTraning
{
	class TraningBase
	{
		StringBilder traningText;
		Thread timeCount = new Thread(myTime);


		static int counter;
		int wrongs;
		int level;
		static int time;
		bool[] chacking = new bool[25];
		public StringBilder TraningText
		{
			get => traningText;
			set => traningText = value;
		}
		public int Counter
		{
			get => counter;
			set => counter = value;
		}
		public int Wrongs
		{
			get => wrongs;
			set => wrongs = value;
		}
		public static int Time
		{
			get => time;
			set => time = value;
		}
		public TraningBase(StringBilder traningText)
		{
			TraningText = traningText;
		}
		public static bool CheckingKey(char key, StringBilder TraningText, int Counter)
		{
			if (key == TraningText.FinalText.ToCharArray()[Counter]) return true;
			else return false;
		}

		public static void myTime()
		{
			while(counter > 0)
			{
			Time = Time + 1;
			Thread.Sleep(1000);
			}
		}

		public void Visible(bool[] isValid)
		{
			Console.Clear();

			for (int i = 0; i < TraningText.FinalText.Length; i++)
			{

				if (i <= Counter)
				{
					if (isValid[i])
					{
						ConsoleColor defaultColor = Console.ForegroundColor;
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write(TraningText.FinalText.ToCharArray()[i]);
						Console.ForegroundColor = defaultColor;
					}
					else
					{
						ConsoleColor defaultColor = Console.ForegroundColor;
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write(TraningText.FinalText.ToCharArray()[i]);
						Console.ForegroundColor = defaultColor;
					}
				}
				else Console.Write(TraningText.FinalText.ToCharArray()[i]);

			}
		}
		public double GoGame(char key)
		{
			if (Counter == 0)
			{
				chacking[Counter] = CheckingKey(key, TraningText, Counter);
				Visible(chacking);
				Counter = Counter + 1;
				timeCount.Start();
				return 0;
			}
			if (Counter > 0 && Counter < TraningText.FinalText.Length - 1)
			{
				chacking[Counter] = CheckingKey(key, TraningText, Counter);
				Visible(chacking);
				Counter = Counter + 1;
				return 0;
			}
			if (Counter == TraningText.FinalText.Length - 1)
			{
				chacking[Counter] = CheckingKey(key, TraningText, Counter);
				Visible(chacking);
				Counter = 0;
				timeCount.Join();
				for(int i = 0; i < TraningText.FinalText.Length; i++)
				{
					if (!chacking[i]) Wrongs = Wrongs + 1;
				}
				return Convert.ToDouble((TraningText.FinalText.Length / Convert.ToDouble(Time)) * 60);
			}
			else return 0;
		}
	}
}
