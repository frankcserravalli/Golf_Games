using System;
using System.Collections.Generic;

namespace Golf_Games
{
	public class NassauGame
	{
		enum HoleResult{Loss, Win, Tie};
			 
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

			foreach (int element in p1HoleWins) 
			{
				p1HoleWins [element] = 0;
				p2HoleWins [element] = 0;
				p3HoleWins [element] = 0;
				p4HoleWins [element] = 0;
			}
			playerHoleWins.Add (p1HoleWins);
			playerHoleWins.Add (p2HoleWins);
			playerHoleWins.Add (p3HoleWins);
			playerHoleWins.Add (p4HoleWins);
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

		//These containers will hold either a 0, 1, or a 2. This will mean a loss, a win, or a tie for each hole respectively.
		private int[] p1HoleWins = new int[18];
		private int[] p2HoleWins = new int[18];
		private int[] p3HoleWins = new int[18];
		private int[] p4HoleWins = new int[18];
		private List<int[]> playerHoleWins = new List<int[]> ();

		//Data members


		//Methods
		public List<int[]> PlayerWinnings
		{
			get{ return playerWinnings; }
			set{playerWinnings = value; }
		}

		public List<int[]> PlayerHoleWins
		{
			get{ return playerHoleWins; }
			set{ playerHoleWins = value; }
		}

		//This function will take in an array and look for the lowest value.
		private Tuple<int, bool> LowestInArrayCheck(int[] values)
		{
			bool tie = false;
			int lowestValueIndex = 0; // Set the lowest index to the first index.


			for (int i = 0; i < values.Length; i++) 
			{
				if(values[i] < values[lowestValueIndex] && values[i] != 0)
					lowestValueIndex = i;

				if (values [i] == values[lowestValueIndex] && values[i] != 0)
					tie = true;
			}


			//indexAndTie.Item1 = lowestValueIndex;
			//indexAndTie.Item2 = tie;
			var indexAndTie = new Tuple <int, bool> (lowestValueIndex, tie);

			return indexAndTie;
			
		}

		//This function is intended to correctly fill out the playerHoleWins.
		public void CalculateHoleBets(List<int[]> strokeList, int numPlayers)
		{
			int[] strokesForHole = new int[4];
			Tuple<int, bool> indexAndTie;

			//The stroke list should have the same amount of players in the game
		
			//For every hole
			for(int j = 0; j < NumHoles; j++)
			{
				//Set all elements to 0
				for (int h = 0; h < strokesForHole.Length; h++)
					strokesForHole [h] = 0;

				//Add all elements from the strokelist hole to this array
				for (int k = 0; k < numPlayers; k++)
					strokesForHole [k] = strokeList [k] [j];

				//Perform a lowest check on this hole
				indexAndTie = LowestInArrayCheck (strokesForHole);

				if (indexAndTie.Item2 == false)
					playerHoleWins [indexAndTie.Item1] [j] = (int)HoleResult.Win;
				else
					playerHoleWins [indexAndTie.Item1] [j] = (int)HoleResult.Tie;

			}


		}
	}
}

