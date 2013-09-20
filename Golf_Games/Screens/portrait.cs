using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public partial class portrait : UIViewController
	{
		string[] oddNums;
		string[] evenNums;

		landscape l_scorecard = new landscape();
		landscape_points_chart l_pts_chart = new landscape_points_chart();
		landscape_score_view l_score_view = new landscape_score_view();

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
			//oddNums = new string[] { "1", "3", "5", "7", "9", "11" };
			//evenNums = new string[] {"2", "4", "6", "8", "10", "12"};


			//tableInputScoreLeft.Source = new TableSource (oddNums);
			//tableInputScoreRight.Source = new TableSource (evenNums);

			//Hide the nav bar
			NavigationController.SetNavigationBarHidden (true, false);

		


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

