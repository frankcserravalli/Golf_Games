//FIRST TAB Landscape Scorecard View


using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Collections.Generic;

namespace Golf_Games
{
	public partial class landscape : UIViewController
	{
		public GameInfo gameInfo;

		public landscape () : base ("landscape", null)
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

			SetupCollectionViews ();


			// Perform any additional setup after loading the view, typically from a nib.
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

			SetupRow (strHolenumbers1, gridBottom9);
			SetupRow (strHoleHandis, gridHoleHandi);
			SetupRow (strHolePars, gridPar);

			SetupRow (strHolenumbers2, gridUpper9);
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

		private void SetupRowWithHandis(string[] rowValues, string[] handiValues, UICollectionView gridRow)
		{
			const int cellWidth = 25;	//This is the size of each cell
			const int cellHeight = 25;
			int tempRowValueLength = 0;
			int tempHandiValueLengh = 0;

			string[] appendedValues = new string[18];


			//Adjust the label so we can have multiple colors to show other values like handicaps
			var regularAttributes = new UIStringAttributes {
				ForegroundColor = UIColor.Black
			};
			var handiAttributes = new UIStringAttributes {
				ForegroundColor = UIColor.Red
			};



			//string[] holenumbers1 = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
			List<GridCell> cells = new List<GridCell>();

			Rectangle cellFrame = new Rectangle (0, 0, cellWidth, cellHeight);


			for (int i = 0; i < 9; i++) 
			{
				cellFrame.X = (i * cellWidth);
				GridCell cell = new GridCell (cellFrame);

				//Get lengths of the cell value
				tempRowValueLength = rowValues [i].Length;
				tempHandiValueLengh = handiValues [i].Length;
				appendedValues [i] = rowValues [i] + "/" + handiValues [i];

				var attrString = new NSMutableAttributedString (appendedValues[i]);
				attrString.SetAttributes(regularAttributes.Dictionary, new NSRange (0, tempRowValueLength));	// This should be long enough to account for the slash
				attrString.SetAttributes(handiAttributes.Dictionary, new NSRange(tempRowValueLength + 1,tempHandiValueLengh ));


				//If the the handicap value and the actual stroke value are the same or if the handicap value is 0
				if (rowValues [i] == handiValues [i] || handiValues[i] == "0")
					cell.label.Text = rowValues [i];	//Only use the value of the stroke and hide the handicap value
				else
					cell.label.AttributedText = attrString;	//Use both stroke and handicap value

				//Insert cell into the list
				cells.Add (cell);
			}

			//Add the cells to the grid
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

		//All this function does is turn the values in from an int over to string values. It is also used to split up 18 hole scoring into 9.
		private void SetupGridPlayer(string[] strGrid, int startIndex, int[] playerStrokeCount)
		{
			const int maxIndex = 9;

			for (int i = 0, j = startIndex; i < maxIndex; i++,j++) 
			{
			

				strGrid [i] = playerStrokeCount[j].ToString ();
			}

		}

		private void SetupPlayerGrids()
		{
			string[] strScoreP1 = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strScoreP1Upper = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strScoreP2 = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strScoreP2Upper = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strScoreP3 = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strScoreP3Upper = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strScoreP4 = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strScoreP4Upper = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries

			string[] strHandiScoreP1 = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strHandiScoreP2 = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strHandiScoreP3 = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strHandiScoreP4 = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strHandiScoreP1Upper = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strHandiScoreP2Upper = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strHandiScoreP3Upper = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries
			string[] strHandiScoreP4Upper = new string[] {"0","0","0","0","0","0","0","0","0" }; //9 entries

			//This will go through all players and determine what the handicap value is for that stroke
			SetupHandicapScores ();

			//Setup the regular stroke scores
			SetupGridPlayer (strScoreP1, 0, gameInfo.scores.strokeCountP1);
			SetupGridPlayer (strScoreP1Upper, 9, gameInfo.scores.strokeCountP1);
			SetupGridPlayer (strScoreP2, 0, gameInfo.scores.strokeCountP2);
			SetupGridPlayer (strScoreP2Upper, 9, gameInfo.scores.strokeCountP2);
			SetupGridPlayer (strScoreP3, 0, gameInfo.scores.strokeCountP3);
			SetupGridPlayer (strScoreP3Upper, 9, gameInfo.scores.strokeCountP3);
			SetupGridPlayer (strScoreP4, 0, gameInfo.scores.strokeCountP4);
			SetupGridPlayer (strScoreP4Upper, 9, gameInfo.scores.strokeCountP4);

			//Setup the handicap stroke scores
			SetupGridPlayer (strHandiScoreP1, 0, gameInfo.scores.handiStrokeCountP1);
			SetupGridPlayer (strHandiScoreP2, 0, gameInfo.scores.handiStrokeCountP2);
			SetupGridPlayer (strHandiScoreP3, 0, gameInfo.scores.handiStrokeCountP3);
			SetupGridPlayer (strHandiScoreP4, 0, gameInfo.scores.handiStrokeCountP4);
			SetupGridPlayer (strHandiScoreP1Upper, 9, gameInfo.scores.handiStrokeCountP1);
			SetupGridPlayer (strHandiScoreP2Upper, 9, gameInfo.scores.handiStrokeCountP2);
			SetupGridPlayer (strHandiScoreP3Upper, 9, gameInfo.scores.handiStrokeCountP3);
			SetupGridPlayer (strHandiScoreP4Upper, 9, gameInfo.scores.handiStrokeCountP4);




			//This is the old way without players handicaps in red
//			SetupRow (strScoreP1, gridPlayer1);
//			SetupRow (strScoreP2, gridPlayer2);
//			SetupRow (strScoreP3, gridPlayer3);
//			SetupRow (strScoreP4, gridPlayer4);
//			SetupRow (strScoreP1Upper, gridPlayer1Upper);
//			SetupRow (strScoreP2Upper, gridPlayer2Upper);
//			SetupRow (strScoreP3Upper, gridPlayer3Upper);
//			SetupRow (strScoreP4Upper, gridPlayer4Upper);

			//This is the new way with players handicaps in red.
			SetupRowWithHandis (strScoreP1, strHandiScoreP1, gridPlayer1);
			SetupRowWithHandis (strScoreP2, strHandiScoreP2, gridPlayer2);
			SetupRowWithHandis (strScoreP3, strHandiScoreP3, gridPlayer3);
			SetupRowWithHandis (strScoreP4, strHandiScoreP4, gridPlayer4);

			SetupRowWithHandis (strScoreP1Upper, strHandiScoreP1Upper, gridPlayer1Upper);
			SetupRowWithHandis (strScoreP2Upper, strHandiScoreP2Upper, gridPlayer2Upper);
			SetupRowWithHandis (strScoreP3Upper, strHandiScoreP3Upper, gridPlayer3Upper);
			SetupRowWithHandis (strScoreP4Upper, strHandiScoreP4Upper, gridPlayer4Upper);
		}

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
				p1Out += gameInfo.scores.strokeCountP1 [i];
				p2Out += gameInfo.scores.strokeCountP2 [i];
				p3Out += gameInfo.scores.strokeCountP3 [i];
				p4Out += gameInfo.scores.strokeCountP4 [i];
				p1In += gameInfo.scores.strokeCountP1 [j];
				p2In += gameInfo.scores.strokeCountP2 [j];
				p3In += gameInfo.scores.strokeCountP3 [j];
				p4In += gameInfo.scores.strokeCountP4 [j];
			}

			labelParOut.Text = parOut.ToString ();
			labelParIn.Text = parIn.ToString ();
			labelP1In.Text = p1In.ToString ();
			labelP2In.Text = p2In.ToString ();
			labelP3In.Text = p3In.ToString ();
			labelP4In.Text = p4In.ToString ();
			labelP1Out.Text = p1Out.ToString ();
			labelP2Out.Text = p2Out.ToString ();
			labelP3Out.Text = p3Out.ToString ();
			labelP4Out.Text = p4Out.ToString ();

			labelParTotal.Text =  (parIn + parOut).ToString();
			labelP1Total.Text = (p1In + p1Out).ToString ();
			labelP2Total.Text = (p2In + p2Out).ToString ();
			labelP3Total.Text = (p3In + p3Out).ToString ();
			labelP4Total.Text = (p4In + p4Out).ToString ();


	
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
		//TODO: (Refactor) This function and DeterminePlayerHandiScore should probably be moved to the Scores class.
		public void SetupHandicapScores()
		{
			DeterminePlayerHandiScore (gameInfo.scores.strokeCountP1, gameInfo.scores.handiStrokeCountP1, System.Convert.ToInt32(gameInfo.player1Handi.Text));
			DeterminePlayerHandiScore (gameInfo.scores.strokeCountP2, gameInfo.scores.handiStrokeCountP2, System.Convert.ToInt32(gameInfo.player2Handi.Text));
			DeterminePlayerHandiScore (gameInfo.scores.strokeCountP3, gameInfo.scores.handiStrokeCountP3, System.Convert.ToInt32(gameInfo.player3Handi.Text));
			DeterminePlayerHandiScore (gameInfo.scores.strokeCountP4, gameInfo.scores.handiStrokeCountP4, System.Convert.ToInt32(gameInfo.player4Handi.Text));
		
		}
		public void DeterminePlayerHandiScore(int[] score, int[]handiScore, int playerHandi)
		{
			for(int i = 0; i < score.Length; i++)	//Score length should be 18
			{
				//Check to make sure there is some score in
				if (score [i] > 0) 
				{
					//If the player handicap is greater or equal than the hole handicap
					if (playerHandi >= gameInfo.courseInfo.holes [i].hole_handicap)
					{
						//TODO: This line may not be this simple. More consideration is neccessary
						handiScore [i] = score [i] - 1;
					}
				}
			}
		}

		public void SplitStrs(string[] wholeString, string[] lowerHalf, string[] upperHalf)
		{
			for (int i = 0; i < (wholeString.Length / 2); i++) 
			{
				lowerHalf [i] = wholeString [i];
			}

			for (int i = (wholeString.Length / 2); i < wholeString.Length; i++) 
			{
				upperHalf [i] = wholeString [i];
			}
		}

	}
}

