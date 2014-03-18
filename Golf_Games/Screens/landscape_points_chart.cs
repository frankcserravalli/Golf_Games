//THIRD TAB Landscape Points Chart View


using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public partial class landscape_points_chart : UIViewController
	{
		public GameInfo gameInfo;

		public landscape_points_chart () : base ("landscape_points_chart", null)
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

			//Add a border to each points chart box. This is similar to the boarder in Portrait mode.
			viewPointsBox1.Layer.BorderColor = UIColor.DarkGray.CGColor;
			viewPointsBox1.Layer.BorderWidth = 3.0f;
			viewPointsBox2.Layer.BorderColor = UIColor.DarkGray.CGColor;
			viewPointsBox2.Layer.BorderWidth = 3.0f;
			viewPointsBox3.Layer.BorderColor = UIColor.DarkGray.CGColor;
			viewPointsBox3.Layer.BorderWidth = 3.0f;
			viewPointsBox4.Layer.BorderColor = UIColor.DarkGray.CGColor;
			viewPointsBox4.Layer.BorderWidth = 3.0f;

			//Hide the boxes if theres less than 4 players
			switch (gameInfo.numPlayers) 
			{
			case 1:
				//Hide boxes 2 through 4
				viewPointsBox2.Hidden = true;
				viewPointsBox3.Hidden = true;
				viewPointsBox4.Hidden = true;
				break;

			case 2:
				//Hide boxes 3 and 4
				viewPointsBox3.Hidden = true;
				viewPointsBox4.Hidden = true;
				break;

			case 3:
				//Hide the 4th box
				viewPointsBox4.Hidden = true;
				break;

			case 4:
				//Hide nothing
				break;

			default:
				break;
			}

			//Set the names of the labels to the player name in gameinfo
			foreach (UILabel element in labelPlayer1) 
			{
				element.Text = gameInfo.player1.Text;
			}
			foreach (UILabel element in labelPlayer2) 
			{
				element.Text = gameInfo.player2.Text;
			}
			foreach (UILabel element in labelPlayer3) 
			{
				element.Text = gameInfo.player3.Text;
			}
			foreach (UILabel element in labelPlayer4) 
			{
				element.Text = gameInfo.player4.Text;
			}



			//Check on the scores of bets and calculate winnings
			UpdateBetScores ();

			//Set the labels of the number values
			labelP1toP2.Text = gameInfo.scores.player1PointsOwed.OwedToPlayer2.ToString();
			labelP1toP3.Text = gameInfo.scores.player1PointsOwed.OwedToPlayer3.ToString();
			labelP1toP4.Text = gameInfo.scores.player1PointsOwed.OwedToPlayer4.ToString();
			labelP1Total.Text = gameInfo.scores.player1PointsOwed.TotalOwed.ToString();

			labelP2toP1.Text = gameInfo.scores.player2PointsOwed.OwedToPlayer1.ToString();
			labelP2toP3.Text = gameInfo.scores.player2PointsOwed.OwedToPlayer3.ToString();
			labelP2toP4.Text = gameInfo.scores.player2PointsOwed.OwedToPlayer4.ToString();
			labelP2Total.Text = gameInfo.scores.player2PointsOwed.TotalOwed.ToString();

			labelP3toP1.Text = gameInfo.scores.player3PointsOwed.OwedToPlayer1.ToString();
			labelP3toP2.Text = gameInfo.scores.player3PointsOwed.OwedToPlayer2.ToString();
			labelP3toP4.Text = gameInfo.scores.player3PointsOwed.OwedToPlayer4.ToString();
			labelP3Total.Text = gameInfo.scores.player3PointsOwed.TotalOwed.ToString();

			labelP4toP1.Text = gameInfo.scores.player4PointsOwed.OwedToPlayer1.ToString();
			labelP4toP2.Text = gameInfo.scores.player4PointsOwed.OwedToPlayer2.ToString();
			labelP4toP3.Text = gameInfo.scores.player4PointsOwed.OwedToPlayer3.ToString();
			labelP4Total.Text = gameInfo.scores.player4PointsOwed.TotalOwed.ToString();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		//This same function exists in landscape bets view. This could possibly be combined into the scores class
		private void UpdateBetScores()
		{

			const int maxHoles = 18;
			//TODO: Perhaps max holes needs to be set in the gameinfo object

			gameInfo.scores.BetBirdie = gameInfo.BetBirdie;
			gameInfo.scores.BetCTP = gameInfo.BetCTP;
			gameInfo.scores.BetGreenie = gameInfo.BetGreenie;
			gameInfo.scores.BetHOFF = gameInfo.BetHOFF;
			gameInfo.scores.BetEagle = gameInfo.BetEagle;
			gameInfo.scores.BetSandyPar = gameInfo.BetSandyPar;

			//This loop calls an important function that calculates the bets and winnings
			for (int holeIndex = 0; holeIndex < maxHoles; holeIndex++)
				gameInfo.scores.CalculateWinnings (holeIndex);

			//Clear the PointsOwed objects before recalculating them
			gameInfo.scores.player1PointsOwed.ClearAll ();
			gameInfo.scores.player2PointsOwed.ClearAll ();
			gameInfo.scores.player3PointsOwed.ClearAll ();
			gameInfo.scores.player4PointsOwed.ClearAll ();

			//Check on total points owed.
			gameInfo.scores.CalculateTotalPointsOwed ();
		}

		public override void WillRotate(UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			base.WillRotate (toInterfaceOrientation, duration);


			this.NavigationController.PopViewControllerAnimated (true);

		}


	}
}

