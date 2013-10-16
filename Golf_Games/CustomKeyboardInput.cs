using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;

namespace Golf_Games
{
	[Register("CustomKeyboardInput")]
	public class CustomKeyboardInput : UITextField
	{
		//[Export ("textInRange:")]
		public override bool ShouldChangeTextInRange (UITextRange inRange, string replacementText)
		{
			//NSRange r = (NSRange)inRange;


			//return base.ShouldChangeTextInRange (inRange, replacementText);
			return this.Text.Length <= 2;
		}
	}
}

