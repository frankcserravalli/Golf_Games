using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public partial class menu3 : UIViewController
	{
		public GameInfo gameInfo;
		menu4 menu4Screen;
		string[] gameTypes;
		GameMode mode;

		//These strings should probably be placed in another file.
		string strokeInfo = "Stroke play, also known as medal play, " +
			"is a scoring system in the sport of golf. It involves " +
			"counting the total number of strokes taken on each hole " +
			"during a given round, or series of rounds. " +
			"The winner is the player who has taken the fewest number of strokes over the course of the round, or rounds.";

		string wolfInfo ="Wolf is one of the classic golf betting games " +
			"for groups of four, but it gets a little complicated. " +
			"Players rotate as the \"Wolf.\" On each hole, the player designated " +
			"as the Wolf has to choose whether to play 1 against 3, or 2 on 2; and " +
			"if 2 on 2, then the Wolf has to choose a partner. The Wolf can win or lose more money by going it alone.";

		string skinsInfo ="In a skins game, golfers compete on each hole, as a separate contest. " +
			"Played for prize money on the professional level or as a means of a wager for amateurs, a skin, " +
			"or the prize money assigned to each hole, carries over to subsequent holes if the hole is tied.";

		public menu3 () : base ("menu3", null)
		{
			this.Title = "Select Game Type";
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
			gameTypes = new string[] { "Strokes", "Skins", "Wolf" };
			gameTypesTable.Source = new TableSource (gameTypes);

			this.btnInfo1.TouchUpInside += (sender, e) => {
				new UIAlertView ("Strokes", strokeInfo, null, "Close", null).Show ();
			};

			this.btnInfo2.TouchUpInside += (sender, e) => {
				new UIAlertView ("Skins", skinsInfo, null, "Close", null).Show ();
			};

			this.btnInfo3.TouchUpInside += (sender, e) => {
				new UIAlertView ("Wolf", wolfInfo, null, "Close", null).Show ();
			};

			this.btnMenu3Next.TouchUpInside += (sender, e) => {
				if (this.menu4Screen == null) {
					this.menu4Screen = new menu4 ();
				}
					NSIndexPath selectedIndex = this.gameTypesTable.IndexPathForSelectedRow;

					//mode = 
					gameInfo.gameMode = (GameMode)selectedIndex.Row;

					//Set the gameinfo for the next menu
					menu4Screen.gameInfo = gameInfo;
					this.NavigationController.PushViewController (this.menu4Screen, true);
				


				// Perform any additional setup after loading the view, typically from a nib.
			};

			NSIndexPath defaultRow = new NSIndexPath();

			//Row 0 is the first Course on the table
			defaultRow = NSIndexPath.FromRowSection (0, 0);
			gameTypesTable.SelectRow (defaultRow, false, UITableViewScrollPosition.None);
		}
	}
}
