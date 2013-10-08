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
	[Register ("menu4")]
	partial class menu4
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnMenu4Start { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch switchSideBets { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtBirdie { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtCTP { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtEagle { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtGreenie { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtHOFF { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtSandyPar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView viewPointValues { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnMenu4Start != null) {
				btnMenu4Start.Dispose ();
				btnMenu4Start = null;
			}

			if (switchSideBets != null) {
				switchSideBets.Dispose ();
				switchSideBets = null;
			}

			if (txtSandyPar != null) {
				txtSandyPar.Dispose ();
				txtSandyPar = null;
			}

			if (txtBirdie != null) {
				txtBirdie.Dispose ();
				txtBirdie = null;
			}

			if (txtGreenie != null) {
				txtGreenie.Dispose ();
				txtGreenie = null;
			}

			if (txtEagle != null) {
				txtEagle.Dispose ();
				txtEagle = null;
			}

			if (txtCTP != null) {
				txtCTP.Dispose ();
				txtCTP = null;
			}

			if (txtHOFF != null) {
				txtHOFF.Dispose ();
				txtHOFF = null;
			}

			if (viewPointValues != null) {
				viewPointValues.Dispose ();
				viewPointValues = null;
			}
		}
	}
}
