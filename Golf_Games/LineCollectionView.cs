using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

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
		public GridCell ()
		{
			BackgroundView = new UIView { BackgroundColor =  UIColor.White };
			ContentView.BackgroundColor = UIColor.Gray;

			//ContentView.AddSubview takes a UIView as a param.
			label = new UILabel ();
			label.Font = UIFont.FromName ("Helvetica-Bold", 10f);
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

