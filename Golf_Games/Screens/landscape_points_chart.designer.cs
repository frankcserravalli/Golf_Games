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
	[Register ("landscape_points_chart")]
	partial class landscape_points_chart
	{
		[Outlet]
		MonoTouch.UIKit.UILabel[] labelPlayer1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel[] labelPlayer2 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel[] labelPlayer3 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel[] labelPlayer4 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView viewPointsBox1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView viewPointsBox2 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView viewPointsBox3 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView viewPointsBox4 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (viewPointsBox1 != null) {
				viewPointsBox1.Dispose ();
				viewPointsBox1 = null;
			}

			if (viewPointsBox2 != null) {
				viewPointsBox2.Dispose ();
				viewPointsBox2 = null;
			}

			if (viewPointsBox3 != null) {
				viewPointsBox3.Dispose ();
				viewPointsBox3 = null;
			}

			if (viewPointsBox4 != null) {
				viewPointsBox4.Dispose ();
				viewPointsBox4 = null;
			}
		}
	}
}
