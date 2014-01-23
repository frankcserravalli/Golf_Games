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

