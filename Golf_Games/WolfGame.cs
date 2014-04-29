using System;
using System.Collections.Generic;

namespace Golf_Games
{
	public class WolfGame
	{
		public WolfGame ()
		{
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

			//CurrentWolf = 0;
			//CurrentWP is set to -1 showing that there is no wolf partner to begin with. A valid range will be 0 through 3.
			//CurrentWP = -1;
		}



		//Data Members
		private int[] p1Winnings = new int[18];
		private int[] p2Winnings = new int[18];
		private int[] p3Winnings = new int[18];
		private int[] p4Winnings = new int[18];
		private List<int[]> playerWinnings = new List<int[]> ();

		//Properties
		public int NumHoles{ get; set; }
		public int CurrentWolf{ get; set; }
		//public int CurrentWP{ get; set; }
		public int NumWolves{ get; set; }

		//public bool[] CurrentWolves = new bool[4]{false, false, false, false};
		public bool[] CurrentWPs = new bool[4]{false, false, false, false};

		//Methods
		public List<int[]> PlayerWinnings
		{
			get{ return playerWinnings; }
			set{playerWinnings = value; }
		}
	}
}

