
using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Collections.Generic;

namespace Golf_Games
{
	public partial class landscape : UIViewController
	{


		public landscape () : base ("landscape", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			const int cellWidth = 20;	//This is the size of each cell
			const int cellHeight = 20;

			string[] holenumbers1 = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
			List<GridCell> cells = new List<GridCell>();

			Rectangle cellFrame = new Rectangle (0, 0, cellWidth, cellHeight);

			for (int i = 0; i < 9; i++) 
			{
				cellFrame.X = (i * cellWidth);
				GridCell cell = new GridCell (cellFrame);
				cell.Label.Text = holenumbers1 [i];

				//Insert cell into the list
				cells.Add (cell);
			}

			for (int i = 0; i < 9; i++)
				gridBottom9.Add (cells [i]);

			//UICollectionViewDataSource dataSource = new CollectionSource (holenumbers1);
			
			//gridBottom9 = 
//			SizeF tableSize = new SizeF ();
//			PointF pos = new PointF ();
//
//			pos = tableHorz1.Center;
//			//These sizes are used based on the xcode representation of the table.
//			tableSize.Height = tableHorz1.Frame.Size.Height;
//			tableSize.Width = tableHorz1.Frame.Size.Width;
//
//			tableHorz1.Transform = CGAffineTransform.MakeRotation ((float)(Math.PI * -90 / 180.0));
//			tableHorz1.Frame = new RectangleF (pos, tableSize);

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void WillRotate(UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			base.WillRotate (toInterfaceOrientation, duration);


			this.NavigationController.PopViewControllerAnimated (true);

		}
	}
}

