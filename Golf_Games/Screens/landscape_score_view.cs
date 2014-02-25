//SECOND TAB Landscape Bets View


using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Collections.Generic;


namespace Golf_Games
{
	public partial class landscape_score_view : UIViewController
	{
		public GameInfo gameInfo;

		public landscape_score_view () : base ("landscape_score_view", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			string p1NameAndHandi = gameInfo.player1.Text + " (" + gameInfo.player1Handi.Text + ")";
			string p2NameAndHandi = gameInfo.player2.Text + " (" + gameInfo.player2Handi.Text + ")";
			string p3NameAndHandi = gameInfo.player3.Text + " (" + gameInfo.player3Handi.Text + ")";
			string p4NameAndHandi = gameInfo.player4.Text + " (" + gameInfo.player4Handi.Text + ")";
			labelPlayer1.Text = p1NameAndHandi;
			labelPlayer2.Text = p2NameAndHandi;
			labelPlayer3.Text = p3NameAndHandi;
			labelPlayer4.Text = p4NameAndHandi;

			HideRows ();

			SetupCollectionViews ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public void HideRows()
		{
			switch (gameInfo.numPlayers) 
			{
				case 1:
				//Hide players 2 through 4 infos
				labelPlayer2.Hidden = true;
				labelPlayer3.Hidden = true;
				labelPlayer4.Hidden = true;
				labelP2In.Hidden = true;
				labelP3In.Hidden = true;
				labelP4In.Hidden = true;
				labelP2Out.Hidden = true;
				labelP3Out.Hidden = true;
				labelP4Out.Hidden = true;
				labelP2Total.Hidden = true;
				labelP3Total.Hidden = true;
				labelP4Total.Hidden = true;
				gridPlayer2Lower.Hidden = true;
				gridPlayer3Lower.Hidden = true;
				gridPlayer4Lower.Hidden = true;
				gridPlayer2Upper.Hidden = true;
				gridPlayer3Upper.Hidden = true;
				gridPlayer4Upper.Hidden = true;


				break;

				case 2:
				//hide players 3 and 4 infos.
				labelPlayer3.Hidden = true;
				labelPlayer4.Hidden = true;
				labelP3In.Hidden = true;
				labelP4In.Hidden = true;
				labelP3Out.Hidden = true;
				labelP4Out.Hidden = true;
				labelP3Total.Hidden = true;
				labelP4Total.Hidden = true;
				gridPlayer3Lower.Hidden = true;
				gridPlayer4Lower.Hidden = true;
				gridPlayer3Upper.Hidden = true;
				gridPlayer4Upper.Hidden = true;
				break;

				case 3:
				//hide player 4 info
				labelPlayer4.Hidden = true;
				labelP4In.Hidden = true;
				labelP4Out.Hidden = true;
				labelP4Total.Hidden = true;
				gridPlayer4Lower.Hidden = true;
				gridPlayer4Upper.Hidden = true;
				break;

				case 4:
				//Hide nothing
				break;

				default:
				break;
			}
		}

		public override void WillRotate(UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			base.WillRotate (toInterfaceOrientation, duration);


			this.NavigationController.PopViewControllerAnimated (true);

		}

		//The main function used to setup and display all the information on the landscape view
		private void SetupCollectionViews()
		{
			//Sample data for some arrays
			string[] strHolenumbers1 = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // 9 holes lower 
			string[] strHolenumbers2 = new string[] { "10", "11", "12", "13", "14", "15", "16", "17", "18" }; // 9 holes upper
			string[] strHoleHandis = new string[] { "99", "99", "99", "99", "99", "99", "99", "99", "99" }; // 9 slots
			string[] strHoleHandis2 = new string[] { "99", "99", "99", "99", "99", "99", "99", "99", "99" }; // 9 slots
			string[] strHolePars = new string[] {"4","4","4","4","4","4","4","4","4"}; // 9 entries
			string[] strHolePars2 = new string[] {"4","4","4","4","4","4","4","4","4"}; // 9 entries


			//This method properly sets up the strings for pars holes 1 through 18.
			SetupParStrings (strHolePars, strHolePars2);
			SetupHoleHandiStrings (strHoleHandis, strHoleHandis2);

			SetupPlayerGrids ();

			SetupInOutLabels ();

			SetupRow (strHolenumbers1, gridHoleBottom9);
			SetupRow (strHoleHandis, gridHoleHandi1);
			SetupRow (strHolePars, gridPar1);

			SetupRow (strHolenumbers2, gridHoleUpper9);
			SetupRow (strHoleHandis2, gridHoleHandi2);
			SetupRow (strHolePars2, gridPar2);

			//SetupBottom9 ();
			//SetupHoleHandi ();
		}

		private void SetupRow(string[] rowValues, UICollectionView gridRow)
		{
			const int cellWidth = 25;	//This is the size of each cell
			const int cellHeight = 25;


			//string[] holenumbers1 = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
			List<GridCell> cells = new List<GridCell>();

			Rectangle cellFrame = new Rectangle (0, 0, cellWidth, cellHeight);

			for (int i = 0; i < 9; i++) 
			{
				cellFrame.X = (i * cellWidth);
				GridCell cell = new GridCell (cellFrame);
				cell.Label.Text = rowValues[i];

				//Insert cell into the list
				cells.Add (cell);
			}

			for (int i = 0; i < 9; i++)
				gridRow.Add (cells [i]);
		}

		private void SetupParStrings(string[] strHolePars, string[] strHolePars2)
		{
			for (int i = 0, j = 0; i < gameInfo.courseInfo.holes.Length; i++) 
			{
				if (i < 9) // 8 is max for first set, 17 will be for second set
					strHolePars [i] = gameInfo.courseInfo.holes [i].par.ToString ();
				else 
				{
					strHolePars2 [j] = gameInfo.courseInfo.holes [i].par.ToString ();
					j++;
				}
			}
		}
		private void SetupHoleHandiStrings(string[] strHandis1, string[] strHandis2)
		{
			for (int i = 0, j = 0; i < gameInfo.courseInfo.holes.Length; i++) 
			{
				if (i < 9) // 8 is max for first set, 17 will be for second set
					strHandis1 [i] = gameInfo.courseInfo.holes [i].hole_handicap.ToString ();
				else 
				{
					strHandis2 [j] = gameInfo.courseInfo.holes [i].hole_handicap.ToString ();
					j++;
				}
			}
		}

		private void SetupGridPlayer(string[] strGrid, int startIndex, int[] playerStrokeCount)
		{
			const int maxIndex = 9;

			for (int i = 0, j = startIndex; i < maxIndex; i++,j++) 
			{
				strGrid [i] = playerStrokeCount[j].ToString ("+#;-#;0");
			}

		}

		private void SetupPlayerGrids()
		{
			int[] totalWinningsP1 = new int[18];
			int[] totalWinningsP2 = new int[18];
			int[] totalWinningsP3 = new int[18];
			int[] totalWinningsP4 = new int[18];

			string[] strScoreP1 = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strScoreP1Upper = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strScoreP2 = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strScoreP2Upper = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strScoreP3 = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strScoreP3Upper = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strScoreP4 = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strScoreP4Upper = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries

			//Here is where the betting scores for each hole needs to be calculated
			UpdateBetScores ();

			ConvertWinningsToIntArray (gameInfo.scores.betScoreP1, totalWinningsP1);
			ConvertWinningsToIntArray (gameInfo.scores.betScoreP2, totalWinningsP2);
			ConvertWinningsToIntArray (gameInfo.scores.betScoreP3, totalWinningsP3);
			ConvertWinningsToIntArray (gameInfo.scores.betScoreP4, totalWinningsP4);

			SetupGridPlayer (strScoreP1, 0, totalWinningsP1);
			SetupGridPlayer (strScoreP1Upper, 9, totalWinningsP1);
			SetupGridPlayer (strScoreP2, 0, totalWinningsP2);
			SetupGridPlayer (strScoreP2Upper, 9, totalWinningsP2);
			SetupGridPlayer (strScoreP3, 0, totalWinningsP3);
			SetupGridPlayer (strScoreP3Upper, 9, totalWinningsP3);
			SetupGridPlayer (strScoreP4, 0, totalWinningsP4);
			SetupGridPlayer (strScoreP4Upper, 9, totalWinningsP4);


			SetupRow (strScoreP1, gridPlayer1Lower);
			SetupRow (strScoreP2, gridPlayer2Lower);
			SetupRow (strScoreP3, gridPlayer3Lower);
			SetupRow (strScoreP4, gridPlayer4Lower);
			SetupRow (strScoreP1Upper, gridPlayer1Upper);
			SetupRow (strScoreP2Upper, gridPlayer2Upper);
			SetupRow (strScoreP3Upper, gridPlayer3Upper);
			SetupRow (strScoreP4Upper, gridPlayer4Upper);
		}

		private void ConvertWinningsToIntArray(PlayerHoleSideBetInfo[] player, int[] totalWinnings)
		{
			for (int i = 0; i < player.Length; i++) 
			{
				totalWinnings [i] = player [i].TotalWinnings;
			}
		}

		//This function sets up the totals for the in and out labels for the bottom and upper 9 holes
		private void SetupInOutLabels()
		{
			const int maxIndex = 9;
			int parOut = 0;
			int parIn = 0;
			int p1Out = 0;
			int p2Out = 0;
			int p3Out = 0;
			int p4Out = 0;
			int p1In = 0;
			int p2In = 0;
			int p3In = 0;
			int p4In = 0;
			//int total = 0;

			for (int i = 0, j = maxIndex; i < maxIndex; i++, j++) 
			{
				parOut += gameInfo.courseInfo.holes [i].par;
				parIn += gameInfo.courseInfo.holes [j].par;
				p1Out += gameInfo.scores.betScoreP1 [i].TotalWinnings;
				p2Out += gameInfo.scores.betScoreP2 [i].TotalWinnings;
				p3Out += gameInfo.scores.betScoreP3 [i].TotalWinnings;
				p4Out += gameInfo.scores.betScoreP4 [i].TotalWinnings;
				p1In += gameInfo.scores.betScoreP1 [j].TotalWinnings;
				p2In += gameInfo.scores.betScoreP2 [j].TotalWinnings;
				p3In += gameInfo.scores.betScoreP3 [j].TotalWinnings;
				p4In += gameInfo.scores.betScoreP4 [j].TotalWinnings;
			}

			labelParOut.Text = parOut.ToString ();
			labelParIn.Text = parIn.ToString ();
			labelP1In.Text = p1In.ToString ("+#;-#;0");
			labelP2In.Text = p2In.ToString ("+#;-#;0");
			labelP3In.Text = p3In.ToString ("+#;-#;0");
			labelP4In.Text = p4In.ToString ("+#;-#;0");
			labelP1Out.Text = p1Out.ToString ("+#;-#;0");
			labelP2Out.Text = p2Out.ToString ("+#;-#;0");
			labelP3Out.Text = p3Out.ToString ("+#;-#;0");
			labelP4Out.Text = p4Out.ToString ("+#;-#;0");

			labelParTotal.Text =  (parIn + parOut).ToString();
			labelP1Total.Text = (p1In + p1Out).ToString ("+#;-#;0");
			labelP2Total.Text = (p2In + p2Out).ToString ("+#;-#;0");
			labelP3Total.Text = (p3In + p3Out).ToString ("+#;-#;0");
			labelP4Total.Text = (p4In + p4Out).ToString ("+#;-#;0");

			//Set all labels to resize if they dont fit.
//			labelP1In.AdjustsFontSizeToFitWidth = true;
//			labelP1Out.AdjustsFontSizeToFitWidth = true;
//			labelP2In.AdjustsFontSizeToFitWidth = true;
//			labelP2Out.AdjustsFontSizeToFitWidth = true;
//			labelP3In.AdjustsFontSizeToFitWidth = true;
//			labelP3Out.AdjustsFontSizeToFitWidth = true;
//			labelP4In.AdjustsFontSizeToFitWidth = true;
//			labelP4Out.AdjustsFontSizeToFitWidth = true;
		}


		public override void ViewDidLayoutSubviews ()
		{
			base.ViewDidLayoutSubviews ();
			this.scrollView.LayoutIfNeeded ();

			SizeF size = viewUpper9.Bounds.Size;
			size.Width = viewUpper9.Bounds.Size.Width + viewBottom9.Bounds.Size.Width;
			this.scrollView.ContentSize = size;

			//PointF point = new PointF (this.scrollView.ContentSize.Width - this.scrollView.Frame.Size.Width, 0);
			//scrollView.SetContentOffset (point, true);


		}

		public void UpdateBetScores()
		{
			const int maxHoles = 18;
			//TODO: Perhaps max holes needs to be set in the gameinfo object

			gameInfo.scores.BetBirdie = gameInfo.BetBirdie;
			gameInfo.scores.BetCTP = gameInfo.BetCTP;
			gameInfo.scores.BetGreenie = gameInfo.BetGreenie;
			gameInfo.scores.BetHOFF = gameInfo.BetHOFF;
			gameInfo.scores.BetEagle = gameInfo.BetEagle;
			gameInfo.scores.BetSandyPar = gameInfo.BetSandyPar;

			for (int holeIndex = 0; holeIndex < maxHoles; holeIndex++)
				gameInfo.scores.CalculateWinnings (holeIndex);
		}
	}
}

