// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Golf_Games
{
	[Register ("portrait")]
	partial class portrait
	{
		[Outlet]
		MonoTouch.UIKit.UITableView tableInputScoreLeft { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView tableInputScoreRight { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tableInputScoreLeft != null) {
				tableInputScoreLeft.Dispose ();
				tableInputScoreLeft = null;
			}

			if (tableInputScoreRight != null) {
				tableInputScoreRight.Dispose ();
				tableInputScoreRight = null;
			}
		}
	}
}
