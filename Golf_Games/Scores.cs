using System;
using System.Collections.Generic;

namespace Golf_Games
{
	public class Scores
	{
		public Scores ()
		{
			//Set stroke counts to 0
			foreach (int element in strokeCountP1) 
			{
				strokeCountP1 [element] = 0;
				strokeCountP2 [element] = 0;
				strokeCountP3 [element] = 0;
				strokeCountP4 [element] = 0;
			}
			//Create a PlayerHoleSideBetInfo object for each element of the array of all 4 arrays.
			for (int i = 0; i < betScoreP1.Length; i++) 
			{

				betScoreP1 [i] = new PlayerHoleSideBetInfo ();
				betScoreP2 [i] = new PlayerHoleSideBetInfo ();
				betScoreP3 [i] = new PlayerHoleSideBetInfo ();
				betScoreP4 [i] = new PlayerHoleSideBetInfo ();
			}
		}

		//Methods

		//Setters and Getters
		public PlayerHoleSideBetInfo[] GetBetScoreP1()
		{
			return betScoreP1;
		}
		public void SetBetScoreP1(PlayerHoleSideBetInfo[] score)
		{
			betScoreP1 = score;
		}

		public PlayerHoleSideBetInfo[] GetBetScoreP2()
		{
			return betScoreP2;
		}
		public void SetBetScoreP2(PlayerHoleSideBetInfo[] score)
		{
			betScoreP2 = score;
		}
		public PlayerHoleSideBetInfo[] GetBetScoreP3()
		{
			return betScoreP3;
		}
		public void SetBetScoreP3(PlayerHoleSideBetInfo[] score)
		{
			betScoreP3 = score;
		}
		public PlayerHoleSideBetInfo[] GetBetScoreP4()
		{
			return betScoreP4;
		}
		public void SetBetScoreP4(PlayerHoleSideBetInfo[] score)
		{
			betScoreP4 = score;
		}

		public void SetBetHoleSwitchesP1(bool[] score, int index)
		{
			betScoreP1 [index].SetSideBetSwitches (score);
		}

		public void SetBetHoleSwitchesP2(bool[] score, int index)
		{
			betScoreP2 [index].SetSideBetSwitches (score);
		}

		public void SetBetHoleSwitchesP3(bool[] score, int index)
		{
			betScoreP3 [index].SetSideBetSwitches (score);
		}

		public void SetBetHoleSwitchesP4(bool[] score, int index)
		{
			betScoreP4 [index].SetSideBetSwitches (score);
		}


		//Data Members

		//Betting information
		//These values should end up being positive or negative for every array entry.
		private PlayerHoleSideBetInfo[] betScoreP1 = new PlayerHoleSideBetInfo[18];
		private PlayerHoleSideBetInfo[] betScoreP2 = new PlayerHoleSideBetInfo[18];
		private PlayerHoleSideBetInfo[] betScoreP3 = new PlayerHoleSideBetInfo[18];
		private PlayerHoleSideBetInfo[] betScoreP4 = new PlayerHoleSideBetInfo[18];


		//Scoring
		public int[] strokeCountP1 = new int[18];
		public int[] strokeCountP2 = new int[18];
		public int[] strokeCountP3 = new int[18];
		public int[] strokeCountP4 = new int[18];

		//Properties

	}
	public class PlayerHoleSideBetInfo
	{
		//Data members
		public int TotalWinnings{ get; set;}
		public int SandyParWinnings{ get; set;}
		public int GreenieWinnings{ get; set;}
		public int CTPWinnings{ get; set;}
		public int HOFFWinnings{ get; set;}
		public int BirdieWinnings{ get; set;}
		public int EagleWinnings{ get; set;}

		private bool[] sideBetSwitches = new bool[6];

		//Methods
		public PlayerHoleSideBetInfo()
		{
			TotalWinnings = 0;
			SandyParWinnings = 0;
			GreenieWinnings = 0;
			CTPWinnings = 0;
			HOFFWinnings = 0;
			BirdieWinnings = 0;
			EagleWinnings = 0;
		}

		public bool[] GetSideBetSwitches()
		{
			return sideBetSwitches;
		}

		public void SetSideBetSwitches(bool[] newSideBetSwitches)
		{
			sideBetSwitches = newSideBetSwitches;
		}

	}
}

