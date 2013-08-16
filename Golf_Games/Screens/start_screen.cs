using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public partial class start_screen : UIViewController
	{
		menu1 menu1Screen;

		public start_screen () : base ("start_screen", null)
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

			this.btnStart.TouchUpInside += (sender, e) => {
				if (this.menu1Screen == null) {
					this.menu1Screen = new menu1 ();
				}

				this.NavigationController.PushViewController (this.menu1Screen, true);
			};
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

