using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;

namespace Golf_Games
{
	public class CustomNavigationController : UINavigationController
	{
		//public CustomNavigationController ()
		//{
		//}

		public override bool ShouldAutorotate () 
		{
			//Prevents an autorotation from occuring. This is set for the rootNavigation controller.
			return true;
		}

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
		{
			//Sets the orientation to be only Portrait
			if (this.TopViewController.NibName != "portrait")
				return UIInterfaceOrientationMask.Portrait;
			else
				return UIInterfaceOrientationMask.All;
		}

	}
}

