// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Golf_Games
{
	[Register ("menu1")]
	partial class menu1
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnMenu1Next { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtPlayer1 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnMenu1Next != null) {
				btnMenu1Next.Dispose ();
				btnMenu1Next = null;
			}

			if (txtPlayer1 != null) {
				txtPlayer1.Dispose ();
				txtPlayer1 = null;
			}
		}
	}
}
