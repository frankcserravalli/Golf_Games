
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
			int displayScore = 0;
			int currentPar = 0;

			for (int i = 0, j = startIndex; i < maxIndex; i++,j++) 
			{
				if (playerStrokeCount [j] > 0) {
					currentPar = gameInfo.courseInfo.holes [j].par;
					displayScore = currentPar - playerStrokeCount [j];
					displayScore = displayScore * -1;
				} else
					displayScore = 0;

				strGrid [i] = displayScore.ToString ("+#;-#;0");
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


			SetupGridPlayer (strScoreP1, 0, gameInfo.scores.strokeCountP1);
			SetupGridPlayer (strScoreP1Upper, 9, gameInfo.scores.strokeCountP1);
			SetupGridPlayer (strScoreP2, 0, gameInfo.scores.strokeCountP2);
			SetupGridPlayer (strScoreP2Upper, 9, gameInfo.scores.strokeCountP2);
			SetupGridPlayer (strScoreP3, 0, gameInfo.scores.strokeCountP3);
			SetupGridPlayer (strScoreP3Upper, 9, gameInfo.scores.strokeCountP3);
			SetupGridPlayer (strScoreP4, 0, gameInfo.scores.strokeCountP4);
			SetupGridPlayer (strScoreP4Upper, 9, gameInfo.scores.strokeCountP4);


			SetupRow (strScoreP1, gridPlayer1);
			SetupRow (strScoreP2, gridPlayer2);
			SetupRow (strScoreP3, gridPlayer3);
			SetupRow (strScoreP4, gridPlayer4);
			SetupRow (strScoreP1Upper, gridPlayer1Upper);
			SetupRow (strScoreP2Upper, gridPlayer2Upper);
			SetupRow (strScoreP3Upper, gridPlayer3Upper);
			SetupRow (strScoreP4Upper, gridPlayer4Upper);
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

	}
}

