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



			//Add the betScores to the betScoreList
			betScoreList.Add (betScoreP1);
			betScoreList.Add (betScoreP2);
			betScoreList.Add (betScoreP3);
			betScoreList.Add (betScoreP4);
		}

		//Methods
		public void AddSideBetPointsToList()
		{
			if (sideBetList.Count == 0) 
			{
				//Add sideBet point values to the list
				sideBetList.Add (BetSandyPar);
				sideBetList.Add (BetBirdie);
				sideBetList.Add (BetGreenie);
				sideBetList.Add (BetEagle);
				sideBetList.Add (BetCTP);
				sideBetList.Add (BetHOFF);
			}
		}

		public void AddStrokeCountsToList()
		{
			if (strokeCountList.Count == 0) 
			{
				strokeCountList.Add (strokeCountP1);
				strokeCountList.Add (strokeCountP2);
				strokeCountList.Add (strokeCountP3);
				strokeCountList.Add (strokeCountP4);
			}
		}



		//Methods

		public void BetsCalculationAllHoles()
		{
			const int maxHoles = 18;
			int playerTempValues = 0;



			//All winnings need to be reset before calculating.
			for (int i = 0; i < betScoreList.Count; i++) 
			{
				for(int j = 0; j < betScoreP1.Length; j++)
					betScoreList [i] [j].ClearAll ();
			}

			for(int holeIndex = 0; holeIndex < maxHoles; holeIndex++)
			{
				for(int j = 0; j < NumPlayers; j++)
				{
					for(int k = 0; k < NumPlayers; k++)
					{
						if (j != k) 
						{
							playerTempValues = BetsCalculationPerPlayer (j, k, betScoreList [j], betScoreList [k], holeIndex);
							betScoreList [j] [holeIndex].TotalWinnings += playerTempValues;

						}
					}

				}
			}
		}

		public int BetsCalculationPerPlayer(int playerIndex, int nextPlayerIndex, PlayerHoleSideBetInfo[] playerHSBI, PlayerHoleSideBetInfo[] nextPlayerHSBI, int holeIndex)
		{
			int playerTempValue = 0;


			for(int switchIndex = 0; switchIndex < sideBetList.Count; switchIndex++)
			{
				if (playerHSBI [holeIndex].GetSideBetSwitches() [switchIndex] == nextPlayerHSBI [holeIndex].GetSideBetSwitches() [switchIndex]) 
				{
					//If both switches are equal, do nothing
				} 
				else 
				{
					//If both switches are not equal, Determine who is the winner
					if (playerHSBI [holeIndex].GetSideBetSwitches () [switchIndex] == true) {
						//PlayerTempValue will be used for total winnings
						playerTempValue += sideBetList [switchIndex];

						switch (switchIndex) {
						case 0:
							playerHSBI [holeIndex].BirdieWinnings += sideBetList [switchIndex];
							break;

						case 1:
							playerHSBI [holeIndex].CTPWinnings += sideBetList [switchIndex];
							break;

						case 2:
							playerHSBI [holeIndex].EagleWinnings += sideBetList [switchIndex];
							break;

						case 3:
							playerHSBI [holeIndex].GreenieWinnings += sideBetList [switchIndex];
							break;

						case 4:
							playerHSBI [holeIndex].HOFFWinnings += sideBetList [switchIndex];
							break;

						case 5:
							playerHSBI [holeIndex].SandyParWinnings += sideBetList [switchIndex];
							break;

						default:
							break;
						}

						//Add on what the losing player owes the winning player for that hole.
						nextPlayerHSBI [holeIndex].owesToPlayerList [playerIndex] += sideBetList [switchIndex];
					} 
					else 
					{
						//You are a loser
						playerTempValue += (sideBetList [switchIndex] * -1);

						switch (switchIndex) {
							case 0:
							playerHSBI [holeIndex].BirdieWinnings += (sideBetList [switchIndex] * -1);
							break;

							case 1:
							playerHSBI [holeIndex].CTPWinnings += (sideBetList [switchIndex]* -1);
							break;

							case 2:
							playerHSBI [holeIndex].EagleWinnings += (sideBetList [switchIndex]* -1);
							break;

							case 3:
							playerHSBI [holeIndex].GreenieWinnings += (sideBetList [switchIndex]* -1);
							break;

							case 4:
							playerHSBI [holeIndex].HOFFWinnings += (sideBetList [switchIndex]* -1);
							break;

							case 5:
							playerHSBI [holeIndex].SandyParWinnings += (sideBetList [switchIndex]* -1);
							break;

							default:
							break;
						}

						//Add on what the winning player owes the losing player for that hole.
						nextPlayerHSBI [holeIndex].owesToPlayerList [playerIndex] += (sideBetList [switchIndex] * -1);
					}

				}

			}

			//Need to keep track of who owes who for the points chart.

			return playerTempValue;
		}

//		//A method used to calculate the values betting wins/losses for the bottom nine. This method is intended primarily for Nassau.
//		public int CalculateTotalBetsLower(int playerIndex)
//		{
//			for (int i = 0; i < NumPlayers; i++) 
//			{
//
//			}
//		}

		//A method used to calculate the stroke count for the bottom nine.
		public int CalculateTotalStrokesLower(int playerIndex)
		{
			int totalStrokes = 0;

			for (int i = 0; i < 9; i++) 
			{
				totalStrokes += strokeCountList [playerIndex] [i];
			}
			return totalStrokes;
		}

		//A method used to calculate the stroke count for the upper nine.
		public int CalculateTotalStrokesUpper(int playerIndex)
		{
			int totalStrokes = 0;

			for (int i = 9; i < 18; i++) 
			{
				totalStrokes += strokeCountList [playerIndex] [i];
			}
			return totalStrokes;
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

		public void CalculateTotalPointsOwed()
		{
			//int playerIndex = playerNumber - 1;
			const int p1Index = 0;
			const int p2Index = 1;
			const int p3Index = 2;
			const int p4Index = 3;

			for (int i = 0; i < betScoreP1.Length; i++) 
			{
				for (int j = 0; j < NumPlayers; j++) 
				{
					switch (j) {
					case 0:
						player1PointsOwed.OwedToPlayer2 += betScoreP1 [i].owesToPlayerList [p2Index];
						player1PointsOwed.OwedToPlayer3 += betScoreP1 [i].owesToPlayerList [p3Index];
						player1PointsOwed.OwedToPlayer4 += betScoreP1 [i].owesToPlayerList [p4Index];
						player1PointsOwed.TotalOwed += betScoreP1 [i].owesToPlayerList [p2Index] + betScoreP1 [i].owesToPlayerList [p3Index] + betScoreP1 [i].owesToPlayerList [p4Index];
						break;

					case 1:
						player2PointsOwed.OwedToPlayer1 += betScoreP2 [i].owesToPlayerList [p1Index];
						player2PointsOwed.OwedToPlayer3 += betScoreP2 [i].owesToPlayerList [p3Index];
						player2PointsOwed.OwedToPlayer4 += betScoreP2 [i].owesToPlayerList [p4Index];
						player2PointsOwed.TotalOwed += betScoreP2 [i].owesToPlayerList [p1Index] + betScoreP2 [i].owesToPlayerList [p3Index] + betScoreP2 [i].owesToPlayerList [p4Index];
						break;

					case 2:
						player3PointsOwed.OwedToPlayer1 += betScoreP3 [i].owesToPlayerList [p1Index];
						player3PointsOwed.OwedToPlayer2 += betScoreP3 [i].owesToPlayerList [p2Index];
						player3PointsOwed.OwedToPlayer4 += betScoreP3 [i].owesToPlayerList [p4Index];
						player3PointsOwed.TotalOwed += betScoreP3 [i].owesToPlayerList [p1Index] + betScoreP3 [i].owesToPlayerList [p2Index] + betScoreP3 [i].owesToPlayerList [p4Index];
						break;

					case 3:
						player4PointsOwed.OwedToPlayer1 += betScoreP4 [i].owesToPlayerList [p1Index];
						player4PointsOwed.OwedToPlayer2 += betScoreP4 [i].owesToPlayerList [p2Index];
						player4PointsOwed.OwedToPlayer3 += betScoreP4 [i].owesToPlayerList [p3Index];
						player4PointsOwed.TotalOwed += betScoreP4 [i].owesToPlayerList [p1Index] + betScoreP4 [i].owesToPlayerList [p2Index] + betScoreP4 [i].owesToPlayerList [p3Index];
						break;

					default:
						break;
					}
				}
			}

		}

		//Data Members

		//Betting information
		//These values should end up being positive or negative for every array entry.
		public PlayerHoleSideBetInfo[] betScoreP1 = new PlayerHoleSideBetInfo[18];
		public PlayerHoleSideBetInfo[] betScoreP2 = new PlayerHoleSideBetInfo[18];
		public PlayerHoleSideBetInfo[] betScoreP3 = new PlayerHoleSideBetInfo[18];
		public PlayerHoleSideBetInfo[] betScoreP4 = new PlayerHoleSideBetInfo[18];

		//These are used for the points chart tab
		public PointsOwed player1PointsOwed = new PointsOwed();
		public PointsOwed player2PointsOwed = new PointsOwed();
		public PointsOwed player3PointsOwed = new PointsOwed();
		public PointsOwed player4PointsOwed = new PointsOwed();


		//Scoring
		public int[] strokeCountP1 = new int[18];
		public int[] strokeCountP2 = new int[18];
		public int[] strokeCountP3 = new int[18];
		public int[] strokeCountP4 = new int[18];

		//Handicap Score
		public int[] handiStrokeCountP1 = new int[18];
		public int[] handiStrokeCountP2 = new int[18];
		public int[] handiStrokeCountP3 = new int[18];
		public int[] handiStrokeCountP4 = new int[18];

		//Properties
		public int NumPlayers{ get; set; }
		public int BetSandyPar{ get; set; }
		public int BetBirdie{ get; set; }
		public int BetGreenie{ get; set; }
		public int BetEagle{ get; set; }
		public int BetCTP{ get; set; }
		public int BetHOFF{ get; set; }


		//List for side bet point values
		public List<int> sideBetList = new List<int> ();

		//List for betScores
		public List<PlayerHoleSideBetInfo[]> betScoreList = new List<PlayerHoleSideBetInfo[]> ();

		public List<int[]> strokeCountList = new List<int[]> ();

		//Game modes
		public SkinsGame skinsGame = new SkinsGame();
		public WolfGame wolfGame = new WolfGame();
		public NassauGame nassauGame = new NassauGame ();

		

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
		public int OwesToPlayer1 { get; set; }
		public int OwesToPlayer2 { get; set; }
		public int OwesToPlayer3 { get; set; }
		public int OwesToPlayer4 { get; set; }
		public List<int> owesToPlayerList = new List<int> ();

		private bool[] sideBetSwitches = new bool[6];

		//Constructors
		public PlayerHoleSideBetInfo()
		{
			TotalWinnings = 0;
			SandyParWinnings = 0;
			GreenieWinnings = 0;
			CTPWinnings = 0;
			HOFFWinnings = 0;
			BirdieWinnings = 0;
			EagleWinnings = 0;
			OwesToPlayer1 = 0;
			OwesToPlayer2 = 0;
			OwesToPlayer3 = 0;
			OwesToPlayer4 = 0;
			owesToPlayerList.Add (OwesToPlayer1);
			owesToPlayerList.Add (OwesToPlayer2);
			owesToPlayerList.Add (OwesToPlayer3);
			owesToPlayerList.Add (OwesToPlayer4);

		}
		//Methods
		public void ClearAll()
		{
			TotalWinnings = 0;
			SandyParWinnings = 0;
			GreenieWinnings = 0;
			CTPWinnings = 0;
			HOFFWinnings = 0;
			BirdieWinnings = 0;
			EagleWinnings = 0;
			OwesToPlayer1 = 0;
			OwesToPlayer2 = 0;
			OwesToPlayer3 = 0;
			OwesToPlayer4 = 0;

			for (int i = 0; i < owesToPlayerList.Count; i++)
				owesToPlayerList [i] = 0;

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

	public class PointsOwed
	{
		//Constructor
		public PointsOwed()
		{
			OwedToPlayer1 = 0;
			OwedToPlayer2 = 0;
			OwedToPlayer3 = 0;
			OwedToPlayer4 = 0;
			TotalOwed = 0;
		}

		//Data members
		public int OwedToPlayer1{ get; set;}
		public int OwedToPlayer2{ get; set;}
		public int OwedToPlayer3{ get; set;}
		public int OwedToPlayer4{ get; set;}
		public int TotalOwed{ get; set;}

		//Methods
		public void ClearAll()
		{
			OwedToPlayer1 = 0;
			OwedToPlayer2 = 0;
			OwedToPlayer3 = 0;
			OwedToPlayer4 = 0;
			TotalOwed = 0;
		}
	}
}

