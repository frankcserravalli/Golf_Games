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

		public portrait () : base ("portrait", null)
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
			oddNums = new string[] { "1", "3", "5", "7", "9", "11" };
			evenNums = new string[] {"2", "4", "6", "8", "10", "12"};

			tableInputScoreLeft.Source = new TableSource (oddNums);
			tableInputScoreRight.Source = new TableSource (evenNums);

			//Hide the nav bar
			NavigationController.SetNavigationBarHidden (true, false);

			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

