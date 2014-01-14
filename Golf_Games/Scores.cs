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
//			for (int i = 0; i < betScoreP1.Length; i++) 
//			{
//
//				betScoreP1 [i] = new PlayerHoleSideBetInfo ();
//				betScoreP2 [i] = new PlayerHoleSideBetInfo ();
//				betScoreP3 [i] = new PlayerHoleSideBetInfo ();
//				betScoreP4 [i] = new PlayerHoleSideBetInfo ();
//			}
		}

		//Methods

		public void CalculateWinnings(int holeIndex)
		{
			List<bool[]> allPlayersSwitches = new List<bool[]> (); 
			bool[] betSwitchesP1 = betScoreP1 [holeIndex].GetSideBetSwitches ();
			bool[] betSwitchesP2 = betScoreP2 [holeIndex].GetSideBetSwitches ();
			bool[] betSwitchesP3 = betScoreP3 [holeIndex].GetSideBetSwitches ();
			bool[] betSwitchesP4 = betScoreP4 [holeIndex].GetSideBetSwitches ();

			bool[] currentBet = new bool[4];

			int betWinnerCount = 0;

			allPlayersSwitches.Add (betSwitchesP1);
			allPlayersSwitches.Add (betSwitchesP2);
			allPlayersSwitches.Add (betSwitchesP3);
			allPlayersSwitches.Add (betSwitchesP4);

			//Calculate who gets what based on the switches and the point values that were inserted

				//Cycle through all the switches for that player
				for(int i = 0; i < betSwitchesP1.Length; i++)
				{
					//Reset the betwinnercount
					betWinnerCount = 0;

					for (int j = 0; j < NumPlayers; j ++) 
					{
						currentBet [j] = allPlayersSwitches [j] [i];
						if (currentBet [j] == true) 
						{
							//This value can help determine how much a player recieves or loses.
							betWinnerCount++;
						}
						
					}

					//compare all switches and decide winnings
					//0 - Birdie
					//1 - CTP
					//2 - Eagle
					//3 - Greenie
					//4 - HOFF
					//5 - SandyPar
					
					switch (betWinnerCount) 
					{
						case 1:
							break;
						case 2:
							break;
						case 3:
							if(currentBet[0] == true)
								betScoreP1[holeIndex].BirdieWinnings = BetBirdie;
							
							break;
						case 4:
							break;
					}	

					switch(i)
					{
						case 0:
							
							break; 
						case 1:
							break; 
						case 2:
							break; 
						case 3:
							break; 
						case 4:
							break; 
						case 5:
							break; 

						default:
							break;
					}
				}
			

		}

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

		//These are special setters need to set the switches inside the PlayerHoleSideBetInfo object
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
		public int NumPlayers{ get; set; }
		public int BetSandyPar{ get; set; }
		public int BetBirdie{ get; set; }
		public int BetGreenie{ get; set; }
		public int BetEagle{ get; set; }
		public int BetCTP{ get; set; }
		public int BetHOFF{ get; set; }
		

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

