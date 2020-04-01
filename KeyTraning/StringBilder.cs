using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyTraning
{
	class StringBilder
	{
		String levelcenter = "asdfghjk;'";
		String levelup = "qwertyuiop[]";
		String leveldown = "zxcvbnm,./";
		String Buffer="";
		String subText="";
		String finalText="";
		int level;
		public String SubText
		{
			get => subText;
			set => subText = value.Length == 4 ? value : "abcd";
		}
		public String FinalText
		{
			get => finalText;
			set => finalText = finalText.Length < 20 ? FinalText.Length == 0 ? value : $"{finalText} {value}" : finalText;
		}
		public int Level
		{
			get => level;
			set => level = value >= 0 && value <= 4 ? value : 0; 
		}
		public StringBilder(int level)
		{
			Level = level;
			Random r = new Random();
			for (int i = 0; i < 4; i++)
			{
				while (Buffer.Length < 4)
				{
					switch (Level)
					{
						case 0: Buffer = Buffer.Length == 0 ? levelcenter.Substring(r.Next(levelcenter.Length), 1) : Buffer + levelcenter.Substring(r.Next(levelcenter.Length), 1); break;
						case 1: Buffer = Buffer.Length == 0 ? levelup.Substring(r.Next(levelcenter.Length), 1) : Buffer + levelup.Substring(r.Next(levelcenter.Length), 1); break;
						case 2: Buffer = Buffer.Length == 0 ? leveldown.Substring(r.Next(levelcenter.Length), 1) : Buffer + leveldown.Substring(r.Next(levelcenter.Length), 1); break;
					}
				}
				SubText = Buffer;
				Buffer = "";
				FinalText = SubText;
			}
			subText = "";
			FinalText.TrimEnd(' ');
		}
	}
}
