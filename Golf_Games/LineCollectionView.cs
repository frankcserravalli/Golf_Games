using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;

namespace Golf_Games
{
	public class LineCollectionView : UICollectionViewController
	{
		string[] collectionItems; 
		static NSString lineCellId = new NSString ("LineCell");
		List<UILabel> labels;

		public LineCollectionView ()
		{
		}

		public LineCollectionView (string[] items)
		{
			collectionItems = items;
		}


		public override UICollectionViewCell GetCell (UICollectionView collectionView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var lineCell = (GridCell)collectionView.DequeueReusableCell (lineCellId, indexPath);

			var label = labels [indexPath.Row];

			//lineCell.Label = label;

			if (lineCell == null)
			{
				lineCell = new GridCell ();
			}

			lineCell.label.Text = collectionItems [indexPath.Row];

			return lineCell;
		}
	}

	//The custom gridcell for our collectionview
	public class GridCell : UICollectionViewCell
	{
		public UILabel label;

		public GridCell()
		{

		}

		[Export ("initWithFrame:")]
		public GridCell (System.Drawing.RectangleF frame) : base (frame)
		{


			BackgroundView = new UIView { BackgroundColor =  UIColor.White };
			ContentView.BackgroundColor = UIColor.White;
			//Original value was .95f, .95f
			ContentView.Transform = CGAffineTransform.MakeScale (.95f, .95f);
			ContentView.Layer.BorderColor = UIColor.Black.CGColor;
			ContentView.Layer.BorderWidth = 0.5f;
			//ContentView.AddSubview takes a UIView as a param.
			label = new UILabel ();

			label.Frame = frame;
			label.Center = ContentView.Center;

			label.Font = UIFont.FromName ("Helvetica-Bold", 15f);	
			label.AdjustsFontSizeToFitWidth = true;


			//TODO: There needs to be size that fits all. This may need to be dynamic.
			//Original value was 0.7, 0.7
			label.Transform = CGAffineTransform.MakeScale (0.9f, 0.9f);	//Originally .7f for both values. A new value of .9 is used to show up better.

			ContentView.AddSubview (label);
		}

		public UILabel Label
		{
			set 
			{
				label = value;
			}
			get
			{
				return label;
			}
		}
	}
}

