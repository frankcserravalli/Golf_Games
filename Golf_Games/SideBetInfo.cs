using System;

namespace Golf_Games
{
	public class SideBetInfo
	{
		//These arrays show what side betting options are selected when the score is inputted.
		public bool[] player1;
		public bool[] player2;
		public bool[] player3;
		public bool[] player4;

		public SideBetInfo ()
		{
			player1 = new bool[] { false, false, false, false, false, false };
			player2 = new bool[] { false, false, false, false, false, false };
			player3 = new bool[] { false, false, false, false, false, false };
			player4 = new bool[] { false, false, false, false, false, false };
		}
	}
}

