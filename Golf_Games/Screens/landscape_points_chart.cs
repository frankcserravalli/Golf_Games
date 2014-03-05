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

			//Set the labels of the number values



			//Check on the scores of bets and calculate winnings

			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void WillRotate(UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			base.WillRotate (toInterfaceOrientation, duration);


			this.NavigationController.PopViewControllerAnimated (true);

		}


	}
}

