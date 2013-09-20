using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public partial class portrait : UIViewController
	{
		//string[] oddNums;
		//string[] evenNums;

		landscape l_scorecard = new landscape();
		landscape_points_chart l_pts_chart = new landscape_points_chart();
		landscape_score_view l_score_view = new landscape_score_view();
		UITableView table = new UITableView();


		public GameInfo gameInfo;
		public UITabBarController tabController;

		public portrait () : base ("portrait", null)
		{
			//This code is for setting up a tab for landscape mode.
			tabController = new UITabBarController();


			tabController.ViewControllers = new UIViewController[] 
			{
				l_scorecard, l_score_view, l_pts_chart
			};

			tabController.ViewControllers [0].Title = "Scorecard";
			tabController.ViewControllers [1].Title = "Bets";
			tabController.ViewControllers [2].Title = "Points Chart";


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

			//Populate the table
			string[] tableItems = new string[] { gameInfo.player1.Text, gameInfo.player2.Text, gameInfo.player3.Text, gameInfo.player4.Text };
			table.Source = new TableSource (tableItems);
			tablePlayers.Source = new TableSource (tableItems);


			//Hide the nav bar
			NavigationController.SetNavigationBarHidden (true, false);


			//Add a border to the playerInfo and holeInfo view
			viewPlayerInfo.Layer.BorderColor = UIColor.DarkGray.CGColor;
			viewPlayerInfo.Layer.BorderWidth = 3.0f;

			//viewHoleInfo.Layer.BorderColor = UIColor.DarkGray.CGColor;
			//viewHoleInfo.Layer.BorderWidth = 3.0f;
		


			// Perform any additional setup after loading the view, typically from a nib.
		}

		//We need a way to move to Landscape view when the screen is rotated
		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
		{
			return UIInterfaceOrientationMask.AllButUpsideDown;

		}

		public override void WillRotate(UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			base.WillRotate (toInterfaceOrientation, duration);

			if (this.tabController == null) {
				this.tabController = new UITabBarController ();
			}

			//this.NavigationController.PushViewController (this.landscape_screen, true);
			this.NavigationController.PushViewController (this.tabController, true);
			//this.PresentViewController (tabController, true, null);


		}


	}
}

