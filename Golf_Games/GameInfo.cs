using System;
using MonoTouch.UIKit;

namespace Golf_Games
{
	public enum GameMode
	{
		Strokes = 0,
		Skins = 1,
		Wolf = 2,
		Nassau = 3,
		Match = 4
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

		//Point values for betting
		public int betSandyPar;
		public int betBirdie;
		public int betGreenie;
		public int betEagle;
		public int betCTP;
		public int betHOFF;

		//Number of players
		public int numPlayers;

		//Game Mode
		public GameMode gameMode;	//A finite range between 0 and some value.

		//Player scoring information
		public Scores scores;

		//Side bets on or off
		public bool sideBets;


		//--Methods--
		public GameInfo ()
		{
			//TODO: The numPlayers variable needs to be handled later
			numPlayers = 4;
			gameMode = GameMode.Strokes;
			sideBets = false;

			scores = new Scores ();

			betSandyPar = 0;
			betBirdie = 0;
			betGreenie = 0;
			betEagle = 0;
			betCTP = 0;
			betHOFF = 0;
			scores.NumPlayers = numPlayers;
		}



		//Properties
		public int BetSandyPar
		{
			get{ return betSandyPar; }
			set{ betSandyPar = value; }
		}

		public int BetBirdie
		{
			get{ return betBirdie; }
			set{ betBirdie = value; }
		}

		public int BetGreenie
		{
			get{ return betGreenie; }
			set{ betGreenie = value; }
		}
		public int BetEagle
		{
			get{ return betEagle; }
			set{ betEagle = value; }
		}
		public int BetCTP
		{
			get{ return betCTP; }
			set{ betCTP = value; }
		}
		public int BetHOFF
		{
			get{ return betHOFF; }
			set{ betHOFF = value; }
		}

	}
}

