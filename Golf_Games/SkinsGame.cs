using System;
using System.Collections.Generic;

namespace Golf_Games
{

	public enum SkinsMode
	{
		Standard = 0,
		Progressive = 1,
		ProgressiveHCP = 2,
		Custom = 3
	};

	enum HoleResult{Loss, Win, Tie};

	public class SkinsGame
	{
		public SkinsGame ()
		{
			foreach (int element in holePtValues)
				holePtValues [element] = 0;

			foreach (int element in holePushValues)
				holePushValues [element] = 0;

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

		//Data members
		//HolePtValues are the point value for each indivudual hole
		private int[] holePtValues = new int[18];
		//holePushValues are the point values that are pushed to the next hole in the event of a tie.
		private  int[] holePushValues = new int[18];

		public SkinsMode skinsMode;

		private int[] p1Winnings = new int[18];
		private int[] p2Winnings = new int[18];
		private int[] p3Winnings = new int[18];
		private int[] p4Winnings = new int[18];
		private List<int[]> playerWinnings = new List<int[]> ();

		//Properties and getters/setters
		public int[] HolePtValues
		{
			get{return holePtValues;}
			set{holePtValues = value;}
		}

		public int[] HolePushValues
		{
			get{return holePushValues;}
			set{holePushValues = value;}
		}
		public List<int[]> PlayerWinnings
		{
			get{ return playerWinnings; }
			set{playerWinnings = value; }
		}

		//Holds the number of skins for the game.
		public int NumSkins{ get; set; }
		public int NumHoles{ get; set; }




		//Methods
		public void ClearAll()
		{
			foreach (int element in holePtValues)
				holePtValues [element] = 0;

			NumSkins = 0;
		}

		public void SetAllHoleValues(int value)
		{
			for (int i = 0; i < holePtValues.Length; i++)
				holePtValues [i] = value;
		}

		//In standard mode, every hole should have the same value.
		public void SetupStandard(int skinValue)
		{
			for (int i = 0; i < holePtValues.Length; i++) 
			{
				holePtValues [i] = skinValue;
				NumSkins++;
			}

		}

		//Currently, this function will add skins to holes toward the backend of the match. This will need to be revised most likely.
		public void SetupProgressive(int skinValue, int numSkins)
		{

			//The holeGap should be between the range of 1 and 18
			int holeGap = NumHoles - numSkins;
			int skinIterator = 0;

			for(int i = 0; i < NumHoles; i++)
			{
				if (i >= holeGap) 
				{
					HolePtValues [i] = skinValue + skinIterator;
					skinIterator++;
				}

			}

		}

		public void SetupProgressiveHCP(int skinValue, int numSkins, CurrentHole[] holes)
		{
			//The holeGap should be between the range of 1 and 18
			//int holeGap = NumHoles - numSkins;
			int skinIterator = 0;


			for(int i = 0; i < NumHoles; i++)
			{
				if (holes[i].hole_handicap <= numSkins)
				{
					HolePtValues [i] = skinValue + skinIterator;
					skinIterator++;
				}

			}
		}

		public void SetupCustom()
		{

		}

		public void CalculatePushes(List<int[]> strokeCountList)
		{
			const int maxHoles = 18;
			const int numPlayers = 4;

			int[] values = new int[] { 0, 0, 0, 0 };
			Tuple<int, int> indexAndTie;

			for(int i = 0; i < maxHoles; i++)
			{
				for (int j = 0; j < values.Length; j++)
					values [j] = strokeCountList [j] [i];

				indexAndTie = LowestInArrayCheck (values);

				if (indexAndTie.Item2 == (int)HoleResult.Tie && i < (maxHoles - 1)) 
				{
					//Push the skin to the next hole. Take the the values that have been previously pushed as well if any.
					HolePushValues [i + 1] = holePtValues [i] + holePushValues [i];
				}
			}

		}

		//This function will take in an array and look for the lowest value.
		//Duplicated from NassauGame
		private Tuple<int, int> LowestInArrayCheck(int[] values)
		{
			//Default the hole result to a win.
			int result = (int)HoleResult.Win;
			int lowestValueIndex = 0; // Set the lowest index to the first index.


			for (int i = 0; i < values.Length; i++) 
			{
				if(values[i] < values[lowestValueIndex] && values[i] != 0)
					lowestValueIndex = i;


			}

			//Check lowest value for a tie
			for (int i = 0; i < values.Length; i++) 
			{
				if (i != lowestValueIndex) 
				{
					if (values [i] == values [lowestValueIndex] && values [lowestValueIndex] != 0)
						result = (int)HoleResult.Tie;
				}

			}
			//If the lowestValueIndex value is 0, then the array was all zeros.
			if (values [lowestValueIndex] == 0)
				result = (int)HoleResult.Loss;

			//indexAndTie.Item1 = lowestValueIndex;
			//indexAndTie.Item2 = tie;
			var indexAndTie = new Tuple <int, int> (lowestValueIndex, result);

			return indexAndTie;

		}


	}
}

