using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public partial class MenuNassau : UIViewController
	{
		public GameInfo gameInfo;
		menu4 menu4Screen;

		public MenuNassau () : base ("MenuNassau", null)
		{
			this.Title = "Nassau Options";
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

			txtFrontNine.ShouldReturn += (textView) => 
			{
				textView.ResignFirstResponder ();
				return true;
			};
			txtBackNine.ShouldReturn += (textView) => 
			{
				textView.ResignFirstResponder ();
				return true;
			};
			txtAllHoles.ShouldReturn += (textView) => 
			{
				textView.ResignFirstResponder ();
				return true;
			};

			txtFrontNine.ShouldChangeCharacters += (text, r, str) =>
			{
				return ScoreInputCheck(text, r, str);
			};

			txtBackNine.ShouldChangeCharacters += (text, r, str) =>
			{
				return ScoreInputCheck(text, r, str);
			};

			txtAllHoles.ShouldChangeCharacters += (text, r, str) =>
			{
				return ScoreInputCheck(text, r, str);
			};

			btnNext.TouchUpInside += (sender, e) => 
			{
				if(menu4Screen == null)
				{
					menu4Screen = new menu4();
				}

				//Copy the values from the text boxes to the gameinfo object.
				gameInfo.scores.nassauGame.BetFrontNine = System.Convert.ToInt32(txtFrontNine.Text);
				gameInfo.scores.nassauGame.BetBackNine = System.Convert.ToInt32(txtBackNine.Text);
				gameInfo.scores.nassauGame.BetAllHoles = System.Convert.ToInt32(txtAllHoles.Text);

				menu4Screen.gameInfo = gameInfo;
				this.NavigationController.PushViewController(menu4Screen, true);

			};

			// Perform any additional setup after loading the view, typically from a nib.
		}







		//TODO: This function should probably be apart of a different cs file, as otheres need it.
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

		//TODO: This function should probably be apart of a different cs file, as otheres need it.
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

