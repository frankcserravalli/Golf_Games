using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;



namespace Golf_Games
{
	public partial class start_screen : UIViewController
	{
		menu1 menu1Screen;
		GameInfo gameInfo = new GameInfo();


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

				this.menu1Screen.gameInfo = this.gameInfo;
				this.NavigationController.PushViewController (this.menu1Screen, true);
			};

			//Need to create directories to store our data
			var documents = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			var directoryname = Path.Combine (documents, "Players");
			Directory.CreateDirectory (directoryname);

			// Perform any additional setup after loading the view, typically from a nib.
		}


		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
		{
			return (toInterfaceOrientation == UIInterfaceOrientation.Portrait);
		}

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
		{
			//Sets the orientation to be only Portrait
			return UIInterfaceOrientationMask.Portrait;
		}

		//public override UIInterfaceOrientationMask SupportedInterfaceOrientations()
		//{

		//	return UIInterfaceOrientationMask.All;

		//}
		                                                              

	}
}

