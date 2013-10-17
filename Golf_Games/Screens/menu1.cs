using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public partial class menu1 : UIViewController
	{

		menu2 menu2Screen;
		public GameInfo gameInfo;

		//TODO: Will need a way to find out how many players there are.
		int numPlayers = 4;

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

			//Show the nav bar
			NavigationController.SetNavigationBarHidden (false, false);

			//Turn off autorotate and keep it fix to portrait
			this.btnMenu1Next.TouchUpInside += (sender, e) => {
				NextBtnHit();
			};

			SetTextTags();

			//Make sure all values for the handicaps are numbers
			txtPlayerHandi1.ShouldChangeCharacters += (text, r, str) =>
			{
				return HandicapInputCheck(text, r, str);
			};
			txtPlayerHandi2.ShouldChangeCharacters += (text, r, str) =>
			{
				return HandicapInputCheck(text, r, str);
			};
			txtPlayerHandi3.ShouldChangeCharacters += (text, r, str) =>
			{
				return HandicapInputCheck(text, r, str);
			};
			txtPlayerHandi4.ShouldChangeCharacters += (text, r, str) =>
			{
				return HandicapInputCheck(text, r, str);
			};
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


		//This function is intended to set all the gameInfo values before moving to the next menu.
		private void SetGameInfoValues()
		{
			this.gameInfo.player1 = this.txtPlayerName1;
			this.gameInfo.player2 = this.txtPlayerName2;
			this.gameInfo.player3 = this.txtPlayerName3;
			this.gameInfo.player4 = this.txtPlayerName4;

			this.gameInfo.player1Handi = this.txtPlayerHandi1;
			this.gameInfo.player2Handi = this.txtPlayerHandi2;
			this.gameInfo.player3Handi = this.txtPlayerHandi3;
			this.gameInfo.player4Handi = this.txtPlayerHandi4;

			this.gameInfo.numPlayers = numPlayers;
		}

		public override bool ShouldAutorotate ()
		{
			return true;

		}

		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
		{
			return (toInterfaceOrientation == UIInterfaceOrientation.Portrait);
		}

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
		{
			return UIInterfaceOrientationMask.Portrait;

		}

		private void SetTextTags()
		{
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
		}

		private void NextBtnHit()
		{
			if (this.menu2Screen == null) {
				this.menu2Screen = new menu2 ();
			}

			//Right here is where we set the GameInfo values before moving to the next menu
			SetGameInfoValues();
			menu2Screen.gameInfo = this.gameInfo;
			this.NavigationController.PushViewController (this.menu2Screen, true);
		}

		private bool HandicapInputCheck(UITextField text, NSRange range, string str)
		{
			char character = 'a';
			if(str.Length == 0)
				return true;

			character = str[0];

			//Check if the length is longer than 2 characters and make sure it is a number
			if((text.Text.Length + str.Length) <= 2 && character >= 48 && character <= 57)
				return true;

			//If all vaild checks fail, then return false
			return false;
		}

	}

}

