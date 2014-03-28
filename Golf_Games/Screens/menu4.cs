using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;


//The Menu Before portrait mode.
namespace Golf_Games
{
	public partial class menu4 : UIViewController
	{
		public GameInfo gameInfo;
		public portrait portraitScreen;
		menu4 menu4Screen;
		//CustomKeyboardInput customTxtBirdie;

		public menu4 () : base ("menu4", null)
		{
			this.Title = "Final Settings";
			//this.txtBirdie = new CustomKeyboardInput ();
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

			//CustomKeyboardInput customTxtBirdie = (CustomKeyboardInput)txtBirdie;



			this.switchSideBets.TouchUpInside += (sender, e) =>
			{
				//If the switch was turned to on
				if(switchSideBets.On == true)
				{
					//Show the point values view
					viewPointValues.Hidden = false;
				}
				else
				{
					viewPointValues.Hidden = true;
				}
			};

			this.btnMenu4Start.TouchUpInside += (sender, e) => {
				if (this.portraitScreen == null) {
					this.portraitScreen = new portrait ();
				}//endif

				//Hide the nav bar
				NavigationController.SetNavigationBarHidden (true, false);

				//Set if side bets are on or off
				this.gameInfo.sideBets = switchSideBets.On;

				//Build course info based on the selection in menu2
				this.gameInfo.courseInfo.FindCourseByID(gameInfo.courseInfo.courseIndex);

				//Copy over to gameInfo
				CopyOverToGameInfo();

				//Copy gameinfo to the portrait object
				portraitScreen.gameInfo = this.gameInfo;

				this.NavigationController.PushViewController (this.portraitScreen, true);

				// Perform any additional setup after loading the view, typically from a nib.
			};

			//ShouldReturns for the textentries
			txtBirdie.ShouldReturn += (textView) =>
			{
				switchSideBets.Enabled = true;
				textView.ResignFirstResponder ();
				return true;
			};

			txtSandyPar.ShouldReturn += (textView) =>
			{
				switchSideBets.Enabled = true;
				textView.ResignFirstResponder ();
				return true;
			};

			txtGreenie.ShouldReturn += (textView) =>
			{
				switchSideBets.Enabled = true;
				textView.ResignFirstResponder ();
				return true;
			};

			txtCTP.ShouldReturn += (textView) =>
			{
				switchSideBets.Enabled = true;
				textView.ResignFirstResponder ();
				return true;
			};

			txtEagle.ShouldReturn += (textView) =>
			{
				switchSideBets.Enabled = true;
				textView.ResignFirstResponder ();
				return true;
			};

			txtHOFF.ShouldReturn += (textView) =>
			{
				switchSideBets.Enabled = true;
				textView.ResignFirstResponder ();
				return true;
			};



			//Keep all input for the score fields numbers.
			txtBirdie.ShouldChangeCharacters += (text, r, str) =>
			{
				return ScoreInputCheck(text, r, str);
			};

			txtCTP.ShouldChangeCharacters += (text, r, str) =>
			{
				return ScoreInputCheck(text, r, str);
			};

			txtEagle.ShouldChangeCharacters += (text, r, str) =>
			{
				return ScoreInputCheck(text, r, str);
			};

			txtGreenie.ShouldChangeCharacters += (text, r, str) =>
			{
				return ScoreInputCheck(text, r, str);
			};

			txtHOFF.ShouldChangeCharacters += (text, r, str) =>
			{
				return ScoreInputCheck(text, r, str);
			};

			txtSandyPar.ShouldChangeCharacters += (text, r, str) =>
			{
				return ScoreInputCheck(text, r, str);
			};


			//The view shifting when a textbox is hit.

			txtBirdie.ShouldBeginEditing += (textField) =>
			{
				switchSideBets.Enabled = false;
				return true;
			};

			txtBirdie.ShouldEndEditing += (textField) =>
			{
				return true;
			};

			txtSandyPar.ShouldBeginEditing += (textField) =>
			{
				switchSideBets.Enabled = false;
				return true;
			};

			txtBirdie.ShouldEndEditing += (textField) =>
			{
				return true;
			};

			txtGreenie.ShouldBeginEditing += (textField) =>
			{
				switchSideBets.Enabled = false;
				//Push screen upwards 90 pixels
				MoveViewPointValues(true, 25);

				return true;
			};

			txtGreenie.ShouldEndEditing += (textField) =>
			{
				//Push screen downwards 90 pixels
				MoveViewPointValues (false, 25);

				return true;
			};

			txtEagle.ShouldBeginEditing += (textField) =>
			{
				switchSideBets.Enabled = false;
				//Push screen upwards 60 pixels
				MoveViewPointValues(true, 60);
	
				return true;
			};

			txtEagle.ShouldEndEditing += (textField) =>
			{
				//Push screen downwards 60 pixels
				MoveViewPointValues (false, 60);

				return true;
			};


			txtCTP.ShouldBeginEditing += (textField) =>
			{
				switchSideBets.Enabled = false;
				//Push screen upwards 90 pixels
				MoveViewPointValues(true, 95);

				return true;
			};

			txtCTP.ShouldEndEditing += (textField) =>
			{
				//Push screen downwards 90 pixels
				MoveViewPointValues (false, 95);

				return true;
			};

			txtHOFF.ShouldBeginEditing += (textField) =>
			{
				switchSideBets.Enabled = false;
				//Push screen upwards 50 pixels
				MoveViewPointValues(true, 135);

				return true;
			};

			txtHOFF.ShouldEndEditing += (textField) =>
			{
				//Push screen downwards 50 pixels
				MoveViewPointValues (false, 135);

				return true;
			};



		}

		private void CopyOverToGameInfo()
		{
			//The range for acceptable values will be 1 to 0
			if(txtBirdie.Text == "")
				this.gameInfo.betBirdie = 0;
			else
				this.gameInfo.betBirdie = System.Convert.ToInt32(txtBirdie.Text);

			if (txtCTP.Text == "")
				this.gameInfo.betCTP = 0;
			else
				this.gameInfo.betCTP = System.Convert.ToInt32(txtCTP.Text);

			if (txtEagle.Text == "")
				this.gameInfo.betEagle = 0;
			else
				this.gameInfo.betEagle = System.Convert.ToInt32(txtEagle.Text);

			if (txtGreenie.Text == "")
				this.gameInfo.betGreenie = 0;
			else
				this.gameInfo.betGreenie = System.Convert.ToInt32(txtGreenie.Text);

			if (txtHOFF.Text == "")
				this.gameInfo.betHOFF = 0;
			else
				this.gameInfo.betHOFF = System.Convert.ToInt32(txtHOFF.Text);

			if (txtSandyPar.Text == "")
				this.gameInfo.betSandyPar = 0;
			else
				this.gameInfo.betSandyPar = System.Convert.ToInt32(txtSandyPar.Text);
		}

		private bool ScoreInputCheck(UITextField text, NSRange range, string str)
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

