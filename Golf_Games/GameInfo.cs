using System;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public enum GameMode
	{
		Strokes = 0,
		Skins = 1,
		Wolf = 2
	};

	public class GameInfo
	{
		//--Data members--

		//Current course info
		public CurrentCourseInfo courseInfo;

		//Player Names and handicaps
		public UITextField player1;
		public UITextField player2;
		public UITextField player3;
		public UITextField player4;
		public UITextField player1Handi;
		public UITextField player2Handi;
		public UITextField player3Handi;
		public UITextField player4Handi;

		//Number of players
		public int numPlayers;

		//Game Mode
		public GameMode gameMode;	//A finite range between 0 and some value.

		//Side bets
		public bool sideBets;


		//--Methods--
		public GameInfo ()
		{
			numPlayers = 1;
			gameMode = GameMode.Strokes;
			sideBets = false;
		}


	}
}

