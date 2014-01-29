using System;
using System.Collections.Generic;

namespace Golf_Games
{
	public class Scores
	{
		public Scores ()
		{
			//Set the number of players


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

		public void CalculateWinnings(int holeIndex)
		{
			List<bool[]> allPlayersSwitches = new List<bool[]> (); 
			bool[] betSwitchesP1 = betScoreP1 [holeIndex].GetSideBetSwitches ();
			bool[] betSwitchesP2 = betScoreP2 [holeIndex].GetSideBetSwitches ();
			bool[] betSwitchesP3 = betScoreP3 [holeIndex].GetSideBetSwitches ();
			bool[] betSwitchesP4 = betScoreP4 [holeIndex].GetSideBetSwitches ();

			PlayerHoleSideBetInfo playerHSBI = new PlayerHoleSideBetInfo ();

			bool[] currentBet = new bool[4];

			int betWinnerCount = 0;
			int tempWinnings = 0;
			int tempTotalWinnings = 0;

			allPlayersSwitches.Add (betSwitchesP1);
			allPlayersSwitches.Add (betSwitchesP2);
			allPlayersSwitches.Add (betSwitchesP3);
			allPlayersSwitches.Add (betSwitchesP4);

			//Calculate who gets what based on the switches and the point values that were inserted
			for (int playerIndex = 0; playerIndex < NumPlayers; playerIndex++) 
			{
				switch (playerIndex) 
				{
					case 0:
					playerHSBI = betScoreP1[holeIndex];
					break;

					case 1:
					playerHSBI = betScoreP2[holeIndex];
					break;

					case 2:
					playerHSBI = betScoreP3[holeIndex];
					break; 

					case 3:
					playerHSBI = betScoreP4[holeIndex];
					break;
				}

				//Cycle through all the switches for that player
				for (int i = 0; i < betSwitchesP1.Length; i++) {
					//Reset the betwinnercount
					betWinnerCount = 0;

					for (int j = 0; j < NumPlayers; j ++) {
						currentBet [j] = allPlayersSwitches [j] [i];
						if (currentBet [j] == true) {
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


					switch (i) {
					case 0:
						tempWinnings = DetermineWinningsForSwitch (holeIndex, currentBet [playerIndex], betWinnerCount, BetBirdie);
						playerHSBI.BirdieWinnings = tempWinnings;
						break; 
					case 1:
						tempWinnings = DetermineWinningsForSwitch (holeIndex, currentBet [playerIndex], betWinnerCount, BetCTP);
						playerHSBI.CTPWinnings = tempWinnings;
						break; 
					case 2:
						tempWinnings = DetermineWinningsForSwitch (holeIndex, currentBet [playerIndex], betWinnerCount, BetEagle);
						playerHSBI.EagleWinnings = tempWinnings;
						break; 
					case 3:
						tempWinnings = DetermineWinningsForSwitch (holeIndex, currentBet [playerIndex], betWinnerCount, BetGreenie);
						playerHSBI.GreenieWinnings = tempWinnings;
						break; 
					case 4:
						tempWinnings = DetermineWinningsForSwitch (holeIndex, currentBet [playerIndex], betWinnerCount, BetHOFF);
						playerHSBI.HOFFWinnings = tempWinnings;
						break; 
					case 5:
						tempWinnings = DetermineWinningsForSwitch (holeIndex, currentBet [playerIndex], betWinnerCount, BetSandyPar);
						playerHSBI.SandyParWinnings = tempWinnings;
						break; 

					default:
						tempWinnings = 0;
						break;
					}

					//The winnings in temp winnings are added to the total winnings for that bet. Total winnings is what should be displayed on screen for that hole.
					tempTotalWinnings = tempTotalWinnings + tempWinnings;


					switch (playerIndex) 
					{
						case 0:
							betScoreP1[holeIndex] = playerHSBI;
							break;

						case 1:
							betScoreP2[holeIndex] = playerHSBI;
							break;

						case 2:
							betScoreP3[holeIndex] = playerHSBI;
							break; 

						case 3:
							betScoreP4[holeIndex] = playerHSBI;
							break;
					}


				}
				playerHSBI.TotalWinnings = tempTotalWinnings;

				//Reset tempTotalWinnings
				tempTotalWinnings = 0;

			}
			

		}

		//Methods
		public int DetermineWinningsForSwitch(int holeIndex, bool currentBet, int betWinnerCount, int pointValue)
		{

			int winnings = 0;

			if (betWinnerCount != NumPlayers && betWinnerCount != 0) 
			{
				if (currentBet == true) 
				{	//If the player has won the current bet 
					//if betwinnercount is odd
					if (betWinnerCount % 2 != 0)
						winnings = pointValue * (NumPlayers - betWinnerCount);
					else {
						winnings = pointValue;
					}
				} 
				else 
				{ //If the currentBet is a loss
					//if betwinnercount is odd
					if (betWinnerCount % 2 != 0)
						winnings = (pointValue * betWinnerCount) * -1;
					else 
					{
						winnings = pointValue * -1;
					}
				} 
			}



			return winnings;
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
		public PlayerHoleSideBetInfo[] betScoreP1 = new PlayerHoleSideBetInfo[18];
		public PlayerHoleSideBetInfo[] betScoreP2 = new PlayerHoleSideBetInfo[18];
		public PlayerHoleSideBetInfo[] betScoreP3 = new PlayerHoleSideBetInfo[18];
		public PlayerHoleSideBetInfo[] betScoreP4 = new PlayerHoleSideBetInfo[18];




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

		public void ClearAll()
		{
			TotalWinnings = 0;
			SandyParWinnings = 0;
			GreenieWinnings = 0;
			CTPWinnings = 0;
			HOFFWinnings = 0;
			BirdieWinnings = 0;
			EagleWinnings = 0;

			//TODO: May need to reset the switches as well.
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

