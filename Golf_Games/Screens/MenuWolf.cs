using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public partial class MenuWolf : UIViewController
	{
		public GameInfo gameInfo;
		menu4 menu4Screen;

		public MenuWolf () : base ("MenuWolf", null)
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

			NSIndexPath defaultRow = new NSIndexPath();
			//Row 0 is player 1
			defaultRow = NSIndexPath.FromRowSection (0, 0);

			string[] players;

			switch (gameInfo.numPlayers) 
			{
			case 1:
				players = new string[] { gameInfo.player1.Text };
				break;

			case 2:
				players = new string[] { gameInfo.player1.Text, gameInfo.player2.Text};
				break;

			case 3:
				players = new string[] { gameInfo.player1.Text, gameInfo.player2.Text, gameInfo.player3.Text};
				break;

			case 4:
				players = new string[] { gameInfo.player1.Text, gameInfo.player2.Text, gameInfo.player3.Text, gameInfo.player4.Text };
				break;

			default:
				break;

			}


			//Populate the table with the players
			tablePlayers.Source = new TableSource (players);

			//Select the first player by default
			tablePlayers.SelectRow (defaultRow, false, UITableViewScrollPosition.None);

			//Button Next hit
			this.btnNext.TouchUpInside += (sender, e) => 
			{
				if (this.menu4Screen == null) {
					this.menu4Screen = new menu4 ();
				}
				//Grab the selected player before moving on.
				gameInfo.scores.wolfGame.CurrentWolf = tablePlayers.IndexPathForSelectedRow.Row;
				menu4Screen.gameInfo = gameInfo;
				this.NavigationController.PushViewController (this.menu4Screen, true);

			};

			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

