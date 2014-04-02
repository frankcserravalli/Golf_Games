using System;
using System.Collections.Generic;

namespace Golf_Games
{
	public class NassauGame
	{
		public NassauGame ()
		{
			BetFrontNine = 0;
			BetBackNine = 0;
			BetAllHoles = 0;

			foreach (int element in p1Winnings) 
			{
				p1Winnings [element] = 0;
				p2Winnings [element] = 0;
				p3Winnings [element] = 0;
				p4Winnings [element] = 0;
			}
			playerWinnings.Add (p1Winnings);
			playerWinnings.Add (p2Winnings);
			playerWinnings.Add (p3Winnings);
			playerWinnings.Add (p4Winnings);
		}

		//Properties
		public int BetFrontNine{ get; set;}
		public int BetBackNine{ get; set;}
		public int BetAllHoles{ get; set;}
		public int NumHoles{ get; set; }

		private int[] p1Winnings = new int[3];	//Front nine, back nine, all 18 for each player
		private int[] p2Winnings = new int[3];
		private int[] p3Winnings = new int[3];
		private int[] p4Winnings = new int[3];
		private List<int[]> playerWinnings = new List<int[]> ();

		//Data members


		//Methods
		public List<int[]> PlayerWinnings
		{
			get{ return playerWinnings; }
			set{playerWinnings = value; }
		}
	}
}

