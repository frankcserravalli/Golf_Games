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
		MonoTouch.UIKit.UIButton btnDone { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnNextHole { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnPrevHole { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblHandicap { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblHoleNum { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblPar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblPlayer1Score { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblPlayer2Score { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblPlayer3Score { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblPlayer4Score { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView tablePlayers { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView viewHoleInfo { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView viewPlayerInfo { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView viewSideBets { get; set; }

		[Action ("actnBtnBets:")]
		partial void actnBtnBets (MonoTouch.Foundation.NSObject sender);

		[Action ("actnBtnScore:")]
		partial void actnBtnScore (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (btnNextHole != null) {
				btnNextHole.Dispose ();
				btnNextHole = null;
			}

			if (btnPrevHole != null) {
				btnPrevHole.Dispose ();
				btnPrevHole = null;
			}

			if (lblHandicap != null) {
				lblHandicap.Dispose ();
				lblHandicap = null;
			}

			if (lblHoleNum != null) {
				lblHoleNum.Dispose ();
				lblHoleNum = null;
			}

			if (lblPar != null) {
				lblPar.Dispose ();
				lblPar = null;
			}

			if (lblPlayer1Score != null) {
				lblPlayer1Score.Dispose ();
				lblPlayer1Score = null;
			}

			if (lblPlayer2Score != null) {
				lblPlayer2Score.Dispose ();
				lblPlayer2Score = null;
			}

			if (lblPlayer3Score != null) {
				lblPlayer3Score.Dispose ();
				lblPlayer3Score = null;
			}

			if (lblPlayer4Score != null) {
				lblPlayer4Score.Dispose ();
				lblPlayer4Score = null;
			}

			if (tablePlayers != null) {
				tablePlayers.Dispose ();
				tablePlayers = null;
			}

			if (viewHoleInfo != null) {
				viewHoleInfo.Dispose ();
				viewHoleInfo = null;
			}

			if (viewPlayerInfo != null) {
				viewPlayerInfo.Dispose ();
				viewPlayerInfo = null;
			}

			if (viewSideBets != null) {
				viewSideBets.Dispose ();
				viewSideBets = null;
			}

			if (btnDone != null) {
				btnDone.Dispose ();
				btnDone = null;
			}
		}
	}
}
