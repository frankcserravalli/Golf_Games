using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public partial class menu2 : UIViewController
	{
		menu3 menu3Screen;
		public GameInfo gameInfo;
		CurrentCourseInfo[] courses = new CurrentCourseInfo[3];
		UITableView table = new UITableView();

		public menu2 () : base ("menu2", null)
		{
			this.Title = "Pick a Course";
			for (int i =0; i < courses.Length; i++)
				courses [i] = new CurrentCourseInfo ();
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

			string[] tableItems = new string[] { "Bethpage","Shield Crest", "Running Y" };
			table.Source = new TableSource (tableItems);
			tableCourses.Source = new TableSource (tableItems);

			this.btnMenu2Next.TouchUpInside += (sender, e) => {
				if (this.menu3Screen == null) {
					this.menu3Screen = new menu3 ();
				}

				//Right here is where we set the GameInfo values before moving to the next menu
				NSIndexPath selectedIndex = this.tableCourses.IndexPathForSelectedRow;

				gameInfo.courseInfo = courses[selectedIndex.Row];



				menu3Screen.gameInfo = this.gameInfo;

				this.NavigationController.PushViewController (this.menu3Screen, true);
			};

			// Perform any additional setup after loading the view, typically from a nib.
		}


	}


		
}
		
