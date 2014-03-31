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
	[Register ("MenuWolf")]
	partial class MenuWolf
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnNext { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView tablePlayers { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tablePlayers != null) {
				tablePlayers.Dispose ();
				tablePlayers = null;
			}

			if (btnNext != null) {
				btnNext.Dispose ();
				btnNext = null;
			}
		}
	}
}
