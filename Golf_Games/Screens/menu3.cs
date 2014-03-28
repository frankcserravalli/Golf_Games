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
		MenuNassau menuNassau;
		MenuSkins menuSkins;
		MenuWolf menuWolf;

		string[] gameTypes;
		//GameMode mode;

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

		string nassauInfo = "The Nassau is a type of bet in golf that is essentially three separate bets. " +
			"Money is wagered on the best match play score in the front nine (holes 1–9), back nine (holes 10–18)," +
			"and total 18 holes. The Nassau is one of golf's most classic and most popular wagers.";

		string matchPlay = "Match play is a scoring system for golf in which a player, or team, earns a point for each hole" +
			"in which they have bested their opponents; this is as opposed to stroke play, in which the total number of strokes" +
			"is counted over one or more rounds of 18 holes. In professional golf, a small number of notable tournaments use the" +
			"match play scoring system.";

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
			gameTypes = new string[] { "Strokes", "Skins", "Wolf", "Nassau", "Match Play" };
			gameTypesTable.Source = new TableSource (gameTypes);

			this.btnInfo1.TouchUpInside += (sender, e) => {
				new UIAlertView ("Stroke (Medal)", strokeInfo, null, "Close", null).Show ();
			};

			this.btnInfo2.TouchUpInside += (sender, e) => {
				new UIAlertView ("Skins", skinsInfo, null, "Close", null).Show ();
			};

			this.btnInfo3.TouchUpInside += (sender, e) => {
				new UIAlertView ("Wolf", wolfInfo, null, "Close", null).Show ();
			};

			this.btnInfo4.TouchUpInside += (sender, e) => {
				new UIAlertView ("Nassau", nassauInfo, null, "Close", null).Show();
			};

			this.btnInfo5.TouchUpInside += (sender, e) => {
				new UIAlertView ("Match Play", matchPlay, null, "Close", null).Show();
			};


			this.btnMenu3Next.TouchUpInside += (sender, e) => {

				NSIndexPath selectedIndex = this.gameTypesTable.IndexPathForSelectedRow;

				//mode = 
				gameInfo.gameMode = (GameMode)selectedIndex.Row;

				//Set the gameinfo for the next menu
				//menu4Screen.gameInfo = gameInfo;

				//Determine which selection was chosen, and switch to the appropiate screen
				switch(selectedIndex.Row)
				{
				case 0:
					if (this.menu4Screen == null) {
						this.menu4Screen = new menu4 ();
					}
					menu4Screen.gameInfo = gameInfo;
					this.NavigationController.PushViewController (this.menu4Screen, true);
					break;

				case 1:
					if (this.menuSkins == null) {
						this.menuSkins = new MenuSkins ();
					}
					menuSkins.gameInfo = gameInfo;
					this.NavigationController.PushViewController (this.menuSkins, true);
					break;

				case 2:
					if (this.menuWolf == null) {
						this.menuWolf = new MenuWolf ();
					}
					menuWolf.gameInfo = gameInfo;
					this.NavigationController.PushViewController (this.menuWolf, true);
					break;

				case 3:
					if (this.menuNassau == null) {
						this.menuNassau = new MenuNassau ();
					}
					menuNassau.gameInfo = gameInfo;
					this.NavigationController.PushViewController (this.menuNassau, true);
					break;

				default:
					if (this.menu4Screen == null) {
						this.menu4Screen = new menu4 ();
					}
					menu4Screen.gameInfo = gameInfo;
					this.NavigationController.PushViewController (this.menu4Screen, true);
					break;
				}


				


				// Perform any additional setup after loading the view, typically from a nib.
			};

			NSIndexPath defaultRow = new NSIndexPath();

			//Row 0 is the first Course on the table
			defaultRow = NSIndexPath.FromRowSection (0, 0);
			gameTypesTable.SelectRow (defaultRow, false, UITableViewScrollPosition.None);
		}
	}
}
