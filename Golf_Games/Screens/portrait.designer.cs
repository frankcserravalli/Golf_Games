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
		MonoTouch.UIKit.UITableView tablePlayers { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView viewHoleInfo { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView viewPlayerInfo { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tablePlayers != null) {
				tablePlayers.Dispose ();
				tablePlayers = null;
			}

			if (viewPlayerInfo != null) {
				viewPlayerInfo.Dispose ();
				viewPlayerInfo = null;
			}

			if (viewHoleInfo != null) {
				viewHoleInfo.Dispose ();
				viewHoleInfo = null;
			}
		}
	}
}
