using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public partial class menu1 : UIViewController
	{

		menu2 menu2Screen;

		public menu1 () : base ("menu1", null)
		{
			this.Title = "Player Setup";
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

			this.btnMenu1Next.TouchUpInside += (sender, e) => {
				if (this.menu2Screen == null) {
					this.menu2Screen = new menu2 ();
				}
			

				this.NavigationController.PushViewController (this.menu2Screen, true);
			};


//			this.txtPlayerName1.ReturnKeyType = UIReturnKeyType.Done;
//			this.txtPlayerName2.ReturnKeyType = UIReturnKeyType.Done;
//			this.txtPlayerName3.ReturnKeyType = UIReturnKeyType.Done;
//			this.txtPlayerName4.ReturnKeyType = UIReturnKeyType.Done;
//
//			this.txtPlayerHandi1.KeyboardType = UIKeyboardType.NumbersAndPunctuation;
//			this.txtPlayerHandi2.KeyboardType = UIKeyboardType.NumbersAndPunctuation;
//			this.txtPlayerHandi3.KeyboardType = UIKeyboardType.NumbersAndPunctuation;
//			this.txtPlayerHandi4.KeyboardType = UIKeyboardType.NumbersAndPunctuation;
//
//			this.txtPlayerHandi1.ReturnKeyType = UIReturnKeyType.Done;
//			this.txtPlayerHandi2.ReturnKeyType = UIReturnKeyType.Done;
//			this.txtPlayerHandi3.ReturnKeyType = UIReturnKeyType.Done;
//			this.txtPlayerHandi4.ReturnKeyType = UIReturnKeyType.Done;


			this.txtPlayerName1.ShouldReturn += (textView) => {
				//textView.ResignFirstResponder ();


				return true;
			};




			// Perform any additional setup after loading the view, typically from a nib.
		}



	}
}

