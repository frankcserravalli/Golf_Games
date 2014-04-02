// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Golf_Games
{
	[Register ("MenuNassau")]
	partial class MenuNassau
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnNext { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtAllHoles { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtBackNine { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtFrontNine { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtFrontNine != null) {
				txtFrontNine.Dispose ();
				txtFrontNine = null;
			}

			if (txtBackNine != null) {
				txtBackNine.Dispose ();
				txtBackNine = null;
			}

			if (txtAllHoles != null) {
				txtAllHoles.Dispose ();
				txtAllHoles = null;
			}

			if (btnNext != null) {
				btnNext.Dispose ();
				btnNext = null;
			}
		}
	}
}
