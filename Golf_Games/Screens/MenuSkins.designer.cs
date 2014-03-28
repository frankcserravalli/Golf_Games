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
	[Register ("MenuSkins")]
	partial class MenuSkins
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnNext { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView tableSkinModes { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtSkinValue { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtTotalSkins { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnNext != null) {
				btnNext.Dispose ();
				btnNext = null;
			}

			if (tableSkinModes != null) {
				tableSkinModes.Dispose ();
				tableSkinModes = null;
			}

			if (txtTotalSkins != null) {
				txtTotalSkins.Dispose ();
				txtTotalSkins = null;
			}

			if (txtSkinValue != null) {
				txtSkinValue.Dispose ();
				txtSkinValue = null;
			}
		}
	}
}
