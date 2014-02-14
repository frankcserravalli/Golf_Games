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
		//int numPlayers = 4;

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

			bool screenShifted = false;
			int activeEdits = 0;

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

			//When player 4 text box is selected, we need to shift the controls up.
			txtPlayerName4.ShouldBeginEditing += (textField) => 
			{
				activeEdits++;
				if(activeEdits < 2)
					MoveViewPointValues(true, 60);

				screenShifted = true;

				return true;
			};

			txtPlayerName4.ShouldEndEditing += (textField) => 
			{
				activeEdits--;
				if(activeEdits == 0)
					MoveViewPointValues (false, 60);

				screenShifted = false;

				return true;
			};

			txtPlayerHandi4.ShouldBeginEditing += (textField) => 
			{
				activeEdits++;
				if(activeEdits < 2)
					MoveViewPointValues(true, 60);

				screenShifted = true;

				return true;
			};

			txtPlayerHandi4.ShouldEndEditing += (textField) => 
			{
				activeEdits--;
				if(activeEdits == 0)
					MoveViewPointValues (false, 60);

				screenShifted = false;
				return true;
			};

			//Any time the segment selection changes, it will update the number of players.
			segNumPlayers.ValueChanged += (sender, e) => 
			{
				//The selected segment is zero indexed. So set number of players to that + 1.
				gameInfo.numPlayers = segNumPlayers.SelectedSegment + 1; 

				HideOrShowPlayerEntries();

			};
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public void NextTextField(UITextField txtPlayer)
		{
			int numPlayerIndex = 0;

			//Event handler
			txtPlayer.ShouldReturn += (textView) => {
			numPlayerIndex = gameInfo.numPlayers * 2;
			textView.BecomeFirstResponder ();

				//The tags are a labeled 1 through 8 for the player name and its handicap field.

				//If the tag is not the last last text field tag
				if (txtPlayer.Tag != txtPlayerHandi4.Tag && numPlayerIndex > txtPlayer.Tag) 
				{
					//The next text field becomes selected
					UITextField txtPlayerHandi = (UITextField)this.View.ViewWithTag(txtPlayer.Tag + 1);

					txtPlayerHandi.BecomeFirstResponder ();
				} 
				else 
				{
					//We are on the last field
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

			//this.gameInfo.numPlayers = numPlayers;
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

			//Perform a check on how many players are playing. We need at least one.


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

		private void HideOrShowPlayerEntries()
		{
			int numPlayers = gameInfo.numPlayers;

			switch (numPlayers) 
			{
			case 1:
				//Hide all but player 1.
				txtPlayerHandi2.Hidden = true;
				txtPlayerName2.Hidden = true;
				txtPlayerHandi3.Hidden = true;
				txtPlayerName3.Hidden = true;
				txtPlayerHandi4.Hidden = true;
				txtPlayerName4.Hidden = true;
				break;

			case 2:
				//Hide player 3 and 4
				txtPlayerHandi2.Hidden = false;
				txtPlayerName2.Hidden = false;
				txtPlayerHandi3.Hidden = true;
				txtPlayerName3.Hidden = true;
				txtPlayerHandi4.Hidden = true;
				txtPlayerName4.Hidden = true;

				break;

			case 3:
				//Hide only player 4
				txtPlayerHandi2.Hidden = false;
				txtPlayerName2.Hidden = false;
				txtPlayerHandi3.Hidden = false;
				txtPlayerName3.Hidden = false;
				txtPlayerHandi4.Hidden = true;
				txtPlayerName4.Hidden = true;
				break;

			case 4:
				//Show all
				txtPlayerHandi2.Hidden = false;
				txtPlayerName2.Hidden = false;
				txtPlayerHandi3.Hidden = false;
				txtPlayerName3.Hidden = false;
				txtPlayerHandi4.Hidden = false;
				txtPlayerName4.Hidden = false;
				break;
			}
		}

		//TODO: This function also exists in the menu4.cs. It could be moved to another class so we dont have duplicates.
		private void MoveViewPointValues(bool keyboardActive, int movementDistance)
		{
			const float movementDuration = 0.3f;

			if (keyboardActive == false)
				movementDistance = movementDistance * -1;

			UIView.Animate (movementDuration, 0, UIViewAnimationOptions.CurveLinear, () => 
			                {
				this.View.Center = new PointF (this.View.Center.X,
				                               this.View.Center.Y - movementDistance);
			}, () => 

			{
				//viewPointValues.Center = pt;
			}

			);


		}

	}

}

