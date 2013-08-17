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
			UITextView txtPlayer;
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
			this.txtPlayerName1.Tag = 1;
			this.txtPlayerHandi1.Tag = 2;
			this.txtPlayerName2.Tag = 3;
			this.txtPlayerHandi2.Tag = 4;
			this.txtPlayerName3.Tag = 5;
			this.txtPlayerHandi3.Tag = 6;
			this.txtPlayerName4.Tag = 7;
			this.txtPlayerHandi4.Tag = 8;

			NextTextField (txtPlayerName1);
			NextTextField (txtPlayerHandi1);
			NextTextField (txtPlayerName2);
			NextTextField (txtPlayerHandi2);
			NextTextField (txtPlayerName3);
			NextTextField (txtPlayerHandi3);
			NextTextField (txtPlayerName4);
			NextTextField (txtPlayerHandi4);



			// Perform any additional setup after loading the view, typically from a nib.
		}

		public void NextTextField(UITextField txtPlayer)
		{
			txtPlayer.ShouldReturn += (textView) => {
				//textView.ResignFirstResponder ();
				//textView.BecomeFirstResponder();
				textView.BecomeFirstResponder ();

				if (txtPlayer.Tag != txtPlayerHandi4.Tag) {
					UITextField txtPlayerHandi = (UITextField)this.View.ViewWithTag(txtPlayer.Tag + 1);

					txtPlayerHandi.BecomeFirstResponder ();
				} else {
					txtPlayer.ResignFirstResponder ();
				}


				return true;
			};
		}



	}
}

