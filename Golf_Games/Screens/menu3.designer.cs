// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Golf_Games
{
	[Register ("menu3")]
	partial class menu3
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnInfo1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnInfo2 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnInfo3 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnMenu3Next { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView gameTypesTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnInfo1 != null) {
				btnInfo1.Dispose ();
				btnInfo1 = null;
			}

			if (btnInfo2 != null) {
				btnInfo2.Dispose ();
				btnInfo2 = null;
			}

			if (btnInfo3 != null) {
				btnInfo3.Dispose ();
				btnInfo3 = null;
			}

			if (gameTypesTable != null) {
				gameTypesTable.Dispose ();
				gameTypesTable = null;
			}

			if (btnMenu3Next != null) {
				btnMenu3Next.Dispose ();
				btnMenu3Next = null;
			}
		}
	}
}
