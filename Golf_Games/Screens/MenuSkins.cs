using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public partial class MenuSkins : UIViewController
	{
		public GameInfo gameInfo;
		menu4 menu4Screen;
		UITableView table = new UITableView();

		public MenuSkins () : base ("MenuSkins", null)
		{
			this.Title = "Skin Options";
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

			string standardStr = "Standard";
			string progressiveStr = "Progressive";
			string progressiveHCPStr = "Progressive HCP";
			string custromStr = "Custom";
			int totalSkins = 0;
			int skinValues = 0;
			//This is our array of skin modes
			string[] tableItems;

			gameInfo.scores.skinsGame.NumHoles = gameInfo.NumHoles;

			//Row 0 is player 1
			defaultRow = NSIndexPath.FromRowSection (0, 0);

			tableItems = new string[] { standardStr, progressiveStr, progressiveHCPStr, custromStr };

			table.Source = new TableSource (tableItems);
			tableSkinModes.Source = new TableSource (tableItems);


			this.btnNext.TouchUpInside += (sender, e) => {
				if (this.menu4Screen == null) {
					this.menu4Screen = new menu4 ();
				}
				totalSkins = System.Convert.ToInt32 (txtTotalSkins.Text);
				skinValues = System.Convert.ToInt32 (txtSkinValue.Text);

				switch (tableSkinModes.IndexPathForSelectedRow.Row) {
				case 0:
					gameInfo.scores.skinsGame.SetupStandard (skinValues);
					break;

				case 1:
					gameInfo.scores.skinsGame.SetupProgressive (skinValues, totalSkins);
					break;

				case 2:
					gameInfo.scores.skinsGame.SetupProgressiveHCP (skinValues, totalSkins, gameInfo.courseInfo.holes);
					break;

				case 3:
					//Custom is not yet implemented
					break;

				default:
					break;

				}


				menu4Screen.gameInfo = gameInfo;
				this.NavigationController.PushViewController (this.menu4Screen, true);
			};


			//Row 0 is the first Course on the table
			defaultRow = NSIndexPath.FromRowSection (0, 0);
			tableSkinModes.SelectRow (defaultRow, false, UITableViewScrollPosition.None);

			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

