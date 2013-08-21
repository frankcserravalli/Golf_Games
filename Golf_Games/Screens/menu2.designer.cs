// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Golf_Games
{
	[Register ("menu2")]
	partial class menu2
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnMenu2Next { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView tableCourses { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnMenu2Next != null) {
				btnMenu2Next.Dispose ();
				btnMenu2Next = null;
			}

			if (tableCourses != null) {
				tableCourses.Dispose ();
				tableCourses = null;
			}
		}
	}
}
