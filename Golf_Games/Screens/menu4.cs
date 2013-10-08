using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public partial class menu4 : UIViewController
	{
		public GameInfo gameInfo;
		public portrait portraitScreen;

		public menu4 () : base ("menu4", null)
		{
			this.Title = "Final Settings";
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

			this.switchSideBets.TouchUpInside += (sender, e) =>
			{
				//If the switch was turned to on
				if(switchSideBets.On == true)
				{
					//Show the point values view
					viewPointValues.Hidden = false;
				}
				else
				{
					viewPointValues.Hidden = true;
				}
			};

			this.btnMenu4Start.TouchUpInside += (sender, e) => {
				if (this.portraitScreen == null) {
					this.portraitScreen = new portrait ();
				}//endif


				//Hide the nav bar
				NavigationController.SetNavigationBarHidden (true, false);

				//Set if side bets are on or off
				this.gameInfo.sideBets = switchSideBets.On;

				//Build course info based on the selection in menu2
				this.gameInfo.courseInfo.FindCourseByID(gameInfo.courseInfo.courseIndex);

				//Copy gameinfo to the portrait object
				portraitScreen.gameInfo = this.gameInfo;
					


				this.NavigationController.PushViewController (this.portraitScreen, true);

				

			
				// Perform any additional setup after loading the view, typically from a nib.
			};

			//ShouldReturns for the textentries
			txtBirdie.ShouldReturn += (textView) =>
			{
				textView.ResignFirstResponder ();

				return true;
			};

			txtSandyPar.ShouldReturn += (textView) =>
			{
				textView.ResignFirstResponder ();

				return true;
			};

			txtGreenie.ShouldReturn += (textView) =>
			{
				textView.ResignFirstResponder ();

				return true;
			};

			txtCTP.ShouldReturn += (textView) =>
			{
				textView.ResignFirstResponder ();

				return true;
			};

			txtEagle.ShouldReturn += (textView) =>
			{
				textView.ResignFirstResponder ();

				return true;
			};

			txtHOFF.ShouldReturn += (textView) =>
			{
				textView.ResignFirstResponder ();

				return true;
			};
		}


	}
}

