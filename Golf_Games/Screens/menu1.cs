using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public partial class menu1 : UIViewController
	{

		menu2 menu2Screen;
		public menu1 () : base ("menu1", null)
		{
			this.Title = "Player Setup";

			this.txtPlayer1.ShouldReturn += (textField) => {
				textField.ResignFirstResponder ();
				return true;
			};
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

			this.btnMenu1Next.TouchUpInside += (sender, e) => {
				if (this.menu2Screen == null) {
					this.menu2Screen = new menu2 ();
				}

				this.NavigationController.PushViewController (this.menu2Screen, true);
			};

			// Perform any additional setup after loading the view, typically from a nib.
		}


	}
}

