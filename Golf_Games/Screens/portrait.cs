using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public partial class portrait : UIViewController
	{
		//string[] oddNums;
		//string[] evenNums;

		landscape l_scorecard = new landscape();
		landscape_points_chart l_pts_chart = new landscape_points_chart();
		landscape_score_view l_score_view = new landscape_score_view();
		UITableView table = new UITableView();
		protected int currentHoleNum = 1;

		public GameInfo gameInfo;
		public UITabBarController tabController;

		//These are bool values to indicate if we have a button selected
		private bool selectedSandyPar = false;
		private bool selectedBirdie = false;
		private bool selectedGreenie = false;
		private bool selectedEagle = false;
		private bool selectedCTP = false;
		private bool selectedHOFF = false;

		public portrait () : base ("portrait", null)
		{
			//This code is for setting up a tab for landscape mode.
			tabController = new UITabBarController();


			tabController.ViewControllers = new UIViewController[] 
			{
				l_scorecard, l_score_view, l_pts_chart
			};

			tabController.ViewControllers [0].Title = "Scorecard";
			tabController.ViewControllers [1].Title = "Bets";
			tabController.ViewControllers [2].Title = "Points Chart";


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
			NSIndexPath defaultRow = new NSIndexPath();

			string p1NameAndHandi = gameInfo.player1.Text + " (" + gameInfo.player1Handi.Text + ")";
			string p2NameAndHandi = gameInfo.player2.Text + " (" + gameInfo.player2Handi.Text + ")";
			string p3NameAndHandi = gameInfo.player3.Text + " (" + gameInfo.player3Handi.Text + ")";
			string p4NameAndHandi = gameInfo.player4.Text + " (" + gameInfo.player4Handi.Text + ")";


			//Row 0 is player 1
			defaultRow = NSIndexPath.FromRowSection (0, 0);


			//Set the par and handicap for the first hole
			this.lblPar.Text = this.gameInfo.courseInfo.holes [0].par.ToString ();
			this.lblHandicap.Text = this.gameInfo.courseInfo.holes [0].hole_handicap.ToString ();

			//Populate the table
			string[] tableItems = new string[] { p1NameAndHandi, p2NameAndHandi, p3NameAndHandi, p4NameAndHandi };
			table.Source = new TableSource (tableItems);
			tablePlayers.Source = new TableSource (tableItems);

			//Hide the nav bar
			//NavigationController.SetNavigationBarHidden (true, false);

			//Add a border to the playerInfo and holeInfo view
			viewPlayerInfo.Layer.BorderColor = UIColor.DarkGray.CGColor;
			viewPlayerInfo.Layer.BorderWidth = 3.0f;

			//Button Next hole hit
			this.btnNextHole.TouchUpInside += (sender, e) => {
				//UpdateInfo with the Next Hole flag set.
				UpdateInfo(0);

			};

			//Button Previous hole hit
			this.btnPrevHole.TouchUpInside += (sender, e) => {
				//UpdateInfo with the Previous Hole flag set.
				UpdateInfo(1);
			};

			//Button Go back to setup is pressed
			this.btnGoBack.TouchUpInside += (sender, e) => {

				//Show the nav bar
				NavigationController.SetNavigationBarHidden (false, false);
				NavigationController.PopViewControllerAnimated(true);
			};

			//Select the first player by default
			tablePlayers.SelectRow (defaultRow, false, UITableViewScrollPosition.None);

			//The done button for the betting view
			this.btnDone.TouchUpInside += (sender, e) => {
				//Hide the betting view
				viewSideBets.Hidden = true;
				//Set the side betting values
				SaveSideBettingSelections();
				//Reset the the betting buttom images
				ResetBetButtons();
				//Select next player
				SelectNextPlayer();
			};


			// Perform any additional setup after loading the view, typically from a nib.
		}

		//We need a way to move to Landscape view when the screen is rotated
		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
		{
			return UIInterfaceOrientationMask.AllButUpsideDown;

		}

		public override void WillRotate(UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			base.WillRotate (toInterfaceOrientation, duration);

			if (this.tabController == null) {
				this.tabController = new UITabBarController ();
			}

			//this.NavigationController.PushViewController (this.landscape_screen, true);
			this.NavigationController.PushViewController (this.tabController, true);
			//this.PresentViewController (tabController, true, null);


		}

		partial void actnBtnScore(MonoTouch.Foundation.NSObject sender)
		{
			//This may need to be moved into the class as a data member.
			int currentPar = gameInfo.courseInfo.holes[currentHoleNum-1].par;

			int displayScore = 0;

			//selectedPlayer functions as an index. 0 is player 1 and 3 is player 4.
			int selectedPlayer = 0;

			//Used to hold the selected score that was inputted.
			int selectedScore = 1;

			//Check for which Player is selected
			selectedPlayer = this.tablePlayers.IndexPathForSelectedRow.Row;


			//Check for which button was pressed.
			//This value should always be in the range 1 to 12.
			selectedScore = ((UIButton)sender).Tag;

			//Set the proper label based on the previous 2 check.
			switch(selectedPlayer)
			{
			case 0:
				this.gameInfo.scores.strokeCountP1[currentHoleNum - 1] = selectedScore;
				break;

			case 1:
				this.gameInfo.scores.strokeCountP2[currentHoleNum - 1] = selectedScore;
				break;

			case 2:
				this.gameInfo.scores.strokeCountP3[currentHoleNum - 1] = selectedScore;
				break;

			case 3 :
				this.gameInfo.scores.strokeCountP4[currentHoleNum - 1] = selectedScore;
				break;

			default:
				break;

			}

			//Calculate how to display the score
			displayScore = currentPar - selectedScore;

			//Needs to be flipped
			displayScore = displayScore * -1;


			//Decide which label to change based upon the which player was selected

			switch(selectedPlayer)
			{
			case 0:
				lblPlayer1Score.Text = displayScore.ToString("+#;-#;0");
				break;

			case 1:
				lblPlayer2Score.Text = displayScore.ToString("+#;-#;0");
				break;

			case 2:
				lblPlayer3Score.Text = displayScore.ToString("+#;-#;0");
				break;

			case 3:
				lblPlayer4Score.Text = displayScore.ToString("+#;-#;0");
				break;

			default:
				break;
			}

			if(gameInfo.sideBets == true)
			{
				viewSideBets.Hidden = false;
			}
			else
				SelectNextPlayer();	//Select the next player after inputting the score
		}

		public void UpdateInfo(int holeDirection)
		{
			int hIndex = 0;
			switch (holeDirection) 
			{
			//Next Hole
			case 0:
				if(this.currentHoleNum < 18)
					this.currentHoleNum++;
				break;

			//Previous Hole
			case 1:
				if(this.currentHoleNum > 1)
					this.currentHoleNum--;
				break;

			//Regular Update
			case 2:
				break;

			default:
				break;

			}

			hIndex = currentHoleNum - 1;

			int currentPar = gameInfo.courseInfo.holes[hIndex].par;
			int strokeP1 = this.gameInfo.scores.strokeCountP1 [hIndex];
			int strokeP2 = this.gameInfo.scores.strokeCountP2 [hIndex];
			int strokeP3 = this.gameInfo.scores.strokeCountP3 [hIndex];
			int strokeP4 = this.gameInfo.scores.strokeCountP4 [hIndex];

			this.lblHoleNum.Text = this.currentHoleNum.ToString ();
			//Set the Par and handicap for current hole
			this.lblPar.Text = this.gameInfo.courseInfo.holes[hIndex].par.ToString();
			this.lblHandicap.Text = this.gameInfo.courseInfo.holes[hIndex].hole_handicap.ToString();


			//TODO: Optimization - A function could be made to handle these statements.
			//Update player 1.
			if (this.gameInfo.scores.strokeCountP1 [hIndex] == 0)
				lblPlayer1Score.Text = "--";
			else
				lblPlayer1Score.Text = CalculateScore(strokeP1, currentPar).ToString ("+#;-#;0");

			//Update player 2.
			if (this.gameInfo.scores.strokeCountP2 [hIndex] == 0)
				lblPlayer2Score.Text = "--";
			else
				lblPlayer2Score.Text = CalculateScore(strokeP2, currentPar).ToString ("+#;-#;0");

			//Update player 3.
			if (this.gameInfo.scores.strokeCountP3 [hIndex] == 0)
				lblPlayer3Score.Text = "--";
			else
				lblPlayer3Score.Text = CalculateScore(strokeP3, currentPar).ToString ("+#;-#;0");

			//Update player 4.
			if (this.gameInfo.scores.strokeCountP4 [hIndex] == 0)
				lblPlayer4Score.Text = "--";
			else
				lblPlayer4Score.Text = CalculateScore(strokeP4, currentPar).ToString ("+#;-#;0");


		}


		//Calculates how to display the score based on strokes.
		public int CalculateScore(int stroke, int currentPar)
		{
			int displayScore = 0;

			//Calculate how to display the score
			displayScore = currentPar - stroke;

			//Needs to be flipped
			displayScore = displayScore * -1;

			return displayScore;
		}



		partial void actnBtnBets(MonoTouch.Foundation.NSObject sender)
		{
			//Determine which button was pressed
			int buttonTag = ((UIButton)sender).Tag;
			UIImage highlighted = new UIImage("gg_greenbutton_highlighted.png");
			UIImage normal = new UIImage("gg_greenbutton.png");
			bool selectedButton = false;

			switch(buttonTag)
			{
			case 1:
				selectedSandyPar = !selectedSandyPar;
				selectedButton = selectedSandyPar;
				break;

			case 2:
				selectedBirdie = !selectedBirdie;
				selectedButton = selectedBirdie;
				break;

			case 3:
				selectedGreenie = !selectedGreenie;
				selectedButton = selectedGreenie;
				break;

			case 4:
				selectedEagle = !selectedEagle;
				selectedButton = selectedEagle;

				break;

			case 5:
				selectedCTP = !selectedCTP;
				selectedButton = selectedCTP;
				break;

			case 6:
				selectedHOFF = !selectedHOFF;
				selectedButton = selectedHOFF;
				break;

			}

			if(selectedButton == true)
			{
				((UIButton)sender).SetBackgroundImage(highlighted, UIControlState.Normal);

			}
			else
			{
				((UIButton)sender).SetBackgroundImage(normal, UIControlState.Normal);
			}


		}

		//Reset the betting buttons back to their original state
		private void ResetBetButtons()
		{
			UIImage normal = new UIImage("gg_greenbutton.png");

			btnSandyPar.SetBackgroundImage(normal, UIControlState.Normal);
			btnCTP.SetBackgroundImage(normal, UIControlState.Normal);
			btnBirdie.SetBackgroundImage(normal, UIControlState.Normal);
			btnEagle.SetBackgroundImage(normal, UIControlState.Normal);
			btnGreenie.SetBackgroundImage(normal, UIControlState.Normal);
			btnHOFF.SetBackgroundImage(normal, UIControlState.Normal);

			selectedSandyPar = false;
			selectedBirdie = false;
			selectedGreenie = false;
			selectedEagle = false;
			selectedCTP = false;
			selectedHOFF = false;
		}

		private void SaveSideBettingSelections()
		{
			int selectedPlayer = this.tablePlayers.IndexPathForSelectedRow.Row;
			//int i = 0;

			switch(selectedPlayer)
			{
			case 0:
				SaveBettingSelectionForPlayer(this.gameInfo.courseInfo.holes[currentHoleNum - 1].sideBetInfo.player1);
				break;

			case 1:
				SaveBettingSelectionForPlayer(this.gameInfo.courseInfo.holes[currentHoleNum - 1].sideBetInfo.player2);
				break;

			case 2:
				SaveBettingSelectionForPlayer(this.gameInfo.courseInfo.holes[currentHoleNum - 1].sideBetInfo.player3);
				break;

			case 3:
				SaveBettingSelectionForPlayer(this.gameInfo.courseInfo.holes[currentHoleNum - 1].sideBetInfo.player4);
				break;

			default:
				break;

			}
		}

		private void SaveBettingSelectionForPlayer(bool[] player)
		{
			//This function assumes that there is 6 entires in the array
			player [0] = selectedBirdie;
			player [1] = selectedCTP;
			player [2] = selectedEagle;
			player [3] = selectedGreenie;
			player [4] = selectedHOFF;
			player [5] = selectedSandyPar;
			
		}

		private void SelectNextPlayer()
		{
			int currentSelection = tablePlayers.IndexPathForSelectedRow.Row;
			NSIndexPath selectNewRow = new NSIndexPath();

			//Current selection must never be below 0 or above 3
			if (currentSelection < 3) 
				currentSelection++;
			else
				currentSelection = 0;

			selectNewRow = NSIndexPath.FromRowSection (currentSelection, 0);
			tablePlayers.SelectRow (selectNewRow, false, UITableViewScrollPosition.None);
		}


	}
}

